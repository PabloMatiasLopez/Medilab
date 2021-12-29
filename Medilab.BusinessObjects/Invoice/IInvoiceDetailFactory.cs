
namespace Medilab.BusinessObjects.Invoice
{
    public interface IInvoiceDetailFactory
    {
        IDetailsDisplayable CreateFullInvoiceDetails(InvoiceDisplay invoiceDisplay);
        IDetailsDisplayable CreateFreeInvoiceDetails(InvoiceDisplay invoiceDisplay);
        IDetailsDisplayable CreateReseumedInvoiceDetails(InvoiceDisplay invoiceDisplay);
    }
}
