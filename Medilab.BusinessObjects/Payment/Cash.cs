using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;

namespace Medilab.BusinessObjects.Payment
{
    public class Cash : Payment
    {
        public override PaymentType GetPaymentType()
        {
            return Utils.PaymentType.Efectivo;
        }
        internal override void Save(MedilabEntities context)
        {
            Insert(context);
        }
        private void Insert(MedilabEntities context)
        {
            var cash = new DataAccess.Cash
            {
                CashId = PaymentId = Guid.NewGuid(),
                CashImport = Import,
                PaymentDate = DateTime.Today,
                ReceiptId = ReceiptId,
                Notes = Notes
            };
            context.AddToCash(cash);
        }

        public static List<Cash> GetCashList(List<DataAccess.Cash> cashPayments)
        {
            return cashPayments.Select(cashPayment => new Cash
            {
                PaymentId = cashPayment.CashId, 
                Import = cashPayment.CashImport, 
                PaymentDate = cashPayment.PaymentDate, 
                ReceiptId = cashPayment.ReceiptId, 
                Notes = cashPayment.Notes,
                PaymentInformationToDisplay = cashPayment.Notes
            }).ToList();
        }
    }
}