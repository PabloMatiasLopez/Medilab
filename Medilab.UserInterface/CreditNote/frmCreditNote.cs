using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.CreditNote
{
    public partial class frmCreditNote : Form
    {
        NoteType _noteType = NoteType.A;
        Guid _invoiceId = Guid.Empty;
        public frmCreditNote()
        {
            InitializeComponent();
        }
        #region Events
        private void frmCreditNote_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            lblNoteDate.Text = DateTime.Today.ToShortDateString();
            GetNextNumber();
        }
        private void txtInvoiceNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            GetInvoice();
        }
        private void txtInvoiceNumber_Leave(object sender, EventArgs e)
        {
            GetInvoice();
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
        private void LoadDropdowns()
        {
            //client
            cbClient.Items.Clear();
            IList<ListItemDto<Guid>> clients = Client.GetClients().ToList();
            clients.Insert(0, new ListItemDto<Guid> { Id = Guid.Empty, Value = string.Empty });
            cbClient.DataSource = clients;
            cbClient.DisplayMember = "Name";
        }
        private void GetInvoice()
        {
            var invoiceType = _noteType == NoteType.A ? InvoiceType.A : InvoiceType.B;
            var invoice = InvoiceHeader.GetInvoiceByNumber(txtInvoiceNumber.Text, invoiceType);
            if (invoice != null)
            {
                lblInvoiceDetails.Text = string.Format("Fecha: {0}, Importe: {1}, Tipo: {2}{3}Cliente: {4}",
                    invoice.DisplayDate, invoice.Total.ToString("C2"), Medilab.BusinessObjects.CAE.Enums.GetLetraComprobante(invoice.InvoiceType),
                    Environment.NewLine, invoice.ClientName);
                _invoiceId = invoice.InvoiceId;
            }
            else
            {
                lblInvoiceDetails.Text = string.Empty;
                _invoiceId = Guid.Empty;
            }
        }
        private void GetNextNumber()
        {
            var nextNumber = new NextCreditNoteNumber();
            var noteNumber = nextNumber.GetNextNumberDisplay(_noteType);
            var splitNumber = noteNumber.Split('-');
            txtSalePoint.Text = splitNumber[0];
            txtNoteNumber.Text = splitNumber[1];
        }
        private double CalculateIVAImport()
        {
            var import = double.Parse(txtNoteImport.Text);
            return Math.Round(import - (import / 1.21), 2);
        }
        private void Save()
        {
            if (IsNoteValid())
            {
                var newNote = new Medilab.BusinessObjects.DebitCreditNote.CreditNote(Guid.Empty)
                {
                    NoteType = _noteType,
                    CreationDate = DateTime.Now,
                    ClientId = ((ListItemDto<Guid>)cbClient.SelectedItem).Id,
                    Detail = txtNoteDetails.Text,
                    Import = double.Parse(txtNoteImport.Text),
                    SalePoint = int.Parse(txtSalePoint.Text),
                    Number = int.Parse(txtNoteNumber.Text),
                    InvoiceId = _invoiceId,
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
        private bool IsNoteValid()
        {
            return Validator.RequiredFieldValidator(cbClient, epCreditNote) &
                Validator.RequiredFieldValidator(txtNoteDetails, epCreditNote) &
                (Validator.RequiredFieldValidator(txtNoteImport, epCreditNote) &&
                Validator.CheckDoubleType(txtNoteImport, epCreditNote) &&
                Validator.GraterThanValidator(double.Parse(txtNoteImport.Text), 0, txtNoteImport, epCreditNote)) &
                (Validator.RequiredFieldValidator(txtSalePoint, epCreditNote) &&
                Validator.CheckIntType(txtSalePoint, epCreditNote)) &
                (Validator.RequiredFieldValidator(txtNoteNumber, epCreditNote) &&
                Validator.CheckIntType(txtNoteNumber, epCreditNote));
        }
        private void ClearForm()
        {
            GetNextNumber();
            cbClient.SelectedItem = cbClient.Items[0];
            txtInvoiceNumber.Text = string.Empty;
            txtNoteDetails.Text = string.Empty;
            txtNoteImport.Text = string.Empty;
            chkIncludeIVA.Checked = false;
            lblInvoiceDetails.Text = string.Empty;
        }
        #endregion

        private void cbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInvoice();
        }
    }
}
