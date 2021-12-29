using System.Collections.Generic;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceFooterDto
    {
        public double Total { set; get; }
        public double SubTotal { set; get; }
        public List<InvoiceRetentionDto> InvoiceRetentions { set; get; }
    }
}
