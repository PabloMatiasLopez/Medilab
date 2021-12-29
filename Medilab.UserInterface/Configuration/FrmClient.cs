using Medilab.BusinessObjects.Address;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmClient : Form
    {
        #region Variables

        private byte[] _lastUpdate;
        private Guid _selectedArea;
        private BindingList<ListItemDto<Guid>> _areas;
        private BindingSource _data;
        private bool _isEditing;
        private string _logoFileExtention;
        private List<ClientListDto> _clientList;
        private bool _quickEdit;
        private Guid _clientId;
        #endregion

        #region Properties

        public Guid SelectedId { get; set; }
        public string SourceFile { get; set; }
        public string ImageName { get; set; }

        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                if (_quickEdit)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    Close();
                }
                else
                {
                    CleanForm();
                }
            }
            else
            {
                Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void gvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var clientId = (Guid)gvClients[0, e.RowIndex].Value;
            LoadClient(clientId);
        }
        private void FrmClient_Load(object sender, EventArgs e)
        {
            _areas = new BindingList<ListItemDto<Guid>>();
            _data = new BindingSource { DataSource = _areas };
            gvAreas.AutoGenerateColumns = false;
            gvAreas.DataSource = _data;
            LoadDropdowns();
            if (_quickEdit)
            {
                LoadClient(_clientId);
            }
            else
            {
                LoadGrid();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAreaName.Text))
            {
                AddArea();
            }
        }
        private void gvAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            _selectedArea = (Guid)gvAreas[0, e.RowIndex].Value;
            txtAreaName.Text = gvAreas[1, e.RowIndex].Value.ToString();
        }
        private void btnEmailList_Click(object sender, EventArgs e)
        {
            var emailListForm = new FrmEmailList(Client.GetEmailList());
            emailListForm.ShowDialog(this);
        }
        private void btnNewClient_Click(object sender, EventArgs e)
        {
            NewClient();
        }
        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            var fileDialogue = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                DefaultExt = "jpg",
                Filter = Resources.ImageFileExtensionList,
                Multiselect = false
            };
            if (fileDialogue.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialogue.FileName.Split('\\')[fileDialogue.FileName.Split('\\').Length - 1];
                txtImageName.Text = fileName;
                ImageName = fileName;
                SourceFile = fileDialogue.FileName;
                imgboxLogo.ImageLocation = SourceFile;
                _logoFileExtention = fileName.Split('.')[1];
            }
        }
        private void txtImageName_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnImageBrowse_MouseHover(object sender, EventArgs e)
        {
            ttipImageSize.Show("Tamaño del logo 177x93 pixels", btnImageBrowse);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                FilterList(txtSearchText.Text.ToLower().Trim());
            }
            else
            {
                gvClients.AutoGenerateColumns = false;
                gvClients.DataSource = _clientList;
            }
        }
        #endregion

        #region Methods
        public FrmClient()
        {
            InitializeComponent();
        }
        public FrmClient(Guid clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            _quickEdit = true;
        }
        private void LoadDropdowns()
        {
            int ivaDefaultId = (int)Iva.IVA_Responsable_Inscripto;
            cbIvaCondition.Items.Clear();
            var ivaConditions = EnumUtils.GetIvaNames();
            var defaultIva = ivaConditions.Select(i => i.Id = ivaDefaultId).First();
            cbIvaCondition.DataSource = ivaConditions;
            cbIvaCondition.DisplayMember = "Value";
            cbIvaCondition.SelectedItem = cbIvaCondition.Items.IndexOf(defaultIva);
            cbRetentionProfile.Items.Clear();
            var profiles = ClientInvoiceProfile.GetAllInvoiceProfile();
            var profileItems = new List<ListItemDto<Guid>>();
            profileItems.Add(new ListItemDto<Guid> { Id = Guid.Empty, Value = "Perfil por defecto" });
            foreach (var item in profiles)
            {
                profileItems.Add(new ListItemDto<Guid>
                    {
                        Id = item.Id,
                        Value = item.Name
                    });
            }
            cbRetentionProfile.Items.AddRange(profileItems.ToArray());
            cbRetentionProfile.SelectedIndex = 0;
            //Document type
            cbDocumentType.Items.Clear();
            var documentTypes = EnumUtils.GetDocumentTypeNames();
            var cuit = documentTypes.Where(d => d.Value == "CUIT").First();
            cbDocumentType.DataSource = documentTypes;
            cbDocumentType.DisplayMember = "Value";
            cbDocumentType.SelectedItem = cbDocumentType.Items[cbDocumentType.Items.IndexOf(cuit)];
        }
        private void LoadClient(Guid clientId)
        {
            btnDelete.Enabled = true;
            Client client = Client.GetClient(clientId);
            if (client == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = client.Id;
                txtName.Text = client.Name;
                foreach (var documentType in cbDocumentType.Items)
                {
                    var document = (ListItemDto<int>)documentType;
                    if (document.Id == (int)client.DocumentType)
                    {
                        cbDocumentType.SelectedItem = documentType;
                        break;
                    }
                }
                txtCuit.Text = client.Cuit;
                txtAditionalInformation.Text = client.AditionalInformation;
                txtPhoneNumber.Text = client.PhoneNumber;
                txtFaxNumber.Text = client.FaxNumber;
                txtEmailAddress.Text = client.EmailAddress;
                txtClientNumber.Text = client.ClientNumber.ToString(CultureInfo.InvariantCulture);
                imgboxLogo.ImageLocation = string.Concat(ConfigurationManager.AppSettings["fileClientLogoServerPath"],
                    client.Logo);
                ImageName = client.Logo;
                foreach (var item in cbIvaCondition.Items)
                {
                    var ivaCondition = (Iva)Enum.Parse(typeof(Iva), item.ToString().Replace(" ", "_"));
                    if (ivaCondition == client.IvaCondition)
                    {
                        cbIvaCondition.SelectedItem = item;
                        break;
                    }
                }
                clientAddress.OwnerId = client.Id;
                clientAddress.LoadAddress(client.Addresses);
                _lastUpdate = client.LastUpdated;
                foreach (var clientArea in client.Areas)
                {
                    _areas.Add(new ListItemDto<Guid>
                        {
                            Id = clientArea.Id,
                            Value = clientArea.Name
                        });
                }
                if (client.InvoiceProfile != null)
                {
                    foreach (var item in cbRetentionProfile.Items)
                    {
                        var actualItem = (ListItemDto<Guid>)item;
                        if (actualItem.Id == client.InvoiceProfile.Id)
                        {
                            cbRetentionProfile.SelectedItem = actualItem;
                            break;
                        }
                    }
                }
                _data.ResetBindings(false);
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
                EnableForm();
            }
        }
        private void LoadGrid()
        {
            CleanForm();
            _clientList = Client.GetDisplayClientList().ToList();
            gvClients.AutoGenerateColumns = false;
            gvClients.DataSource = new SortableBindingList<ClientListDto>(_clientList);
        }
        private void CleanForm()
        {
            txtName.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtAditionalInformation.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtFaxNumber.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            clientAddress.LoadAddress(new List<Address>());
            epClient.Clear();
            SelectedId = Guid.Empty;
            btnDelete.Enabled = false;
            epClient.Clear();
            txtAreaName.Text = string.Empty;
            _areas.Clear();
            _data.ResetBindings(false);
            tabClient.SelectTab(0);
            btnCancel.Text = Resources.CloseButtonText;
            txtClientNumber.Text = string.Empty;
            _isEditing = false;
            btnSave.Enabled = false;
            tabClient.Enabled = false;
            cbRetentionProfile.SelectedIndex = 0;
            imgboxLogo.ImageLocation = string.Empty;
            ImageName = string.Empty;
            SourceFile = string.Empty;
            txtImageName.Text = string.Empty;
            int ivaDefaultId = (int)Iva.IVA_Responsable_Inscripto; 
            foreach (var item in cbIvaCondition.Items)
            {
                var ivaType = (ListItemDto<int>)item;
                if (ivaType.Id == ivaDefaultId)
                {
                    cbIvaCondition.SelectedItem = item;
                    break;
                }
            }
            foreach (var item in cbDocumentType.Items)
            {
                var documentType = (ListItemDto<int>)item;
                if (documentType.Id == (int)DocumentType.CUIT)
                {
                    cbDocumentType.SelectedItem = documentType;
                    break;
                }
            }
            txtSearchText.Text = string.Empty;
            gvClients.AutoGenerateColumns = false;
            gvClients.DataSource = _clientList;
        }
        private bool ValidateForm()
        {
            var isValid = Validator.RequiredFieldValidator(txtName, epClient) &
                   Validator.RequiredFieldValidator(txtCuit, epClient) &
                   (Validator.RequiredFieldValidator(txtClientNumber, epClient) &&
                    Validator.CheckIntType(txtClientNumber, epClient) &&
                    Validator.GraterThanValidator(double.Parse(txtClientNumber.Text), 0, txtClientNumber, epClient)) &
                   clientAddress.IsValid;
            var existCode = Client.ExistCode(int.Parse(txtClientNumber.Text), SelectedId);
            if (existCode)
            {
                epClient.SetError(txtClientNumber, Resources.NumberMustBeUnique);
            }
            var exitsCuit = Client.ExistCuit(txtCuit.Text, SelectedId);
            if (exitsCuit)
            {
                epClient.SetError(txtCuit, Resources.CuitMustBeUnique);
            }
            return isValid && !existCode && !exitsCuit;
        }
        private void Delete()
        {
            DialogResult rta = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                               Resources.ConfirmationDialogDeleteTitle,
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                               MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes && CompanyInfo.IsAnyConfigurationActive())
            {
                var client = Client.GetClient(SelectedId);
                if (!string.IsNullOrEmpty(client.Logo))
                {
                    File.Delete(ConfigurationManager.AppSettings["fileClientLogoServerPath"] + client.Logo);
                }
                Client.Delete(SelectedId);
                CleanForm();
                LoadGrid();
            }
        }
        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }

            try
            {
                var documentType = (ListItemDto<int>)cbDocumentType.SelectedItem;
                var client = new Client(SelectedId)
                {
                    Name = txtName.Text,
                    DocumentType = (DocumentType)documentType.Id,
                    Cuit = txtCuit.Text,
                    AditionalInformation = txtAditionalInformation.Text,
                    LastUpdated = _lastUpdate,
                    PhoneNumber = txtPhoneNumber.Text,
                    FaxNumber = txtFaxNumber.Text,
                    EmailAddress = txtEmailAddress.Text,
                    Addresses = clientAddress.GetAddress().ToList(),
                    ClientNumber = int.Parse(txtClientNumber.Text),
                    IvaCondition =
                        (Iva)Enum.Parse(typeof(Iva), cbIvaCondition.Text.Replace(" ", "_")),
                    Logo = _logoFileExtention

                };
                var clientAreas = new List<ClientArea>();
                foreach (var area in _areas)
                {
                    clientAreas.Add(new ClientArea(area.Id)
                    {
                        Name = area.Value
                    });
                }
                client.Areas = clientAreas;
                var retentionProfile = (ListItemDto<Guid>)cbRetentionProfile.SelectedItem;
                if (retentionProfile.Id != Guid.Empty)
                {
                    client.InvoiceProfile = new ClientInvoiceProfile(retentionProfile.Id);
                }
                else
                {
                    client.InvoiceProfile = null;
                }
                client.Save();

                if (!string.IsNullOrEmpty(txtImageName.Text))
                {
                    if (Directory.Exists(ConfigurationManager.AppSettings["fileClientLogoServerPath"]))
                    {
                        if (
                            !File.Exists(ConfigurationManager.AppSettings["fileClientLogoServerPath"] +
                                         string.Concat(client.Id, ".", _logoFileExtention)))
                        {
                            File.Copy(SourceFile,
                                ConfigurationManager.AppSettings["fileClientLogoServerPath"] +
                                string.Concat(client.Id, ".", _logoFileExtention));
                        }
                        else
                        {
                            if (ImageName != string.Concat(client.Id, ".", _logoFileExtention) &&
                                !string.IsNullOrEmpty(ImageName))
                            {
                                File.Delete(string.Concat(ConfigurationManager.AppSettings["fileClientLogoServerPath"],
                                    client.Id, ".", _logoFileExtention));
                                File.Copy(SourceFile,
                                    ConfigurationManager.AppSettings["fileClientLogoServerPath"] +
                                    string.Concat(client.Id, ".", _logoFileExtention));
                            }
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(ConfigurationManager.AppSettings["fileClientLogoServerPath"]);
                        File.Copy(SourceFile, ConfigurationManager.AppSettings["fileClientLogoServerPath"] + ImageName);
                    }
                }
                if (_quickEdit)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddArea()
        {
            var existingArea = (from a in _areas where a.Value == txtAreaName.Text select a).FirstOrDefault();
            if (existingArea != null)
            {
                epClient.SetError(txtAreaName, "El nombre ya existe");
            }
            else
            {
                if (_selectedArea != Guid.Empty)
                {
                    var item = (from a in _areas where a.Id == _selectedArea select a).FirstOrDefault();
                    if (item != null)
                    {
                        _areas[_areas.IndexOf(item)].Value = txtAreaName.Text;
                    }
                }
                else
                {
                    _areas.Add(new ListItemDto<Guid>
                        {
                            Id = Guid.Empty,
                            Value = txtAreaName.Text
                        });
                }
                epClient.SetError(txtAreaName, string.Empty);
                txtAreaName.Text = string.Empty;
                _selectedArea = Guid.Empty;
                _data.ResetBindings(false);
            }
        }
        private void NewClient()
        {
            CleanForm();
            EnableForm();
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
            txtClientNumber.Text = (Client.MaxClientNumber() + 1).ToString();
        }
        private void EnableForm()
        {
            tabClient.Enabled = true;
            btnSave.Enabled = true;
            if (_quickEdit)
            {
                btnDelete.Visible = false;
                btnSearch.Visible = false;
                txtSearchText.Visible = false;
                lblSearch.Visible = false;
                gvClients.Visible = false;
                btnEmailList.Visible = false;
                btnNewClient.Visible = false;
                epClient.Clear();
                tabClient.Top = lblSearch.Top;
                btnSave.Top = tabClient.Top + tabClient.Height + 10;
                btnCancel.Top = btnSave.Top;
                this.Height = btnSave.Top + btnSave.Width + 10;
            }
        }
        private void FilterList(string filterText)
        {
            var filteredList =
                (from p in _clientList where p.Name.ToLower().Contains(filterText) || p.ClientNumber.ToString().Contains(filterText) select p).ToList();
            gvClients.AutoGenerateColumns = false;
            gvClients.DataSource = filteredList;
        }
        #endregion
    }
}