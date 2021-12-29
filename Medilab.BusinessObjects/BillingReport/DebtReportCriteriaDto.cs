using System;

namespace Medilab.BusinessObjects.BillingReport
{
    public class DebtReportCriteriaDto
    {
        public bool OnlyPending { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool SearchByClientNumber { get; set; }
        public Guid ClientId { get; set; }
        public int ClientNumber { get; set; }
    }
}
