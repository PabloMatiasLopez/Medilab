using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Medilab.UserInterface.PrintUtilities
{
    public static class MedicalExamUtils
    {
        public static void PrintAffidavit(Guid clinicalHistoryId)
        {
            var _companyExcelFormat = CompanyInfo.GetCompanyExcelFormat();
            var _templatePath = ConfigurationManager.AppSettings["ExcelPathTemplates"];
            var _affidavitTemplateFile = ConfigurationManager.AppSettings["Affidavit"];
            //only this two opyions because the printpartial it's only going to be visible if the company is labomed or movilmem
            //If it's another company it shouldn't be allowed to make a partial print.
            if (_companyExcelFormat.Equals("Labomed"))
            {
                LaboMedExcelnHandler.GeneratePartialExcel(clinicalHistoryId, string.Concat(_templatePath, _affidavitTemplateFile), _companyExcelFormat);
            }
            else
            {
                MovilmedExcelnHandler.GeneratePartialExcel(clinicalHistoryId, string.Concat(_templatePath, _companyExcelFormat, "1.xlsx"), _companyExcelFormat);
            }
        }
    }
}
