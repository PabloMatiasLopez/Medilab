
using Medilab.BusinessObjects.Configuration;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceHeaderFactory : IInvoiceHeaderFactory
    {
        public IHeaderDisplayable GetHeaderAInvoice()
        {
            return new InvoiceAHeader(new NextInvoiceNumber());
        }

        public IHeaderDisplayable GetHeaderBInvoice()
        {
            return new InvoiceBHeader(new NextInvoiceNumber());
        }
    }
}
