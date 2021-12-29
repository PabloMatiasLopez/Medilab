using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;

namespace Medilab.BusinessObjects.Payment
{
    public class Check : Payment
    {
        public override PaymentType GetPaymentType()
        {
            return Utils.PaymentType.Cheque;
        }
        public string BankName { set; get; }
        public DateTime IssuanceDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Number { set; get; }
        public string OwnerName { set; get; }
        public bool IsOwner { set; get; }
        internal override void Save(MedilabEntities context)
        {
            Insert(context);
        }
        private void Insert(MedilabEntities context)
        {
            var check = new DataAccess.Check
            {
                CheckId = PaymentId = Guid.NewGuid(),
                PaymentDate = DateTime.Today,
                CheckImport = Import,
                Notes = Notes,
                ReceiptId = ReceiptId,
                BankName = BankName,
                IssuanceDate = IssuanceDate,
                ExpirationDate = ExpirationDate,
                CheckNumber = Number,
                OwnerName = OwnerName,
                IsOwner = IsOwner
            };
            context.AddToCheck(check);
        }

        public static List<Check> GetCheckList(List<DataAccess.Check> checkPayments)
        {
            return checkPayments.Select(checkPayment => new Check
            {
                PaymentId = checkPayment.CheckId,
                Import = checkPayment.CheckImport,
                PaymentDate = checkPayment.PaymentDate,
                ReceiptId = checkPayment.ReceiptId,
                Notes = checkPayment.Notes,
                BankName = checkPayment.BankName,
                IssuanceDate = checkPayment.IssuanceDate,
                ExpirationDate = checkPayment.ExpirationDate,
                Number = checkPayment.CheckNumber,
                OwnerName = checkPayment.OwnerName,
                IsOwner = checkPayment.IsOwner,
                PaymentInformationToDisplay = string.Concat("Bco: ", checkPayment.BankName, 
                                                            ", Nº ", checkPayment.CheckNumber, 
                                                            ", Vto: ", checkPayment.ExpirationDate.ToString("dd/MM/yy"))
            }).ToList();
        }
    }
}
