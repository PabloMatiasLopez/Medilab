using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceHeaderDto : IPrintableInvoiceHeaderDto
    {
        public DateTime Date { set; get; }

        public string DisplayDate
        {
            get { return InvoiceDate.ToShortDateString(); }
        }

        public Guid InvoiceId { set; get; }
        public string ClientName { set; get; }
        public string ClientAddress { set; get; }
        public string IVACondition { set; get; }
        public string SellCondition { set; get; }
        public string ClientCUIT { set; get; }
        public string ClientNumber { set; get; }
        public InvoiceType InvoiceType { set; get; }
        public string InvoiceNumberDisplay { set; get; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public double Remainer { get; set; }
        public InvoiceStatus Status { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CAE { set; get; }
        public string CreateUser { set; get; }
        public string UpdateUser { set; get; }
        public CAE.Enums.TipoComprobante DocumentType { get; set; }

    }
}