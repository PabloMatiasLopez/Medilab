using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class PendingExamFilterCriteria
    {
        public DateTime FilterByFromDate { set; get; }
        public DateTime FilterByToDate { set; get; }
        public ClinicalExamStatus FilterByStatus { set; get; }
        public Guid Speciality { set; get; }
        public Guid ClientId { set; get; }
     }
}
