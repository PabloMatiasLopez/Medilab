using Medilab.BusinessObjects.Payment;
using Medilab.UserInterface.Utilities;
using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.PaymentTypes
{
    public partial class frmElectronicTransfer : frmPayment
    {
        private bool _readOnly;
        private bool _isFormatted;
        public frmElectronicTransfer(bool readOnly = false)
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
        private void frmElectronicTransfer_Load(object sender, EventArgs e)
        {
            if (Payment != null)
            {
                LoadData();
            }
        }
        private void txtImport_Leave(object sender, EventArgs e)
        {
            txtImport.Text = txtImport.Text.Replace(".", UiUtils.GetDecimalSeparator());
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
                txtImport.Text = txtImport.Text.Replace(".", UiUtils.GetDecimalSeparator());
            }
            return Validator.RequiredFieldValidator(txtImport, epElectronicTransfer) &&
                Validator.CheckDoubleType(txtImport, epElectronicTransfer) &&
                Validator.GraterThanValidator(double.Parse(txtImport.Text), 0, txtImport, epElectronicTransfer);
        }
        private void Save()
        {
            if (!IsValid()) return;
            var transfer = new ElectronicTransfer
            {
                Import = double.Parse(txtImport.Text),
                BankName = txtBankName.Text,
                AccountNumber = txtAccount.Text,
                Notes = txtNotes.Text,
                TransferDate = dtpTransferDate.Value
            };
            Payment = transfer;
            Close();
        }
        private void LoadData()
        {
            txtImport.Text = Payment.Import.ToString("#.00");
            txtNotes.Text = Payment.Notes;
            txtBankName.Text = ((ElectronicTransfer)Payment).BankName;
            txtAccount.Text = ((ElectronicTransfer)Payment).AccountNumber;
            dtpTransferDate.Value = ((ElectronicTransfer)Payment).TransferDate;
            SetupControls();
        }
        private void SetupControls()
        {
            if (_readOnly)
            {
                txtImport.Enabled = false;
                txtNotes.Enabled = false;
                txtBankName.Enabled = false;
                txtAccount.Enabled = false;
                btnSave.Visible = false;
                dtpTransferDate.Enabled = false;
            }
        }
        #endregion
    }
}
