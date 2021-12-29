
using System.Collections.Generic;

namespace Medilab.BusinessObjects.Invoice
{
    public class ResumedInvoiceBodyDto : IPrintableInvoiceDetail
    {
        public List<InvoiceBodyDto> InvoiceDetails { set; get; }

        //public IPrintableInvoiceDetail GetInvoiceItems()
        //{
        //    return new ResumedInvoiceBodyDto();
        //}
         public IPrintableInvoiceDetail GetInvoiceItems()
        {
            var fakeList = new List<InvoiceBodyDto>();
            for (int i = 1; i < 12; i++)
             {
                 var bodyDto = new InvoiceBodyDto
                 {
                     Quantity = i,
                     Description = "Esta es una descripcion de ejemplo",
                     UnitPrice = 12.5,
                     TotalPrice = (12.5*i)
                 };

                 fakeList.Add(bodyDto);
             }
            var fakedto = new ResumedInvoiceBodyDto {InvoiceDetails = fakeList};
             return fakedto;
        }
        
    }
}
