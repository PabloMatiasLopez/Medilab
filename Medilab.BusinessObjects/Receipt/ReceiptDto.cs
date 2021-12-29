using System;

namespace Medilab.BusinessObjects.Receipt
{
    public class ReceiptDto
    {
        public DateTime Date { set; get; }

        public string DisplayDate
        {
            get { return Date.ToShortDateString(); }
        }

        public Guid ReceiptId { set; get; }
        public string ClientName { set; get; }
        public string ReceiptNumber { set; get; }
        public double Total { get; set; }
    }
}