using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmSpeciality : Form
    {
        #region Variables
        protected Guid SelectedId { set; get; }
        private byte[] _lastUpdated;
        private bool _isEditing;
        #endregion
        public FrmSpeciality()
        {
            InitializeComponent();
        }
        // ReSharper disable InconsistentNaming
        #region Events
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                LoadGrid();
            }
            else
            {
                Close();
            }
        }
        private void gvSpecialities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvSpecialities[0, e.RowIndex].Value;
            LoadSpeciality(id);
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            _isEditing = true;
            btnCancel.Text = Resources.CancelButtonText;
        }
        private void FrmSpeciality_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        #endregion
        // ReSharper restore InconsistentNaming
        #region Methods
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText, Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var speciality = Speciality.GetSpeciality(SelectedId);
                speciality.Delete();
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            CleanForm();
            var specialities = Speciality.GetList();
            gvSpecialities.AutoGenerateColumns = false;
            gvSpecialities.DataSource = specialities;
        }
        private void CleanForm()
        {
            SelectedId = Guid.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtDisplayName.Text = string.Empty;
            btnDelete.Visible = false;
            epSpeciality.Clear();
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
        }
        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            var speciality = new Speciality(SelectedId)
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                LastUpdated = _lastUpdated,
                DisplayName = txtDisplayName.Text
            };
            speciality.Save();
            LoadGrid();
        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtName, epSpeciality);

        }
        private void LoadSpeciality(Guid id)
        {
            var speciality = Speciality.GetSpeciality(id);
            if (speciality == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = speciality.Id;
                txtName.Text = speciality.Name;
                txtDescription.Text = speciality.Description;
                _lastUpdated = speciality.LastUpdated;
                txtDisplayName.Text = speciality.DisplayName;
                btnDelete.Visible = true;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
            }
        }
        #endregion
    }
}
