using Medilab.BusinessObjects.CAE;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.DebitCreditNote
{
    public class DebitNote
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
        public DebitNote()
        {
        }
        public DebitNote(Guid noteId)
        {
            Id = noteId;
        }
        public DebitNote Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private DebitNote Update()
        {
            using (var context = new MedilabEntities())
            {
                var note = (from dn in context.DebitNote where dn.DebitNoteId == Id select dn).First();
                note.State = (int)NoteState;
                context.SaveChanges();
                return this;
            }
        }

        public static DebitNote GetDebitNote(string noteNumber)
        {
            var splitNumber = noteNumber.Split('-');
            var salePoint = int.Parse(splitNumber[0]);
            var number = int.Parse(splitNumber[1]);
            using (var context = new MedilabEntities())
            {
                var note = (from dn in context.DebitNote where dn.SalePoint == salePoint && dn.DebitNoteNumber == number select dn).FirstOrDefault();
                if (note != null)
                {
                    var newNote = new DebitNote(note.DebitNoteId)
                    {
                        SalePoint = note.SalePoint,
                        Number = note.DebitNoteNumber,
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
        private DebitNote Insert()
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
                var note = new DataAccess.DebitNote
                {
                    DebitNoteId = Id = Guid.NewGuid(),
                    SalePoint = SalePoint,
                    DebitNoteNumber = Number,
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
                context.AddToDebitNote(note);
                context.SaveChanges();
                var creditNoteNumber = new Configuration.NextDebitNoteNumber();
                creditNoteNumber.AddCreditNoteNumber(NoteType);
                return this;
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
                DocumentType = Enums.GetTipoDebitNote(NoteType),
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
                var creditNote = BusinessObjects.DebitCreditNote.CreditNote.GetCreditNote(InvoiceId.Value);
                processCAE.AssociatedDocumentType = Enums.GetTipoComprobante(Enums.GetTipoCreditNote(creditNote.NoteType));
                processCAE.SalePointAssociatedDocument = creditNote.SalePoint;
                processCAE.NumberAssociatedDocument = creditNote.Number;
            }
            processCAE.GetCAE();
            IVAImport = processCAE.IvaPerception;
            CAE = processCAE.CAE;
            CAEExpirationDate = processCAE.CAEExpirationDate;
        }
        public static List<DebitNote> GetDebitNoteByClient(Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                var notes = (from dn in context.DebitNote where dn.ClientId == clientId select dn);
                return notes.Select(note => new DebitNote
                {
                    Id = note.DebitNoteId,
                    SalePoint = note.SalePoint,
                    Number = note.DebitNoteNumber,
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
        public static List<DebitNote> GetDebitNoteByClient(int clientNumber)
        {
            using (var context = new MedilabEntities())
            {
                var notes = (from cn in context.DebitNote where cn.Client.ClientNumber == clientNumber select cn);
                return notes.Select(note => new DebitNote
                {
                    Id = note.DebitNoteId,
                    SalePoint = note.SalePoint,
                    Number = note.DebitNoteNumber,
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
        //TODO: hay que implemetar este metodo
        public static InvoiceHeaderDto GetDebitNoteToPrint(Guid debitNoteId)
        {
            using (var context = new MedilabEntities())
            {
                var invoice = (from h in context.DebitNote
                               where h.DebitNoteId == debitNoteId
                               select h).FirstOrDefault();
                if (invoice == null)
                {
                    return null;
                }
                var invoiceDto = new InvoiceHeaderDto()
                {
                    InvoiceId = invoice.DebitNoteId,
                    InvoiceNumberDisplay = invoice.SalePoint.ToString("0000") + "-" + invoice.DebitNoteNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)invoice.CreditNoteType,
                    ClientName = invoice.Client.ClientName,
                    Subtotal = invoice.Import,
                    Total = invoice.Import,
                    Status = (InvoiceStatus)invoice.State,
                    InvoiceDate = invoice.CreationDate,
                    CAE = invoice.CAE,
                    DocumentType = invoice.CreditNoteType == 1 ? Enums.TipoComprobante.NOTAS_DE_DEBITO_A : Enums.TipoComprobante.NOTAS_DE_DEBITO_B
                };
                return invoiceDto;
            }
        }
        public static List<PendingToPayDto> GetDebitNoteToPayList(Guid clientId, DateTime fromDate, DateTime toDate)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.DebitNote
                                         where
                                             h.Client.ClientId == clientId && (h.State == (int)InvoiceStatus.Generada || h.State == (int)InvoiceStatus.Impresa) &&
                                             (h.CreationDate >= fromDate && h.CreationDate <= toDate)
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new PendingToPayDto
                {
                    Id = h.DebitNoteId,
                    Number = h.SalePoint.ToString("0000") + "-" + h.DebitNoteNumber.ToString("00000000"),
                    VoucherType = h.CreditNoteType == 1 ? Enums.TipoComprobante.NOTAS_DE_DEBITO_A : Enums.TipoComprobante.NOTAS_DE_DEBITO_B,
                    ClientName = h.Client.ClientName,
                    SubTotal = h.Import - h.IVAImport,
                    Total = h.Import,
                    Status = (InvoiceStatus)h.State,
                    CreationDate = h.CreationDate,
                    CAE = h.CAE,
                    Balance = h.Import,
                    CreatedBy = GetUserName(h.CreatorUserId),
                    UpdatedBy = GetUserName(h.CreatorUserId)
                }).ToList();
            }
        }
        private static string GetUserName(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return string.Empty;
            }
            else
            {
                var user = Configuration.User.GetUser(userId);
                return string.Concat(user.LastName, ", ", user.FirstName);
            }

        }
        internal static void UpdatePaymentInformation(MedilabEntities context, Guid id, Guid receiptId)
        {
            var debitNote = (from i in context.DebitNote where i.DebitNoteId == id select i).First();
            debitNote.State = (int)InvoiceStatus.Pagada;
            debitNote.ReceiptId = receiptId;
        }

        public static string GetDebitNoteNumber(MedilabEntities context, Guid debitNoteId)
        {
            var debitNote = (from i in context.DebitNote where i.DebitNoteId == debitNoteId select new { i.SalePoint, i.DebitNoteNumber }).First();
            return string.Format("{0}-{1}", debitNote.SalePoint.ToString("0000"), debitNote.DebitNoteNumber.ToString("00000000"));
        }
    }
}
