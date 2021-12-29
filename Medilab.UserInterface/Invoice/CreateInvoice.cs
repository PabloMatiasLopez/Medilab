using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using InvoiceFooter = Medilab.BusinessObjects.Invoice.InvoiceFooter;

namespace Medilab.UserInterface.Invoice
{
    public partial class CreateInvoice : Form
    {
        #region Properties
        private Client _client;
        private List<InvoiceDetails> _details;
        private List<InvoiceDetails> _selectedDetails;
        private readonly IInvoiceDetailFactory _detailFactory;
        private readonly IInvoiceHeaderFactory _headerFactory;
        private readonly InvoiceType _invoiceType;
        private InvoiceDisplay _invoiceDisplay;
        private readonly InvoiceProcess _invoiceProcess;
        private IDetailPreview _detailPreview;
        private BindingSource _data;
        #endregion
        public CreateInvoice(InvoiceType invoiceType)
        {
            InitializeComponent();
            _invoiceType = invoiceType;
            _detailFactory = new InvoiceDetailFactory();
            _headerFactory = new InvoiceHeaderFactory();
            _invoiceProcess = new InvoiceProcess();
            this.Text = string.Concat(this.Text, " ", _invoiceType);
        }
        #region Events
        private void CreateInvoice_Load(object sender, EventArgs e)
        {
           LoadClientList(GetClientListToDiplay(true));
        }
        private void btnFilterClient_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtFilterClient.Text))
            {
                FilterClientList(txtFilterClient.Text);
            }
            else
            {
                cbArea.Items.Clear();
                cbArea.Text = string.Empty;
                cbArea.Enabled = false;
                LoadClientList(GetClientListToDiplay(true));
            }
        }
        private void cbClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadHeaderInformation(((ListItemDto<System.Guid>)(cbClient.SelectedItem)).Id);
            }
        }
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanHeaderInformation();
            if (cbClient.SelectedIndex > 0)
            {
                LoadHeaderInformation(((ListItemDto<System.Guid>)(cbClient.SelectedItem)).Id);
            }
            EnableDisableButtons();
            DisableFreeText();
            CleanItemList();
        }
        private void btnLoadInvoiceItems_Click(object sender, EventArgs e)
        {
            btnLoadInvoiceItems.Enabled = false;
            chkSelectAll.Checked = true;
            var selectedArea = (ListItemDto<Guid>)cbArea.SelectedItem;
            var areaId = selectedArea == null ? Guid.Empty : selectedArea.Id;
            IList<InvoiceDetails> clientDetails = _invoiceProcess.GetPendigItemsByClient(_client.Id, areaId);
            _details.AddRange(clientDetails);
            _data.ResetBindings(false);
        }
        void gvDetails_CellBeginEdit(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = gvDetails.Columns[e.ColumnIndex];
            if (col.DataPropertyName == "Price")
            {
                DataGridViewCell cell = gvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string editedValue = cell.EditedFormattedValue.ToString().Contains("$")
                    ? cell.EditedFormattedValue.ToString().Replace('$', ' ').Trim()
                    : cell.EditedFormattedValue.ToString().Trim();
                double value;
                if (!Double.TryParse(editedValue, out value))
                {
                    if (cell.FormattedValue != null)
                    {
                        gvDetails.EditingControl.Text = cell.FormattedValue.ToString();
                    }
                }
            }
        }
        private void chkFreeDetails_CheckedChanged(object sender, EventArgs e)
        {
            panelFreeText.Visible = chkFreeDetails.Checked;
            gvDetails.Visible = !chkFreeDetails.Checked;
            if (cbClient.SelectedIndex > 0)
            {
                btnLoadInvoiceItems.Enabled = !chkFreeDetails.Checked;
                btnAdditionaltem.Enabled = !chkFreeDetails.Checked;
            }

        }
        private void bntViewInvoice_Click(object sender, EventArgs e)
        {
            PreviewInvoice();
        }
        private void btnAdditionaltem_Click(object sender, EventArgs e)
        {
            var frmAdditionalItem = new FrmSelectAdditionalItem(string.Empty);
            frmAdditionalItem.ShowDialog();
            var additionalItem = frmAdditionalItem.SelectedItem;
            if (additionalItem != null)
            {
                _details.Add(additionalItem);
                _data.ResetBindings(false);
            }
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _details)
            {
                item.Selected = chkSelectAll.Checked;
            }
            _data.ResetBindings(false);
        }
        private void rdbAllClients_Click(object sender, EventArgs e)
        {
            LoadClientList(GetClientListToDiplay(true));
        }
        private void rdbClientsPendingItems_Click(object sender, EventArgs e)
        {
            LoadClientList(GetClientListToDiplay(false));
        }
        private void btnEditClient_Click(object sender, EventArgs e)
        {
            var clientForm = new FrmClient(_client.Id);
            clientForm.StartPosition = FormStartPosition.CenterParent;
            var result = clientForm.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                LoadHeaderInformation(_client.Id);
            }
        }
        #endregion

        #region Methods
        private void LoadClientList(IList<ListItemDto<Guid>> clients)
        {
            if (clients.Count > 0)
            {
                cbClient.DataSource = clients;
                cbClient.DisplayMember = "Name";
            }
        }

        private void FilterClientList(string filter)
        {
            var filteredClients = Client.GetFilteredClientList(filter);
            IList<ListItemDto<Guid>> clientList = null; 
            foreach (var client in filteredClients.ToList())
            {
               clientList.Insert(0, new ListItemDto<Guid> { Id = client.Id , Value = client.Name});
            }
            LoadClientList(clientList);
        }

        private void LoadHeaderInformation(Guid clientId)
        {
            var client = Client.GetClient(clientId);
            if (client == null) return;
            lblClientName.Text = client.Name;
            lblClientNumber.Text = client.ClientNumber.ToString(CultureInfo.InvariantCulture);
            lblCUIT.Text = client.Cuit;
            lblIvaCondition.Text = EnumUtils.AddSpaceInCapitalLetter(client.IvaCondition.ToString());
            lblSaleCondition.Text = @"Contado";
            try
            {
                var defaultAddres = (from ad in client.Addresses where ad.IsDefault select ad).First();
                lblAddress.Text = defaultAddres.ToString();
            }
            catch (Exception)
            {
                throw new Exception("La dirección está incompleta.");
            }
            cbArea.Items.Clear();
            cbArea.Enabled = false;
            if (client.Areas.Count() > 0)
            {
                cbArea.Enabled = true;
                var allAreas = new ListItemDto<Guid> { Id = Guid.Empty, Value = "Todas" };
                cbArea.Items.Add(allAreas);
                foreach (var area in client.Areas.ToList())
                {
                    cbArea.Items.Add(new ListItemDto<Guid> { Id = area.Id, Value = area.Name });
                }
                cbArea.SelectedItem = allAreas;
            }
            _client = client;
        }

        private void CleanHeaderInformation()
        {
            lblClientName.Text = string.Empty;
            lblClientNumber.Text = string.Empty;
            lblCUIT.Text = string.Empty;
            lblIvaCondition.Text = string.Empty;
            lblSaleCondition.Text = string.Empty;
            lblAddress.Text = string.Empty;
        }

        private void PreviewInvoice()
        {
            if (_details.Any(x => x.Selected))
            {
                _selectedDetails = _details.Where(x => x.Selected).ToList();
                _invoiceDisplay = new InvoiceDisplay();
                GetInvoiceHeader();
                _invoiceDisplay.Header.LoadHeader(_client);
                _invoiceDisplay.Header.GetHeader().InvoiceDate = DateTime.Today;
                _invoiceDisplay.InvoiceItems = _selectedDetails;
                LoadInvoiceRetentions();
                GetInvoiceDetails();
                GetInvoiceFooter();
                _detailPreview.LoadPreview();
                ShowPreviewWindow();
            }
        }

        private void GetInvoiceFooter()
        {
            _invoiceDisplay.Footer = new InvoiceFooter(_selectedDetails, _invoiceDisplay.InvoiceRetentions, _invoiceDisplay.Header.GetHeader().InvoiceType);
        }

        private void ShowPreviewWindow()
        {
            var invoicePreview = new InvoicePreview(_invoiceDisplay, _detailPreview, _client,chkIncludeInvoiceDetail.Checked);
            var result = invoicePreview.ShowDialog();
            if (result == DialogResult.OK)
            {
                cbClient.SelectedIndex = 0;
                cbArea.Items.Clear();
                cbArea.Enabled = false;
            }
            invoicePreview.Dispose();
        }

        private void GetInvoiceDetails()
        {
            if (chkFreeDetails.Checked)
            {
                GetInvoiceFreeDetails();
            }
            else
            {
                GetOtherInvoiceDetails();
            }
        }

        private void GetOtherInvoiceDetails()
        {
            if (_details.Count > 1)
            {
                _invoiceDisplay.Details =
                    _detailFactory.CreateReseumedInvoiceDetails(_invoiceDisplay);
                _detailPreview = new ucResumedInvoiceDetail(_invoiceDisplay.Details);
            }
            else
            {
                _invoiceDisplay.Details =
                    _detailFactory.CreateFullInvoiceDetails(_invoiceDisplay);
                _detailPreview = new ucFullDetailPreview(_invoiceDisplay.Details);
            }
        }

        private void GetInvoiceFreeDetails()
        {
            var freeDetails = new List<InvoiceDetails>
            {
                new InvoiceDetails
                {
                    Quantity = 1,
                    Description = txtFreeText.Text,
                    Price = _invoiceDisplay.InvoiceItems.Sum(x => x.Price * x.Quantity),
                }
            };
            _invoiceDisplay.InvoicedPractices = _invoiceDisplay.InvoiceItems;
            _invoiceDisplay.InvoiceItems = freeDetails;
            _invoiceDisplay.Details = _detailFactory.CreateFreeInvoiceDetails(_invoiceDisplay);
            _detailPreview = new ucFreeTextPreview(_invoiceDisplay.Details);
        }

        private void GetInvoiceHeader()
        {
            switch (_invoiceType)
            {
                case InvoiceType.A:
                    _invoiceDisplay.Header = _headerFactory.GetHeaderAInvoice();
                    break;
                case InvoiceType.B:
                    _invoiceDisplay.Header = _headerFactory.GetHeaderBInvoice();
                    break;
                case InvoiceType.C:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IList<ListItemDto<Guid>> GetClientListToDiplay(bool allClients)
        {
            IList<ListItemDto<Guid>> clients;// = new IList<ListItemDto<Guid>>();
            if(allClients)
            {
                clients = Client.GetClientsForInvoice(_invoiceType).ToList();
            }
            else
            {
                clients = Client.GetClientsForInvoiceWithPendingItems(_invoiceType).ToList();
            }
            //IList<ListItemDto<Guid>> clients = Client.GetClientsForInvoice(_invoiceType).ToList();
            clients.Insert(0, new ListItemDto<Guid> { Id = Guid.Empty, Value = string.Empty });
            
            return clients;
        }

        private void EnableDisableButtons()
        {
            if (cbClient.SelectedIndex > 0)
            {
                btnLoadInvoiceItems.Enabled = true;
                bntViewInvoice.Enabled = true;
                chkFreeDetails.Enabled = true;
                btnAdditionaltem.Enabled = true;
                chkIncludeInvoiceDetail.Enabled = true;
            }
            else
            {
                btnLoadInvoiceItems.Enabled = false;
                bntViewInvoice.Enabled = false;
                chkFreeDetails.Enabled = false;
                btnAdditionaltem.Enabled = false;
                chkIncludeInvoiceDetail.Enabled = false;
            }
        }

        private void DisableFreeText()
        {
            chkFreeDetails.Checked = false;
            panelFreeText.Visible = false;
            txtFreeText.Text = string.Empty;
            gvDetails.Visible = true;
        }

        private void CleanItemList()
        {
            _details = new List<InvoiceDetails>();
            _data = new BindingSource {DataSource = _details};
            gvDetails.AutoGenerateColumns = false;
            gvDetails.DataSource = _data;
            _data.ResetBindings(false);
        }

        private void LoadInvoiceRetentions()
        {
            ClientInvoiceProfile clientProfile = _client.InvoiceProfile ?? ClientInvoiceProfile.GetDefaultProfile();
            _invoiceDisplay.InvoiceRetentions = clientProfile.Retentions.ToList();
        }

        #endregion
    }
}
