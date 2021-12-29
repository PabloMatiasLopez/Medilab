using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;

namespace Medilab.BusinessObjects.Payment
{
    public class Retention : Payment
    {
        public override PaymentType GetPaymentType()
        {
            return Utils.PaymentType.CertificadoRetención;
        }
        public RetentionType TypeOfRetention { set; get; }
        public string CertificateNumber { set; get; }
        internal override void Save(MedilabEntities context)
        {
            Insert(context);
        }
        private void Insert(MedilabEntities context)
        {
            var certificate = new DataAccess.RetentionCertificate
            {
                RetentionCertificateId = PaymentId = Guid.NewGuid(),
                PaymentDate = DateTime.Today,
                RetentionImport = Import,
                Notes = Notes,
                ReceiptId = ReceiptId,
                CertificateNumber = CertificateNumber,
                RetentionType = (int)TypeOfRetention
            };
            context.AddToRetentionCertificate(certificate);
        }

        public static List<Retention> GetRetentionList(List<RetentionCertificate> retentionPayments)
        {
            return retentionPayments.Select(cashPayment => new Retention
            {
                PaymentId = cashPayment.RetentionCertificateId,
                Import = cashPayment.RetentionImport,
                PaymentDate = cashPayment.PaymentDate,
                ReceiptId = cashPayment.ReceiptId,
                Notes = cashPayment.Notes,
                CertificateNumber = cashPayment.CertificateNumber,
                TypeOfRetention = (RetentionType)cashPayment.RetentionType,
                PaymentInformationToDisplay = string.Concat((RetentionType)cashPayment.RetentionType)
            }).ToList();
        }
    }
}
