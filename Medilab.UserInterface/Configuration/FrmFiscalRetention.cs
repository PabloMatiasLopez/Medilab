using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmFiscalRetention : Form
    {
        #region Variables

        protected Guid SelectedId { set; get; }
        private byte[] _lastUpdated;
        private bool _isEditing;
        private List<FiscalRetention> _retentions;
        #endregion
        public FrmFiscalRetention()
        {
            InitializeComponent();
        }
        #region Events
        private void FrmFiscalRetention_Load(object sender, EventArgs e)
        {
            _retentions = new List<FiscalRetention>();
            LoadGrid();
            CleanForm();
            LoadDropdown();
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gvRetentions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvRetentions[0, e.RowIndex].Value;
            LoadRetention(id);
        }
        private void txtcontrol_TextChanged(object sender, EventArgs e)
        {
            _isEditing = true;
            btnCancel.Text = Resources.CancelButtonText;
        }
        private void txtSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void btnNewPractice_Click(object sender, EventArgs e)
        {
            NewRetention();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        #endregion
        #region Methods
        private void CleanForm()
        {
            SelectedId = Guid.Empty;
            txtName.Text = string.Empty;
            txtName.Enabled = false;
            txtDescription.Text = string.Empty;
            txtDescription.Enabled = false;
            txtValue.Text = string.Empty;
            txtValue.Enabled = false;
            btnDelete.Visible = false;
            epRetention.Clear();
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
            btnNewPractice.Enabled = true;
            btnSave.Enabled = false;
        }
        private void LoadGrid()
        {
            CleanForm();
            _retentions = (List<FiscalRetention>)FiscalRetention.GetAllRetentions();
            gvRetentions.AutoGenerateColumns = false;
            gvRetentions.DataSource = _retentions;
        }
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                      Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var retention = FiscalRetention.GetRetention(SelectedId);
                retention.Delete();
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
                var retention = new FiscalRetention(SelectedId)
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    LastUpdated = _lastUpdated,
                    Value = double.Parse(txtValue.Text),
                    IsIVA = chkIsIVA.Checked,
                    CAECode = ((ListItemDto<int>)cbCAECode.SelectedItem).Id
                };
                retention.Save();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateForm()
        {
            var isRequiredFieldsValid = Validator.RequiredFieldValidator(txtName, epRetention) &
                                        Validator.RequiredFieldValidator(txtDescription, epRetention);

            var valueIsValid = Validator.RequiredFieldValidator(txtValue, epRetention);
            if (valueIsValid)
            {
                valueIsValid = Validator.CheckDoubleType(txtValue, epRetention);
                if (valueIsValid)
                {
                    valueIsValid = Validator.RangeValidator(double.Parse(txtValue.Text), 0, 100, txtValue, epRetention);
                }
            }
            return isRequiredFieldsValid && valueIsValid;
        }
        private void LoadRetention(Guid id)
        {
            var practice = FiscalRetention.GetRetention(id);
            if (practice == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = practice.Id;
                txtName.Text = practice.Name;
                txtDescription.Text = practice.Description;
                txtValue.Text = practice.Value.ToString("0.00");
                _lastUpdated = practice.LastUpdated;
                btnDelete.Visible = true;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
                chkIsIVA.Checked = practice.IsIVA;
                EnableForm();
            }
        }
        private void EnableForm()
        {
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            txtValue.Enabled = true;
            btnNewPractice.Enabled = false;
            btnSave.Enabled = true;
        }
        private void Search()
        {
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                FilterList(txtSearchText.Text.ToLower().Trim());
            }
            else
            {
                gvRetentions.AutoGenerateColumns = false;
                gvRetentions.DataSource = _retentions;
            }
        }
        private void FilterList(string filterText)
        {
            var filteredList =
                (from p in _retentions where p.Name.ToLower().Contains(filterText) || p.Description.ToLower().Contains(filterText) select p).ToList();
            gvRetentions.AutoGenerateColumns = false;
            gvRetentions.DataSource = filteredList;
        }
        private void NewRetention()
        {
            EnableForm();
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
        }
        private void LoadDropdown()
        {
            cbCAECode.Items.Clear();
            
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 1, Value = "No Gravado" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 2, Value = "Exento" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 3, Value = "Cero porciento (0 %)" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 4, Value = "Diez y medio porciento (10,5 %)" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 5, Value = "Veintiun porciento (21 %)" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 6, Value = "Veintisiete porciento (27 %)" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 1, Value = "Impuestos nacionales" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 2, Value = "Impuestos provinciales" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 3, Value = "Impuestos municipales" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 4, Value = "Impuestos internos" });
            cbCAECode.Items.Add(new ListItemDto<int> { Id = 99, Value = "Otros" });
        }
        #endregion
    }
}