using System;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceRetentionDto
    {
        public Guid FiscalRetentionId { set; get; }
        public string Name { set; get; }
        public double Value { set; get; }
        public double RetentionValue { set; get; }
    }
}
