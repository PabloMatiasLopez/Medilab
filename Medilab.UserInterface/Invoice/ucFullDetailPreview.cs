using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.Invoice
{
    public partial class ucFullDetailPreview : UserControl, IDetailPreview
    {
        private IDetailsDisplayable _details;

        public ucFullDetailPreview(IDetailsDisplayable details)
        {
            _details = details;
            InitializeComponent();
        }

        private void ucFullDetailPreview_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
        }

        public void LoadPreview()
        {
            LoadItemsToShow((FullInvoiceDetails) _details);
        }

        private void LoadItemsToShow(FullInvoiceDetails itemsDetails)
        {
            var top = Top;
            var left = Left + 5;
            foreach (var fullInvoiceDetail in itemsDetails.Items)
            {
                var itemsPreview = new ucPatientDetailInvoicePreview(fullInvoiceDetail.Key, fullInvoiceDetail.Value);
                itemsPreview.Top = top;
                itemsPreview.Left = left;
                Controls.Add(itemsPreview);
                top = top + itemsPreview.Height;
            }
        }
    }
}
