using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.DTOs
{
    public class ReportDto
    {
        public string Filters { get; set; }
        public string DateTimeFilter { get; set; }
        public string ColumnsToShow { get; set; }
    }
}
