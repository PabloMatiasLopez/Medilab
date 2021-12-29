
using System.Collections.Generic;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceDisplay
    {
        public IHeaderDisplayable Header { set; get; }
        public IDetailsDisplayable Details { set; get; }
        public List<InvoiceDetails> InvoiceItems { set; get; }
        public List<InvoiceDetails> InvoicedPractices { set; get; }
        public IFooterDisplayable Footer { set; get; }
        public List<FiscalRetention> InvoiceRetentions; 
    }
}
