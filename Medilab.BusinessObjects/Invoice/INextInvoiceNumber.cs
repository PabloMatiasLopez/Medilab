using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Invoice
{
    public interface INextInvoiceNumber
    {
        void SetNextInvoiceNumber(InvoiceType invoiceType);
        INextInvoiceNumber GetNextInvoiceNumber(InvoiceType invoiceType);
        string GetNextInvoiceNumberDisplay(InvoiceType invoiceType);
        void AddInvoiceNumber(InvoiceType invoiceType, MedilabEntities context);
    }
}
