using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using OfficeOpenXml;
using Medilab.BusinessObjects.Utils;
using System.Configuration;
using System.Collections.Generic;
using Medilab.BusinessObjects.Invoice;


namespace Medilab.UserInterface.Excel
{
    public class InvoiceExcelHandler
    {
        public static void GenerateExcel(InvoiceHeader invoiceHeader, bool isPreview)
        {
            Guid documentGuid = Guid.NewGuid();
            var excel = new MSExcel();
            string excelPath = ConfigurationManager.AppSettings["ExcelPath"];
            string templatePath = ConfigurationManager.AppSettings["ExcelPathTemplates"];
            CleanFolder(excelPath);
            //RemoveFile(string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
            var clientAddress = (from ad in invoiceHeader.ClientInformation.Addresses where ad.IsDefault select ad).First();
            var invoiceToPrint = new InvoiceToPrint(invoiceHeader);
            //Based on invoicetype i choose the corresponding file
            if (invoiceHeader.InvoiceType == InvoiceType.A)
            {
                if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.FullDetail)
                {
                    templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["InvoiceA"]);
                }
                else if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.Resumed)
                {
                    templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["InvoiceAr"]);
                }
                else
                {
                    templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["InvoiceAf"]);
                }
            }
            else
            {
                if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.FullDetail)
                {
                    templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["InvoiceB"]);
                }
                else if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.Resumed)
                {
                    templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["InvoiceBr"]);
                }
                else
                {
                    templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["InvoiceBf"]);
                }

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

                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();
                        double retentionTotal = 1 + invoiceHeader.Retentions.Sum(retention => retention.Value/100);

                        #region InvoiceHeader
                        currentWorksheet.Cells["N4"].Value = string.Concat("000",invoiceHeader.SalePoint,"-",zeros,invoiceHeader.InvoiceNumber);
                        currentWorksheet.Cells["P6"].Value = invoiceHeader.Date;
                        currentWorksheet.Cells["B10"].Value = string.Concat(invoiceHeader.Company.Address," ",invoiceHeader.Company.PostalCode);
                        currentWorksheet.Cells["B11"].Value = invoiceHeader.Company.Phone;
                        currentWorksheet.Cells["B12"].Value = invoiceHeader.Company.Email;
                        currentWorksheet.Cells["B15"].Value = string.Concat("Sr/es: ",invoiceHeader.ClientInformation.Name);
                        currentWorksheet.Cells["B16"].Value = string.Concat("Domicilio: ", clientAddress.ToString());
                        currentWorksheet.Cells["B17"].Value = string.Concat("I.V.A.: ", invoiceHeader.ClientInformation.IvaCondition.ToString().Replace("_"," "));
                        currentWorksheet.Cells["L17"].Value = string.Concat(invoiceHeader.ClientInformation.DocumentType.ToString(), ": ",invoiceHeader.ClientInformation.Cuit);
                        currentWorksheet.Cells["B18"].Value = "Condición de Venta: CONTADO"; ///TODO Add the sell condition to the invoice header entity
                        currentWorksheet.Cells["L18"].Value = string.Concat("Cliente Nº: ", invoiceHeader.ClientInformation.ClientNumber.ToString());
                        #endregion
                        #region InvoiceBody
                        
                        int c = 0; // the start position in the excel template for the details
                        if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.FullDetail)
                        {   
                            c = 22;
                            var invoiceDetail = (FullInvoiceBodyDto)invoiceToPrint.InvoiceDetail;
                            
                            foreach (KeyValuePair<string, List<InvoiceBodyDto>> person in invoiceDetail.Items)
                            {
                                //Person Name
                                currentWorksheet.Cells[string.Concat("E" , c)].Value = person.Key.ToUpper();
                                c++;
                                foreach (InvoiceBodyDto practice in person.Value)
                                {
                                     //Practice descripcion
                                    if (practice.Description.Contains("\n"))
                                    {
                                        List<string> descriptionSpecial = practice.Description.Split('\n').ToList();
                                        currentWorksheet.Cells[string.Concat("B", c)].Value = practice.Quantity;
                                        if (invoiceHeader.InvoiceType == InvoiceType.A)
                                        {
                                            currentWorksheet.Cells[string.Concat("N", c)].Value = practice.UnitPrice;
                                            currentWorksheet.Cells[string.Concat("Q", c)].Value = practice.TotalPrice;
                                        }
                                        else
                                        {
                                            currentWorksheet.Cells[string.Concat("N", c)].Value = practice.UnitPrice * retentionTotal;
                                            currentWorksheet.Cells[string.Concat("Q", c)].Value = practice.TotalPrice * retentionTotal;
                                        }
                                        
                                        foreach (var line in descriptionSpecial)
                                        {
                                            currentWorksheet.Cells[string.Concat("E", c)].Value = line;
                                            c++;
                                        }
                                    }
                                    else
                                    {
                                        currentWorksheet.Cells[string.Concat("E", c)].Value = practice.Description;
                                        currentWorksheet.Cells[string.Concat("B", c)].Value = practice.Quantity;
                                        if (invoiceHeader.InvoiceType == InvoiceType.A)
                                        {
                                            currentWorksheet.Cells[string.Concat("N", c)].Value = practice.UnitPrice;
                                            currentWorksheet.Cells[string.Concat("Q", c)].Value = practice.TotalPrice;
                                        }
                                        else
                                        {
                                            var unitPriceB = Math.Round(practice.UnitPrice * retentionTotal, 1);
                                            currentWorksheet.Cells[string.Concat("N", c)].Value = unitPriceB;
                                            currentWorksheet.Cells[string.Concat("Q", c)].Value = unitPriceB * practice.Quantity;
                                        }
                                    }
                                    c++;
                                }
                            }
                        }
                        else if (invoiceToPrint.InvoiceDetailType == InvoiceDetailType.Resumed)
                        {
                            c = 22;// the start position in the excel template for the details
                            var invoiceDetail = (ResumedInvoiceBodyDto)invoiceToPrint.InvoiceDetail;
                            foreach (var practice in invoiceDetail.InvoiceDetails)
                            {
                                currentWorksheet.Cells[string.Concat("B", c)].Value = practice.Quantity;
                                currentWorksheet.Cells[string.Concat("E", c)].Value = practice.Description;
                                if (invoiceHeader.InvoiceType == InvoiceType.A)
                                {
                                    currentWorksheet.Cells[string.Concat("N", c)].Value = practice.UnitPrice;
                                    currentWorksheet.Cells[string.Concat("Q", c)].Value = practice.TotalPrice;
                                }
                                else
                                {
                                    var unitPriceB = Math.Round(practice.UnitPrice*retentionTotal, 1);
                                    currentWorksheet.Cells[string.Concat("N", c)].Value = unitPriceB;
                                    currentWorksheet.Cells[string.Concat("Q", c)].Value = unitPriceB * practice.Quantity;
                                }
                                c+=1;
                            }
                        }
                        else
                        {
                            c = 22;
                            var invoiceDetail  = (FreeInvoiceBodyDto)invoiceToPrint.InvoiceDetail;

                            currentWorksheet.Cells[string.Concat("C", c)].Value = invoiceDetail.Description;
                            if (invoiceHeader.InvoiceType == InvoiceType.A)
                            {
                                currentWorksheet.Cells[string.Concat("N", c)].Value = invoiceDetail.UnitPrice;
                                currentWorksheet.Cells[string.Concat("Q", c)].Value = invoiceDetail.TotalPrice;
                            }
                            else
                            {
                                currentWorksheet.Cells[string.Concat("N", c)].Value = ((InvoiceFullFooterDto)invoiceToPrint.InvoiceFooter).Total;
                                currentWorksheet.Cells[string.Concat("Q", c)].Value = ((InvoiceFullFooterDto)invoiceToPrint.InvoiceFooter).Total;
                            }
                            currentWorksheet.Cells[string.Concat("N", c)].Value = invoiceDetail.UnitPrice;
                            currentWorksheet.Cells[string.Concat("Q", c)].Value = invoiceDetail.TotalPrice;
                        }
                        #endregion
                        #region Ivoice Footer
                        
                        var footer = (InvoiceFullFooterDto)invoiceToPrint.InvoiceFooter;
                        if (footer.InvoiceType == InvoiceType.A)
                        {
                            c=63;
                            currentWorksheet.Cells["Q60"].Value = footer.SubTotal;
                            currentWorksheet.Cells["Q71"].Value = footer.Total;
                            foreach (var retention in footer.InvoiceRetentions)
                            {
                                currentWorksheet.Cells[string.Concat("N", c)].Value = retention.Name;//string.Concat(retention.Name," (",retention.Value,"%)");
                                currentWorksheet.Cells[string.Concat("Q",c)].Value = retention.RetentionValue;
                                c++;
                            }
                            currentWorksheet.Cells["B73"].Value = string.Concat("CAE: ", invoiceHeader.CAE);
                        }
                        else
                        {
                            currentWorksheet.Cells["Q60"].Value = footer.Total;
                            currentWorksheet.Cells["B65"].Value = string.Concat("CAE: ", invoiceHeader.CAE);
                        }
                       

                        #endregion
                     
                        package.Save();
                        if (isPreview)
                        {
                            Process.Start(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
                        }
                        else
                        {
                            excel.Open(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
                            excel.Print();
                            excel.Close();
                            excel.Quit();
                            RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
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

        private static void CleanFolder(string folderPath)
        {
            var downloadedMessageInfo = new DirectoryInfo(folderPath);

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
