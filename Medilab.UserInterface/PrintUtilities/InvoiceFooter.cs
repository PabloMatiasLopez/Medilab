using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;

namespace Medilab.UserInterface.PrintUtilities
{
    public class InvoiceFooter
    {
        private PrinterMetaData _sectionLabel;
        private PrinterMetaData _subTotal;
        private PrinterMetaData _mainTotal;
        private readonly List<PrinterMetaData> _footerElements = new List<PrinterMetaData>();

        public List<PrinterMetaData> FillInvoiceFooter(InvoiceFullFooterDto invoiceFooter)
        {
            #region Static Values
            //SubTotal
            _subTotal.isBold = true;
            _subTotal.maxLineLength = 100;
            _subTotal.printFont = new Font("Arial", 12);
            _subTotal.xPos = _subTotal.UnitConvertion2(19.0F);
            _subTotal.yPos =  _subTotal.UnitConvertion2(21.0F);

            //Main Total
            _mainTotal.isBold = true;
            _mainTotal.maxLineLength = 100;
            _mainTotal.printFont = new Font("Arial", 12);
            _mainTotal.xPos = _mainTotal.UnitConvertion2(19.0F);
            _mainTotal.yPos = _mainTotal.UnitConvertion2(26.3F);

            //Section label
            _sectionLabel.isBold = true;
            _sectionLabel.maxLineLength = 100;
            _sectionLabel.printFont = new Font("Arial", 12);
            _sectionLabel.xPos = _mainTotal.UnitConvertion2(1.1F);
            _sectionLabel.yPos = _mainTotal.UnitConvertion2(21.9F);

            //Filling the information to print
            _sectionLabel.Data = "IMPUESTOS";
           
            _footerElements.Add(_sectionLabel);
            #endregion

            const float xposLeft = 1.1F;
            const float xposRight = 19.5F;
            float ypos = 23.0F;

            if (invoiceFooter.InvoiceType == InvoiceType.A)
            {
                _subTotal.Data = invoiceFooter.SubTotal.ToString(CultureInfo.CurrentCulture);
                _mainTotal.Data = invoiceFooter.Total.ToString(CultureInfo.CurrentCulture);
                _footerElements.Add(_subTotal);
                foreach (var retention in invoiceFooter.InvoiceRetentions)
                {
                    var retentionToPrint = new PrinterMetaData();
                    var retentionToPrintValue = new PrinterMetaData();

                    //Retention description
                    retentionToPrint.maxLineLength = 100;
                    retentionToPrint.printFont = new Font("Arial", 11);
                    retentionToPrint.xPos = retentionToPrint.UnitConvertion(xposLeft);
                    retentionToPrint.yPos = retentionToPrint.UnitConvertion(ypos);
                    retentionToPrint.Data = retention.Name;

                    //Retention value
                    retentionToPrintValue.maxLineLength = 100;
                    retentionToPrintValue.printFont = new Font("Arial", 11);
                    retentionToPrintValue.xPos = retentionToPrintValue.UnitConvertion(xposRight);
                    retentionToPrintValue.yPos = retentionToPrintValue.UnitConvertion(ypos);
                    retentionToPrintValue.Data = retention.RetentionValue.ToString(CultureInfo.CurrentCulture);


                    _footerElements.Add(retentionToPrint);
                    _footerElements.Add(retentionToPrintValue);
                    ypos += 0.4F;

                }
            }
            else
            {
                // for the B & C invoice types we don need to discriminate the retentions even if they have them
                _subTotal.Data = invoiceFooter.Total.ToString(CultureInfo.CurrentCulture);
                _mainTotal.Data = invoiceFooter.Total.ToString(CultureInfo.CurrentCulture);
                _footerElements.Add(_subTotal);
            }
            _footerElements.Add(_mainTotal);
           return _footerElements;

        }
    }
}
