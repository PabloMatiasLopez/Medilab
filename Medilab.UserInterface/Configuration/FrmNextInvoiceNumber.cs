using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmNextInvoiceNumber : Form
    {
        #region Variables
        private byte[] _lastUpdated;
        #endregion
        public FrmNextInvoiceNumber()
        {
            InitializeComponent();
        }
        #region Events
        private void FrmNextInvoiceNumber_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
        }
        private void cbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var invoiceType = (InvoiceType) Enum.Parse(typeof (InvoiceType), cbInvoiceType.Text);
            LoadNextNumber(invoiceType);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion
        #region Methods
        private void LoadDropdowns()
        {
            cbInvoiceType.Items.Clear();
            cbInvoiceType.Items.AddRange(Enum.GetNames(typeof(InvoiceType)));
            cbInvoiceType.Text = InvoiceType.A.ToString();
        }
        private void LoadNextNumber(InvoiceType invoiceType)
        {
            var invoiceNumber = (NextInvoiceNumber) new NextInvoiceNumber().GetNextInvoiceNumber(invoiceType);
            txtMasterNumber.Text = invoiceNumber.MasterNumber.ToString("0000");
            txtInvoiceNumber.Text = invoiceNumber.InvoiceNumber.ToString("00000000");
            _lastUpdated = invoiceNumber.LastUpdated;
        }
        private void Save()
        {
            if(!ValidateForm()) return;
            var invoiceType = (InvoiceType) Enum.Parse(typeof (InvoiceType), cbInvoiceType.Text);
            var nextNumber = new NextInvoiceNumber
                                 {
                                     MasterNumber = int.Parse(txtMasterNumber.Text),
                                     InvoiceNumber = int.Parse(txtInvoiceNumber.Text),
                                     LastUpdated = _lastUpdated
                                 };
            try
            {
                nextNumber.SetNextInvoiceNumber(invoiceType);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format(@"Ha ocurrido un error: {0}.", ex.Message);
                MessageBox.Show(errorMessage, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtMasterNumber, epInvoiceNumber) &
                   Validator.RequiredFieldValidator(txtInvoiceNumber, epInvoiceNumber) &
                   Validator.CheckIntType(txtMasterNumber, epInvoiceNumber) &
                   Validator.CheckIntType(txtInvoiceNumber, epInvoiceNumber);

        }
        #endregion
    }
}
