using Medilab.BusinessObjects.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.DebitCreditNote
{
    public class DebitNoteDto
    {
        public string Date { set; get; }
        public string ReceiptNumber { set; get; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public CompanyInfoDto CompanyInfo { get; set; }
        public Client Client { get; set; }
        public string CreditNoteNumber { get; set; }
        public string Detail { get; set; }
    }
}
