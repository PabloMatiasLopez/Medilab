using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sautinsoftlocal;
using System.IO;
using System.Configuration;

namespace Medilab.UserInterface.PrintUtilities
{
    public class ExcelToPdf
    {
        public ExcelToPdf(string filename)
        {
            this.PreviewExcelAsPdf(filename);
        }
        
        private void PreviewExcelAsPdf(string excelFileName)
        {
            //Convert Excel file to PDF file
            SautinSoft.ExcelToPdf x = new SautinSoft.ExcelToPdf();

            //Set PDF format for output document
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            string excelPath = string.Concat(excelFileName,ConfigurationManager.AppSettings["ExcelExtention"]);
            string pdfPath = string.Concat(excelFileName, ".pdf");

            if (x.ConvertFile(excelPath, pdfPath) == 0)
            {
                System.Diagnostics.Process.Start(pdfPath);
            }
        }

    }
}