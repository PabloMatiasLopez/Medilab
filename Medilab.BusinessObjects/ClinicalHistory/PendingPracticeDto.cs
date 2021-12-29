using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class PendingPracticeDto
    {
        public Guid Id { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Guid SpecialityId { set; get; }
        public bool IsDone { set; get; }
        public ClinicalExamStatus Status { set; get; }
    }
}
