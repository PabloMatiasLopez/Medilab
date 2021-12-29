
using Medilab.BusinessObjects.Configuration;

namespace Medilab.BusinessObjects.Invoice
{
    public interface IHeaderDisplayable
    {
        void LoadHeader(Client client);
        InvoiceHeaderDto GetHeader();
    }
}
