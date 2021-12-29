using System;
using Medilab.BusinessObjects.Utils;

namespace Medilab.UserInterface.ClinicalHistory
{
    public class PracticeListDto
    {
        public Guid Id { set; get; }
        public Guid MedicalHistoryId { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool IsGroup { set; get; }
        public ClinicalExamStatus Status { set; get; }
    }
}
