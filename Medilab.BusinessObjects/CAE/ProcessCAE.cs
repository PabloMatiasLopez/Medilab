using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Medilab.BusinessObjects.CAE
{
    public class ProcessCAE
    {
        private CAEInputFileDto _inputFile;
        private InvoiceDataDto _invoiceData;
        private HeaderInputDto _headerData;
        private List<IvaDto> _iva;
        private List<OtherTaxesDto> _otherTaxes;
        private AssociatedReceiptDto _associatedDocument;
        private bool _includeRetentions;
        private bool _includeOtherDocuments;
        public DateTime CreationDate { set; get; }
        public InvoiceType DocumentType { set; get; }
        public int SalePoint { set; get; }
        public int Number { get; set; }
        public Client ClientInformation { set; get; }
        public double Total { set; get; }
        public double SubTotal { set; get; }
        public double NotTaxed { set; get; }
        public double IvaPerception { set; get; }
        public double OtherPerception { set; get; }
        public string Observations { set; get; }
        public IEnumerable<FiscalRetention> RetentionList { set; get; }
        public Enums.TipoComprobante AssociatedDocumentType { set; get; }
        public int SalePointAssociatedDocument { set; get; }
        public int NumberAssociatedDocument { set; get; }
        public string CAE { set; get; }
        public DateTime CAEExpirationDate { set; get; }
        public ProcessCAE(bool includeRetentions, bool includeOtherDocuments)
        {
            _inputFile = new CAEInputFileDto();
            _invoiceData = new InvoiceDataDto();
            _headerData = new HeaderInputDto();
            _iva = new List<IvaDto>();
            _otherTaxes = new List<OtherTaxesDto>();
            _associatedDocument = new AssociatedReceiptDto();
            _inputFile.WebServerType = new WebServerTypeDto
            {
                WebService = 2
            };
            _includeRetentions = includeRetentions;
            _includeOtherDocuments = includeOtherDocuments;
        }
        private void LoadInvoiceData()
        {
            _invoiceData.FechaComprobante = string.Format("{0}{1}{2}",
                CreationDate.Year.ToString("0000"), CreationDate.Month.ToString("00"), CreationDate.Day.ToString("00"));
            _invoiceData.TipoDelComprobante = Enums.GetTipoComprobante(DocumentType);
            _invoiceData.LetraDelComprobante = Enums.GetLetraComprobante(DocumentType);
            _invoiceData.PuntoVenta = SalePoint;
            _invoiceData.NumeroComprobante = Number;
            _inputFile.InvoiceData = _invoiceData;
        }
        private void LoadHeaderData()
        {
            var defaulAddress = ClientInformation.Addresses.Where(x => x.IsDefault).First();
            var cuit = ClientInformation.Cuit.Replace("-", "");
            _headerData.CodigoDocumentoComprador = ClientInformation.DocumentType;
            _headerData.NumeroDocumentoComprador = long.Parse(cuit);
            _headerData.NombreComprador = BusinessObjects.Utils.FormatForString.CleanText(ClientInformation.Name);
            _headerData.CondicionIVAComprador = (int)ClientInformation.IvaCondition;
            _headerData.CalleComprador = defaulAddress.StreetLineOne;
            _headerData.NumeroCalleComprador = defaulAddress.Number;
            //PisoDomicilioComprado = string.Empty,
            //DepartamentoDomicilioComprador = string.Empty,
            //SectorDomicilioComprador = string.Empty,
            //TorreDomicilioComprador = string.Empty,
            //ManzanaDomicilioComprador = "D",
            _headerData.ProvinciaDomicilioComprador = defaulAddress.AddressState.Id;
            //CodigoPostalComprador = defaulAddress,
            _headerData.LocalidadDomicilioComprador = BusinessObjects.Utils.FormatForString.CleanText(defaulAddress.City);
            _headerData.ImporteTotalOperacion = Total;
            _headerData.ImporteNetoNoGravado = NotTaxed;
            _headerData.ImporteNetoGravado = SubTotal;
            _headerData.ImpuestoOtrosTributos = OtherPerception;
            _headerData.ImporteOperacionesExternas = 0.0;
            _headerData.ImporteSubtotal = SubTotal;
            _headerData.ImporteIVA = IvaPerception;
            //FechaDesdeServicio = string.Empty,
            //FechaHastaServicio = string.Empty,
            _headerData.TipoMoneda = Enums.Monedas.PESOS;
            _headerData.TipoCambio = 1;
            _headerData.CodigoConcepto = Enums.Concepto.Productos;
            //FechaVencimietoComprobante = "20141004",
            _headerData.EmailCliente = ClientInformation.EmailAddress;
            _headerData.Observaciones = BusinessObjects.Utils.FormatForString.CleanText(Observations);
            _inputFile.Header = _headerData;
        }
        private void ProcessRetentions()
        {
            var totalIva = 0.0;
            var totalOther = 0.0;
            foreach (var retention in RetentionList)
            {
                if (retention.IsIVA)
                {
                    totalIva += ProcessIVA(retention);
                }
                else
                {
                    totalOther += ProcessOtherTaxes(retention);
                }
            }
            //Validar los totales
            if (!ValidateTotal(SubTotal, totalIva, totalOther, Total))
            {
                var message = string.Format("Los totales no coinciden. Subtotal: {0}, IVA: {1}, Otras tasas: {2}, Total: {3}",
                    SubTotal, totalIva, totalOther, Total);
                throw new Exception(message);
            }
            _inputFile.Iva = _iva;
            _inputFile.OtherTaxes = _otherTaxes;
            _inputFile.Header.ImporteIVA = IvaPerception = totalIva;
            _inputFile.Header.ImpuestoOtrosTributos = OtherPerception = totalOther;
        }
        private double ProcessIVA(FiscalRetention retention)
        {
            var ivaPercentage = 0.0;
            Enums.TipoIva codigoIva;
            switch (retention.CAECode)
            {
                case 1:
                    codigoIva = Enums.TipoIva.No_Gravado;
                    break;
                case 2:
                    codigoIva = Enums.TipoIva.Exento;
                    break;
                case 3:
                    codigoIva = Enums.TipoIva.Cero;
                    break;
                case 4:
                    codigoIva = Enums.TipoIva.DiezPuntoCinco;
                    ivaPercentage = 0.105;
                    break;
                case 5:
                    codigoIva = Enums.TipoIva.Veintiuno;
                    ivaPercentage = 0.21;
                    break;
                default:
                    codigoIva = Enums.TipoIva.Veintisiete;
                    ivaPercentage = 0.27;
                    break;
            }
            var ivaAmmount = SubTotal * ivaPercentage;
            _iva.Add(new IvaDto
            {
                CodigoIva = codigoIva,
                ImporteIva = ivaAmmount,
                ImporteNetoGravado = SubTotal
            });
            return ivaAmmount;
        }
        private double ProcessOtherTaxes(FiscalRetention retention)
        {
            Enums.TipoTributo codigoTributo;
            switch (retention.CAECode)
            {
                case 1:
                    codigoTributo = Enums.TipoTributo.Impuestos_nacionales;
                    break;
                case 2:
                    codigoTributo = Enums.TipoTributo.Impuestos_provinciales;
                    break;
                case 3:
                    codigoTributo = Enums.TipoTributo.Impuestos_municipales;
                    break;
                case 4:
                    codigoTributo = Enums.TipoTributo.Impuestos_internos;
                    break;
                default:
                    codigoTributo = Enums.TipoTributo.Otros;
                    break;
            }
            var otherImport = Math.Round(SubTotal * retention.Value / 100, 2);
            _otherTaxes.Add(new OtherTaxesDto
            {
                CodigoTributo = codigoTributo,
                DescripcionTributo = retention.Description,
                BaseImponible = SubTotal,
                ImpuestoOtrosTributos = otherImport,
                Alicuota = retention.Value
            });
            return otherImport;
        }
        private void ProcessOtherDocuments()
        {
            _associatedDocument.TipoDelComprobanteAsociado = AssociatedDocumentType;
            _associatedDocument.PuntoVentaAsociado = SalePointAssociatedDocument;
            _associatedDocument.NumeroComprobanteAsociado = NumberAssociatedDocument;
            _inputFile.AssociatedReceipt = _associatedDocument;
        }
        private void ProcessFile()
        {
            var inputPath = ConfigurationManager.AppSettings["CAEInputFolder"];
            _inputFile.InputFolderPath = inputPath;
            var outputFolder = ConfigurationManager.AppSettings["CAEOutputFolder"];
            string fileName;
            try
            {
                var CaeFile = new CreateInputFile(_inputFile);
                fileName = CaeFile.CreateFile();
                var outputFileName = fileName.Replace(inputPath, outputFolder);
                var outputErrorFileName = outputFileName.Insert(outputFileName.Length - 4, "_E");
                outputFileName = outputFileName.Insert(outputFileName.Length - 4, "_R");
                var sleepTimeValue = Configuration.Configuration.GetValue(Constants.CAESleepTimeName);
                var retryTimesValue = Configuration.Configuration.GetValue(Constants.CAERetryTimes);
                int sleepTime = 5000;
                int retryTimes = 3;
                if (!string.IsNullOrEmpty(sleepTimeValue))
                {
                    sleepTime = int.Parse(sleepTimeValue);
                    sleepTime = sleepTime * 1000;
                }
                if (!string.IsNullOrEmpty(retryTimesValue))
                {
                    retryTimes = int.Parse(retryTimesValue);
                }
                var retry = 0;
                var fileExist = false;
                do
                {
                    Thread.Sleep(sleepTime);
                    fileExist = ReadResultFile(outputFileName, outputErrorFileName);
                    retry += 1;
                } while (!fileExist && retry < retryTimes);
                if (!fileExist)
                {
                    var completedFileName = fileName.Insert(fileName.Length - 4, "_f");
                    File.Delete(fileName);
                    File.Delete(completedFileName);
                    throw new Exception("Archivo no procesado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool ReadResultFile(string outputFileName, string outputErrorFileName)
        {
            var fileExist = false;
            if (File.Exists(outputFileName))
            {
                fileExist = true;
                var responseFile = File.ReadAllLines(outputFileName);
                var countResponseLines = responseFile.Count();
                var errorMessage = string.Empty;
                if (File.Exists(outputErrorFileName))
                {
                    var errorFile = File.ReadAllLines(outputErrorFileName);
                    if (errorFile.Count() > 0)
                    {
                        var countErrorLines = errorFile.Count();
                        for (int i = 0; i < countErrorLines; i++)
                        {
                            errorMessage += errorFile[i] + "\n";
                        }
                    }
                }
                for (int i = 0; i < countResponseLines; i++)
                {
                    if (responseFile[i].StartsWith("1"))
                    {
                        CAE = responseFile[i].Substring(2505, 14);
                        if (string.IsNullOrWhiteSpace(CAE))
                        {
                            throw new Exception(errorMessage);
                        }
                        var expirationDate = responseFile[i].Substring(2519, 8);
                        var year = int.Parse(expirationDate.Substring(0, 4));
                        var month = int.Parse(expirationDate.Substring(4, 2));
                        var day = int.Parse(expirationDate.Substring(6, 2));
                        CAEExpirationDate = new DateTime(year, month, day);
                        break;
                    }
                }
            }
            return fileExist;
        }
        public void GetCAE()
        {

            LoadInvoiceData();
            LoadHeaderData();
            if (_includeRetentions)
            {
                ProcessRetentions();
            }
            if (_includeOtherDocuments)
            {
                ProcessOtherDocuments();
            }
            ProcessFile();

            
            //inputFile.Optional = new OptionalDto
            //{
            //    CodigoOpcional = 45,
            //    Valor = 154.6
            //};
           
        }
        private bool ValidateTotal(double subtotal, double ivaImport, double otherTaxes, double total)
        {
            if (_invoiceData.TipoDelComprobante == Enums.TipoComprobante.FACTURAS_B)
            {
                ivaImport = Math.Round(ivaImport, 1, MidpointRounding.ToEven);
                subtotal = Math.Round(subtotal, 1, MidpointRounding.ToEven);
                total = Math.Round(total, 1, MidpointRounding.ToEven);
                otherTaxes = Math.Round(otherTaxes, 1, MidpointRounding.ToEven);
            }
            else
            {
                ivaImport = Math.Round(ivaImport, 2);
            }
            var totalWithTaxes = subtotal + ivaImport + otherTaxes;
            return Math.Round(totalWithTaxes, 2) == total;
        }
    }
}
