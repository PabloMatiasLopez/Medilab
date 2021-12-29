using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Login
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }
        #region Events
        // ReSharper disable InconsistentNaming
        private void btnClose_Click(object sender, EventArgs e)

        {
            Dispose();
            Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var logedUser = User.GetUser(Security.GetCurrentUser());
                var currentUser = BusinessObjects.Login.Login.Validate(logedUser.UserName, txtCurrentPassword.Text);
                if (currentUser.IsValid)
                {
                    var user = User.GetUser(currentUser.UserId);
                    user.ChangePassword(txtNewPassword.Text);
                    MessageBox.Show(@"Clave actualizada correctamente.", @"Actualizacion correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                    Close();
                }
            }
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Methods

        private bool ValidateForm()
        {
            return
                Validator.CompareFieldValidator(txtNewPassword, txtRetypeNewPassword, passErrorProvider) &
                Validator.MinLengthValidator(txtNewPassword, 6, passErrorProvider) &
                Validator.RequiredFieldValidator(txtNewPassword, passErrorProvider);
        }

       

        #endregion
    }
}