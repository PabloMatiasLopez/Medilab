using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class FreeInvoiceDetails : IDetailsDisplayable
    {
        private readonly InvoiceDisplay _invoiceDisplay;
        public FreeInvoiceDetails(InvoiceDisplay invoiceDisplay)
        {
            Item = new InvoiceBodyDto();
            _invoiceDisplay = invoiceDisplay;
            LoadDetails(_invoiceDisplay.InvoiceItems);
        }
        public InvoiceBodyDto Item { private set; get; }
        public void LoadDetails(List<InvoiceDetails> details)
        {
            var detail = details.First();
            Item.Quantity = detail.Quantity;
            Item.Description = detail.Description;
            double unitPrice;
            if (_invoiceDisplay.Header.GetHeader().InvoiceType == InvoiceType.B)
            {
                double itemRetention = _invoiceDisplay.InvoiceRetentions.Sum(invoiceRetentionDto => invoiceRetentionDto.Value * detail.Price / 100);
                unitPrice = Math.Round(itemRetention + detail.Price, 1);
            }
            else
            {
                unitPrice = detail.Price;
            }

            Item.UnitPrice = unitPrice;
            Item.TotalPrice = (detail.Quantity * unitPrice);
        }

        public InvoiceDetailType GetInvoiceDetailType()
        {
            return InvoiceDetailType.Free;
        }
    }
}
