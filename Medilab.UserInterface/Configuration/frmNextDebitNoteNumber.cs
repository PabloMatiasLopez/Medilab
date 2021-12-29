using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.Configuration
{
    public partial class frmNextDebitNoteNumber : Form
    {
        #region Variables
        private byte[] _lastUpdated;
        #endregion
        #region Methods
        private void LoadDropdowns()
        {
            cbNoteType.Items.Clear();
            cbNoteType.Items.AddRange(Enum.GetNames(typeof(NoteType)));
            cbNoteType.Text = NoteType.A.ToString();
        }
        private void LoadNextNumber(NoteType noteType)
        {
            var noteNumber = (NextDebitNoteNumber)new NextDebitNoteNumber().GetNextNumber(noteType);
            txtSalePoint.Text = noteNumber.MasterNumber.ToString("0000");
            txtNoteNumber.Text = noteNumber.DebitNoteNumber.ToString("00000000");
            _lastUpdated = noteNumber.LastUpdated;
        }
        private void Save()
        {
            if (!ValidateForm()) return;
            var invoiceType = (NoteType)Enum.Parse(typeof(NoteType), cbNoteType.Text);
            var nextNumber = new NextDebitNoteNumber
            {
                MasterNumber = int.Parse(txtSalePoint.Text),
                DebitNoteNumber = int.Parse(txtNoteNumber.Text),
                LastUpdated = _lastUpdated
            };
            try
            {
                nextNumber.SetNextNumber(invoiceType);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format(@"Ha ocurrido un error: {0}.", ex.Message);
                MessageBox.Show(errorMessage, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtSalePoint, epNextNumber) &
                   Validator.RequiredFieldValidator(txtNoteNumber, epNextNumber) &
                   Validator.CheckIntType(txtSalePoint, epNextNumber) &
                   Validator.CheckIntType(txtNoteNumber, epNextNumber);

        }
        #endregion
        #region Events
        public frmNextDebitNoteNumber()
        {
            InitializeComponent();
        }
        private void frmNextDebitNoteNumber_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
        }
        private void cbNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var noteType = (NoteType)Enum.Parse(typeof(NoteType), cbNoteType.Text);
            LoadNextNumber(noteType);
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
    }
}
