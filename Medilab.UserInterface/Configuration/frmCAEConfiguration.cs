using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.Configuration
{
    public partial class frmCAEConfiguration : Form
    {
        public frmCAEConfiguration()
        {
            InitializeComponent();
        }
        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void frmCAEConfiguration_Load(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
        }
        #endregion

        #region Methods
        private void Save()
        {
            if (IsFormValid())
            {
                BusinessObjects.Configuration.Configuration.SetValue(Constants.CAESleepTimeName, txtSleepTime.Text);
                BusinessObjects.Configuration.Configuration.SetValue(Constants.CAERetryTimes, txtRetryTimes.Text);
                Close();
            }
        }
        private bool IsFormValid()
        {
            return Validator.RequiredFieldValidator(txtSleepTime, epCAEConfiguration) &&
                Validator.CheckIntType(txtSleepTime, epCAEConfiguration) &&
                Validator.GraterThanValidator(double.Parse(txtSleepTime.Text), 1, txtSleepTime, epCAEConfiguration) &&
                Validator.RequiredFieldValidator(txtRetryTimes, epCAEConfiguration) &&
                Validator.CheckIntType(txtRetryTimes, epCAEConfiguration) &&
                Validator.GraterThanValidator(double.Parse(txtRetryTimes.Text), 1, txtRetryTimes, epCAEConfiguration);
        }
        private void LoadCurrentConfiguration()
        {
            var sleepValue = BusinessObjects.Configuration.Configuration.GetValue(Constants.CAESleepTimeName);
            if (sleepValue != null)
            {
                txtSleepTime.Text = sleepValue;
            }
            var retryValue = BusinessObjects.Configuration.Configuration.GetValue(Constants.CAERetryTimes);
            if (retryValue != null)
            {
                txtRetryTimes.Text = retryValue;
            }
        }
        #endregion
    }
}
