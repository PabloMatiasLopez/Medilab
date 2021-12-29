using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Invoice
{
    public partial class FrmInvoicePendingList : Form
    {
        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(((ListItemDto<System.Guid>)(cbClient.SelectedItem)).Id, txtClientNumber.Text);
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
        public FrmInvoicePendingList()
        {
            InitializeComponent();
            LoadDropdowns();
        }
        private void LoadDropdowns()
        {
            //Companies   
            cbClient.Items.Clear();
            cbClient.DataSource = null;
            var companies = Client.GetClients().ToList();
            cbClient.DataSource = companies;
        }
        private void BindGrid(List<InvoiceHeaderDto> invoiceHeader)
        {
            
            gvInvoice.AutoGenerateColumns = false;
            gvInvoice.DataSource = invoiceHeader;
            gvInvoice.Visible = true;
        }
        private void Search(Guid clientId, string clientNumber)
        {
            List<InvoiceHeaderDto> invoiceHeaderList;
            if (!string.IsNullOrWhiteSpace(clientNumber))
            {
                int number;
                Int32.TryParse(clientNumber, out number);
                invoiceHeaderList = InvoiceHeader.GetInvoiceListWithRemainder(number);
            }
            else
            {
                invoiceHeaderList = InvoiceHeader.GetInvoiceListWithRemainder(clientId);
            }
            BindGrid(invoiceHeaderList);

        }
        #endregion
    }
}
