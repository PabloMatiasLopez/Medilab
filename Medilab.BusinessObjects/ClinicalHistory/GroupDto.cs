using System;
using System.Collections.Generic;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    internal class GroupDto
    {
        public Guid Id { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public IEnumerable<PracticeDto> Practices { set; get; }
        public byte[] LastUpdated { get; set; }
        public double Price { set; get; }
    }
}
