using System;
using System.Collections.Generic;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;

namespace Medilab.UserInterface.PrintUtilities
{
    public class Invoice
    {
        private List<PrinterMetaData> _informationToBePrinted;

        public List<PrinterMetaData> GenerateInvoiceToPrint(BusinessObjects.Invoice.InvoiceHeader invoide)
        {
            var invoiceToPrint = new InvoiceToPrint(invoide);

            //Fill the list with the header information
            _informationToBePrinted = new InvoiceHeader().FillInvoiceHeader((InvoiceHeaderDto)invoiceToPrint.InvoiceHeader);


            if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.FullDetail)
            {
                _informationToBePrinted.AddRange(new InvoiceBodyFull().FillInvoiceBody(invoiceToPrint.InvoiceDetail));
            }
            else if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.Resumed)
            {
                _informationToBePrinted.AddRange(new InvoiceBodyResumed().FillInvoiceBody(invoiceToPrint.InvoiceDetail));
            }
            else
            {
                _informationToBePrinted.AddRange(new InvoiceBodyFree().FillInvoiceBody(invoiceToPrint.InvoiceDetail));
            }

            //Fill the list with the footer information
            _informationToBePrinted.AddRange(new InvoiceFooter().FillInvoiceFooter((InvoiceFullFooterDto)invoiceToPrint.InvoiceFooter));

            return _informationToBePrinted;
        }

    }
}

