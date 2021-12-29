using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.Payment
{
    public class CreditNotePayment : Payment
    {
        public string NoteNumber { set; get; }
        public override PaymentType GetPaymentType()
        {
            return Utils.PaymentType.NotaCredito;
        }
        public NoteType CreditNoteType { set; get; }

        internal override void Save(MedilabEntities context)
        {
            var splitNumber = NoteNumber.Split('-');
            var salePoint = int.Parse(splitNumber[0]);
            var number = int.Parse(splitNumber[1]);
            var noteType = (int)CreditNoteType;
            var note = (from cn in context.CreditNote where cn.SalePoint == salePoint && cn.CreditNoteNumber == number && cn.CreditNoteType == noteType select cn).First();
            note.ReceiptId = ReceiptId;
            note.Observations = Notes;
            note.State = (int)CrediDebitNoteState.Usada;
        }

        public static List<CreditNotePayment> GetCreditNoteList(List<CreditNote> creditNotePayments)
        {
            return creditNotePayments.Select(creditNote => new CreditNotePayment
            {
                PaymentId = creditNote.CreditNoteId,
                Import = creditNote.Import,
                PaymentDate = creditNote.CreationDate,
                ReceiptId = creditNote.ReceiptId.HasValue ? creditNote.ReceiptId.Value : Guid.Empty,
                Notes = creditNote.Observations,
                NoteNumber = string.Concat(creditNote.SalePoint.ToString("0000"), "-",  creditNote.CreditNoteNumber.ToString("00000000")),
                PaymentInformationToDisplay = string.Concat("Nº ", creditNote.SalePoint.ToString("0000"), "-",            
                                                             creditNote.CreditNoteNumber.ToString("00000000"), ", Fecha: ", 
                                                             creditNote.CreationDate.ToString("dd/MM/yy"))
            }).ToList();
        }
    }
}
