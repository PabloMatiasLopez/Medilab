using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.PrintUtilities
{
    public class InvoiceBodyResumed : IInvoiceBody
    {
        public List<PrinterMetaData> FillInvoiceBody(IPrintableInvoiceDetail invoiceBody)
        {
            var bodyElements = new List<PrinterMetaData>();
            var dto = (ResumedInvoiceBodyDto) invoiceBody;

            //For the aggregated version or detail 
            const float xpos = 1.7F; //set the initial position
            float ypos = 8.9F; //set the initial position


            foreach (InvoiceBodyDto practice in dto.InvoiceDetails)
            {
                
                //Print in the following line the quatity and the practice name
                var quantity = new PrinterMetaData
                {
                    Data = practice.Quantity.ToString(CultureInfo.InvariantCulture),
                    printFont = new Font("Arial", 9),
                    isBold = false
                };
                quantity.xPos = quantity.UnitConvertion(xpos);
                quantity.yPos = quantity.UnitConvertion(ypos + 0.4F);

                //Print in the following line the practice name
                var practiceToPrint = new PrinterMetaData
                {
                    Data = practice.Description,
                    printFont = new Font("Arial", 9),
                    isBold = false
                };
                practiceToPrint.xPos = practiceToPrint.UnitConvertion(xpos + 1.25F);
                practiceToPrint.yPos = practiceToPrint.UnitConvertion(ypos + 0.4F);

                //Print the unit price
                var unitPrice = new PrinterMetaData
                {
                    Data = practice.UnitPrice.ToString(CultureInfo.CurrentCulture),
                    printFont = new Font("Arial", 9),
                    isBold = true
                };
                unitPrice.xPos = unitPrice.UnitConvertion(xpos + 14.3F);
                unitPrice.yPos = unitPrice.UnitConvertion(ypos + 0.4F);

                //Print the unit price
                var totalPrice = new PrinterMetaData
                {
                    Data = practice.TotalPrice.ToString(CultureInfo.CurrentCulture),
                    printFont = new Font("Arial", 9),
                    isBold = true
                };
                totalPrice.xPos = totalPrice.UnitConvertion(xpos + 17.8F);
                totalPrice.yPos = totalPrice.UnitConvertion(ypos + 0.4F);


                //add to the printable list of invoice body elements
                bodyElements.Add(quantity);
                bodyElements.Add(practiceToPrint);
                bodyElements.Add(unitPrice);
                bodyElements.Add(totalPrice);
                ypos += 0.4F;
            }
            
            return bodyElements;
        }
     }
 }

