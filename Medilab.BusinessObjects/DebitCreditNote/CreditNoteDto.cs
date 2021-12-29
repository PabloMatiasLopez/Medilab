using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using System;
﻿
namespace Medilab.BusinessObjects.DebitCreditNote
{
    public class CreditNoteDto
    {
        public Guid NoteId { set; get; }
        public DateTime Date { set; get; }
        public string ReceiptNumber { set; get; }
        public string CreditNoteNumber { set; get; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double IvaImport { get; set; }
        public CompanyInfoDto CompanyInfo { get; set; }
        public string ClientName { get; set; }
        public string Detail { get; set; }
        public NoteType NoteType { set; get; }
        public Client Client { set; get; }
        public string InvoiceNumber { set; get; }
        public DateTime InvoiceDate { set; get; }
        public InvoiceType InvoiceType { set; get; }
        public string CAE { set; get; }
        public DateTime CaeExperirationDate { set; get; }
        public bool IncludeIVA { set; get; }
        
        
    }
}
