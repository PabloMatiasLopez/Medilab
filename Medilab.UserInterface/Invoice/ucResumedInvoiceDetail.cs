using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.Invoice
{
    public partial class ucResumedInvoiceDetail : UserControl, IDetailPreview
    {
        private IDetailsDisplayable _details;
        public ucResumedInvoiceDetail(IDetailsDisplayable details)
        {
            _details = details;
            InitializeComponent();
        }

        public void LoadPreview()
        {
            LoadItemsToShow((ResumeInvoiceDetails)_details);
        }
        private void LoadItemsToShow(ResumeInvoiceDetails itemsDetails)
        {
            gvItems.AutoGenerateColumns = false;
            gvItems.DataSource = itemsDetails.Items;
            gvItems.AllowUserToResizeRows = false;
            gvItems.AllowUserToResizeColumns = false;
            gvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            gvItems.Height = GetHeight();
            Height = gvItems.Height + 50;
        }

        private int GetHeight()
        {
            const int maxHeight = 200;
            int height = Utilities.UiUtils.GetDataGridViewHeight(gvItems);
            if (height > maxHeight)
            {
                return maxHeight;
            }
            return height;
        }
    }
}
