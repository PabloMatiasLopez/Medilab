using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.DTOs
{
    public class InvoicePaymentDto
    {
        public string InvoiceType { set; get; }
        public DateTime Date { set; get; }
        public double PaymentAmount { set; get; }
        public double InvoiceRemainder { set; get; }
        public double Total { set; get; }
        public Guid InvoiceId { set; get; }
        public string InvoiceNumber { set; get; }
    }
}
