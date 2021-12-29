using System;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class MedicalHistoryDto
    {
        #region Properties

        public Guid Id { set; get; }
        public int PatientNumber { set; get; }
        public string DocumentNumber { set; get; }
        public string PatientName { set; get; }
        public string ClientName { set; get; }
        public string Status { set; get; }
        public DateTime LastUpdatedDate { set; get; }
        public int? Version { set; get; }

        #endregion
    }
}