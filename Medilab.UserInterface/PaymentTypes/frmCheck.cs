using Medilab.BusinessObjects.Payment;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medilab.UserInterface.PaymentTypes
{
    public partial class frmCheck : frmPayment
    {
        private bool _readOnly;
        public frmCheck(bool readOnly = false)
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
        private void frmCheck_Load(object sender, EventArgs e)
        {
            if (Payment != null)
            {
                LoadData();   
            }
        }
        private void txtImport_Leave(object sender, EventArgs e)
        {
            txtImport.Text = txtImport.Text.Replace(".", UiUtils.GetDecimalSeparator()).Replace(",", UiUtils.GetDecimalSeparator());
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
            epCheck.Clear();
            var areCommonFieldsValid = (Validator.RequiredFieldValidator(txtImport, epCheck) &&
                Validator.CheckDoubleType(txtImport, epCheck) &&
                Validator.GraterThanValidator(double.Parse(txtImport.Text), 0, txtImport, epCheck)) &
                Validator.RequiredFieldValidator(txtBankName, epCheck) &
                Validator.RequiredFieldValidator(txtCheckNumber, epCheck);
            var isOwnerNameValid = true;
            if(!chkIsOwner.Checked)
            {
                isOwnerNameValid = Validator.RequiredFieldValidator(txtOwnerName, epCheck);
            }
            var isIssuanceDateValid = dtpIssuanceDate.Value < DateTime.Today.AddDays(1);
            if (!isIssuanceDateValid)
            {
                epCheck.SetError(dtpIssuanceDate, "La fecha debe ser menor o igual que hoy");
            }
            var isExpirationDateValid = dtpExpirationDate.Value <= dtpIssuanceDate.Value.AddYears(1);
            if (!isExpirationDateValid)
            {
                epCheck.SetError(dtpExpirationDate, "La fecha debe ser menor que un año de la fecha de emisión");
            }
            return areCommonFieldsValid && isIssuanceDateValid && isExpirationDateValid && isOwnerNameValid;
        }
        private void Save()
        {
            if (!IsValid()) return;
            var bankCheck = new Check
            {
                Import = double.Parse(txtImport.Text),
                BankName = txtBankName.Text,
                Number = txtCheckNumber.Text,
                IssuanceDate = dtpIssuanceDate.Value,
                ExpirationDate = dtpExpirationDate.Value,
                OwnerName = txtOwnerName.Text,
                IsOwner = chkIsOwner.Checked,
                Notes = txtNotes.Text
            };
            Payment = bankCheck;
            Close();
        }
        private void LoadData()
        {
            txtImport.Text = Payment.Import.ToString("#.00");
            txtNotes.Text = Payment.Notes;
            txtBankName.Text = ((Check)Payment).BankName;
            txtCheckNumber.Text = ((Check)Payment).Number;
            txtOwnerName.Text = ((Check)Payment).OwnerName;
            chkIsOwner.Checked = ((Check)Payment).IsOwner;
            dtpIssuanceDate.Value = ((Check)Payment).IssuanceDate;
            dtpExpirationDate.Value = ((Check)Payment).ExpirationDate;
            SetupControls();
        }
        private void SetupControls()
        {
            if (_readOnly)
            {
                txtImport.Enabled = false;
                txtNotes.Enabled = false;
                txtBankName.Enabled = false;
                txtCheckNumber.Enabled = false;
                txtOwnerName.Enabled = false;
                chkIsOwner.Enabled = false;
                dtpExpirationDate.Enabled = false;
                dtpIssuanceDate.Enabled = false;
                btnSave.Visible = false;
            }
        }
        #endregion
    }
}
