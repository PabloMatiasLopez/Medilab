using System;
using System.Globalization;
using System.Linq;
using System.IO;
using Medilab.BusinessObjects.Configuration;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Drawing;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using Medilab.BusinessObjects.ClinicalHistory;
using System.Configuration;
using Medilab.BusinessObjects.Address;
using System.Collections.Generic;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.DebitCreditNote;
using Medilab.UserInterface.PrintUtilities;
using Aspose.Cells;


namespace Medilab.UserInterface.Excel
{
    public class CreditNoteExcelHandler
    {
        public static void GenerateExcel(CreditNoteDto creditNote,bool isPreview)
        {
         Guid documentGuid = Guid.NewGuid();
            MSExcel excel = new MSExcel();
            string excelPath = ConfigurationManager.AppSettings["ExcelPath"];
            string templatePath = ConfigurationManager.AppSettings["ExcelPathTemplates"];
            RemoveFile(string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
            var clientAddress = (from ad in creditNote.Client.Addresses where ad.IsDefault select ad).First();

            if (creditNote.NoteType == NoteType.A)
            {
                templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["CreditNoteA"]);
            }
            else
            {
                templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["CreditNoteB"]);
            }
                     
            File.Copy(templatePath,
                         string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));

            var template =
                new FileInfo(string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));

            //// Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {

                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();
                        
                        #region CreditNoteHeader
                        currentWorksheet.Cells["L4"].Value = string.Concat("N° ", creditNote.CreditNoteNumber);
                        currentWorksheet.Cells["P6"].Value = creditNote.Date;
                        currentWorksheet.Cells["B10"].Value = string.Concat(creditNote.CompanyInfo.Address, " ", creditNote.CompanyInfo.PostalCode);
                        currentWorksheet.Cells["B11"].Value = creditNote.CompanyInfo.Phone;
                        currentWorksheet.Cells["B12"].Value = creditNote.CompanyInfo.Email;
                        currentWorksheet.Cells["B15"].Value = string.Concat("Sr/es: ", creditNote.Client.Name);
                        currentWorksheet.Cells["B16"].Value = string.Concat("Domicilio: ", clientAddress.ToString());
                        currentWorksheet.Cells["B17"].Value = string.Concat("I.V.A.: ", creditNote.Client.IvaCondition.ToString().Replace("_", " "));
                        currentWorksheet.Cells["L17"].Value = string.Concat(creditNote.Client.DocumentType.ToString(), ": ", creditNote.Client.Cuit);
                        currentWorksheet.Cells["B18"].Value = "Condición de Venta: CONTADO"; ///TODO Add the sell condition to the invoice header entity
                        currentWorksheet.Cells["L18"].Value = string.Concat("Cliente Nº: ", creditNote.Client.ClientNumber.ToString());
                        #endregion
                        #region CreditNoteBody

                                               
                        currentWorksheet.Cells["B23"].Value = "1";
                        currentWorksheet.Cells["D23"].Value = creditNote.Detail;
                        currentWorksheet.Cells["N23"].Value = creditNote.SubTotal;
                        currentWorksheet.Cells["Q23"].Value = creditNote.SubTotal;

                        #endregion
                        #region CreditNote Footer
                        currentWorksheet.Cells["F40"].Value = "FACTURA";
                        currentWorksheet.Cells["F41"].Value = creditNote.InvoiceType.ToString();
                        currentWorksheet.Cells["F42"].Value = creditNote.InvoiceNumber;
                        currentWorksheet.Cells["F43"].Value = creditNote.InvoiceDate.ToShortDateString();
                       


                        if (creditNote.NoteType == NoteType.A)
                        {
                            currentWorksheet.Cells["Q37"].Value = creditNote.SubTotal;
                            if (creditNote.IncludeIVA)
                            {
                                currentWorksheet.Cells["N40"].Value = "IVA";
                                currentWorksheet.Cells["Q40"].Value = creditNote.IvaImport;
                                currentWorksheet.Cells["Q47"].Value = creditNote.Total;
                                currentWorksheet.Cells["B49"].Value = string.Concat("CAE: ", creditNote.CAE, " Fecha de vencimiento: ", creditNote.CaeExperirationDate.ToShortDateString());

                            }
                        }
                        else
                        {
                            currentWorksheet.Cells["Q37"].Value = creditNote.Total;
                            currentWorksheet.Cells["B46"].Value = string.Concat("CAE: ", creditNote.CAE, " Fecha de vencimiento: ", creditNote.CaeExperirationDate.ToShortDateString());
                        }
                      

                        #endregion

                        package.Save();
                        
                        if(!isPreview)

                        { 
                            excel.Open(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
                            excel.Print();
                            excel.Close();
                            excel.Quit();
                            RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
                        }
                        else
                        {
                            /*var excelToPedf = new ExcelToPdf(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 documentGuid.ToString()));*/

                            Workbook workbook = new Workbook(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));

                            //Save the document in PDF format
                            workbook.Save(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 documentGuid.ToString(),".pdf"), SaveFormat.Pdf);

                            System.Diagnostics.Process.Start(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 documentGuid.ToString(), ".pdf"));
                        }


                    }
                }
            }
        }
        
        private static void RemoveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}
