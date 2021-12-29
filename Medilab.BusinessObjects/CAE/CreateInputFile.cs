using System;
using System.IO;
using System.Text;

namespace Medilab.BusinessObjects.CAE
{
    public class CreateInputFile
    {
        private CAEInputFileDto _caeInputFile;
        public CreateInputFile(CAEInputFileDto inputFile) 
        {
            _caeInputFile = inputFile;
        }
        private string ProcessHeader()
        {
            var header = _caeInputFile.Header;
            header.InvoiceData = _caeInputFile.InvoiceData;
            var line = new StringBuilder();
            line.Append(header.TipoRegistro.ToString());
            line.Append(header.InvoiceData.IdentificadorOriginal);
            line.Append(header.InvoiceData.FechaComprobante);
            line.Append(((int)header.InvoiceData.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(header.InvoiceData.LetraDelComprobante.ToString());
            line.Append(header.InvoiceData.PuntoVenta.ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(header.InvoiceData.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(8)));
            line.Append(header.CodigoTipoAutorizacion);
            line.Append(((int)header.CodigoDocumentoComprador).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(header.NumeroDocumentoComprador.ToString(Utils.FormatForString.IntNumber(11)));
            line.Append(header.NombreComprador.PadLeft(30));
            line.Append(((int)header.CondicionIVAComprador).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(header.CalleComprador.PadLeft(30));
            line.Append(header.NumeroCalleComprador.PadLeft(6));
            line.Append(header.PisoDomicilioComprador.PadLeft(5));
            line.Append(header.DepartamentoDomicilioComprador.PadLeft(5));
            line.Append(header.SectorDomicilioComprador.PadLeft(5));
            line.Append(header.TorreDomicilioComprador.PadLeft(5));
            line.Append(header.ManzanaDomicilioComprador.PadLeft(5));
            line.Append(((int)header.ProvinciaDomicilioComprador).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(header.CodigoPostalComprador.PadLeft(8));
            line.Append(header.LocalidadDomicilioComprador.PadLeft(25));
            line.Append(header.ImporteTotalOperacion.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.ImporteNetoNoGravado.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.ImporteNetoGravado.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.ImpuestoOtrosTributos.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.ImporteOperacionesExternas.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.ImporteSubtotal.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.ImporteIVA.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(header.FechaDesdeServicio.PadLeft(8));
            line.Append(header.FechaHastaServicio.PadLeft(8));
            line.Append(header.TipoMonedaArchivo);
            line.Append(header.TipoCambio.ToString(Utils.FormatForString.FloatNumberFiveDecimals(10)).Replace(".", ","));
            line.Append(((int)header.CodigoConcepto).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(header.FechaVencimietoComprobante.PadLeft(8));
            line.Append(header.EmailCliente.PadLeft(170));
            line.Append(header.Observaciones.PadLeft(2000));
            line.Append(header.WebService.ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(header.CodigoAutorizacion);
            line.Append(header.CodigoAutorizacionElectronica.PadLeft(14));
            line.Append(header.FechaVencimientoCAE.PadLeft(8));
            line.Append(header.Filler);
            if (line.Length == header.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("Cabecera: La longitud no coincide: " + line.Length);
        }
        private string ProcessIva(IvaDto iva)
        {
            iva.InvoiceData = _caeInputFile.InvoiceData;
            var line = new StringBuilder();
            line.Append(iva.TipoRegistro.ToString());
            line.Append(iva.InvoiceData.IdentificadorOriginal);
            line.Append(iva.InvoiceData.FechaComprobante);
            line.Append(((int)iva.InvoiceData.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(iva.InvoiceData.LetraDelComprobante.ToString());
            line.Append(iva.InvoiceData.PuntoVenta.ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(iva.InvoiceData.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(8)));
            line.Append(((int)iva.CodigoIva).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(iva.ImporteIva.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(iva.ImporteNetoGravado.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            if (line.Length == iva.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("IVA: La longitud no coincide: " + line.Length);
        }
        private string ProcessOtherTaxes(OtherTaxesDto otherTaxes)
        {
            otherTaxes.InvoiceData = _caeInputFile.InvoiceData;
            var line = new StringBuilder();
            line.Append(otherTaxes.TipoRegistro.ToString());
            line.Append(otherTaxes.InvoiceData.IdentificadorOriginal);
            line.Append(otherTaxes.InvoiceData.FechaComprobante);
            line.Append(((int)otherTaxes.InvoiceData.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(otherTaxes.InvoiceData.LetraDelComprobante.ToString());
            line.Append(otherTaxes.InvoiceData.PuntoVenta.ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(otherTaxes.InvoiceData.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(8)));
            line.Append(((int)otherTaxes.CodigoTributo).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(otherTaxes.DescripcionTributo.PadLeft(80));
            line.Append(otherTaxes.BaseImponible.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(otherTaxes.ImpuestoOtrosTributos.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", ","));
            line.Append(otherTaxes.Alicuota.ToString(Utils.FormatForString.FloatNumberTwoDecimals(5)).Replace(".", ","));
            if (line.Length == otherTaxes.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("Otros Tributos:La longitud no coincide: " + line.Length);
        }
        private string ProcessAssociatedReceipt()
        {
            var associatedReceipt = _caeInputFile.AssociatedReceipt;
            associatedReceipt.InvoiceData = _caeInputFile.InvoiceData;
            var line = new StringBuilder();
            line.Append(associatedReceipt.TipoRegistro.ToString());
            line.Append(associatedReceipt.InvoiceData.IdentificadorOriginal);
            line.Append(associatedReceipt.InvoiceData.FechaComprobante);
            line.Append(((int)associatedReceipt.InvoiceData.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(associatedReceipt.InvoiceData.LetraDelComprobante.ToString());
            line.Append(associatedReceipt.InvoiceData.PuntoVenta.ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(associatedReceipt.InvoiceData.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(8)));
            line.Append(((int)associatedReceipt.TipoDelComprobanteAsociado).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(associatedReceipt.PuntoVentaAsociado.ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(associatedReceipt.NumeroComprobanteAsociado.ToString(Utils.FormatForString.IntNumber(8)));
            if (line.Length == associatedReceipt.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("Comprobantes asociados: La longitud no coincide: " + line.Length);
        }
        private string ProcessOptional()
        {
            var optional = _caeInputFile.Optional;
            optional.InvoiceData = _caeInputFile.InvoiceData;
            var line = new StringBuilder();
            line.Append(optional.TipoRegistro.ToString());
            line.Append(optional.InvoiceData.IdentificadorOriginal);
            line.Append(optional.InvoiceData.FechaComprobante);
            line.Append(((int)optional.InvoiceData.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(optional.InvoiceData.LetraDelComprobante.ToString());
            line.Append(optional.InvoiceData.PuntoVenta.ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(optional.InvoiceData.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(8)));
            line.Append(optional.CodigoOpcional.ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(optional.Valor.ToString(Utils.FormatForString.FloatNumberTwoDecimals(100)).Replace(".", ","));
            if (line.Length == optional.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("Opcional: La longitud no coincide: " + line.Length);
        }
        public string CreateFile()
        {
            var fileName = string.Format("{0}{1}_{2}_{3}.txt", 
                _caeInputFile.InputFolderPath,
                _caeInputFile.InvoiceData.TipoDelComprobante,
                _caeInputFile.InvoiceData.PuntoVenta.ToString(Utils.FormatForString.IntNumber(4)),
                _caeInputFile.InvoiceData.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(8)));
            try
            {
                using (var file = new StreamWriter(fileName, true))
                {
                    file.WriteLine(_caeInputFile.WebServerType.ToString());
                    file.WriteLine(ProcessHeader());
                    if (_caeInputFile.Iva != null)
                    {
                        foreach (var iva in _caeInputFile.Iva)
                        {
                            file.WriteLine(ProcessIva(iva));
                        }
                    }
                    if (_caeInputFile.OtherTaxes != null)
                    {
                        foreach (var tax in _caeInputFile.OtherTaxes)
                        {
                            file.WriteLine(ProcessOtherTaxes(tax));
                        }
                    }
                    if (_caeInputFile.AssociatedReceipt != null)
                    {
                        file.WriteLine(ProcessAssociatedReceipt());
                    }
                    if (_caeInputFile.Optional != null)
                    {
                        file.WriteLine(ProcessOptional());
                    }
                    file.Close();
                }
                var closeFileName = fileName.Insert(fileName.Length - 4, "_f");
                var closeFile = new StreamWriter(closeFileName, true);
                closeFile.Close();
                return fileName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
