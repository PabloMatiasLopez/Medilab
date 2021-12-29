using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.UserInterface.PrintUtilities;
using InvoiceHeader = Medilab.BusinessObjects.Invoice.InvoiceHeader;
using Medilab.BusinessObjects.DTOs;
using Medilab.UserInterface.Properties;

namespace Medilab.UserInterface.Invoice
{
    public partial class FrmInvoiceList : Form
    {
        #region Events
        private void btnSearchByInvoice_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInvoiceNumber.Text))
            {
                SearchByInvoiceNumber(txtInvoiceNumber.Text, cbInvoiceType.Text);
            }
        }
        private void txtInvoiceNumber_TextChanged(object sender, EventArgs e)
        {
            btnSearchByInvoice.Enabled = !string.IsNullOrEmpty(txtInvoiceNumber.Text);
        }
        private void btnCombinedSearch_Click(object sender, EventArgs e)
        {
            FilterList();
        }
        private void gvInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var invoiceId = (Guid) gvInvoice[0, e.RowIndex].Value;
            var invoiceEditForm = new FrmInvoiceEdit(invoiceId);
            var result = invoiceEditForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                FilterList();
            }
        }
        private void gvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = btnPreview.Enabled = gvInvoice.SelectedRows.Count > 0;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var invoiceId = Guid.Parse(gvInvoice.SelectedRows[0].Cells[0].Value.ToString());
            var printer = new Printer();
            printer.PrintInvoice(invoiceId);
            if(chkIncludeInvoiceDetail.Checked)
            {
                PrintDetails.PrintInvoiceDetails(InvoiceHeader.GetInvoiceById(invoiceId));
            }
        }
        private void txtClientNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        #endregion
        #region Methods
        public FrmInvoiceList()
        {
            InitializeComponent();
            LoadDropdowns();
            PresetDatePickers();
            FilterList();
        }
        private void LoadDropdowns()
        {
            //Companies   
            cbClient.Items.Clear();
            
            cbClient.DataSource = null;
            var companies = Client.GetClients().ToList();
            cbClient.DataSource = companies;
            
            //invoice status
            cbStatus.Items.Clear();
            var invoiceStatus = EnumUtils.GetDisplayNames(Enum.GetNames(typeof(InvoiceStatus))).ToList();
            invoiceStatus.Insert(0,Resources.StatusFilterAll);
            cbStatus.Items.AddRange(invoiceStatus.ToArray());
            cbStatus.Text = Resources.StatusFilterAll;

            //invoice types
            cbInvoiceType.Items.Clear();
            cbInvoiceType.Items.AddRange(new object[]{"A","B","C"});
            cbInvoiceType.Text = "A";
            
        }
        private void PresetDatePickers()
        {
            //Defines a preset 3 month time period
            dtmDateTo.Value = DateTime.Now;
            dtpDateFrom.Value = DateTime.Now.AddMonths(-3);
        }
        private void SearchByInvoiceNumber(string invoiceNumber, string type)
        {
            var headers = new List<InvoiceHeaderDto>();
            var invoiceType = (InvoiceType) Enum.Parse(typeof (InvoiceType), type, true);
            var invoiceHeader = InvoiceHeader.GetInvoiceByNumber(invoiceNumber, invoiceType);
            if (invoiceHeader != null)
            {
                headers.Add(invoiceHeader);
            }
            BindGrid(headers);
        }
        private void CombinedSearch(Guid clientId, string clientNumber, int invoiceStatus, DateTime dateFrom, DateTime dateTo)
        {
            List<InvoiceHeaderDto> invoiceHeaderList;
            if (!string.IsNullOrWhiteSpace(clientNumber))
            {
                int number;
                Int32.TryParse(clientNumber, out number);
                invoiceHeaderList = InvoiceHeader.GetInvoiceList(number, invoiceStatus, dateFrom, dateTo);
            }
            else
            {
                invoiceHeaderList = InvoiceHeader.GetInvoiceList(clientId, invoiceStatus, dateFrom, dateTo);
            }

            if (invoiceHeaderList.Count > 0)
            {
                BindGrid(invoiceHeaderList);
            }
        }
        private void BindGrid(List<InvoiceHeaderDto> invoiceHeader)
        {
            gvInvoice.AutoGenerateColumns = false;
            gvInvoice.DataSource = invoiceHeader;
            gvInvoice.Visible = true;
        }


        private void FilterList()
        {
            gvInvoice.DataSource = null;
            gvInvoice.Refresh();
            txtInvoiceNumber.Text = string.Empty;
            btnSearchByInvoice.Enabled = false;
            int status = 0;
            if (cbStatus.SelectedItem.ToString() != Resources.StatusFilterAll)
            {
                status = (int)Enum.Parse(typeof(InvoiceStatus), cbStatus.SelectedItem.ToString().Replace(" ", String.Empty));
            }
            CombinedSearch(((ListItemDto<Guid>)(cbClient.SelectedItem)).Id, txtClientNumber.Text, status, dtpDateFrom.Value,
                dtmDateTo.Value);
        }
        
        #endregion

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var invoiceId = Guid.Parse(gvInvoice.SelectedRows[0].Cells[0].Value.ToString());
            var printer = new Printer();
            printer.PrintInvoice(invoiceId, true);
        }

        private void cbClient_OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterList();
            }
        }
    }
}
