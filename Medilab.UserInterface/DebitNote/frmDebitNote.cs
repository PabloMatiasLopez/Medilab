using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medilab.UserInterface.DebitNote
{
    public partial class frmDebitNote : Form
    {
        NoteType _noteType = NoteType.A;
        Guid _creditNoteId = Guid.Empty;
        public frmDebitNote()
        {
            InitializeComponent();
        }
        #region Events
        private void frmDebitNote_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            lblNoteDate.Text = DateTime.Today.ToShortDateString();
            GetNextNumber();
        }
        private void txtCreditNoteNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            GetCreditNote();
        }
        private void txtCreditNoteNumber_Leave(object sender, EventArgs e)
        {
            GetCreditNote();
        }
        private void txtNoteImport_Leave(object sender, EventArgs e)
        {
            double import = 0;
            if (double.TryParse(txtNoteImport.Text, out import))
            {
                txtNoteImport.Text = import.ToString("N2");
            }
        }
        private void rbTypeA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTypeA.Checked)
            {
                _noteType = NoteType.A;
                GetNextNumber();
            }
        }
        private void rbTypeB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTypeB.Checked)
            {
                _noteType = NoteType.B;
                GetNextNumber();
            }
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
        private void GetNextNumber()
        {
            var nextNumber = new NextDebitNoteNumber();
            var noteNumber = nextNumber.GetNextNumberDisplay(_noteType);
            var splitNumber = noteNumber.Split('-');
            txtSalePoint.Text = splitNumber[0];
            txtNoteNumber.Text = splitNumber[1];
        }
        private void LoadDropdowns()
        {
            //client
            cbClient.Items.Clear();
            IList<ListItemDto<Guid>> clients = Client.GetClients().ToList();
            clients.Insert(0, new ListItemDto<Guid> { Id = Guid.Empty, Value = string.Empty });
            cbClient.DataSource = clients;
            cbClient.DisplayMember = "Name";
        }
        private void GetCreditNote()
        {
            if (string.IsNullOrWhiteSpace(txtCreditNoteNumber.Text.Replace("-",""))) return;
            var creditNote = BusinessObjects.DebitCreditNote.CreditNote.GetDisplayCreditNote(txtCreditNoteNumber.Text);
            if (creditNote != null)
            {
                lblCreditNoteDetails.Text = string.Format("Fecha: {0}, Importe: {1}, Tipo: {2}{3}Cliente: {4}",
                    creditNote.Date, creditNote.Total.ToString("C2"), 
                    BusinessObjects.CAE.Enums.GetLetraComprobante(BusinessObjects.CAE.Enums.GetTipoCreditNote(creditNote.NoteType)),
                    Environment.NewLine, creditNote.ClientName);
                _creditNoteId = creditNote.NoteId;
            }
            else
            {
                lblCreditNoteDetails.Text = string.Empty;
                _creditNoteId = Guid.Empty;
            }
        }
        private void Save()
        {
            if (IsNoteValid())
            {
                var newNote = new Medilab.BusinessObjects.DebitCreditNote.DebitNote(Guid.Empty)
                {
                    NoteType = _noteType,
                    CreationDate = DateTime.Now,
                    ClientId = ((ListItemDto<Guid>)cbClient.SelectedItem).Id,
                    Detail = txtNoteDetails.Text,
                    Import = double.Parse(txtNoteImport.Text),
                    SalePoint = int.Parse(txtSalePoint.Text),
                    Number = int.Parse(txtNoteNumber.Text),
                    InvoiceId = _creditNoteId,
                    IncludeIVA = chkIncludeIVA.Checked,
                    IVAImport = chkIncludeIVA.Checked ? CalculateIVAImport() : 0,
                    Observations = string.Empty
                };
                try
                {
                    newNote.Save();
                    MessageBox.Show(Resources.VoucherSaveSuccesfulyTitle, Resources.VoucherSaveSuccesfulyText, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.ErrorTitle, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearForm()
        {
            cbClient.SelectedItem = cbClient.Items[0];
            txtNoteNumber.Text = string.Empty;
            txtNoteDetails.Text = string.Empty;
            txtNoteImport.Text = string.Empty;
            chkIncludeIVA.Checked = false;
            lblNoteDetails.Text = string.Empty;
            lblCreditNoteDetails.Text = string.Empty;
            txtCreditNoteNumber.Text = string.Empty;
            GetNextNumber();
        }
        private double CalculateIVAImport()
        {
            var import = double.Parse(txtNoteImport.Text);
            return Math.Round(import - (import / 1.21), 2);
        }
        private bool IsNoteValid()
        {
            return Validator.RequiredFieldValidator(cbClient, epDebitNote) &
                Validator.RequiredFieldValidator(txtNoteDetails, epDebitNote) &
                (Validator.RequiredFieldValidator(txtNoteImport, epDebitNote) &&
                Validator.CheckDoubleType(txtNoteImport, epDebitNote) &&
                Validator.GraterThanValidator(double.Parse(txtNoteImport.Text), 0, txtNoteImport, epDebitNote)) &
                (Validator.RequiredFieldValidator(txtSalePoint, epDebitNote) &&
                Validator.CheckIntType(txtSalePoint, epDebitNote)) &
                (Validator.RequiredFieldValidator(txtNoteNumber, epDebitNote) &&
                Validator.CheckIntType(txtNoteNumber, epDebitNote));
        }
        #endregion
    }
}
