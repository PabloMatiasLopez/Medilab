using System;
using System.Configuration;
using System.Linq;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public static class InvoiceTypeCalculator
    {
        public static InvoiceDetailType CalculateInvoiceType(InvoiceHeader invoice)
        {
            if (!string.IsNullOrWhiteSpace(invoice.ManualDetailText))
            {
                return InvoiceDetailType.Free;
            }

            int invoiceDetailLimit = Int32.Parse(ConfigurationManager.AppSettings["InvoiceDetailLimit"]);

            var itemGroupsCount = invoice.Items.GroupBy(p => p.PatientId).Count();
            int itemsQuantiy = itemGroupsCount + invoice.Items.Count();
            if (itemsQuantiy <= invoiceDetailLimit)
            {
                return InvoiceDetailType.FullDetail;
            }

            itemGroupsCount = invoice.Items.GroupBy(p => p.Code).Count();
            if (itemGroupsCount <= invoiceDetailLimit)
            {
                return InvoiceDetailType.Resumed;
            }

            return InvoiceDetailType.Free;
        }
    }
}
