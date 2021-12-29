using System.Collections.Generic;

namespace Medilab.BusinessObjects.BillingReport
{
    public class DebtReportResultDto
    {
        public List<DebtByClientItemDto> Items { get; set; }
        public double Total { get; set; }
    }
}
