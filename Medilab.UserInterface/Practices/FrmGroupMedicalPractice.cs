using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Practices
{
    public partial class FrmGroupMedicalPractice : Form
    {
        #region Variables

        protected Guid SelectedId { set; get; }
        private byte[] _lastUpdated;
        private List<Practice> _practices;
        private BindingSource _data;
        private bool _isEditing;
        private List<Group> _groupList;
        #endregion

        public FrmGroupMedicalPractice()
        {
            InitializeComponent();
        }

        #region Events

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

        private void FrmGroupMedicalPractice_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            _practices = new List<Practice>();
            gvPractices.AutoGenerateColumns = false;
            _data = new BindingSource {DataSource = _practices};
            gvPractices.DataSource = _data;
            LoadGrid();
        }

        private void gvGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid) gvGroups[0, e.RowIndex].Value;
            LoadGroup(id);
        }

        private void gvPractices_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            var id = Guid.Parse(gvPractices.SelectedRows[0].Cells[0].Value.ToString());
            foreach (var practice in _practices)
            {
                if (practice.Id != id) continue;
                _practices.Remove(practice);
                _data.ResetBindings(false);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void txtPracticeCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_practices.Any(item => item.Code.ToString() == txtPracticeCode.Text))
                {
                    return;
                }
                var practice = Practice.GetPractice(int.Parse(txtPracticeCode.Text));
                if (practice != null)
                {
                    _practices.Add(practice);
                    _data.ResetBindings(false);
                    cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
                }
            }
        }

        private void cbPracticeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPractice = (PracticeDto) cbPracticeName.SelectedItem;
            if (_practices == null || _practices.Any(p => p.Code.Equals(selectedPractice.Code)))
            {
                return;
            }
            _practices.Add(new Practice(selectedPractice.Id)
                               {
                                   Code = selectedPractice.Code,
                                   Name = selectedPractice.Name,
                                   Description = selectedPractice.Description
                               });
            _data.ResetBindings(false);
            cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
        }
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            NewGroup();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                FilterList(txtSearchText.Text.ToLower().Trim());
            }
            else
            {
                gvGroups.AutoGenerateColumns = false;
                gvGroups.DataSource = _groupList;
            }
        }
        #endregion

        #region Methods

        private void LoadGrid()
        {
            CleanForm();
            _groupList = Group.GetList().ToList();
            gvGroups.AutoGenerateColumns = false;
            gvGroups.DataSource = new SortableBindingList<Group>(_groupList);
        }

        private void CleanForm()
        {
            SelectedId = Guid.Empty;
            txtName.Text = string.Empty;
            txtName.Enabled = false;
            txtCode.Text = string.Empty;
            txtCode.Enabled = false;
            txtDescription.Text = string.Empty;
            txtDescription.Enabled = false;
            btnDelete.Visible = false;
            epGroup.Clear();
            _practices.Clear();
            _data.ResetBindings(false);
            txtPrice.Text = string.Empty;
            txtPrice.Enabled = false;
            btnCancel.Text = Resources.CloseButtonText;
            _isEditing = false;
            gbPractices.Enabled = false;
            btnNewGroup.Enabled = true;
            btnSave.Enabled = false;
            txtSearchText.Text = string.Empty;
        }

        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                      Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta != DialogResult.Yes) return;
            var group = Group.GetGroup(SelectedId);
            group.Delete();
            LoadGrid();
        }

        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            try
            {
                var group = new Group(SelectedId)
                {
                    Name = txtName.Text,
                    Code = int.Parse(txtCode.Text),
                    Description = txtDescription.Text,
                    LastUpdated = _lastUpdated,
                    Practices = _practices,
                    Price = double.Parse(txtPrice.Text)
                };
                group.Save();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            var isRequiredFieldsValid = Validator.RequiredFieldValidator(txtName, epGroup);

            var isCodeInt = Validator.CheckIntType(txtCode, epGroup);
            var isPracticesValid = true;
            epGroup.SetError(gbPractices, string.Empty);
            if (_practices.Count == 0)
            {
                isPracticesValid = false;
                epGroup.SetError(gbPractices, Resources.SelectAtLeastOnePractice);
            }
            bool existCode = true;
            if (isCodeInt)
            {
                existCode = BusinessObjects.Configuration.Utilities.ExistCode(int.Parse(txtCode.Text), SelectedId);
                if (existCode)
                {
                    epGroup.SetError(txtCode, Resources.CodeMustBeUnique);
                }
            }
            var priceIsValid = Validator.RequiredFieldValidator(txtPrice, epGroup);
            if (priceIsValid)
            {
                priceIsValid = Validator.CheckDoubleType(txtPrice, epGroup);
                if (priceIsValid)
                {
                    priceIsValid = Validator.GraterThanValidator(double.Parse(txtPrice.Text), 0, txtPrice, epGroup);
                }
            }
            return isRequiredFieldsValid && isPracticesValid && isCodeInt && !existCode && priceIsValid;
        }

        private void LoadGroup(Guid id)
        {
            var group = Group.GetGroup(id);
            if (group == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = group.Id;
                txtName.Text = group.Name;
                txtCode.Text = group.Code.ToString();
                txtDescription.Text = group.Description;
                _lastUpdated = group.LastUpdated;
                _practices.Clear();
                _practices.AddRange(group.Practices);
                _data.ResetBindings(false);
                btnDelete.Visible = true;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
                txtPrice.Text = group.Price.ToString("0.00");
                EnableForm();
            }
        }

        private void LoadDropdowns()
        {
            //Practices
            cbPracticeName.Items.Clear();
            var practices = Practice.GetList();
            cbPracticeName.DataSource = practices;
            cbPracticeName.DisplayMember = "Name";
            cbPracticeName.Text = string.Empty;
        }

        private void EnableForm()
        {
            txtName.Enabled = true;
            txtCode.Enabled = true;
            txtDescription.Enabled = true;
            txtPrice.Enabled = true;
            gbPractices.Enabled = true;
            btnNewGroup.Enabled = false;
            btnSave.Enabled = true;
        }
        private void NewGroup()
        {
            EnableForm();
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
            txtCode.Text = (BusinessObjects.Configuration.Utilities.MaxCodeNumber() + 1).ToString();
        }
        #endregion
        private void FilterList(string filterText)
        {
            var filteredList =
                (from p in _groupList where p.Name.ToLower().Contains(filterText) || p.Code.ToString().Contains(filterText) select p).ToList();
            gvGroups.AutoGenerateColumns = false;
            gvGroups.DataSource = filteredList;
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
    }
}