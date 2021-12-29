using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using Medilab.BusinessObjects.Configuration;
using NextInvoiceNumber = Medilab.BusinessObjects.Configuration.NextInvoiceNumber;

namespace Medilab.BusinessObjects.Receipt
{
    public class Receipt
    {
        #region Properties
        public Guid Id { private set; get; }
        private string _receiptNumber;
        public string ReceiptNumber
        {
            set { _receiptNumber = value;  }
            get
            {
                if (string.IsNullOrWhiteSpace(_receiptNumber))
                {
                    _receiptNumber = _number.GetNextInvoiceNumberDisplay(InvoiceType.ReciboA);
                }
                return _receiptNumber;
            }
        }
        public Guid ClientId { set; get; }
        public double Total 
        { 
            get { return GetTotal(); }
        }

        public Guid CreateUserId { set; get; }
        public Guid UpdateUserId { set; get; }
        public string ReceiverName { set; get; }
        public DateTime Date { set; get; }
        public DateTime CreatedDate { set; get; }
        public List<PendingToPayDto> PaidInvoices { set; get; }
        public List<Payment.Payment> Payments { set; get; }
        private readonly INextInvoiceNumber _number;
        public double Discount { set; get; }
        public string Notes { set; get; }
        #endregion
        #region Methods

        public Receipt()
        {
            Payments = new List<Payment.Payment>();
            PaidInvoices = new List<PendingToPayDto>();
            _number = new NextInvoiceNumber();
        }

