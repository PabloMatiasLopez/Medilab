using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmRole : Form
    {
        #region Variables
        protected Guid SelectedId { set; get; }
        private byte[] _lastUpdated;
        private bool _isEditing;
        #endregion
        public FrmRole()
        {
            InitializeComponent();
        }
        #region Events
        private void FrmRoleLoad(object sender, EventArgs e)
        {
            LoadGrid();
            LoadPrivileges();
        }
        private void GvRolesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvRoles[0, e.RowIndex].Value;
            LoadRole(id);
        }
        private void BtnSaveClick(object sender, EventArgs e)
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
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            _isEditing = true;
            btnCancel.Text = Resources.CancelButtonText;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        #endregion
        // ReSharper restore InconsistentNaming
        #region Methods
        private void LoadGrid()
        {
            CleanForm();
            var roles = Role.GetList();
            gvRoles.AutoGenerateColumns = false;
            gvRoles.DataSource = roles;
        }
        private void CleanForm()
        {
            SelectedId = Guid.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnDelete.Visible = false;
            roleErrorProvider.Clear();
            LoadPrivileges();
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
        }
        private void LoadPrivileges()
        {
            chklstPrivileges.Items.Clear();
            chklstPrivileges.Items.AddRange(Enum.GetNames(typeof(Privileges)));
        }
        private void MarkSelectedPrivileges(IEnumerable<RolePrivilege> privileges )
        {
            LoadPrivileges();
            foreach (var privilege in privileges)
            {
                var index = chklstPrivileges.Items.IndexOf(privilege.Privilege);
                chklstPrivileges.SetItemCheckState(index, CheckState.Checked);
            }
        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(chklstPrivileges, roleErrorProvider) &
                Validator.RequiredFieldValidator(txtName, roleErrorProvider);
            
        }
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText, Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var role = Role.GetRole(SelectedId);
                role.Delete();
                LoadGrid();
            }
        }
        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            var role = new Role(SelectedId)
                               {
                                   Name = txtName.Text,
                                   Description = txtDescription.Text,
                                   LastUpdated = _lastUpdated
                               };
            var privelegesList = new List<RolePrivilege>();
            foreach (var item in chklstPrivileges.CheckedItems)
            {
                var privilege = (Privileges)Enum.Parse(typeof(Privileges), item.ToString());
                privelegesList.Add(new RolePrivilege { RoleId = role.Id, Privilege = privilege.ToString() });
            }
            role.Privileges = privelegesList;
            role.Save();
            LoadGrid();
        }
        private void LoadRole(Guid id)
        {
            var role = Role.GetRole(id);
            if (role == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = role.Id;
                txtName.Text = role.Name;
                txtDescription.Text = role.Description;
                _lastUpdated = role.LastUpdated;
                MarkSelectedPrivileges(role.Privileges);
                btnDelete.Visible = true;
                btnCancel.Text = Resources.CancelButtonText;
                _isEditing = true;
            }
        }
        #endregion
    }
}
