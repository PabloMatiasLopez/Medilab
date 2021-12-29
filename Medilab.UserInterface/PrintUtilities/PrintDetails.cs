using Medilab.BusinessObjects.Invoice;
using Medilab.UserInterface.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Medilab.UserInterface.PrintUtilities
{
    public abstract class PrintDetails
    {
        
        public static void PrintInvoiceDetails(Medilab.BusinessObjects.Invoice.InvoiceHeader  invoiceHeader)
        {

            //TODO REMOVE this FAKE INFORMATION GENERATED
            InvoiceToPrint invoiceToPrint = new InvoiceToPrint(invoiceHeader);
            List<InvoiceDetailDto> invoiceDetailDto = invoiceToPrint.LoadInvoiceDetails();

            MSExcel excel = new MSExcel();
            // Get the file we are going to process
            string filename = string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                            "InvoiceDetail_" + Guid.NewGuid().ToString(), ".xlsx");

            File.Copy(string.Concat(
                ConfigurationManager.AppSettings["ExcelPathTemplates"],
                ConfigurationManager.AppSettings["InvoiceDetail"]),
                      filename);

            var template = new FileInfo(filename);

            // Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        //Calculate de number of spreadsheets to be use in the excel file

                        double obj = (double)invoiceDetailDto.Count() / 60;
                        int sheetNumber = (int)Math.Ceiling(obj);
                        for (int i = 1; i < sheetNumber; i++)
                        {
                            workBook.Worksheets.Add(i.ToString(), workBook.Worksheets[1]);
                        }

                        int pageIndicator = 1;
                        foreach (var worksheet in workBook.Worksheets)
                        {
                            worksheet.Cells["S74"].Value = string.Concat(pageIndicator, "/", sheetNumber.ToString());
                            pageIndicator++;
                        }
                        // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();
                       
                        //calculation of the number of pages
                        int counter = 13;
                        int sheetCounter = 1;

                        string invoiceNumberModified = invoiceHeader.InvoiceNumber.ToString();
                        int invoicedigits = 8;
                        string zeros = "";
                        if (invoiceNumberModified.Length < invoicedigits)
                        {
                            invoicedigits -= invoiceNumberModified.Length;
                            
                            for (int i = 0; i < invoicedigits; i++)
                            {
                                zeros += 0;
                            }
                        }

                        workBook.Worksheets[1].Cells["N4"].Value = string.Concat("000", invoiceHeader.SalePoint, "-", zeros, invoiceHeader.InvoiceNumber); 
                        workBook.Worksheets[1].Cells["P6"].Value = invoiceHeader.Date;
                        workBook.Worksheets[1].Cells["B10"].Value = string.Concat("Sr/es: ", invoiceHeader.ClientInformation.Name);


                        var sortedDetailDto = invoiceDetailDto.OrderBy(i => i.PatientFirstLastName).ToList();
                        foreach (var detail in sortedDetailDto)
                        {
                            if (counter > 73)
                            {
                                counter = 13;
                                if (sheetCounter < workBook.Worksheets.Count)
                                {
                                    sheetCounter++;
                                    workBook.Worksheets[sheetCounter].Cells["N4"].Value = string.Concat("000", invoiceHeader.SalePoint, "-", zeros, invoiceHeader.InvoiceNumber); 
                                    workBook.Worksheets[sheetCounter].Cells["P6"].Value = invoiceHeader.Date;
                                    workBook.Worksheets[sheetCounter].Cells["B10"].Value = string.Concat("Sr/es: ", invoiceHeader.ClientInformation.Name);
                                    sortedDetailDto = invoiceDetailDto.OrderBy(i => i.PatientFirstLastName).ToList();
                                }
                                
                            }
                          
                            if (!string.IsNullOrEmpty(detail.PatientDocumentNumber))
                            {
                                workBook.Worksheets[sheetCounter].Cells["B" + counter].Value = detail.PatientFirstLastName;
                                workBook.Worksheets[sheetCounter].Cells["I" + counter].Value = detail.PatientDocumentNumber;
                                workBook.Worksheets[sheetCounter].Cells["L" + counter].Value = detail.Date.Remove(11);
                                workBook.Worksheets[sheetCounter].Cells["M" + counter].Value = (detail.PracticeDescription.Length > 56 ? detail.PracticeDescription.Remove(56) : detail.PracticeDescription);
                            }
                            else
                            {
                               
                            }
                            counter++;
                        }
                    }
                    package.Save();
                    excel.Open(filename);
                    excel.Print();
                    excel.Close();
                    excel.Quit();
                    RemoveFile(filename);

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