        public static Receipt GetReceiptById(Guid receiptId)
        {
            using (var context = new MedilabEntities())
            {
                DataAccess.Receipt receipt = (from r in context.Receipt
                                              where r.ReceiptId == receiptId 
                                              select r).FirstOrDefault();
                if (receipt != null)
                {
                    return new Receipt
                    {
                        Id = receipt.ReceiptId,
                        ReceiptNumber = receipt.ReceiptNumber,
                        ClientId = receipt.ClientId,
                        CreateUserId = receipt.CreateUserId,
                        UpdateUserId = receipt.LastUpdateUserId,
                        ReceiverName = receipt.ReceiverName,
                        Date = receipt.Date,
                        CreatedDate = receipt.CreatedDate,
                        Payments = Payment.Payment.LoadPaymentsData(receipt),
                        PaidInvoices = LoadInvoicesData(context, receipt.ReceiptInvoice.ToList()),
                        Discount = receipt.Discount,
                        Notes = receipt.Notes
                    };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }

        public Receipt Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private double GetTotal()
        {
            return Payments.Aggregate<Payment.Payment, double>(0, (current, payment) => current + payment.Import);
        }
        private Receipt Update()
        {
            Guid userId = Security.GetCurrentUser();
            using (var context = new MedilabEntities())
            {
                DataAccess.Receipt receipt = (from r in context.Receipt where r.ReceiptId == Id select r).First();
                receipt.Total = Total;
                receipt.LastUpdateUserId = UpdateUserId = userId;
                receipt.Notes = Notes;
                context.SaveChanges();
            }
            return this;
        }
        private Receipt Insert()
        {
            if (PaidInvoices.Count == 0 || Payments.Count == 0)
            {
                throw new InvalidOperationException("El recibo no tiene facturas o no tiene pagos asignados");
            }
            if (PaidInvoices.Any(p => Math.Abs(p.PaymentAmount) < 0.0001) || Payments.Any(p => Math.Abs(p.Import) < 0.0001))
            {
                throw new InvalidOperationException("Los montos a pagar tienen que ser mayores que 0");
            }
            DateTime createdDate = DateTime.Now;
            Guid userId = Security.GetCurrentUser();
            using (var context = new MedilabEntities())
            {
                var receipt = new DataAccess.Receipt
                {
                    ReceiptId = Guid.NewGuid(),
                    ReceiptNumber = ReceiptNumber,
                    ClientId = ClientId,
                    Total = Total,
                    CreateUserId = CreateUserId = userId,
                    LastUpdateUserId = UpdateUserId = userId,
                    ReceiverName = ReceiverName,
                    Date = Date == DateTime.MinValue ? Date = createdDate : Date,
                    CreatedDate = createdDate,
                    Discount = Discount,
                    Notes = Notes
                };
                context.AddToReceipt(receipt);
                SavePaidInvoices(context, receipt.ReceiptId);
                SavePayments(context, receipt.ReceiptId);
                _number.AddInvoiceNumber(InvoiceType.ReciboA, context);
                context.SaveChanges();
                Id = receipt.ReceiptId;
            }
            return this;
        }
        private void SavePayments(MedilabEntities context, Guid receiptId)
        {
            foreach (Payment.Payment payment in Payments)
            {
                payment.ReceiptId = receiptId;
                payment.Save(context);
            }
        }

        private void SavePaidInvoices(MedilabEntities context, Guid receiptId)
        {
            foreach (var paidInvoice in PaidInvoices)
            {
                paidInvoice.UpdatePaidAmmount(context, receiptId);
                paidInvoice.RegisterPayment(context, receiptId);
            }
        }

        private static List<PendingToPayDto> LoadInvoicesData(MedilabEntities context, IEnumerable<DataAccess.ReceiptInvoice> receiptInvoice)
        {
            var payments = new List<PendingToPayDto>();
            foreach (var item in receiptInvoice.ToList())
            {
                var voucher = new PendingToPayDto
                {
                    Id = item.InvoiceId,
                    PaymentAmount = item.PaymentAmount,
                    VoucherType = (CAE.Enums.TipoComprobante)item.VoucherType
                };
                switch (voucher.VoucherType)
                {
                    case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.FACTURAS_A:
                    case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.FACTURAS_B:
                        var invoice = (from i in context.InvoiceHeader where i.InvoiceHeaderId == item.InvoiceId select i).First();
                        voucher.Number = invoice.SalePoint.ToString("0000") + "-" + invoice.InvoiceNumber.ToString("00000000");
                        voucher.CreationDate = invoice.Date;
                        voucher.Total = invoice.Total;
                        voucher.Balance = invoice.InvoiceRemainder;
                        break;
                    case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_A:
                    case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_B:
                        var note = (from n in context.DebitNote where n.DebitNoteId == item.InvoiceId select n).First();
                        voucher.Number = note.SalePoint.ToString("0000") + "-" + note.DebitNoteNumber.ToString("00000000");
                        voucher.CreationDate = note.CreationDate;
                        voucher.Total = note.Import;
                        voucher.Balance = 0.0;
                        break;
                    default:
                        continue;
                }
                payments.Add(voucher);
            }
            return payments;
        }
        public static List<ReceiptDto> GetReceiptList(Guid clientId, DateTime fromDate, DateTime toDate)
        {
            using (var context = new MedilabEntities())
            {
                var receiptList = (from h in context.Receipt
                                         where
                                             h.Client.ClientId == clientId &&
                                             (h.Date >= fromDate && h.Date <= toDate)
                                         orderby h.Date descending 
                                         select h).ToList();

                return receiptList.Select(h => new ReceiptDto
                {
                    ReceiptId = h.ReceiptId,
                    ReceiptNumber = h.ReceiptNumber,
                    ClientName = h.Client.ClientName,
                    Total = h.Total,
                    Date = h.Date,
                }).ToList();
            }
        }

        public static ReceiptDto GetReceiptByNumber(string receiptNumber)
        {
            using (var context = new MedilabEntities())
            {
                var receipt = (from h in context.Receipt
                               where h.ReceiptNumber == receiptNumber
                               select new ReceiptDto()
                               {
                                   ReceiptId = h.ReceiptId,
                                   ReceiptNumber = h.ReceiptNumber,
                                   ClientName = h.Client.ClientName,
                                   Total = h.Total,
                                   Date = h.Date
                               }).FirstOrDefault();
                return receipt;
            }
        }

        public static List<ReceiptDto> GetReceiptByInvoiceNumber(string invoiceNumber)
        {
            int number;
            int salePoint;
            var receiptList = new List<ReceiptDto>();
            try
            {
                string[] values = invoiceNumber.Split('-');
                number = int.Parse(values[1]);
                salePoint = int.Parse(values[0]);
            }
            catch (Exception)
            {
                return receiptList;
            }
            using (var context = new MedilabEntities())
            {
                var invoiceId = (from invoice in context.InvoiceHeader where invoice.InvoiceNumber == number && invoice.SalePoint == salePoint select invoice.InvoiceHeaderId).FirstOrDefault();
                var debitNoteId = (from note in context.DebitNote where note.DebitNoteNumber == number && note.SalePoint == salePoint select note.DebitNoteId).FirstOrDefault();
                if (invoiceId != null)
                {
                    receiptList.Add(GetReceiptInformation(context, invoiceId));
                }
                if (debitNoteId != null)
                {
                    receiptList.Add(GetReceiptInformation(context, debitNoteId));
                }
            }
            return receiptList;
        }

        private static ReceiptDto GetReceiptInformation(MedilabEntities context, Guid id)
        {
            var invoiceInformation = (from information in context.ReceiptInvoice where information.InvoiceId == id select information).FirstOrDefault();
            if (invoiceInformation != null)
            {
                return new ReceiptDto
                 {
                     ReceiptId = invoiceInformation.Receipt.ReceiptId,
                     ReceiptNumber = invoiceInformation.Receipt.ReceiptNumber,
                     ClientName = invoiceInformation.Receipt.Client.ClientName,
                     Total = invoiceInformation.Receipt.Total,
                     Date = invoiceInformation.Receipt.Date
                 };
            }
            return null;
        }

        public static bool ReceiptNumberIsValid(string number)
        {
            using (var context = new MedilabEntities())
            {
                return !context.Receipt.Any(r => r.ReceiptNumber == number);
            }
        }

        public static List<ReceiptDto> GetReceiptList(int clientNumber, DateTime dateFrom, DateTime dateTo)
        {
            using (var context = new MedilabEntities())
            {
                var receiptList = (from h in context.Receipt
                                   where
                                       h.Client.ClientNumber == clientNumber &&
                                       (h.Date >= dateFrom && h.Date <= dateTo)
                                   orderby h.Date descending
                                   select h).ToList();

                return receiptList.Select(h => new ReceiptDto
                {
                    ReceiptId = h.ReceiptId,
                    ReceiptNumber = h.ReceiptNumber,
                    ClientName = h.Client.ClientName,
                    Total = h.Total,
                    Date = h.Date,
                }).ToList();
            }
        }

        public static ReceiptToPrintDto GetReceiptToPrint(Guid receiptId)
        {
            using (var context = new MedilabEntities())
            {
                DataAccess.Receipt receipt = (from r in context.Receipt
                                              where r.ReceiptId == receiptId
                                              select r).FirstOrDefault();

                var user = Medilab.BusinessObjects.Configuration.User.GetUser(receipt.CreateUserId);
                if (receipt != null)
                {
                    return new ReceiptToPrintDto
                    {
                        ReceiptNumber = receipt.ReceiptNumber,
                        Client = Configuration.Client.GetClient(receipt.ClientId),
                        Date = receipt.Date.ToShortDateString(),
                        Payments = Payment.Payment.LoadPaymentsData(receipt),
                        Invoices = LoadInvoicesToPrint(receipt.ReceiptInvoice.ToList()),
                        Total = receipt.Total,
                        CompanyInfo = Configuration.CompanyInfo.GetCompanyToPrint(),
                        Notes = receipt.Notes,
                        Discount = receipt.Discount,
                        TotalWithDiscount = receipt.Total,
                        CreatedBy = string.Concat(user.LastName, " ",user.FirstName)

                    };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }

        private static List<InvoiceHeaderDto> LoadInvoicesToPrint(IEnumerable<DataAccess.ReceiptInvoice> receiptInvoices)
        {
            var invoiceList = new List<InvoiceHeaderDto>();

            foreach (var item in receiptInvoices)
            {
                var invoice = Invoice.InvoiceHeader.GetInvoiceToPrint(item.InvoiceId);
                if (invoice != null)
                {
                    invoiceList.Add(invoice);
                }
                else
                {
                    var debitNote = DebitCreditNote.DebitNote.GetDebitNoteToPrint(item.InvoiceId);
                    if (debitNote != null)
                    {
                        invoiceList.Add(debitNote);
                    }
                }
            }
            return invoiceList;
        }

        public static void DeleteReceipt(Guid receiptId)
        {
            using (var context = new MedilabEntities())
            {
                DataAccess.Receipt receipt = (from r in context.Receipt
                                              where r.ReceiptId == receiptId
                                              select r).FirstOrDefault();
                if (receipt != null)
                {
                    DeletePayments(receipt, context);
                    UpdateInvoices(receipt, context);
                    context.Receipt.DeleteObject(receipt);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception(BOResources.RecordNotFoudExeptionMessage);
                }
            }
        }

        private static void UpdateInvoices(DataAccess.Receipt receipt, MedilabEntities context)
        {
            foreach (var receiptInvoice in receipt.ReceiptInvoice.ToList())
            {
                var voucheType = (CAE.Enums.TipoComprobante)receiptInvoice.VoucherType;
                switch (voucheType)
                {
                    case CAE.Enums.TipoComprobante.FACTURAS_A:
                    case CAE.Enums.TipoComprobante.FACTURAS_B:
                        var invoice = (from i in context.InvoiceHeader where i.InvoiceHeaderId == receiptInvoice.InvoiceId select i).First();
                        invoice.InvoiceRemainder += receiptInvoice.PaymentAmount;
                        if (invoice.InvoiceRemainder > 0)
                        {
                            invoice.Status = (int)InvoiceStatus.Impresa;
                        }
                        break;
                    case CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_A:
                    case CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_B:
                        var note = (from n in context.DebitNote where n.DebitNoteId == receiptInvoice.InvoiceId select n).First();
                        note.ReceiptId = null;
                        note.State = (int)InvoiceStatus.Generada;
                        break;
                    default:
                        continue;
                }
                context.ReceiptInvoice.DeleteObject(receiptInvoice);
            }
        }

        private static void DeletePayments(DataAccess.Receipt receipt, MedilabEntities context)
        {
            foreach (Cash cashPaiment in receipt.Cash.ToList())
            {
                context.Cash.DeleteObject(cashPaiment);
            }
            foreach (Check checkPaiment in receipt.Check.ToList())
            {
                context.Check.DeleteObject(checkPaiment);
            }
            foreach (CreditNote creditNotePaiment in receipt.CreditNote.ToList())
            {
                creditNotePaiment.ReceiptId = null;
                creditNotePaiment.State = (int) CrediDebitNoteState.Nueva;
            }
            foreach (ElectronicTransfer electronicTransferPaiment in receipt.ElectronicTransfer.ToList())
            {
                context.ElectronicTransfer.DeleteObject(electronicTransferPaiment);
            }
            foreach (RetentionCertificate retentionCertificatePaiment in receipt.RetentionCertificate.ToList())
            {
                context.RetentionCertificate.DeleteObject(retentionCertificatePaiment);
            }
        }

        #endregion
    }

}
