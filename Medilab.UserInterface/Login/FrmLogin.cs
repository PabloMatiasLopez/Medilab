using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System.IO;
using System.Configuration;

namespace Medilab.UserInterface.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

// ReSharper disable InconsistentNaming
        #region Events
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            #if DEBUG
            //TODO: only for dev, remove later
            txtUserName.Text = @"Administrator";
            txtPassword.Text = @"123456";//@"P@ssword1";
            #endif
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    #endregion
   // ReSharper restore InconsistentNaming
        #region Methods
        private void ValidateUser()
        {
            var login = BusinessObjects.Login.Login.Validate(txtUserName.Text, txtPassword.Text);
            if (login.IsValid)
            {
                var rolesArray = (from p in login.Privileges select p.ToString()).ToArray();
                Thread.CurrentPrincipal =
                    new GenericPrincipal(new GenericIdentity(login.UserId.ToString(), "Custom"), rolesArray);
                var frmMain = FormHandler.GetInstance<MainWindow>(this);
                frmMain.LoggedUser = login;
                frmMain.Show();
                Hide();
            }
            else
            {
                lblErrorMessage.Text = Resources.LoginFailedMessage;
                lblErrorMessage.Visible = true;
            }
        }
        #endregion        
    }
}
