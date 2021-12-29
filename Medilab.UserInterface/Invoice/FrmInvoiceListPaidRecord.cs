using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.UserInterface.Receipt;
using InvoiceHeader = Medilab.BusinessObjects.Invoice.InvoiceHeader;
using Medilab.BusinessObjects.DTOs;

namespace Medilab.UserInterface.Invoice
{
    public partial class FrmInvoiceListPaidRecord : Form
    {
        #region Properties

        private List<ClientListItemDto> _clientList;
        #endregion

        #region Events

        private void txtInvoiceNumber_TextChanged_1(object sender, EventArgs e)
        {
            btnSearchByInvoice.Enabled = !string.IsNullOrEmpty(txtInvoiceNumber.Text);
        }
        private void btnSearchByInvoice_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInvoiceNumber.Text))
            {
                SearchByInvoiceNumber(txtInvoiceNumber.Text);
            }
        }
        private void btnCombinedSearch_Click_1(object sender, EventArgs e)
        {
            FilterList();
        }
        private void btnPaymentRegistration_Click(object sender, EventArgs e)
         {
             RegisterPayment(false);
         }
        private void btnRegisterPaymentExistent_Click(object sender, EventArgs e)
        {
            RegisterPayment(true);
        }
        private void txtClientNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (gvInvoice.DataSource != null)
            {
                foreach (DataGridViewRow row in gvInvoice.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells[1]).Value = chkSelectAll.Checked;
                }
            }
        }
        #endregion

        #region Methods
      
        public FrmInvoiceListPaidRecord()
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
        private void SearchByInvoiceNumber(string invoiceNumber)
        {
            var headers = new List<PendingToPayDto>();
            var invoiceHeader = InvoiceHeader.GetInvoiceByNumberPending(invoiceNumber);
            if (invoiceHeader != null)
            {
                headers.Add(invoiceHeader);
                BindGrid(headers);
            }
        }
        private void CombinedSearch(Guid clientId, string clientNumber, DateTime dateFrom, DateTime dateTo)
        {
            var invoiceHeaderList = new List<PendingToPayDto>();
            if (!string.IsNullOrWhiteSpace(clientNumber))
            {
                int number;
                Int32.TryParse(clientNumber, out number);
                var selectedClient = _clientList.FirstOrDefault(client => client.Number == number);
                if (selectedClient != null)
                {
                    cbClient.SelectedIndex = _clientList.IndexOf(selectedClient);
                    clientId = selectedClient.Id;
                }
            }
            invoiceHeaderList = InvoiceHeader.GetInvoiceList(clientId, dateFrom, dateTo);
            var debitNotes = BusinessObjects.DebitCreditNote.DebitNote.GetDebitNoteToPayList(clientId, dateFrom, dateTo);
            if (debitNotes.Count > 0)
            {
                invoiceHeaderList.AddRange(debitNotes);
            }
            BindGrid(invoiceHeaderList);
        }
        private void BindGrid(List<PendingToPayDto> invoiceHeader)
        {
            gvInvoice.AutoGenerateColumns = false;
            gvInvoice.DataSource = invoiceHeader;
            gvInvoice.Visible = true;
            chkSelectAll.Checked = false;
        }
        private void FilterList()
        {
            gvInvoice.DataSource = null;
            gvInvoice.Refresh();
            txtInvoiceNumber.Text = string.Empty;
            btnSearchByInvoice.Enabled = false;

            CombinedSearch(((ClientListItemDto)(cbClient.SelectedItem)).Id, txtClientNumber.Text, dtpDateFrom.Value,
                dtmDateTo.Value);
        }
        private void RegisterPayment(bool alreadyExistReceip)
        {
            if (gvInvoice.DataSource != null)
            {
                var itemsToPay = new List<PendingToPayDto>();
                foreach (DataGridViewRow row in gvInvoice.Rows)
                {
                    var selected = (DataGridViewCheckBoxCell)row.Cells[1];
                    if (selected.Value != null)
                    {
                        if ((bool)selected.Value)
                        {
                            var pendingItem = new PendingToPayDto
                            {
                                Id = (Guid)gvInvoice[0, row.Index].Value,
                                Number = (string)gvInvoice[3, row.Index].Value,
                                CreationDate = (DateTime)gvInvoice[4, row.Index].Value,
                                VoucherType = (BusinessObjects.CAE.Enums.TipoComprobante)Enum.Parse(typeof(BusinessObjects.CAE.Enums.TipoComprobante),
                                            gvInvoice[5, row.Index].Value.ToString().Replace(" ","_")),
                                Total = (double)gvInvoice[8, row.Index].Value,
                                Balance = (double)gvInvoice[9, row.Index].Value,
                            };
                            if (pendingItem.VoucherType == BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_A || 
                                pendingItem.VoucherType == BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_B)
                            {
                                pendingItem.PaymentAmount = pendingItem.Total;
                            }
                            itemsToPay.Add(pendingItem);
                        }
                    }
                }
                if(itemsToPay.Count > 0)
                {
                    var frmNewReceipt =  new FrmCreateReceipt(itemsToPay, Client.GetClient(((ClientListItemDto)(cbClient.SelectedItem)).Id), !alreadyExistReceip);
                    frmNewReceipt.StartPosition = FormStartPosition.CenterParent;
                    frmNewReceipt.ShowDialog(this);
                    FilterList();
                }

            }
        }
       
        #endregion
    }
}


