using Medilab.BusinessObjects.Receipt;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.Invoice
{
    public class PendingToPayDto: IPayable
    {
        public Guid Id { set; get; }
        public string ClientName { set; get; }
        public DateTime CreationDate { set; get; }
        /// <summary>
        /// Format: A 0000-00000000
        /// </summary>
        public string Number { set; get; }
        /// <summary>
        /// Factura, Nota de Débito, etc.
        /// </summary>
        public string VoucherTypeDisplay 
        {
            get
            {
                return VoucherType.ToString().Replace("_"," ");
            }
        }
        public CAE.Enums.TipoComprobante VoucherType { set; get; }
        public InvoiceStatus Status { set; get; }
        public double SubTotal { set; get; }
        public double Total { set; get; }
        public double Balance { set; get; }
        public double PaymentAmount { set; get; }
        public string CreatedBy { set; get; }
        public string UpdatedBy { set; get; }
        public string CAE { set; get; }

        #region Payable
        public void UpdatePaidAmmount(MedilabEntities context, Guid receiptId)
        {
            switch (VoucherType)
            {
                case BusinessObjects.CAE.Enums.TipoComprobante.FACTURAS_A:
                case BusinessObjects.CAE.Enums.TipoComprobante.FACTURAS_B:
                    InvoiceHeader.UpdatePaymentInformation(context, Id, PaymentAmount);
                    break;
                case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_A:
                case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_B:
                    DebitCreditNote.DebitNote.UpdatePaymentInformation(context, Id, receiptId);
                    break;
                default:
                    throw new Exception("Tipo de Comprobante no reconodido");
            }
        }
        public void RegisterPayment(MedilabEntities context, Guid receiptId)
        {
            var receiptInvoice = new Receipt.ReceiptInvoice
            {
                ReceiptId = receiptId,
                InvoiceId = Id,
                PaymentAmount = PaymentAmount,
                VoucherType = VoucherType
            };
            receiptInvoice.Save(context);
        }
        #endregion
    }
}
