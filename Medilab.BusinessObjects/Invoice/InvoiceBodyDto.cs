
namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceBodyDto
    {
        public int Quantity { set; get; }
        public string Description { set; get; }
        public double UnitPrice { set; get; }
        public double TotalPrice { set; get; }
    }
}
