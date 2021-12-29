using Medilab.BusinessObjects.Payment;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.PaymentTypes
{
    public partial class frmCreditNotePayment : frmPayment
    {
        private readonly bool _readOnly;
        private NoteType _noteType;
        public frmCreditNotePayment(bool readOnly = false)
        {
            InitializeComponent();
            Payment = null;
            _readOnly = readOnly;
            cbNoteType.Items.Clear();
            cbNoteType.Items.AddRange(new object[] { "A", "B" });
            cbNoteType.Text = "A";
            _noteType = NoteType.A;
        }

        #region Events
        private void frmCreditNotePayment_Load(object sender, EventArgs e)
        {
            if (Payment != null)
            {
                LoadData();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Payment = null;
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void txtNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            GetCreditNote();
        }
        private void txtNumber_Leave(object sender, EventArgs e)
        {
            GetCreditNote();
        }

        private void cbNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim() != "-")
            {
                GetCreditNote();   
            }
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            txtImport.Text = Payment.Import.ToString("#.00");
            txtNotes.Text = Payment.Notes;
            txtNumber.Text = ((CreditNotePayment)Payment).NoteNumber;
            SetupControls();
        }
        private void SetupControls()
        {
            if (_readOnly)
            {
                txtNumber.Enabled = false;
                txtImport.Enabled = false;
                txtNotes.Enabled = false;
                btnSave.Visible = false;
            }
        }
        private bool IsValid()
        {
            return (Validator.RequiredFieldValidator(txtImport, epCreditNote) &&
                Validator.CheckDoubleType(txtImport, epCreditNote) &&
                Validator.GraterThanValidator(double.Parse(txtImport.Text), 0, txtImport, epCreditNote)) &
                Validator.RequiredFieldValidator(txtNumber, epCreditNote);
        }
        private void Save()
        {
            if (!IsValid()) return;
            var note = new CreditNotePayment
            {
                Import = double.Parse(txtImport.Text),
                Notes = txtNotes.Text,
                NoteNumber = txtNumber.Text,
                CreditNoteType = _noteType
            };
            Payment = note;
            Close();
        }
        private void GetCreditNote()
        {
            try
            {
                _noteType = (NoteType)Enum.Parse(typeof(NoteType), cbNoteType.Text, true);
                var creditNote = BusinessObjects.DebitCreditNote.CreditNote.GetCreditNote(txtNumber.Text, _noteType);
                txtImport.Text = creditNote != null ? creditNote.Import.ToString("#.00") : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
