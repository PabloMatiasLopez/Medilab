
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Receipt;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Excel;
using Medilab.UserInterface.Properties;

namespace Medilab.UserInterface.Receipt
{
    public partial class FrmReceiptList : Form
    {
        #region Properties

        private List<ClientListItemDto> _clientList;
        #endregion

        #region Events
        private void btnSearchByReceipt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceiptNumber.Text))
            {
                SearchByReceiptNumber(txtReceiptNumber.Text);
            }
        }
        private void btnSearchByInvoice_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInvoiceNumber.Text))
            {
                SearchByInvoiceNumber(txtInvoiceNumber.Text);
            }
        }
        private void txtReceiptNumber_TextChanged(object sender, EventArgs e)
        {
            btnSearchByReceipt.Enabled = !string.IsNullOrEmpty(txtReceiptNumber.Text);
        }
        private void txtInvoiceNumber_TextChanged(object sender, EventArgs e)
        {
            btnSearchByInvoice.Enabled = !string.IsNullOrEmpty(txtInvoiceNumber.Text);
        }
        private void btnCombinedSearch_Click(object sender, EventArgs e)
        {
            FilterList();
        }
        private void gvReceipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvReceipt.CurrentRow != null && e.RowIndex != -1)
            {
                var receiptId = ((ReceiptDto)gvReceipt.CurrentRow.DataBoundItem).ReceiptId; 
                var receiptViewForm = new FrmCreateReceipt(receiptId);
                receiptViewForm.ShowDialog(this);
            }
        }
        private void gvReceipt_SelectionChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = btnDelete.Enabled = gvReceipt.SelectedRows.Count > 0;
        }
        private void txtClientNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var receiptId = Guid.Parse(gvReceipt.SelectedRows[0].Cells[0].Value.ToString());
            ReceiptToPrintDto dto = BusinessObjects.Receipt.Receipt.GetReceiptToPrint(receiptId);
            ReceiptExcelHandler.GenerateExcel(dto);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        #endregion

        #region Methods
        public FrmReceiptList()
        {
            InitializeComponent();
            LoadDropdowns();
            PresetDatePickers();
            FilterList();
            btnDelete.Visible  = Security.IsAuthozired(SecurityAreas.Administration);
        }
        private void LoadDropdowns()
        {
            cbClient.Items.Clear();
            cbClient.DataSource = null;
            _clientList = Client.GetClientsWithNumer().ToList();
            var companies = _clientList;
            cbClient.DataSource = companies;
        }
        private void PresetDatePickers()
        {
            //Defines a preset 3 month time period
            dtmDateTo.Value = DateTime.Now;
            dtpDateFrom.Value = DateTime.Now.AddMonths(-3);
        }
        private void SearchByReceiptNumber(string receiptNumber)
        {
            var receipts = new List<ReceiptDto>();
            var receipt = BusinessObjects.Receipt.Receipt.GetReceiptByNumber(receiptNumber);
            if (receipt != null)
            {
                receipts.Add(receipt);
                BindGrid(receipts);
            }
        }
        private void SearchByInvoiceNumber(string invoiceNumber)
        {
            var receiptList = BusinessObjects.Receipt.Receipt.GetReceiptByInvoiceNumber(invoiceNumber);
            if (receiptList != null)
            {
                BindGrid(receiptList);
            }
        }
        private void CombinedSearch(Guid clientId, string clientNumber, DateTime dateFrom, DateTime dateTo)
        {
            List<ReceiptDto> invoiceHeaderList;
            if (!string.IsNullOrWhiteSpace(clientNumber))
            {
                int number;
                Int32.TryParse(clientNumber, out number);
                var selectedClient = _clientList.FirstOrDefault(client => client.Number == number);
                if (selectedClient == null)
                {
                    invoiceHeaderList = new List<ReceiptDto>();
                }
                else
                {
                    cbClient.SelectedIndex = _clientList.IndexOf(selectedClient);
                    invoiceHeaderList = BusinessObjects.Receipt.Receipt.GetReceiptList(selectedClient.Id, dateFrom, dateTo);
                }
            }
            else
            {
                invoiceHeaderList = BusinessObjects.Receipt.Receipt.GetReceiptList(clientId, dateFrom, dateTo);
            }
            BindGrid(invoiceHeaderList);
        }
        private void BindGrid(List<ReceiptDto> receiptHeader)
        {
            gvReceipt.AutoGenerateColumns = false;
            gvReceipt.DataSource = receiptHeader;
            gvReceipt.Visible = true;
        }
        private void FilterList()
        {
            gvReceipt.DataSource = null;
            gvReceipt.Refresh();
            txtReceiptNumber.Text = string.Empty;
            btnSearchByReceipt.Enabled = false;
            CombinedSearch(((ClientListItemDto)(cbClient.SelectedItem)).Id, txtClientNumber.Text, dtpDateFrom.Value.Date, dtmDateTo.Value.Date.AddDays(1).AddSeconds(-1));
        }
        private void Delete()
        {
            var clientName = gvReceipt.SelectedRows[0].Cells[1].Value.ToString();
            var number = gvReceipt.SelectedRows[0].Cells[2].Value.ToString();
            var date = gvReceipt.SelectedRows[0].Cells[3].Value.ToString();
            var import = double.Parse(gvReceipt.SelectedRows[0].Cells[4].Value.ToString()).ToString("C2");
            var receiptInformation = string.Format("Cliente: {0}, Número: {1}, Fecha: {2}, Importe: {3}", clientName, number, date, import);
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText + Environment.NewLine + receiptInformation, 
                Resources.ConfirmationDialogDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rta == System.Windows.Forms.DialogResult.Yes)
            {
                var receiptId = Guid.Parse(gvReceipt.SelectedRows[0].Cells[0].Value.ToString());
                BusinessObjects.Receipt.Receipt.DeleteReceipt(receiptId);
                FilterList();
            }
        }
        #endregion
    }
}
