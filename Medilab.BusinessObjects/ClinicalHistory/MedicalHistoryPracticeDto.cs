using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class MedicalHistoryPracticeDto
    {
        public Guid Id { set; get; }
        public Guid ClinicalHistoryId { set; get; }
        public Guid MedicalPracticeId { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public ClinicalExamStatus Status { set; get; }
        public Guid? GroupId { set; get; }
        public string Observations { set; get; }
        public ClinicalExamResult Result { set; get; }
        public bool IsExternal { set; get; }
    }
}
