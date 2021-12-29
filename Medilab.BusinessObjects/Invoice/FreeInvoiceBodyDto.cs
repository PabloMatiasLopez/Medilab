
namespace Medilab.BusinessObjects.Invoice
{
    public class FreeInvoiceBodyDto : InvoiceBodyDto, IPrintableInvoiceDetail
    {
        //public IPrintableInvoiceDetail GetInvoiceItems()
        //{
        //    return new FreeInvoiceBodyDto();
        //}
        
        public IPrintableInvoiceDetail GetInvoiceItems()
        {
            var dto = new FreeInvoiceBodyDto
            {
                Quantity = 1,
                Description = "Esta es una descripcion de ejemplo",
                UnitPrice = 12.5,
                TotalPrice = 12.5
            };
            return dto;
        }
    }
}
