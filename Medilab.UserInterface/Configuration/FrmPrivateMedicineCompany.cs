using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmPrivateMedicineCompany : Form
    {
        #region Variables
        private byte[] _lastUpdate;
        private bool _isEditing;
        #endregion
        #region Properties
        public Guid SelectedId { get; set; }
        #endregion
        #region Events
        // ReSharper disable InconsistentNaming
        private void gvPrivateMedicineCompanies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadPrivateMedicineCompany(e);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void FrmPrivateMedicineCompany_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Methods
        public FrmPrivateMedicineCompany()
        {
            InitializeComponent();
        }
        private void LoadPrivateMedicineCompany(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var pmcId = (Guid)gvPrivateMedicineCompanies[0, e.RowIndex].Value;
            PrivateMedicineCompany privateMedicineCompany = PrivateMedicineCompany.GetPrivateMedicineCompany(pmcId);
            if (privateMedicineCompany == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                btnDelete.Enabled = true;
                SelectedId = privateMedicineCompany.Id;
                txtName.Text = privateMedicineCompany.Name;
                txtDescription.Text = privateMedicineCompany.Description;
                _lastUpdate = privateMedicineCompany.LastUpdated;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
            }
        }
        private void LoadGrid()
        {
            CleanForm();
            var privateMedicineCompany = PrivateMedicineCompany.GetPrivateMedicineCompanyList();
            gvPrivateMedicineCompanies.AutoGenerateColumns = false;
            gvPrivateMedicineCompanies.DataSource = privateMedicineCompany;
        }
        private void CleanForm()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            SelectedId = Guid.Empty;
            btnDelete.Enabled = false;
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
            epPrivateMedicineCompany.Clear();
        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtName, epPrivateMedicineCompany);
        }
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText, Resources.ConfirmationDialogDeleteTitle,
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                PrivateMedicineCompany.Delete(SelectedId);
                LoadGrid();
            }
        }
        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            var pmc = new PrivateMedicineCompany(SelectedId)
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                LastUpdated = _lastUpdate
            };
            pmc.Save();
            LoadGrid();
        }
        #endregion
    }
}
