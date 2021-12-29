
namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceDetailFactory:IInvoiceDetailFactory
    {
        public IDetailsDisplayable CreateFullInvoiceDetails(InvoiceDisplay invoiceDisplay)
        {
            return new FullInvoiceDetails(invoiceDisplay);
        }

        public IDetailsDisplayable CreateFreeInvoiceDetails(InvoiceDisplay invoiceDisplay)
        {
            return new FreeInvoiceDetails(invoiceDisplay);
        }

        public IDetailsDisplayable CreateReseumedInvoiceDetails(InvoiceDisplay invoiceDisplay)
        {
            return new ResumeInvoiceDetails(invoiceDisplay);
        }
    }
}
