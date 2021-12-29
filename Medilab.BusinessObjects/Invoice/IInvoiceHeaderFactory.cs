
namespace Medilab.BusinessObjects.Invoice
{
    public interface IInvoiceHeaderFactory
    {
        IHeaderDisplayable GetHeaderAInvoice();
        IHeaderDisplayable GetHeaderBInvoice();
    }
}
