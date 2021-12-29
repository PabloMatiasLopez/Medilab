using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmCompanyInformation : Form
    {
        #region Variables

        private byte[] _lastUpdate;
        private string _selectedDropdownItem;
        private bool _isEditing;
        private const string ImagePath = "fileImagePath";

        #endregion

        #region Properties

        public Guid SelectedId { get; set; }
        public string SourceFile { get; set; }
        public string ImageName { get; set; }

        #endregion

        #region Events

        // ReSharper disable InconsistentNaming
        private void CompanyInformation_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadDropDown();
            ForceCompanyCreationOrActivation(CompanyInfo.IsAnyConfigurationActive());
        }

        private void ddlFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ((ComboBox) sender).SelectedValue.ToString();
            if (value != "Formato")
            {
                btnSave.Enabled = true;
                _selectedDropdownItem = value;
            }
            else
            {
                btnSave.Enabled = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void gvCompanyInformation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadCompanyInfo(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                CleanForm();
            }
            else
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CompanyInfo.IsAnyConfigurationActive())
            {
                Close();
            }
            else
            {
                ForceCompanyCreationOrActivation(false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btn_Click(object sender, EventArgs e)
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
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtFax_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtImageName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        // ReSharper restore InconsistentNaming

        #endregion

        #region Methods

        public FrmCompanyInformation()
        {
            InitializeComponent();
        }

        private void LoadCompanyInfo(DataGridViewCellEventArgs e)
        {
            ddlFormato.Enabled = true;
            if (e.RowIndex < 0)
            {
                return;
            }
            var ciId = (Guid) gvCompanyInformation[0, e.RowIndex].Value;
            btnDelete.Enabled = true;
            _isEditing = true;
            btnCancel.Text = Resources.CancelButtonText;
            CompanyInfo companyInformation = CompanyInfo.GetCompanyInfo(ciId);
            if (companyInformation == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = companyInformation.Id;
                txtAddress.Text = companyInformation.Address;
                txtCountry.Text = companyInformation.Country;
                txtCuit.Text = companyInformation.Cuit;
                txtEmail.Text = companyInformation.Email;
                txtFax.Text = companyInformation.Fax;
                txtName.Text = companyInformation.Name;
                txtPhone.Text = companyInformation.Phone;
                txtPostalCode.Text = companyInformation.PostalCode;
                foreach (var item in cbState.Items)
                {
                    var state = (State)item;
                    if (state.Name == companyInformation.Province)
                    {
                        cbState.SelectedItem = item;
                        break;
                    }
                }
                txtImageName.Text = companyInformation.Image;
                chkIsActive.Checked = companyInformation.IsActive;
                imgboxLogo.ImageLocation = ConfigurationManager.AppSettings[ImagePath] + companyInformation.Image;
                ImageName = companyInformation.Image;
                _lastUpdate = companyInformation.LastUpdated;
                ddlFormato.SelectedItem = _selectedDropdownItem = companyInformation.ExcelFormat;

            }
        }

        private void LoadGrid()
        {
            CleanForm();
            //LoadDropDown();
            IEnumerable<CompanyInfo> companyInformation = CompanyInfo.GetCompanyInfoList();
            gvCompanyInformation.AutoGenerateColumns = false;
            gvCompanyInformation.DataSource = companyInformation;
        }

        private void CleanForm()
        {
            epCompanyInformation.Clear();
            txtAddress.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtImageName.Text = string.Empty;
            chkIsActive.Checked = false;
            imgboxLogo.ImageLocation = string.Empty;

            SelectedId = Guid.Empty;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
            _selectedDropdownItem = string.Empty;
            foreach (var item in cbState.Items)
            {
                var state = (State)item;
                if (state.Name == "Mendoza")
                {
                    cbState.SelectedItem = item;
                    break;
                }
            }
        }

        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtAddress, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtCountry, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtCuit, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtEmail, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtFax, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtName, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtPhone, epCompanyInformation) &
                   Validator.RequiredFieldValidator(txtPostalCode, epCompanyInformation) &
                   Validator.RequiredFieldValidator(cbState, epCompanyInformation) &
                   Validator.RequiredFieldValidator(ddlFormato, epCompanyInformation)&
                   Validator.RequiredFieldValidator(txtImageName, epCompanyInformation);
        }

        private void ForceCompanyCreationOrActivation(bool isAnyConfigurationActive)
        {
            if (!isAnyConfigurationActive)
            {
                MessageBox.Show(
                    Resources.NoActiveConfigurationErrorText,
                    Resources.WarningText,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            }
        }

        private void Delete()
        {
            DialogResult rta = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                               Resources.ConfirmationDialogDeleteTitle,
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                               MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes && CompanyInfo.IsAnyConfigurationActive())
            {
                CompanyInfo.Delete(SelectedId);
                CleanForm();
                LoadGrid();
            }
        }

        private void Save()
        {
            bool isActiveChecked = chkIsActive.Checked;
            if (!ValidateForm())
            {
                return;
            }
            if (!CompanyInfo.IsAnyConfigurationActive())
            {
                isActiveChecked = true;
            }
            var companyInformation = new CompanyInfo(SelectedId)
                                         {
                                             Address = txtAddress.Text,
                                             Name = txtName.Text,
                                             PostalCode = txtPostalCode.Text,
                                             Province = ((Medilab.BusinessObjects.Configuration.State)(cbState.SelectedValue)).Name,
                                             Country = txtCountry.Text,
                                             Phone = txtPhone.Text,
                                             Fax = txtFax.Text,
                                             Email = txtEmail.Text,
                                             Image = ImageName,
                                             Cuit = txtCuit.Text,
                                             IsDeleted = false,
                                             IsActive = isActiveChecked,
                                             LastUpdated = _lastUpdate,
                                             ExcelFormat = _selectedDropdownItem
                                         };
            companyInformation.Save();
            if (Directory.Exists(ConfigurationManager.AppSettings[ImagePath]))
            {
                if (!File.Exists(ConfigurationManager.AppSettings[ImagePath] + ImageName))
                {
                    File.Copy(SourceFile, ConfigurationManager.AppSettings[ImagePath] + ImageName);
                }
            }
            else
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings[ImagePath]);
                File.Copy(SourceFile, ConfigurationManager.AppSettings[ImagePath] + ImageName);
            }

            LoadGrid();
        }

        private void LoadDropDown()
        {
            _selectedDropdownItem = string.Empty;
            ddlFormato.DataSource = Enum.GetNames(typeof (CompanyName));
            //State
            cbState.Items.Clear();
            var states = State.GetList().ToArray();
            var stateDefault = states.First(s => s.Name == "Mendoza");
            cbState.DataSource = states;
            cbState.DisplayMember = "Name";
            cbState.SelectedItem = cbState.Items[cbState.Items.IndexOf(stateDefault)];
        }

        #endregion

        // <summary>
        // TODO: Arreglar el tema de las Validaciones que se disparan al comienzo.
        //           Agregar el OnClosing cuando no hay ninguna configuracion de empresa Seleccionada.
        // </summary>
    }
}