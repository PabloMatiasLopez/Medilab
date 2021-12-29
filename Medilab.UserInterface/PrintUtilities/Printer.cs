using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Excel;

namespace Medilab.UserInterface.PrintUtilities
{
    public  class Printer
    {
        //TODO:Find the way to get the corresponding DTO's filled with the right client information
        //TODO: To change Guid.Empty to an existing header Id on DB
        private List<PrinterMetaData> _invoice;
        public bool PrintInvoice(Guid invoiceId, bool isPreview = false)
        {
            BusinessObjects.Invoice.InvoiceHeader invoice = BusinessObjects.Invoice.InvoiceHeader.GetInvoiceById(invoiceId);
            try
            {
                InvoiceExcelHandler.GenerateExcel(invoice, isPreview); 
                invoice.Status = InvoiceStatus.Impresa;
                invoice.Save();
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // The PrintPage event is raised for each page to be printed. 
        private void PdPrintPage(object sender, PrintPageEventArgs ev)
        {
            foreach (PrinterMetaData printerData in _invoice)
            {
                ev.Graphics.DrawString(printerData.Data, printerData.printFont, Brushes.Black,
                   printerData.xPos, printerData.yPos, new System.Drawing.StringFormat());
            }
        }
    }
}
