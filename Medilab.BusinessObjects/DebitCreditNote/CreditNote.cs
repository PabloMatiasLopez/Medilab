using Medilab.BusinessObjects.CAE;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Medilab.BusinessObjects.DebitCreditNote
{
    public class CreditNote
    {
        #region Properties
        private double _subtotal;
        private IEnumerable<Invoice.FiscalRetention> _retentions;
        public Guid Id { private set; get; }
        public int SalePoint { set; get; }
        public int Number { set; get; }
        public string DisplayNumber
        {
            get
            {
                return string.Format("{0}-{1}", SalePoint.ToString("0000"), Number.ToString("00000000"));
            }
        }
        public DateTime CreationDate { set; get; }
        public Guid ClientId { set; get; }
        public Guid? InvoiceId { set; get; }
        public string Detail { set; get; }
        public double Import { set; get; }
        public bool IncludeIVA { set; get; }
        public double IVAImport { set; get; }
        public Enums.TipoIva IVAType { set; get; }
        public Guid CreatorUserId { private set; get; }
        public NoteType NoteType { set; get; }
        public CrediDebitNoteState NoteState { set; get; }
        public string Observations { set; get; }
        public string CAE { private set; get; }
        public DateTime CAEExpirationDate { private set; get; }
        #endregion

        #region Methods
        public CreditNote()
        {
        }
        public CreditNote(Guid noteId)
        {
            Id = noteId;
        }
        public CreditNote Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private CreditNote Update()
        {
            using (var context = new MedilabEntities())
            {
                var note = (from cn in context.CreditNote where cn.CreditNoteId == Id select cn).First();
                note.State = (int)NoteState;
                context.SaveChanges();
                return this;
            }
        }

        public static CreditNote GetCreditNote(string noteNumber, NoteType noteType)
        {
            try
            {
                var splitNumber = noteNumber.Split('-');
                var salePoint = int.Parse(splitNumber[0]);
                var number = int.Parse(splitNumber[1]);
                var type = (int) noteType;
                using (var context = new MedilabEntities())
                {
                    var note = (from cn in context.CreditNote where cn.SalePoint == salePoint && cn.CreditNoteNumber == number && cn.CreditNoteType == type select cn).FirstOrDefault();
                    if (note != null)
                    {
                        var newNote = new CreditNote(note.CreditNoteId)
                        {
                            SalePoint = note.SalePoint,
                            Number = note.CreditNoteNumber,
                            CreationDate = note.CreationDate,
                            ClientId = note.ClientId,
                            Import = note.Import,
                            IncludeIVA = note.IVA,
                            IVAImport = note.IVAImport,
                            Observations = note.Observations,
                            CAE = note.CAE,
                            CAEExpirationDate = note.CAEExpirationDate
                        };
                        return newNote;
                    }
                    return null;
                }
            }
            catch (FormatException)
            {
                throw new Exception("El formato del número de comprobate es incorrecto (0000-00000000)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CreditNote Insert()
        {
            try
            {
                GetCAE();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            using (var context = new MedilabEntities())
            {
                var note = new DataAccess.CreditNote
                {
                    CreditNoteId = Id = Guid.NewGuid(),
                    SalePoint = SalePoint,
                    CreditNoteNumber = Number,
                    CreationDate = CreationDate,
                    ClientId = ClientId,
                    RelatedInvoiceId = InvoiceId == Guid.Empty ? null : InvoiceId,
                    Detail = Detail,
                    Import = Import,
                    IVA = IncludeIVA,
                    IVAImport = IVAImport,
                    IVAType = (int)IVAType,
                    CreatorUserId = CreatorUserId = Security.GetCurrentUser(),
                    CreditNoteType = (int)NoteType,
                    State = (int)CrediDebitNoteState.Nueva,
                    Observations = Observations,
                    CAE = CAE,
                    CAEExpirationDate = CAEExpirationDate
                };
                context.AddToCreditNote(note);
                context.SaveChanges();
                var creditNoteNumber = new Configuration.NextCreditNoteNumber();
                creditNoteNumber.AddCreditNoteNumber(NoteType);
                return this;
            }
        }

        public static CreditNote GetCreditNote(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var note = (from cn in context.CreditNote where cn.CreditNoteId == id select cn).FirstOrDefault();
                if (note != null)
                {
                    var newNote = new CreditNote(note.CreditNoteId)
                    {
                        SalePoint = note.SalePoint,
                        Number = note.CreditNoteNumber,
                        CreationDate = note.CreationDate,
                        ClientId = note.ClientId,
                        Import = note.Import,
                        IncludeIVA = note.IVA,
                        IVAImport = note.IVAImport,
                        Observations = note.Observations,
                        CAE = note.CAE,
                        CAEExpirationDate = note.CAEExpirationDate,
                        NoteType = (NoteType)note.CreditNoteType
                    };
                    return newNote;
                }
                return null;
            }
        }
        public static CreditNoteDto GetDisplayCreditNote(string noteNumber)
        {
            var splitNumber = noteNumber.Split('-');
            var salePoint = int.Parse(splitNumber[0]);
            var number = int.Parse(splitNumber[1]);
            using (var context = new MedilabEntities())
            {
                var note = (from cn in context.CreditNote where cn.SalePoint == salePoint && cn.CreditNoteNumber == number select cn).FirstOrDefault();
                if (note != null)
                {
                    var newNote = new CreditNoteDto
                    {
                        NoteId = note.CreditNoteId,
                        ClientName = note.Client.ClientName,
                        Date = note.CreationDate,
                        Total = note.Import,
                        NoteType = (NoteType)note.CreditNoteType
                    };
                    return newNote;
                }
                return null;
            }
        }
        private void GetCAE()
        {
            var ClientInformation = BusinessObjects.Configuration.Client.GetClient(ClientId);
            var defaulAddress = ClientInformation.Addresses.Where(x => x.IsDefault).First();
            var cuit = ClientInformation.Cuit.Replace("-", "");
            if (IncludeIVA)
            {
                CalculateSubtotal(ClientInformation);
            }
            var processCAE = new ProcessCAE(IncludeIVA, InvoiceId.Value != Guid.Empty)
            {
                DocumentType = Enums.GetTipoCreditNote(NoteType),
                SalePoint = SalePoint,
                Number = Number,
                CreationDate = CreationDate,
                ClientInformation = ClientInformation,
                Total = Import,
                SubTotal = _subtotal,
                Observations = Detail,
                NotTaxed = IncludeIVA ? 0.0 : Import,
                IvaPerception = IVAImport,
                RetentionList = _retentions
            };
            if (InvoiceId.Value != Guid.Empty)
            {
                var invoice = BusinessObjects.Invoice.InvoiceHeader.GetInvoiceById(InvoiceId.Value);
                processCAE.AssociatedDocumentType = Enums.GetTipoComprobante(invoice.InvoiceType);
                processCAE.SalePointAssociatedDocument = invoice.SalePoint;
                processCAE.NumberAssociatedDocument = invoice.InvoiceNumber;
            }
            processCAE.GetCAE();
            IVAImport = processCAE.IvaPerception;
            CAE = processCAE.CAE;
            CAEExpirationDate = processCAE.CAEExpirationDate;
        }
        public static List<CreditNote> GetCreditNoteByClient(Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                var notes = (from cn in context.CreditNote where cn.ClientId == clientId select cn);
                return notes.Select(note => new CreditNote
                {
                    Id = note.CreditNoteId,
                    SalePoint = note.SalePoint,
                    Number = note.CreditNoteNumber,
                    CreationDate = note.CreationDate,
                    ClientId = note.ClientId,
                    Import = note.Import,
                    IncludeIVA = note.IVA,
                    IVAImport = note.IVAImport,
                    Observations = note.Observations,
                    Detail = note.Detail
                }).ToList();
            }
        }
        public static List<CreditNote> GetCreditNoteByClient(int clientNumber)
        {
            using (var context = new MedilabEntities())
            {
                var notes = (from cn in context.CreditNote where cn.Client.ClientNumber == clientNumber select cn);
                return notes.Select(note => new CreditNote
                {
                    Id = note.CreditNoteId,
                    SalePoint = note.SalePoint,
                    Number = note.CreditNoteNumber,
                    CreationDate = note.CreationDate,
                    ClientId = note.ClientId,
                    Import = note.Import,
                    IncludeIVA = note.IVA,
                    IVAImport = note.IVAImport,
                    Observations = note.Observations
                }).ToList();
            }
        }
        #endregion
        private void CalculateSubtotal(BusinessObjects.Configuration.Client client)
        {
            ClientInvoiceProfile invoiceProfile;
            if (client.InvoiceProfile == null)
            {
                invoiceProfile = ClientInvoiceProfile.GetDefaultProfile();
            }
            else
            {
                invoiceProfile = ClientInvoiceProfile.GetInviceProfile(client.InvoiceProfile.Id);
            }
            _retentions = invoiceProfile.Retentions;
            foreach (var item in _retentions)
            {
                if (item.IsIVA)
                {
                    IVAType = (Enums.TipoIva)item.CAECode;
                    break;
                }
            }
            var ivaPercentage = 0.0;
            switch (IVAType)
            {
                case Enums.TipoIva.No_Gravado:
                case Enums.TipoIva.Exento:
                case Enums.TipoIva.Cero:
                    ivaPercentage = 0.0;
                    break;
                case Enums.TipoIva.DiezPuntoCinco:
                    ivaPercentage = 1.105;
                    break;
                case Enums.TipoIva.Veintisiete:
                    ivaPercentage = 1.27;
                    break;
                default:
                    ivaPercentage = 1.21;
                    break;
            };
            _subtotal = 0.0;
            if (ivaPercentage > 0)
            {
                _subtotal = Math.Round(Import / ivaPercentage, 2);
                IVAImport = Import - _subtotal;
            }
        }

        public static CreditNoteDto GetCreditNoteToPrint(Guid creditNoteId)
        {
            using (var context = new MedilabEntities())
            {
                var note = (from cn in context.CreditNote where cn.CreditNoteId == creditNoteId select cn).FirstOrDefault();
                if (note != null)
                {
                    var newNote = new CreditNoteDto()
                    {
                        Client = Configuration.Client.GetClient(note.ClientId),
                        CompanyInfo = Configuration.CompanyInfo.GetCompanyToPrint(),
                        Date = note.CreationDate,
                        Detail = note.Detail,
                        InvoiceNumber = string.Format("{0}-{1}",note.InvoiceHeader.SalePoint.ToString("0000"), note.InvoiceHeader.InvoiceNumber.ToString("00000000")),
                        CreditNoteNumber = string.Format("{0}-{1}", note.SalePoint.ToString("0000"), note.CreditNoteNumber.ToString("00000000")),
                        NoteType = (NoteType)note.CreditNoteType,
                        Total = note.Import,
                        SubTotal = note.Import - note.IVAImport,
                        IvaImport = note.IVAImport,
                        CAE = note.CAE,
                        CaeExperirationDate = note.CAEExpirationDate,
                        InvoiceType = (InvoiceType)note.InvoiceHeader.InvoiceType,
                        InvoiceDate = note.InvoiceHeader.Date,
                        IncludeIVA = note.IVA
                    };
                    return newNote;
                }
                return null;
            }
        }
    }
}
