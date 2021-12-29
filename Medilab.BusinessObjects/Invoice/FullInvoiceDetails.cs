using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class FullInvoiceDetails : IDetailsDisplayable
    {
        public Dictionary<string, List<InvoiceBodyDto>> Items { private set; get; }
        private readonly InvoiceDisplay _invoiceDisplay;

        public FullInvoiceDetails(InvoiceDisplay invoiceDisplay)
        {
            Items = new Dictionary<string, List<InvoiceBodyDto>>();
            _invoiceDisplay = invoiceDisplay;
            LoadDetails(_invoiceDisplay.InvoiceItems);
        }

        public void LoadDetails(List<InvoiceDetails> details)
        {
            var sortedDetails = from p in details
                                group p by p.PatientId
                                into g
                                select new {PatientId = g.Key, Practices = g.ToList()};
            foreach (var sortedDetail in sortedDetails)
            {
                var practices = sortedDetail.Practices;
                var items = new List<InvoiceBodyDto>();
                foreach (var practice in practices)
                {
                    double unitPrice;
                    if (_invoiceDisplay.Header.GetHeader().InvoiceType == InvoiceType.B)
                    {
                        double itemRetention = _invoiceDisplay.InvoiceRetentions.Sum(invoiceRetentionDto => invoiceRetentionDto.Value * practice.Price / 100);
                        unitPrice = Math.Round(itemRetention + practice.Price, 1);
                    }
                    else
                    {  
                        unitPrice = practice.Price;
                    }
                    items.Add(new InvoiceBodyDto
                                  {
                                      Quantity = practice.Quantity,
                                      Description = practice.Description,
                                      UnitPrice = unitPrice,
                                      TotalPrice = (practice.Quantity*unitPrice)
                                  });
                }

                Items.Add(sortedDetail.Practices.First().FullName, items);
            }
        }

        public InvoiceDetailType GetInvoiceDetailType()
        {
            return InvoiceDetailType.FullDetail;
        }
    }
}
