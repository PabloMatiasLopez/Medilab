using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.CAE;

namespace Medilab.BusinessObjects.Siap
{
    public class ProcessIVA
    {
        private List<RegistroIvaDto> _registrosIva;
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public ProcessIVA()
        {
            _registrosIva = new List<RegistroIvaDto>();
        }
        private void GetInvoiceValues()
        {
            using(var context = new MedilabEntities())
            {
                var invoiceList = (from invoice in context.InvoiceHeader
                             where invoice.Date >= StartDate && invoice.Date <= EndDate
                             select new
                             {
                                 invoice.Date,
                                 invoice.InvoiceType,
                                 invoice.SalePoint,
                                 invoice.InvoiceNumber,
                                 invoice.Client.DocumentTypeId,
                                 invoice.Client.ClientCuit,
                                 invoice.Client.ClientName,
                                 invoice.Total,
                                 invoice.SubTotal,
                                 invoice.IvaPerception,
                                 invoice.Client.InvoiceProfileId
                             }).ToList();
                foreach (var item in invoiceList)
                {
                    var comprobante = new ComprobanteIVADto
                    {
                        FechaComprobante = item.Date.Year.ToString("0000") + item.Date.Month.ToString("00") + item.Date.Day.ToString("00"),
                        TipoDelComprobante = (CAE.Enums.TipoComprobante)item.InvoiceType,
                        PuntoVenta = item.SalePoint,
                        NumeroComprobante = item.InvoiceNumber,
                        CodigoDocumentoComprador = (Utils.DocumentType)item.DocumentTypeId,
                        NumeroDocumentoComprador = item.ClientCuit.Replace("-", ""),
                        NombreComprador = item.ClientName,
                        ImporteTotal = item.Total
                    };
                    CAE.Enums.TipoIva? tipoIVA = null;
                    ClientInvoiceProfile invoiceProfile;
                    if (item.InvoiceProfileId.HasValue)
                    {
                        invoiceProfile = ClientInvoiceProfile.GetInviceProfile(item.InvoiceProfileId.Value);
                    }
                    else
                    {
                        invoiceProfile = ClientInvoiceProfile.GetDefaultProfile();
                    }
                    foreach (var retention in invoiceProfile.Retentions)
                    {
                        if (retention.IsIVA)
                        {
                            tipoIVA = (CAE.Enums.TipoIva)retention.CAECode;
                            break;
                        }
                    }
                    if (!tipoIVA.HasValue)
                    {
                        throw new Exception("Tipo de IVA incorrecto");
                    }
                    var alicuota = new AlicuotaIVADto
                    {
                        ImporteNetoGravado = item.SubTotal,
                        AlicuotaIVA = tipoIVA.Value,
                        ImporteIva = item.IvaPerception
                    };
                    _registrosIva.Add(new RegistroIvaDto
                    {
                        Comprobante = comprobante,
                        Alicuota = alicuota
                    });
                }
            }
        }
        private void GetCreditNoteValues()
        {
            using (var context = new MedilabEntities())
            {
                var creditNoteList = (from creditNote in context.CreditNote
                                   where creditNote.CreationDate >= StartDate && creditNote.CreationDate <= EndDate &&
                                   creditNote.IVA
                                   select new
                                   {
                                       creditNote.CreationDate,
                                       creditNote.CreditNoteType,
                                       creditNote.SalePoint,
                                       creditNote.CreditNoteNumber,
                                       creditNote.Client.DocumentTypeId,
                                       creditNote.Client.ClientCuit,
                                       creditNote.Client.ClientName,
                                       creditNote.Import,
                                       creditNote.IVAImport,
                                       creditNote.IVAType
                                   }).ToList();
                foreach (var item in creditNoteList)
                {
                    var comprobante = new ComprobanteIVADto
                    {
                        FechaComprobante = item.CreationDate.Year.ToString("0000") + item.CreationDate.Month.ToString("00") + item.CreationDate.Day.ToString("00"),
                        TipoDelComprobante = (CAE.Enums.TipoComprobante)item.CreditNoteType,
                        PuntoVenta = item.SalePoint,
                        NumeroComprobante = item.CreditNoteNumber,
                        CodigoDocumentoComprador = (Utils.DocumentType)item.DocumentTypeId,
                        NumeroDocumentoComprador = item.ClientCuit.Replace("-", ""),
                        NombreComprador = item.ClientName,
                        ImporteTotal = item.Import
                    };
                    var alicuota = new AlicuotaIVADto
                    {
                        ImporteNetoGravado = item.Import - item.IVAImport,
                        AlicuotaIVA = (Enums.TipoIva)item.IVAType,
                        ImporteIva = item.IVAImport
                    };
                    _registrosIva.Add(new RegistroIvaDto
                    {
                        Comprobante = comprobante,
                        Alicuota = alicuota
                    });
                }
            }
        }
        private void GetDebitNoteValues()
        {
            using (var context = new MedilabEntities())
            {
                var debitNoteList = (from debitNote in context.DebitNote
                                      where debitNote.CreationDate >= StartDate && debitNote.CreationDate <= EndDate &&
                                      debitNote.IVA
                                      select new
                                      {
                                          debitNote.CreationDate,
                                          debitNote.CreditNoteType,
                                          debitNote.SalePoint,
                                          debitNote.DebitNoteNumber,
                                          debitNote.Client.DocumentTypeId,
                                          debitNote.Client.ClientCuit,
                                          debitNote.Client.ClientName,
                                          debitNote.Import,
                                          debitNote.IVAImport,
                                          debitNote.IVAType
                                      }).ToList();
                foreach (var item in debitNoteList)
                {
                    var comprobante = new ComprobanteIVADto
                    {
                        FechaComprobante = item.CreationDate.Year.ToString("0000") + item.CreationDate.Month.ToString("00") + item.CreationDate.Day.ToString("00"),
                        TipoDelComprobante = (CAE.Enums.TipoComprobante)item.CreditNoteType,
                        PuntoVenta = item.SalePoint,
                        NumeroComprobante = item.DebitNoteNumber,
                        CodigoDocumentoComprador = (Utils.DocumentType)item.DocumentTypeId,
                        NumeroDocumentoComprador = item.ClientCuit.Replace("-", ""),
                        NombreComprador = item.ClientName,
                        ImporteTotal = item.Import
                    };
                    var alicuota = new AlicuotaIVADto
                    {
                        ImporteNetoGravado = item.Import - item.IVAImport,
                        AlicuotaIVA = (Enums.TipoIva)item.IVAType,
                        ImporteIva = item.IVAImport
                    };
                    _registrosIva.Add(new RegistroIvaDto
                    {
                        Comprobante = comprobante,
                        Alicuota = alicuota
                    });
                }
            }
        }
        public void GetIVAFiles()
        {
            GetInvoiceValues();
            GetCreditNoteValues();
            GetDebitNoteValues();
            var files = new IVAFile(_registrosIva);
            files.CreateFiles();
        }
    }
}
