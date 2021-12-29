using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.PrintUtilities
{
    public class InvoiceBodyFree : IInvoiceBody
    {
        public List<PrinterMetaData> FillInvoiceBody(IPrintableInvoiceDetail invoiceBody)
        {
            var bodyElements = new List<PrinterMetaData>();
            var dto = (FreeInvoiceBodyDto)invoiceBody;

            //For the aggregated version or detail 
            const float xpos = 1.7F; //set the initial position
            const float ypos = 8.9F; //set the initial position

            
            //Print in the following line the quatity and the practice name
            var quantity = new PrinterMetaData
            {
                Data = dto.Quantity.ToString(CultureInfo.InvariantCulture),
                printFont = new Font("Arial", 9),
                isBold = false
            };
            quantity.xPos = quantity.UnitConvertion(xpos);
            quantity.yPos = quantity.UnitConvertion(ypos);

            //Print in the following line the Description
            var description = new PrinterMetaData
            {
                Data = dto.Description,
                printFont = new Font("Arial", 9),
                isBold = false
            };
            description.xPos = description.UnitConvertion(xpos + 1.25F);
            description.yPos = description.UnitConvertion(ypos );

            //Print the unit price
            var unitPrice = new PrinterMetaData
            {
                Data = dto.UnitPrice.ToString(CultureInfo.CurrentCulture),
                printFont = new Font("Arial", 9),
                isBold = true
            };

            unitPrice.xPos = unitPrice.UnitConvertion(xpos + 14.3F);
            unitPrice.yPos = unitPrice.UnitConvertion(ypos);

            //Print the unit price
            var totalPrice = new PrinterMetaData
            {
                Data = dto.TotalPrice.ToString(CultureInfo.CurrentCulture),
                printFont = new Font("Arial", 9),
                isBold = true
            };
            totalPrice.xPos = totalPrice.UnitConvertion(xpos + 17.8F);
            totalPrice.yPos = totalPrice.UnitConvertion(ypos);

            //add to the printable list of invoice body elements
            bodyElements.Add(quantity);
            bodyElements.Add(description);
            bodyElements.Add(unitPrice);
            bodyElements.Add(totalPrice);
            return bodyElements; 
        }
    }
}
