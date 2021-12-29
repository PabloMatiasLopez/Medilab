using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Receipt;
using Medilab.BusinessObjects.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Medilab.UserInterface.Excel
{
    public class ReceiptExcelHandler
    {
        public static void GenerateExcel(ReceiptToPrintDto receiptDto)
        {
            #region SheetSpace
            const int totalAvailableRows = 53;

            int effectiveUsedRows = receiptDto.Invoices.Count + receiptDto.Payments.Count + 15;//represent the addition between the invoice total and the footer and the grids separations
           
            #endregion
            Guid documentGuid = Guid.NewGuid();
            MSExcel excel = new MSExcel();
            string excelPath = ConfigurationManager.AppSettings["ExcelPath"];
            string templatePath = ConfigurationManager.AppSettings["ExcelPathTemplates"];
            RemoveFile(string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
            var clientAddress = (from ad in receiptDto.Client.Addresses where ad.IsDefault select ad).First();

            //Based on invoicetype i choose the corresponding file

            templatePath = string.Concat(templatePath, ConfigurationManager.AppSettings["Receipt"]);

            File.Copy(templatePath,
                         string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));

            var template =
                new FileInfo(string.Concat(excelPath, documentGuid.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));

            // Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        #region ReceiptHeader
                        currentWorksheet.Cells["I4"].Value = receiptDto.ReceiptNumber;//string.Concat("000",invoiceHeader.SalePoint,"-",zeros,invoiceHeader.InvoiceNumber);
                        currentWorksheet.Cells["I6"].Value = receiptDto.Date;
                        currentWorksheet.Cells["B9"].Value = string.Concat(receiptDto.CompanyInfo.Address, " ", receiptDto.CompanyInfo.PostalCode);
                        currentWorksheet.Cells["B10"].Value = receiptDto.CompanyInfo.Phone;
                        currentWorksheet.Cells["B11"].Value = receiptDto.CompanyInfo.Email;
                        currentWorksheet.Cells["B16"].Value = string.Concat("Sr/es: ", receiptDto.Client.Name);
                        currentWorksheet.Cells["B18"].Value = string.Concat("Domicilio: ", clientAddress.ToString());
                        currentWorksheet.Cells["B20"].Value = string.Concat("I.V.A.: ", receiptDto.Client.IvaCondition.ToString().Replace("_", " "));
                        currentWorksheet.Cells["G20"].Value = string.Concat(receiptDto.Client.DocumentType.ToString(), ": ", receiptDto.Client.Cuit);

                        currentWorksheet.Cells["I20"].Value = string.Concat("Cliente Nº: ", receiptDto.Client.ClientNumber.ToString());
                        #endregion

                        #region Sheet number calculation
                        if (totalAvailableRows < effectiveUsedRows)
                        {
                            //Calculate de number of spreadsheets to be use in the excel file

                            double obj = (double)effectiveUsedRows / totalAvailableRows;
                            int sheetNumber = (int)Math.Ceiling(obj);
                            for (int i = 1; i < sheetNumber; i++)
                            {
                                workBook.Worksheets.Add(i.ToString(), workBook.Worksheets[1]);
                            }
                        }

                       
                        // Get the first worksheet
                        currentWorksheet = workBook.Worksheets.First();
                        #endregion

                        #region Invoices

                        //indicate in which worksheet place the information
                        int worksheetNumber = 1;
                        //indicate the starting point on each sheet and indicates when to change the sheet
                        int invoiceCounter = 25;
                        //counts the number of iterations made
                        int iterationCounter = 1;
                         string formedRange = string.Empty;


                        workBook.Worksheets[2].Cells["B30:J31"].Copy(workBook.Worksheets[worksheetNumber].Cells["B23:J24"]);
                        double totalInvoices = 0;
                        foreach (var invoice in receiptDto.Invoices)
                        {
                            if (invoiceCounter > 73)
                            {
                                if(worksheetNumber == 1)
                                {
                                    //the second page is occupied with the elements to create the differents section of the receipt
                                    worksheetNumber+=2;
                                }
                                else 
                                {
                                    worksheetNumber++;
                                }
                                invoiceCounter = 23;
                            }

                            formedRange = string.Concat("B", invoiceCounter, ":", "J", invoiceCounter);
                            //copy de row format based on the position the final row has an special format
                            if (receiptDto.Invoices.Count() > iterationCounter)
                            {
                                //common row
                             
                                workBook.Worksheets[2].Cells["B1:J1"].Copy(workBook.Worksheets[worksheetNumber].Cells[formedRange]);
                            }
                            else
                            {
                                //final row
                                workBook.Worksheets[2].Cells["B3:J3"].Copy(workBook.Worksheets[worksheetNumber].Cells[formedRange]);
                            }
                            //information binding
                            var docuemntTypeToDisplay = string.Empty;
                            switch (invoice.DocumentType)
                            {
                                case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.FACTURAS_A:
                                    docuemntTypeToDisplay = "Factura A";
                                    break;
                                case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_A:
                                    docuemntTypeToDisplay = "Nota Débito A";
                                    break;
                                case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.FACTURAS_B:
                                    docuemntTypeToDisplay = "Factura B";
                                    break;
                                case Medilab.BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_B:
                                    docuemntTypeToDisplay = "Nota Débito A";
                                    break;
                                default:
                                    docuemntTypeToDisplay = string.Empty;
                                    break;
                            }
                            workBook.Worksheets[worksheetNumber].Cells["B" + invoiceCounter].Value = invoice.InvoiceDate.ToString("dd/MM/yy");
                            workBook.Worksheets[worksheetNumber].Cells["D" + invoiceCounter].Value = docuemntTypeToDisplay; //TODO: check with nico not only invoices in this list
                            workBook.Worksheets[worksheetNumber].Cells["F" + invoiceCounter].Value = invoice.InvoiceNumberDisplay;
                            workBook.Worksheets[worksheetNumber].Cells["J" + invoiceCounter].Value = invoice.Total;
                            totalInvoices += invoice.Total;
                            invoiceCounter++;
                            iterationCounter++;
                        }
                        //copy the format of the total of invoices
                        workBook.Worksheets[2].Cells["H6:J6"].Copy(workBook.Worksheets[worksheetNumber].Cells[string.Concat("H", invoiceCounter, ":", "J", invoiceCounter)]);
                        // total data binding
                        workBook.Worksheets[worksheetNumber].Cells["J" + invoiceCounter].Value = totalInvoices;
                      

                        #endregion

                        #region Payments
                        //leave one empty row and then paste the payments grids on the second row position
                        invoiceCounter += 2;
                        if (invoiceCounter > 73)
                        {
                            if (worksheetNumber == 1)
                            {
                                //the second page is occupied with the elements to create the differents section of the receipt
                                worksheetNumber += 2;
                            }
                            else
                            {
                                worksheetNumber++;
                            }
                            invoiceCounter = 23;
                        }

                        //copy the header of the payments grid
                        workBook.Worksheets[2].Cells["B8:J9"].Copy(workBook.Worksheets[worksheetNumber].Cells[string.Concat("B", invoiceCounter, ":", "J", invoiceCounter + 1)]);
                        //increment the counter in order to start inserting the grid content
                        invoiceCounter += 2;
                        iterationCounter = 1;
                        foreach (var payment in receiptDto.Payments)
                        {
                            if (invoiceCounter > 73)
                            {
                                if (worksheetNumber == 1)
                                {
                                    //the second page is occupied with the elements to create the differents section of the receipt
                                    worksheetNumber += 2;
                                }
                                else
                                {
                                    worksheetNumber++;
                                }
                                invoiceCounter = 23;
                            }
                            formedRange = string.Concat("B", invoiceCounter, ":", "J", invoiceCounter);
                            if (receiptDto.Payments.Count() > iterationCounter)
                            {
                                workBook.Worksheets[2].Cells["B13:J13"].Copy(workBook.Worksheets[worksheetNumber].Cells[formedRange]);
                            }
                            else
                            {
                                workBook.Worksheets[2].Cells["B15:J15"].Copy(workBook.Worksheets[worksheetNumber].Cells[formedRange]);
                            }
                            
                            string description = string.Empty;
                           
                            if (payment.PaymentType == "Transferencia Electrónica")
                            {
                                description = "TRANSFERENCIA";
                            }
                            else if (payment.PaymentType.Contains("Retenci"))
                            {
                                description = "RETENCION";
                            }
                            else if (payment.PaymentType == "Nota de Crédito")
                            {
                                description = "N. CRED.";
                            }
                            else
                            {

                                description = payment.PaymentType.ToUpper();
                            }

                            workBook.Worksheets[worksheetNumber].Cells["B" + invoiceCounter].Value = description;
                            workBook.Worksheets[worksheetNumber].Cells["D" + invoiceCounter].Value = payment.PaymentInformationToDisplay;
                            workBook.Worksheets[worksheetNumber].Cells["J" + invoiceCounter].Value = payment.Import;
                          


                            invoiceCounter++;
                            iterationCounter++;
                        }
                        //payments footeer
                        if (invoiceCounter > 73)
                        {
                            if (worksheetNumber == 1)
                            {
                                //the second page is occupied with the elements to create the differents section of the receipt
                                worksheetNumber += 2;
                            }
                            else
                            {
                                worksheetNumber++;
                            }
                            invoiceCounter = 23;
                        }
                        workBook.Worksheets[2].Cells["H34:J34"].Copy(workBook.Worksheets[worksheetNumber].Cells[string.Concat("H", invoiceCounter, ":", "J", invoiceCounter)]);
                        workBook.Worksheets[worksheetNumber].Cells["J" + invoiceCounter].Value = receiptDto.Total;

                        #endregion
                        
                        #region Footer

                        //leave one empty row and then paste the payments grids on the second row position
                        invoiceCounter += 10;
                        if (invoiceCounter > 73)
                        {
                            if (worksheetNumber == 1)
                            {
                                //the second page is occupied with the elements to create the differents section of the receipt
                                worksheetNumber += 2;
                            }
                            else
                            {
                                worksheetNumber++;
                            }
                            invoiceCounter = 23;
                        }
                        else
                        {
                            invoiceCounter -= 9;
                        }


                        //copy the header of the payments grid
                        workBook.Worksheets[2].Cells["B17:j25"].Copy(workBook.Worksheets[worksheetNumber].Cells[string.Concat("B", invoiceCounter, ":", "J", invoiceCounter + 10)]);
                        //increment the counter in order to start inserting the grid content
                        invoiceCounter++;

                        workBook.Worksheets[worksheetNumber].Cells["B" + invoiceCounter].Value = receiptDto.Notes;
                        workBook.Worksheets[worksheetNumber].Cells["J" + invoiceCounter].Value = totalInvoices;
                        invoiceCounter++;
                        workBook.Worksheets[worksheetNumber].Cells["j" + invoiceCounter].Value = receiptDto.Discount;
                        invoiceCounter++;
                        workBook.Worksheets[worksheetNumber].Cells["J" + invoiceCounter].Value = receiptDto.TotalWithDiscount;
                        invoiceCounter += 5;
                        workBook.Worksheets[worksheetNumber].Cells["I" + invoiceCounter].Value = receiptDto.CreatedBy;

                       
                        
                        
                        #endregion

                        

                        

                        //deletes the utils worksheets
                        package.Workbook.Worksheets.Delete(workBook.Worksheets[2]);
                        
                        //Adds the page number to each page
                        int pageIndicator = 1;
                        foreach (var worksheet in workBook.Worksheets)
                        {
                            worksheet.Cells["J74"].Value = string.Concat(pageIndicator, "/", workBook.Worksheets.Count().ToString());
                            pageIndicator++;

                        }
                        package.Save();

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

        private static void RemoveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}
