using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.PrintUtilities
{
    public interface IInvoiceBody
    {
        List<PrinterMetaData> FillInvoiceBody(IPrintableInvoiceDetail invoiceBody);
    }
}
