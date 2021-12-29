using System;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System.Linq;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.BusinessObjects.Receipt
{
    public class ReceiptInvoice
    {
        public Guid Id { private set; get; }
        public double PaymentAmount { set; get; }
        public Guid InvoiceId { set; get; }
        public Guid ReceiptId { set; get; }
        public CAE.Enums.TipoComprobante VoucherType { set; get; }        
        internal ReceiptInvoice Save(MedilabEntities context)
        {
            return Id == Guid.Empty ? Insert(context) : Update(context);
        }

        private ReceiptInvoice Update(MedilabEntities context)
        {
            throw new NotImplementedException();
        }

        private ReceiptInvoice Insert(MedilabEntities context)
        {
            var receiptInvoice = new DataAccess.ReceiptInvoice
            {
                ReceiptInvoiceId = Id = Guid.NewGuid(),
                InvoiceId = InvoiceId,
                ReceiptId = ReceiptId,
                PaymentAmount = PaymentAmount,
                VoucherType = (int)VoucherType
            };
            context.AddToReceiptInvoice(receiptInvoice);
            return this;
        }

        public PendingToPayDto GetDto()
        {
            using (var context = new MedilabEntities())
            {
                var invoice = (from i in context.InvoiceHeader
                                where i.InvoiceHeaderId == InvoiceId
                               select new { i.Date, i.InvoiceType, i.InvoiceNumber, i.Total, i.InvoiceRemainder, i.SalePoint }).First();
                return new PendingToPayDto
                {
                    CreationDate = invoice.Date,
                    Total = invoice.Total,
                    VoucherType = invoice.InvoiceType == 1 ? CAE.Enums.TipoComprobante.FACTURAS_A : CAE.Enums.TipoComprobante.FACTURAS_B,
                    Id = InvoiceId,
                    Number = invoice.SalePoint.ToString("0000") + "-" + invoice.InvoiceNumber.ToString("00000000"),
                    Balance = invoice.InvoiceRemainder,
                    PaymentAmount = PaymentAmount
                };
            }
        }
    }
}
