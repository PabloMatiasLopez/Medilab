using System.Collections.Generic;

namespace Medilab.BusinessObjects.Invoice
{
    public class FullInvoiceBodyDto :  IPrintableInvoiceDetail
    {
        public Dictionary<string, List<InvoiceBodyDto>> Items { set; get; }
    }
}
