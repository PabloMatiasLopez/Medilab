using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmWorkRiskInsurance : Form
    {
        #region Variables
        private byte[] _lastUpdate;
        private Guid _selectedId;
        private bool _isEditing;
        #endregion
        public FrmWorkRiskInsurance()
        {
            InitializeComponent();
        }
        #region Methods
        // ReSharper disable InconsistentNaming
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
        private void FrmWorkRiskInsurance_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void gvWorkRiskInsurance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var wriId = (Guid)gvWorkRiskInsurance[0, e.RowIndex].Value;
            LoadWorkRiskInsurance(wriId);
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _isEditing = true;
            btnCancel.Text = Resources.CancelButtonText;
        }
        // ReSharper restore InconsistentNaming
        #endregion

        #region Methods
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText, Resources.ConfirmationDialogDeleteTitle,
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                WorkRiskInsurance.Delete(_selectedId);
                LoadGrid();
            }
        }
        private void CleanForm()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            _selectedId = Guid.Empty;
            btnDelete.Enabled = false;
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
        }
        private void LoadGrid()
        {
            CleanForm();
            var privateMedicineCompany = WorkRiskInsurance.GetWorkRiskInsuranceList();
            gvWorkRiskInsurance.AutoGenerateColumns = false;
            gvWorkRiskInsurance.DataSource = privateMedicineCompany;
        }
        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            var wri = new WorkRiskInsurance(_selectedId)
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                LastUpdated = _lastUpdate
            };
            wri.Save();
            LoadGrid();
        }

        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtName, epWorkRiskInsurance);
        }
        private void LoadWorkRiskInsurance(Guid wriId)
        {
            var workRiskInsurance = WorkRiskInsurance.GetWorkRiskInsurance(wriId);
            if (workRiskInsurance == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                btnDelete.Enabled = true;
                _selectedId = workRiskInsurance.Id;
                txtName.Text = workRiskInsurance.Name;
                txtDescription.Text = workRiskInsurance.Description;
                _lastUpdate = workRiskInsurance.LastUpdated;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
            }
        }
        #endregion
    }
}
