
using System.Collections.Generic;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceFullFooterDto : IPrintableInvoiceFooterDto
    {
        public string Total { set; get; }
        public string SubTotal { set; get; }
        public List<InvoiceRetentionDto> InvoiceRetentions { set; get; }
        public InvoiceType InvoiceType;
    }
}
