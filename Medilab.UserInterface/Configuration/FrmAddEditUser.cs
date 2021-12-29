using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmAddEditUser : Form
    {
        #region Properties
        private Guid _selectedId;
        private IEnumerable<ListItemDto<Guid>> _roles;
        private bool _isNewRecord;
        private byte[] _lastUpdated;
        private bool _isCustomUsername;
        #endregion
        #region Events
        // ReSharper disable InconsistentNaming
        public FrmAddEditUser(Guid id)
        {
            _selectedId = id;
            InitializeComponent();
            LoadDropdowns();
            if (_selectedId == Guid.Empty)
            {
                _isNewRecord = true;
                chkIsActive.Checked = true;
                chkResetPassword.Visible = false;
                base.Text = Resources.NewUserText;
                LoadRoles();
            }
            else
            {
                _isNewRecord = false;
                LoadUser();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    return;
                }
                SaveUser();
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format(@"Ha ocurrido un error: {0}.", ex.Message);
                MessageBox.Show(errorMessage, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode != Keys.Tab)
            {
                _isCustomUsername = true;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.Trim().Replace(" ", "");
            if(txtUserName.Text.Length == 0)
            {
                _isCustomUsername = false;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if(_isCustomUsername || !_isNewRecord) return;
            if(txtFirstName.Text.Length == 0) return;
            var firstLetterName = txtFirstName.Text.Substring(0, 1);
            if (txtUserName.Text.Length > 0)
            {
                var currentUsername = txtUserName.Text.Substring(1).Replace(" ", string.Empty);
                txtUserName.Text = firstLetterName + currentUsername;
            }
            else
            {
                txtUserName.Text = firstLetterName.Replace(" ", string.Empty);
            }
        }
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (_isCustomUsername || !_isNewRecord) return;
            if (txtUserName.Text.Length > 0)
            {
                var firstLetter = txtUserName.Text.Substring(0, 1);
                txtUserName.Text = firstLetter + txtLastName.Text.Replace(" ", string.Empty);
            }
            else
            {
                txtUserName.Text = txtLastName.Text.Replace(" ", string.Empty);
            }
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Methods

        private void LoadUser(User user = null)
        {
            if(user == null)
            {
                user = User.GetUser(_selectedId);
            }
            Text = string.Format("Editar {0} {1}", user.FirstName, user.LastName);
            txtUserName.Text = user.UserName;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtPassword.Visible = true;
            txtRetypePassword.Visible = true;
            lblPassword.Visible = true;
            lblRetypePassword.Visible = true;
            chkIsActive.Checked = user.IsActive;
            _lastUpdated = user.LastUpdated;
            LoadRoles(user.UserRoles.ToList());
            foreach (var item in cbSpeciality.Items)
            {
                var spec = (ListItemDto<Guid>)item;
                if (spec.Id == user.Speciality.Id)
                {
                    cbSpeciality.SelectedItem = item;
                    break;
                }
            }
            chkResetPassword.Visible = true;
        }

        private void LoadRoles(List<UserRole> userRoles = null)
        {
            if (_roles == null)
            {
                _roles = (from r in Role.GetList() select new ListItemDto<Guid> { Id = r.Id, Value = r.Name }).ToList();
            }
            chklstRoles.Items.Clear();
            foreach (var listItemDto in _roles)
            {
                var isChecked = false;
                if (userRoles != null)
                {
                    isChecked = (from ur in userRoles where ur.RoleId == listItemDto.Id select ur.Id).Any();
                }
                chklstRoles.Items.Add(listItemDto, isChecked);
            }
        }
        private bool ValidateForm()
        {
            var isPasswordValid = true;
            var commonFieldsAreValid = Validator.RequiredFieldValidator(txtFirstName, userErrorProvider) &
                                       Validator.RequiredFieldValidator(txtLastName, userErrorProvider) &
                                       Validator.RequiredFieldValidator(chklstRoles, userErrorProvider) &
                                       Validator.RequiredFieldValidator(cbSpeciality, userErrorProvider);
            var userNameisValid = Validator.RequiredFieldValidator(txtUserName, userErrorProvider) &&
                                    Validator.MinLengthValidator(txtUserName, 6, userErrorProvider) &&
                                    Validator.InvalidCharsValidator(txtUserName, @"*'%$&()\?/<>#@!=+",
                                                                    userErrorProvider);
            if (_isNewRecord || chkResetPassword.Checked)
            {
                isPasswordValid =
                    Validator.CompareFieldValidator(txtPassword, txtRetypePassword, userErrorProvider) &&
                    Validator.MinLengthValidator(txtPassword, 6, userErrorProvider) &&
                    Validator.RequiredFieldValidator(txtPassword, userErrorProvider);
            }
            var isUserNameAvailable = User.IsUserNameAvailable(txtUserName.Text, _selectedId);
            if (!isUserNameAvailable)
            {
                userErrorProvider.SetError(txtUserName, Resources.UserNameAlreadyExist);
            }
            return commonFieldsAreValid && isPasswordValid && isUserNameAvailable && userNameisValid;
        }

        private void SaveUser()
        {
            var user = new User(_selectedId)
            {
                UserName = txtUserName.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                IsActive = chkIsActive.Checked,
                LastUpdated = _lastUpdated
            };

            if (_isNewRecord || chkResetPassword.Checked)
            {
                user.Password = txtPassword.Text;
            }
            else
            {
                user.Password = null;
            }
            var roleList = new List<UserRole>();
            foreach (object checkedItem in chklstRoles.CheckedItems)
            {
                var item = (ListItemDto<Guid>)checkedItem;
                roleList.Add(new UserRole
                {
                    RoleId = item.Id,
                    UserId = user.Id,
                    RoleName = item.Value
                });
            }
            user.UserRoles = roleList;
            var speciality = (ListItemDto<Guid>) cbSpeciality.SelectedItem;
            user.Speciality = new Speciality(speciality.Id) { Name = speciality.Value };
            user = user.Save();
            _selectedId = user.Id;
            _isNewRecord = false;
            Close();
        }
        private void LoadDropdowns()
        {
            //Specialities
            cbSpeciality.Items.Clear();
            var specialities = Speciality.GetList();
            var specList = specialities.Select(speciality => new ListItemDto<Guid>
                                                                 {
                                                                     Id = speciality.Id, Value = speciality.Name
                                                                 }).ToList();
            specList = (from s in specList orderby s.Value select s).ToList();
            var firstItem = (from s in specList where s.Id == Constants.NoSpecialityId select s).First();
            specList.Remove(firstItem);
            specList.Insert(0,firstItem);
            cbSpeciality.DataSource = specList;
            cbSpeciality.DisplayMember = "Value";
        }
        #endregion
    }
}
