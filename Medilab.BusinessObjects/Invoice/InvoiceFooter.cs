using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceFooter:IFooterDisplayable
    {
        private readonly List<InvoiceDetails> _invoiceDetails;
        private readonly InvoiceFooterDto _footer;
        private readonly InvoiceType _invoiceType;

        public InvoiceFooter(List<InvoiceDetails> invoiceDetails, IEnumerable<FiscalRetention> retentions, InvoiceType invoiceType)
        {
            _footer = new InvoiceFooterDto();
            _invoiceDetails = invoiceDetails;
            _invoiceType = invoiceType;
            CalculateInvoiceAmounts(retentions.ToList());
        }
        private void CalculateSubTotal()
        {
            _footer.SubTotal = _invoiceDetails.Sum(detail => ((detail.Quantity != 0 ? detail.Quantity : 1) * detail.Price)); 
        }

        public InvoiceFooterDto GetFooter()
        {
            return _footer;
        }

        private void LoadInvoiceRetentions(IEnumerable<FiscalRetention> retentions)
        {
            _footer.InvoiceRetentions = new List<InvoiceRetentionDto>();
            foreach (FiscalRetention fiscalRetention in retentions)
            {
                _footer.InvoiceRetentions.Add(new InvoiceRetentionDto
                {
                    FiscalRetentionId = fiscalRetention.Id,
                    Name = fiscalRetention.Name,
                    Value = fiscalRetention.Value,
                    RetentionValue = Math.Round(_footer.SubTotal * fiscalRetention.Value / 100, 2)
                });
            }
        }

        private void CalculateTotal()
        {
            double totalRetentions = _footer.InvoiceRetentions.Sum(retention => retention.RetentionValue);
            _footer.Total = Math.Round(_footer.SubTotal + totalRetentions, 2);
        }

        private void CalculateInvoiceAmounts(List<FiscalRetention> retentions)
        {
            if (_invoiceType == InvoiceType.B)
            {
                //Para facturas B el calculo del subtototal se hace en base al total, esto es así para que coincidan los datos impresos y los presentados a AFIP
                double totalRetention = (retentions.Sum(retention => retention.Value)/100) + 1;
                double total = 0;
                foreach (var item in _invoiceDetails)
                {
                    var price = (item.Quantity != 0 ? item.Quantity : 1) * item.Price;
                    price = price * totalRetention;
                    price = Math.Round(price, 1);
                    total += price;
                }
                _footer.Total = total;
                var subtotal = _footer.Total / totalRetention;
                _footer.SubTotal = subtotal;
                LoadInvoiceRetentions(retentions);
            }
            else
            {
                CalculateSubTotal();
                LoadInvoiceRetentions(retentions);
                CalculateTotal();
            }
        }
    }
}
