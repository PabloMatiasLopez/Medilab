using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.Utils
{
    public static class Constants
    {
        public static  readonly  Guid LabId = new Guid("531D8EDE-01D0-43CD-8D0E-27DCD9C6F5BF");
        public static readonly Guid ClinicId = new Guid("1F73513A-D81D-44F4-B6D6-EA793AA5A691");
        public static readonly Guid NoSpecialityId = new Guid("E45E6981-CF7D-4DA5-9BD9-7B7ED8ECCF16");
        public static readonly Guid ClinicalExamId = new Guid("E0083882-1341-45BA-BB52-09B6C6E99DC2");
        public static readonly string NotAvailable = "No disponible";
        public static readonly string NotMade = "NE";
        public static readonly string NotAffection = "No Refiere";
        public static readonly string Yes = @"Si";
        public static readonly string No = @"No";
        public static readonly string CAESleepTimeName = "CAESleepTime";
        public static readonly string CAERetryTimes = "CAERetryTimes";
    }
}
