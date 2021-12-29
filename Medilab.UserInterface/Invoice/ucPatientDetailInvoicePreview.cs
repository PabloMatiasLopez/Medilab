using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.Invoice
{
    public partial class ucPatientDetailInvoicePreview : UserControl
    {
        private string _patientName;
        private List<InvoiceBodyDto> _items;
        public ucPatientDetailInvoicePreview(string patientName, List<InvoiceBodyDto> items )
        {
            _patientName = patientName;
            _items = items;
            InitializeComponent();
        }

        private void ucPatientDetailInvoicePreview_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadPatientName();
            LoadItems();
            ResizeControl();
        }

        private void LoadPatientName()
        {
            lblName.Text = _patientName;
        }

        private void LoadItems()
        {
            gvItems.AutoGenerateColumns = false;
            gvItems.DataSource = _items;
        }

        private void ResizeControl()
        {
            gvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            gvItems.AllowUserToResizeRows = false;
            gvItems.Height =  Utilities.UiUtils.GetDataGridViewHeight(gvItems);
            Height = lblName.Height + gvItems.Height + 50;
        }
    }
}
