using System;

namespace Medilab.BusinessObjects.BillingReport
{
    public class DebtByClientItemDto
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public double Total { get; set; }
        public string Remainder { get; set; }
        public string DocumentNumber { get; set; }
        public string Notes { get; set; }
    }
}
