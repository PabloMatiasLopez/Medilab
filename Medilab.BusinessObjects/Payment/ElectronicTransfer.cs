using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;

namespace Medilab.BusinessObjects.Payment
{
    public class ElectronicTransfer : Payment
    {
        public override PaymentType GetPaymentType()
        {
            return Utils.PaymentType.TransferenciaElectrónica;
        }
        public string BankName { set; get; }
        public string AccountNumber { set; get; }
        public DateTime TransferDate { set; get; }
        internal override void Save(MedilabEntities context)
        {
            Insert(context);
        }
        private void Insert(MedilabEntities context)
        {
            var transfer = new DataAccess.ElectronicTransfer
            {
                ElectronicTransferId = PaymentId = Guid.NewGuid(),
                PaymentDate = DateTime.Today,
                TransferImport = Import,
                Notes = Notes,
                BankName = BankName,
                AccountNumber = AccountNumber,
                ReceiptId = ReceiptId,
                TransferDate = TransferDate
            };
            context.AddToElectronicTransfer(transfer);
        }

        public static List<ElectronicTransfer> GetElectronicTransferList(List<DataAccess.ElectronicTransfer> electronicTransferPayments)
        {
            return electronicTransferPayments.Select(electronicTransferPayment => new ElectronicTransfer
            {
                PaymentId = electronicTransferPayment.ElectronicTransferId,
                Import = electronicTransferPayment.TransferImport,
                PaymentDate = electronicTransferPayment.PaymentDate,
                ReceiptId = electronicTransferPayment.ReceiptId,
                Notes = electronicTransferPayment.Notes,
                BankName = electronicTransferPayment.BankName,
                AccountNumber = electronicTransferPayment.AccountNumber,
                PaymentInformationToDisplay = string.Format("Banco: {0}, Cta. Cte.: {1}, Fecha: {2}", electronicTransferPayment.BankName,
                electronicTransferPayment.AccountNumber, electronicTransferPayment.TransferDate.ToString("dd/MM/yyyy")),
                TransferDate = electronicTransferPayment.TransferDate
            }).ToList();
        }
    }
}
