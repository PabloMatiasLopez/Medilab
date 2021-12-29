using System.Collections.Generic;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public interface IDetailsDisplayable
    {
        void LoadDetails(List<InvoiceDetails> details);
        InvoiceDetailType GetInvoiceDetailType();
    }
}
