using System;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class PracticeDto
    {
        public Guid Id { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Guid SpecialityId { set; get; }
        public string SpecialityName { set; get; }
        public byte[] LastUpdated { set; get; }
        public string PracticeFormatResult { set; get; }
        public double Price { set; get; }
        public bool IsExternal { set; get; }
        public string ReportName { set; get; }
    }
}
