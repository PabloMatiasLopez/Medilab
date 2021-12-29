using System;
using System.Text;
using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.Invoice
{
    public partial class ucFreeTextPreview : UserControl, IDetailPreview
    {
        public string FreeDetail { get; private set; }
        private IDetailsDisplayable _details;
        public ucFreeTextPreview(IDetailsDisplayable details)
        {
            _details = details;
            InitializeComponent();
        }

        private void ucFreeTextPreview_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
        }

        public void LoadPreview()
        {
            LoadItemsToShow((FreeInvoiceDetails) _details);
        }

        private void LoadItemsToShow(FreeInvoiceDetails itemsDetails)
        {
            var text = new StringBuilder();
            text.Append(itemsDetails.Item.Quantity).Append("\t");
            text.Append(itemsDetails.Item.Description).Append("\t");
            text.Append(itemsDetails.Item.UnitPrice.ToString("C2")).Append("\t");
            text.Append(itemsDetails.Item.TotalPrice.ToString("C2")).Append("\t");
            txtInvoiceText.Text = text.ToString();
            FreeDetail = text.ToString();
        }
    }
}
