using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Properties;

namespace Medilab.UserInterface.Invoice
{
    public partial class FrmInvoiceEdit : Form
    {
        private readonly InvoiceHeader _invoice;
        public FrmInvoiceEdit(Guid invoiceId)
        {
            InitializeComponent();
            _invoice = InvoiceHeader.GetInvoiceById(invoiceId);
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool confirm = true;
            var status = (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), cbStatus.SelectedItem.ToString());
            if (status == InvoiceStatus.Anulada)
            {
                if (string.IsNullOrWhiteSpace(txtObservations.Text))
                {
                    epComment.SetError(txtObservations, "Debe ingresar un comentario al anular una factura.");
                    return;
                }
                if (_invoice.Status != InvoiceStatus.Anulada)
                {
                    DialogResult rta =
                        MessageBox.Show(String.Format(Resources.QuestionDisableInvoiceText, _invoice.InvoiceNumber),
                            Resources.QuestionDisableInvoiceTitle,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);
                    confirm = rta == DialogResult.Yes;
                }
            }
            if (confirm)
            {
                _invoice.Status = status;
                _invoice.Observation = txtObservations.Text;
                _invoice.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void LoadData()
        {
            string[] invoiceStatus = { };
            switch (_invoice.Status)
            {
                case InvoiceStatus.Anulada:
                    invoiceStatus = new[] { InvoiceStatus.Anulada.ToString() };
                    break;
                case InvoiceStatus.Generada:
                    invoiceStatus = new[] { InvoiceStatus.Generada.ToString(), InvoiceStatus.Anulada.ToString() };
                    break;
                case InvoiceStatus.Impresa:
                    invoiceStatus = new[] { InvoiceStatus.Impresa.ToString(), InvoiceStatus.Anulada.ToString() };
                    break;
                case InvoiceStatus.Pagada:
                    invoiceStatus = new[] { InvoiceStatus.Pagada.ToString(), InvoiceStatus.Anulada.ToString() };
                    break;
            }

            cbStatus.Items.AddRange(invoiceStatus);
            cbStatus.SelectedIndex = 0;
            txtObservations.Text = _invoice.Observation;
            CheckEditPrivilege();
        }

        private void CheckEditPrivilege()
        {
            var canEdit = Security.IsAuthozired(SecurityAreas.EditInvoice);
            cbStatus.Enabled = canEdit && _invoice.Status != InvoiceStatus.Anulada;
            txtObservations.Enabled = canEdit;
            btnSave.Enabled = canEdit;
        }
    }
}
