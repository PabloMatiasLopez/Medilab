using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class ResumeInvoiceDetails : IDetailsDisplayable
    {
        private readonly InvoiceDisplay _invoiceDisplay;
        public ResumeInvoiceDetails(InvoiceDisplay invoiceDisplay)
        {
            Items = new List<InvoiceBodyDto>();
            _invoiceDisplay = invoiceDisplay;
            LoadDetails(_invoiceDisplay.InvoiceItems);
        }

        public List<InvoiceBodyDto> Items { private set; get; }
        public void LoadDetails(List<InvoiceDetails> details)
        {
            var groupedDetails = from p in details
                                 group p by p.Code
                                 into g
                                 select new {Code = g.Key, Practices = g.ToList()};
            foreach (var detail in groupedDetails)
            {
                int count = detail.Practices.Sum(item => item.Quantity);
                var price = detail.Practices.First().Price;
                double unitPrice;
                if (_invoiceDisplay.Header.GetHeader().InvoiceType == InvoiceType.B)
                {
                    double itemRetention = _invoiceDisplay.InvoiceRetentions.Sum(invoiceRetentionDto => invoiceRetentionDto.Value * price / 100);
                    unitPrice = Math.Round(itemRetention + price, 1);
                }
                else
                {
                    unitPrice = price;
                }
                Items.Add(new InvoiceBodyDto
                              {
                                  Quantity = count,
                                  Description = detail.Practices.First().Description,
                                  UnitPrice = unitPrice,
                                  TotalPrice = (count * unitPrice)
                              });
            }
        }

        public InvoiceDetailType GetInvoiceDetailType()
        {
            return InvoiceDetailType.Resumed;
        }
    }
}
