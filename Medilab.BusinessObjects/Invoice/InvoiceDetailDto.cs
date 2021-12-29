using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceDetailDto
    {
        public string Date {  get; set; }
        public string ClientName { get; set; }
        public string PatientDocumentNumber { get; set; }
        public string PatientFirstLastName { get; set; }
        public string ExamType { get; set; }
        public string PracticeDescription { get; set; }
        public string PracticePrice { get; set; }
        public string PracticePriceIva { get; set; }
        public string PracticeTotal { get; set; }//Practice + PracticeIva
        public string InvoiceNumberDisplay { get; set; }

        /// <summary>
        /// This is the very last row in the detail attached to the invoice
        /// The first value is the addition of all practice without IVA
        /// The second one is the Iva addition
        /// The third one is the addition of the previous two values
        /// </summary>
        public string MainPracticeTotal { get; set; }
        public string IvaMainTotal { get; set; }
        public string MainTotal { get; set; }
       
    }
}
