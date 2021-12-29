using System;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class PendingPatientDto
    {
        public Guid ClinicalHistoryId { set; get; }
        public Guid PatientId { set; get; }
        public string DocumentNumber { set; get; }
        public string PatientName { set; get; }
        public int PatientNumber { set; get; }
    }
}
