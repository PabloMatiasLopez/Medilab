using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Payment;
using Medilab.BusinessObjects.Receipt;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.PaymentTypes;
using Medilab.UserInterface.Properties;
using Medilab.BusinessObjects.Invoice;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Receipt
{
    public partial class FrmCreateReceipt : Form
    {
        #region Properties
        private readonly BusinessObjects.Receipt.Receipt _receipt;
        public List<PendingToPayDto> InvoicePaymentDtos;
        private readonly bool _isElectronicReceipt;
        private bool _isReadOnly;
        #endregion

        #region Events
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            var paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), cbPaymentTypes.SelectedItem.ToString().Replace(" ", string.Empty));
            frmPayment paymentForm = PaymentFormFactory.Instace.GetPaymentForm(paymentType);
            paymentForm.StartPosition = FormStartPosition.CenterParent;
            paymentForm.ShowDialog();
            if (paymentForm.Payment != null)
            {
                LoadPaymentsGrid(paymentForm.Payment);
            }
            EnableDisableSave();
        }

        private void gvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvPayments.CurrentRow != null && e.RowIndex != -1)
            {
                var payment = (Payment)gvPayments.CurrentRow.DataBoundItem;
                frmPayment paymentForm = PaymentFormFactory.Instace.GetPaymentForm(payment.GetPaymentType(), _isReadOnly);
                paymentForm.Payment = payment;
                paymentForm.ShowDialog();
                if (paymentForm.Payment != null)
                {
                    var payments = (List<Payment>)((BindingSource)gvPayments.DataSource).DataSource;
                    int index = gvPayments.CurrentRow.Index;
                    payments[index] = paymentForm.Payment;
                    FillPaymentsGrid(payments);
                    gvPayments.Rows[index].Selected = true;
                }
                EnableDisableSave();
            }
        }

        private void gvPayments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult response = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                               Resources.ConfirmationDialogDeleteTitle,
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                               MessageBoxDefaultButton.Button2);
            if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void gvPayments_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            EnableDisableSave();
        }

        private void gvInvoices_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 5) e.Cancel = true;
            var voucherType = (BusinessObjects.CAE.Enums.TipoComprobante)Enum.Parse(typeof(BusinessObjects.CAE.Enums.TipoComprobante),gvInvoices[2,e.RowIndex].Value.ToString().Replace(" ","_"));
            if (voucherType == BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_A || 
                voucherType == BusinessObjects.CAE.Enums.TipoComprobante.NOTAS_DE_DEBITO_B)
            {
                e.Cancel = true;
            }
        }

        private void gvInvoices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = gvInvoices.Columns[e.ColumnIndex];
            DataGridViewCell cell = gvInvoices.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (col.DataPropertyName == "PaymentAmount")
            {
                string editedValue = cell.EditedFormattedValue.ToString().Contains("$")
                    ? cell.EditedFormattedValue.ToString().Replace('$', ' ').Trim()
                    : cell.EditedFormattedValue.ToString().Trim();
                if (!cell.EditedFormattedValue.ToString().Contains("$"))
                {
                    editedValue = editedValue.Replace(".", UiUtils.GetDecimalSeparator()).Replace(",", UiUtils.GetDecimalSeparator());
                }
                double value;
                if (!Double.TryParse(editedValue, out value))
                {
                    if (cell.FormattedValue != null)
                    {
                        gvInvoices.EditingControl.Text = cell.FormattedValue.ToString();
                    }
                }
                else if (gvInvoices.EditingControl != null)
                {
                    gvInvoices.EditingControl.Text = Math.Round(value, 2).ToString(CultureInfo.CurrentCulture);
                }
            }
        }

        private void gvInvoices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EnableDisableSave();
        }

        private void gvInvoices_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult response = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                               Resources.ConfirmationDialogDeleteTitle,
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                               MessageBoxDefaultButton.Button2);
            if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void gvInvoices_UserDeletedRow(object sender, EventArgs eventArgs)
        {
            EnableDisableSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveReceipt();
        }

        private void mtxtReceiptNumber_OnClick(object sender, EventArgs e)
        {
            ShowNumberWithoutZeros(mtxtReceiptNumber);
        }

        private void mtxtReceiptNumber_OnEnter(object sender, EventArgs e)
        {
            ShowNumberWithoutZeros(mtxtReceiptNumber);
        }

        private void mtxtReceiptNumber_OnLeave(object sender, EventArgs e)
        {
            mtxtReceiptNumber.Text = mtxtReceiptNumber.Text.PadLeft(8, '0');
        }

        private void mtxtMasterNumber_OnClick(object sender, EventArgs e)
        {
            ShowNumberWithoutZeros(mtxtMasterNumber);
        }

        private void mtxtMasterNumber_OnEnter(object sender, EventArgs e)
        {
            ShowNumberWithoutZeros(mtxtMasterNumber);
        }

        private void mtxtMasterNumber_OnLeave(object sender, EventArgs e)
        {
            mtxtMasterNumber.Text = mtxtMasterNumber.Text.PadLeft(4, '0');
        }

        private void mtxt_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void mtxt_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.KeyChar = (char)0;
            }
        }
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            FormatDiscount();
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormatDiscount();
            }
        }
        #endregion

        #region Methods
        public FrmCreateReceipt(Guid receiptId)
        {
            _receipt = BusinessObjects.Receipt.Receipt.GetReceiptById(receiptId);
            InvoicePaymentDtos = _receipt.PaidInvoices;
            _isElectronicReceipt = false;
            InitializeComponent();
            dtpDate.MaxDate = DateTime.Now.Date;
            mtxtMasterNumber.Text = _receipt.ReceiptNumber.Substring(0,4);
            mtxtReceiptNumber.Text = _receipt.ReceiptNumber.Substring(5, 8);
            dtpDate.Value = _receipt.Date.Date;
            txtReceiverName.Text = _receipt.ReceiverName;
            txtDiscount.Text = _receipt.Discount.ToString("N2");
            txtNotes.Text = _receipt.Notes;
            LoadClientInformation(Client.GetClient(_receipt.ClientId));
            ReadOnlyForm();
            LoadInvoicesGrid();
            FillPaymentsGrid(_receipt.Payments);
            UpdateTotals();
        }

        public FrmCreateReceipt(List<PendingToPayDto> invoicePaymentDtos, Client client, bool isElectronicReceipt)
        {
            InvoicePaymentDtos = invoicePaymentDtos;
            _receipt = new BusinessObjects.Receipt.Receipt { ClientId = client.Id };
            _isElectronicReceipt = isElectronicReceipt;
            InitializeComponent();
            if (!_isElectronicReceipt)
            {
                mtxtMasterNumber.Text = "0001";
            }
            else
            {
                mtxtMasterNumber.Text = _receipt.ReceiptNumber.Substring(0, 4);
            }
            dtpDate.MaxDate = DateTime.Now.Date;
            dtpDate.Value = DateTime.Now.Date;
            LoadClientInformation(client);
            HideShowLoadFields();
            LoadInvoicesGrid();
            LoadPaymentTypes();
        }

        private void ReadOnlyForm()
        {
            _isReadOnly = true;
            btnAddPayment.Visible = false;
            cbPaymentTypes.Visible = false;
            btnSave.Visible = false;
            gvInvoices.ReadOnly = true;
            gvInvoices.AllowUserToDeleteRows = false;
            gvPayments.ReadOnly = true;
            gvPayments.AllowUserToDeleteRows = false;
            lblTotalInvoices.Text = Resources.TotalPagado;
            mtxtMasterNumber.Enabled = false;
            mtxtReceiptNumber.Enabled = false;
            txtReceiverName.Enabled = false;
            if (!string.IsNullOrWhiteSpace(txtReceiverName.Text))
            {
                txtReceiverName.Visible = true;
                lblReceiverName.Visible = true;
            }
            txtNotes.Enabled = false;
            txtDiscount.Enabled = false;
        }

        private void LoadClientInformation(Client client)
        {
            if (client == null) return;
            lblClientName.Text = client.Name;
            lblClientNumber.Text = client.ClientNumber.ToString(CultureInfo.InvariantCulture);
            lblCUIT.Text = client.Cuit.Trim();
            lblIvaCondition.Text = client.IvaCondition.ToString().Replace("_", " ");
            var defaultAddres = (from ad in client.Addresses where ad.IsDefault select ad).First();
            lblAddress.Text = defaultAddres.ToString();
        }

        private void HideShowLoadFields()
        {
            if (_isElectronicReceipt)
            {
                mtxtMasterNumber.Enabled = false;
                mtxtReceiptNumber.Enabled = false;
                mtxtMasterNumber.Text = _receipt.ReceiptNumber.Substring(0, 4);
                mtxtReceiptNumber.Text = _receipt.ReceiptNumber.Substring(5, 8);
            }
            else
            {
                txtReceiverName.Visible = true;
                lblReceiverName.Visible = true;
                dtpDate.Enabled = true;
            }
        }

        private void LoadPaymentTypes()
        {
            var paymentTypes = EnumUtils.GetDisplayNames(Enum.GetNames(typeof(PaymentType))).ToArray();
            cbPaymentTypes.Items.AddRange(paymentTypes);
            cbPaymentTypes.Text = EnumUtils.AddSpaceInCapitalLetter(BusinessObjects.Utils.PaymentType.TransferenciaElectrónica.ToString());
        }

        private void LoadInvoicesGrid()
        {
            var source = new BindingSource { DataSource = InvoicePaymentDtos };
            gvInvoices.AutoGenerateColumns = false;
            gvInvoices.DataSource = source;
            gvInvoices.Visible = true;
            EnableDisableSave();
        }

        private void LoadPaymentsGrid(Payment payment)
        {
            List<Payment> paymentList;
            if (gvPayments.DataSource == null)
            {
                paymentList = new List<Payment>();
            }
            else
            {
                paymentList = (List<Payment>)((BindingSource)gvPayments.DataSource).DataSource;
            }
            paymentList.Add(payment);
            FillPaymentsGrid(paymentList);
            EnableDisableSave();
        }

        private void SaveReceipt()
        {
            if (!_isElectronicReceipt)
            {
                string number = String.Format("{0}-{1}", mtxtMasterNumber.Text, mtxtReceiptNumber.Text);
                bool hasError = false;
                epNumber.Clear();
                epReceiverName.Clear();
                if (!BusinessObjects.Receipt.Receipt.ReceiptNumberIsValid(number))
                {
                    epNumber.SetError(mtxtReceiptNumber, string.Format("Ya existe un recibo con el numero {0}.", number));
                    hasError = true;
                }
                if (string.IsNullOrWhiteSpace(txtReceiverName.Text))
                {
                    epReceiverName.SetError(txtReceiverName, "Debe ingresar el nombre del cobrador.");
                    hasError = true;
                }
                if (hasError)
                {
                    return;
                }
                _receipt.Date = dtpDate.Value.Date;
                _receipt.ReceiptNumber = number;
                _receipt.ReceiverName = txtReceiverName.Text;
            }
            if (ValidateDiscount())
            {
                _receipt.Discount = double.Parse(txtDiscount.Text);
            }
            _receipt.Notes = txtNotes.Text;
            LoadPaidInvoices();
            LoadPayments();
            try
            {
                _receipt.Save();
                Close();
            }
            catch (Exception ex)
            {
                _receipt.Payments = new List<Payment>();
                _receipt.PaidInvoices = new List<PendingToPayDto>();
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaidInvoices()
        {
            var paidInvoices = (List<PendingToPayDto>)((BindingSource)gvInvoices.DataSource).DataSource;
            foreach (var invoicePaymentDto in paidInvoices)
            {
                _receipt.PaidInvoices.Add(invoicePaymentDto);
            }
        }

        private void LoadPayments()
        {
            var payments = (List<Payment>)((BindingSource)gvPayments.DataSource).DataSource;
            foreach (Payment payment in payments)
            {
                _receipt.Payments.Add(payment);
            }
        }

        private void EnableDisableSave()
        {
            if (ListsAreValid())
            {
                double discount = 0;
                if (ValidateDiscount())
                {
                    discount = double.Parse(txtDiscount.Text);
                }
                btnSave.Enabled = Math.Abs(GetInvoicesTotal() - GetPaymentsTotal() - discount) < 0.0001;
            }
            else
            {
                btnSave.Enabled = false;
            }
            UpdateTotals();
        }

        private bool ListsAreValid()
        {
            if (gvInvoices.RowCount == 0 || gvPayments.RowCount == 0)
            {
                return false;
            }
            var paidInvoices = (List<PendingToPayDto>)((BindingSource)gvInvoices.DataSource).DataSource;
            return !paidInvoices.Any(i => Math.Abs(i.PaymentAmount) < 0.0001);
        }

        private double GetPaymentsTotal()
        {
            if (gvPayments.DataSource != null)
            {
                var payments = (List<Payment>) ((BindingSource) gvPayments.DataSource).DataSource;
                return payments.Aggregate<Payment, double>(0, (current, payment) => current + payment.Import);
            }
            return 0;
        }

        private double GetInvoicesTotal()
        {
            var invoices = (List<PendingToPayDto>)((BindingSource)gvInvoices.DataSource).DataSource;
            return invoices.Aggregate<PendingToPayDto, double>(0, (current, invoice) => current + invoice.PaymentAmount);
        }

        private void UpdateTotals()
        {
            lblTotalInvoiceValue.Text = GetInvoicesTotal().ToString("C2");
            lblTotalPaymentsValue.Text = GetPaymentsTotal().ToString("C2");
        }

        private void FillPaymentsGrid(List<Payment> payments)
        {
            var source = new BindingSource {DataSource = payments};
            gvPayments.AutoGenerateColumns = false;
            gvPayments.DataSource = source;
            gvPayments.Visible = true;
        }

        private void ShowNumberWithoutZeros(MaskedTextBox textBox)
        {
            textBox.Text = textBox.Text.TrimStart('0');
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }
        #endregion
        private bool ValidateDiscount()
        {
            return Validator.CheckDoubleType(txtDiscount, epNumber);
        }
        private void FormatDiscount()
        {
            if (ValidateDiscount())
            {
                txtDiscount.Text = double.Parse(txtDiscount.Text).ToString("N2");
                EnableDisableSave();
            }
        }
    }
}
