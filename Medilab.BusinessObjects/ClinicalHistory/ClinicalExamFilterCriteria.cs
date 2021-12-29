using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class ClinicalExamFilterCriteria
    {
        public string FilterByPatient { set; get; }
        public string FilterByDocumentNumber { set; get; }
        public string FilterByClient { set; get; }
        public DateTime FilterByFromDate { set; get; }
        public DateTime FilterByToDate { set; get; }
        public ClinicalHistoryStatus FilterByStatus { set; get; }
    }
}
