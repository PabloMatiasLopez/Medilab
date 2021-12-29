using System;
using System.Collections.Generic;
using Medilab.BusinessObjects.Patient;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class PatientPracticesDto
    {
        public int PatientNumber { set; get; }
        public Guid ClinicalHistoryId { set; get; }
        public PatientListItemDto PatientInformation { set; get; }
        public string ClientName { set; get; }
        public string Observations { set; get; }
        public ExamType HistoryType { set; get; }
        public IEnumerable<PendingPracticeDto> Practices { set; get; }
    }
}
