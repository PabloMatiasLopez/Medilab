using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;

namespace Medilab.BusinessObjects.Payment
{
    public abstract class Payment
    {
        private double _import;
        public Guid PaymentId { protected set; get; }
        public double Import
        {
            set
            {
                _import = Math.Round(value, 2);
            }
            get
            {
                return _import;
            }
        }
        public string PaymentType 
        {
            get
            {
                if (GetPaymentType() != Utils.PaymentType.CertificadoRetención)
                {
                    return EnumUtils.AddSpaceInCapitalLetter(GetPaymentType().ToString());
                }
                return string.Format("Retención {0}", EnumUtils.AddSpaceInCapitalLetter(((Retention) this).TypeOfRetention.ToString()));
            }
        }
        public abstract PaymentType GetPaymentType();
        public DateTime PaymentDate { set; get; }
        public Guid ReceiptId { set; get; }
        public string Notes { set; get; }
        public string PaymentInformationToDisplay { set; get; }
        internal abstract void Save(MedilabEntities context);
        public static List<Payment> LoadPaymentsData(DataAccess.Receipt receipt)
        {
            var result = new List<Payment>();
            if (receipt.Cash.Count > 0)
            result.AddRange(Cash.GetCashList(receipt.Cash.ToList()));
            if (receipt.Check.Count > 0)
            result.AddRange(Check.GetCheckList(receipt.Check.ToList()));
            if (receipt.ElectronicTransfer.Count > 0)
            result.AddRange(ElectronicTransfer.GetElectronicTransferList(receipt.ElectronicTransfer.ToList()));
            if (receipt.RetentionCertificate.Count > 0)
            result.AddRange(Retention.GetRetentionList(receipt.RetentionCertificate.ToList()));
            if (!receipt.CreditNote.Equals(null))
                result.AddRange(CreditNotePayment.GetCreditNoteList(receipt.CreditNote.ToList()));
            return result;
        }
    }
}
