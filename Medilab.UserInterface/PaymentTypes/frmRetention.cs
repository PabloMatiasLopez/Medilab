using Medilab.BusinessObjects.Payment;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.PaymentTypes
{
    public partial class frmRetention : frmPayment
    {
        private bool _readOnly;
        private bool _isFormatted;
        public frmRetention(bool readOnly = false) 
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
        private void frmRetention_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
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
        private void LoadDropdowns()
        {
            cbRetentionType.Items.Clear();
            cbRetentionType.Items.AddRange(EnumUtils.GetDisplayNames(Enum.GetNames(typeof(RetentionType))).ToArray());
            cbRetentionType.Text = EnumUtils.AddSpaceInCapitalLetter(RetentionType.IVA.ToString());
        }
        private bool IsValid()
        {
            if (_isFormatted)
            {
                txtImport.Text = txtImport.Text.Replace(".", UiUtils.GetDecimalSeparator()).Replace(",", UiUtils.GetDecimalSeparator());   
            }
            return (Validator.RequiredFieldValidator(txtImport, epRetention) &&
                Validator.CheckDoubleType(txtImport, epRetention) &&
                Validator.GraterThanValidator(double.Parse(txtImport.Text), 0, txtImport, epRetention)) &
                Validator.RequiredFieldValidator(cbRetentionType, epRetention);
        }
        private void Save()
        {
            if (!IsValid()) return;
            var retention = new Retention
            {
                Import = double.Parse(txtImport.Text),
                CertificateNumber = txtCertificateNumber.Text,
                Notes = txtNotes.Text,
                TypeOfRetention = (RetentionType)Enum.Parse(typeof(RetentionType), cbRetentionType.Text.Replace(" ", string.Empty))
            };
            Payment = retention;
            Close();
        }
        private void LoadData()
        {
            txtImport.Text = Payment.Import.ToString("#.00");
            txtNotes.Text = Payment.Notes;
            txtCertificateNumber.Text = ((Retention)Payment).CertificateNumber;
            cbRetentionType.Text = EnumUtils.AddSpaceInCapitalLetter(Enum.GetName(typeof(RetentionType), ((Retention)Payment).TypeOfRetention));
            SetupControls();
        }
        private void SetupControls()
        {
            if(_readOnly)
            {
                txtImport.Enabled = false;
                txtNotes.Enabled = false;
                txtCertificateNumber.Enabled = false;
                cbRetentionType.Enabled = false;
                btnSave.Visible = false;
            }
        }
        #endregion
    }
}
