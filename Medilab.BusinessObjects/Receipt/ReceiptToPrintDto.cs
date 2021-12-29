using System.Collections.Generic;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.BusinessObjects.Receipt
{
    public class ReceiptToPrintDto
    {
        public string Date { set; get; }
        public string ReceiptNumber { set; get; }
        public double Total { get; set; }
        public CompanyInfoDto CompanyInfo { get; set; }
        public Client Client { get; set; }
        public List<InvoiceHeaderDto> Invoices { get; set; }
        public List<Payment.Payment> Payments { get; set; }
        public string Notes { get; set; }
        public double Discount { get; set; }
        public double TotalWithDiscount { get; set; }
        public string CreatedBy { get; set; }
      

    }
}