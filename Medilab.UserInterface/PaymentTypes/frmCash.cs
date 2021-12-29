using Medilab.BusinessObjects.Payment;
using Medilab.UserInterface.Utilities;
using System;
using System.Globalization;
using System.Windows.Forms;
using Medilab.UserInterface.Utilities;


namespace Medilab.UserInterface.PaymentTypes
{
    public partial class frmCash : frmPayment
    {
        private bool _readOnly;
        private bool _isFormatted;
        public frmCash(bool readOnly = false)
        {
            InitializeComponent();
            Payment = null;
            _readOnly = readOnly;
        }
        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            Payment = null;
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void frmCash_Load(object sender, EventArgs e)
        {
            if(Payment != null)
            {
                LoadData();
            }
        }
        private void txtImport_Leave(object sender, EventArgs e)
        {
            txtImport.Text = txtImport.Text.Replace(".", UiUtils.GetDecimalSeparator()).Replace(",", UiUtils.GetDecimalSeparator());
            _isFormatted = true;
            double import = 0;
            if (double.TryParse(txtImport.Text, out import))
            {
                txtImport.Text = import.ToString("#.00");
            }
        }
        #endregion
        #region Methods
        private bool IsValid()
        {
            if (!_isFormatted)
            {
                txtImport.Text = txtImport.Text.Replace(".", UiUtils.GetDecimalSeparator()).Replace(",", UiUtils.GetDecimalSeparator());
            }
            return Validator.RequiredFieldValidator(txtImport, epCash) &&
                Validator.CheckDoubleType(txtImport, epCash) &&
                Validator.GraterThanValidator(double.Parse(txtImport.Text), 0, txtImport, epCash);
        }
        private void Save()
        {
            if (!IsValid()) return;
            var cash = new Cash
            {
                Import = double.Parse(txtImport.Text),
                Notes = txtNotes.Text
            };
            Payment = cash;
            Close();
        }
        private void LoadData()
        {
            txtImport.Text = Payment.Import.ToString("#.00");
            txtNotes.Text = Payment.Notes;
            SetupControls();
        }
        private void SetupControls()
        {
            if (_readOnly)
            {
                txtImport.Enabled = false;
                txtNotes.Enabled = false;
                btnSave.Visible = false;
            }
        }
        #endregion
    }
}
