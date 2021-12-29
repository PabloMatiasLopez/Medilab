using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.Receipt
{
    partial class FrmCreateReceipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvInvoices = new System.Windows.Forms.DataGridView();
            this.gvPayments = new System.Windows.Forms.DataGridView();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.cbPaymentTypes = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbDate = new System.Windows.Forms.Label();
            this.lblTotalInvoices = new System.Windows.Forms.Label();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.lblTotalInvoiceValue = new System.Windows.Forms.Label();
            this.lblTotalPaymentsValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblReceiptNumberLabel = new System.Windows.Forms.Label();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.lblClientNumber = new System.Windows.Forms.Label();
            this.lblClientNumberLabel = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblCUITLabel = new System.Windows.Forms.Label();
            this.lblIvaCondition = new System.Windows.Forms.Label();
            this.lblIvaConditionLabel = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientNameLabel = new System.Windows.Forms.Label();
            this.mtxtReceiptNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtMasterNumber = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.epNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.epReceiverName = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtReceiverName = new System.Windows.Forms.TextBox();
            this.lblReceiverName = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceRemainder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPayments)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReceiverName)).BeginInit();
            this.SuspendLayout();
            // 
            // gvInvoices
            // 
            this.gvInvoices.AllowUserToAddRows = false;
            this.gvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNumber,
            this.Date,
            this.Type,
            this.Total,
            this.InvoiceRemainder,
            this.Payment,
            this.InvoiceId});
            this.gvInvoices.Location = new System.Drawing.Point(22, 171);
            this.gvInvoices.Name = "gvInvoices";
            this.gvInvoices.Size = new System.Drawing.Size(543, 150);
            this.gvInvoices.TabIndex = 0;
            this.gvInvoices.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gvInvoices_CellBeginEdit);
            this.gvInvoices.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInvoices_CellEndEdit);
            this.gvInvoices.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvInvoices_CellValidating);
            this.gvInvoices.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gvInvoices_UserDeletedRow);
            this.gvInvoices.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvInvoices_UserDeletingRow);
            // 
            // gvPayments
            // 
            this.gvPayments.AllowUserToAddRows = false;
            this.gvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentType,
            this.PaymentAmount});
            this.gvPayments.Location = new System.Drawing.Point(594, 171);
            this.gvPayments.MultiSelect = false;
            this.gvPayments.Name = "gvPayments";
            this.gvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPayments.Size = new System.Drawing.Size(344, 150);
            this.gvPayments.TabIndex = 1;
            this.gvPayments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPayments_CellDoubleClick);
            this.gvPayments.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gvPayments_UserDeletedRow);
            this.gvPayments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvPayments_UserDeletingRow);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(594, 362);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(108, 23);
            this.btnAddPayment.TabIndex = 2;
            this.btnAddPayment.Text = "Agregar Pago";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // cbPaymentTypes
            // 
            this.cbPaymentTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPaymentTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPaymentTypes.FormattingEnabled = true;
            this.cbPaymentTypes.Location = new System.Drawing.Point(728, 364);
            this.cbPaymentTypes.Name = "cbPaymentTypes";
            this.cbPaymentTypes.Size = new System.Drawing.Size(210, 21);
            this.cbPaymentTypes.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(737, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(847, 503);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(820, 15);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(127, 20);
            this.dtpDate.TabIndex = 14;
            this.dtpDate.Value = new System.DateTime(2015, 4, 11, 13, 3, 18, 579);
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(777, 18);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(37, 13);
            this.lbDate.TabIndex = 15;
            this.lbDate.Text = "Fecha";
            // 
            // lblTotalInvoices
            // 
            this.lblTotalInvoices.AutoSize = true;
            this.lblTotalInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvoices.Location = new System.Drawing.Point(308, 180);
            this.lblTotalInvoices.Name = "lblTotalInvoices";
            this.lblTotalInvoices.Size = new System.Drawing.Size(111, 17);
            this.lblTotalInvoices.TabIndex = 16;
            this.lblTotalInvoices.Text = "Total a pagar:";
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.AutoSize = true;
            this.lblTotalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayment.Location = new System.Drawing.Point(100, 180);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(114, 17);
            this.lblTotalPayment.TabIndex = 17;
            this.lblTotalPayment.Text = "Total cobrado:";
            // 
            // lblTotalInvoiceValue
            // 
            this.lblTotalInvoiceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalInvoiceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvoiceValue.Location = new System.Drawing.Point(425, 180);
            this.lblTotalInvoiceValue.Name = "lblTotalInvoiceValue";
            this.lblTotalInvoiceValue.Size = new System.Drawing.Size(128, 21);
            this.lblTotalInvoiceValue.TabIndex = 18;
            this.lblTotalInvoiceValue.Text = "$ 99.999.999,99";
            this.lblTotalInvoiceValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalPaymentsValue
            // 
            this.lblTotalPaymentsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPaymentsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaymentsValue.Location = new System.Drawing.Point(206, 180);
            this.lblTotalPaymentsValue.Name = "lblTotalPaymentsValue";
            this.lblTotalPaymentsValue.Size = new System.Drawing.Size(148, 21);
            this.lblTotalPaymentsValue.TabIndex = 19;
            this.lblTotalPaymentsValue.Text = "$ 99.999.999,99";
            this.lblTotalPaymentsValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalInvoices);
            this.groupBox1.Controls.Add(this.lblTotalInvoiceValue);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 204);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalPayment);
            this.groupBox2.Controls.Add(this.lblTotalPaymentsValue);
            this.groupBox2.Location = new System.Drawing.Point(584, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 249);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pagos";
            // 
            // lblReceiptNumberLabel
            // 
            this.lblReceiptNumberLabel.AutoSize = true;
            this.lblReceiptNumberLabel.Location = new System.Drawing.Point(12, 18);
            this.lblReceiptNumberLabel.Name = "lblReceiptNumberLabel";
            this.lblReceiptNumberLabel.Size = new System.Drawing.Size(99, 13);
            this.lblReceiptNumberLabel.TabIndex = 22;
            this.lblReceiptNumberLabel.Text = "Número de Recibo:";
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lblClientNumber);
            this.gbHeader.Controls.Add(this.lblClientNumberLabel);
            this.gbHeader.Controls.Add(this.lblCUIT);
            this.gbHeader.Controls.Add(this.lblCUITLabel);
            this.gbHeader.Controls.Add(this.lblIvaCondition);
            this.gbHeader.Controls.Add(this.lblIvaConditionLabel);
            this.gbHeader.Controls.Add(this.lblAddress);
            this.gbHeader.Controls.Add(this.lblAddressLabel);
            this.gbHeader.Controls.Add(this.lblClientName);
            this.gbHeader.Controls.Add(this.lblClientNameLabel);
            this.gbHeader.Location = new System.Drawing.Point(15, 44);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(936, 99);
            this.gbHeader.TabIndex = 24;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "Datos Cliente";
            // 
            // lblClientNumber
            // 
            this.lblClientNumber.AutoSize = true;
            this.lblClientNumber.Location = new System.Drawing.Point(447, 58);
            this.lblClientNumber.Name = "lblClientNumber";
            this.lblClientNumber.Size = new System.Drawing.Size(19, 13);
            this.lblClientNumber.TabIndex = 0;
            this.lblClientNumber.Text = "23";
            // 
            // lblClientNumberLabel
            // 
            this.lblClientNumberLabel.AutoSize = true;
            this.lblClientNumberLabel.Location = new System.Drawing.Point(372, 58);
            this.lblClientNumberLabel.Name = "lblClientNumberLabel";
            this.lblClientNumberLabel.Size = new System.Drawing.Size(72, 13);
            this.lblClientNumberLabel.TabIndex = 0;
            this.lblClientNumberLabel.Text = "Nº de Cliente:";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(96, 77);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(70, 13);
            this.lblCUIT.TabIndex = 0;
            this.lblCUIT.Text = "30-52585654";
            // 
            // lblCUITLabel
            // 
            this.lblCUITLabel.AutoSize = true;
            this.lblCUITLabel.Location = new System.Drawing.Point(7, 77);
            this.lblCUITLabel.Name = "lblCUITLabel";
            this.lblCUITLabel.Size = new System.Drawing.Size(47, 13);
            this.lblCUITLabel.TabIndex = 0;
            this.lblCUITLabel.Text = "C.U.I.T.:";
            // 
            // lblIvaCondition
            // 
            this.lblIvaCondition.AutoSize = true;
            this.lblIvaCondition.Location = new System.Drawing.Point(97, 58);
            this.lblIvaCondition.Name = "lblIvaCondition";
            this.lblIvaCondition.Size = new System.Drawing.Size(127, 13);
            this.lblIvaCondition.TabIndex = 0;
            this.lblIvaCondition.Text = "IVA Responsable Incripto";
            // 
            // lblIvaConditionLabel
            // 
            this.lblIvaConditionLabel.AutoSize = true;
            this.lblIvaConditionLabel.Location = new System.Drawing.Point(7, 58);
            this.lblIvaConditionLabel.Name = "lblIvaConditionLabel";
            this.lblIvaConditionLabel.Size = new System.Drawing.Size(27, 13);
            this.lblIvaConditionLabel.TabIndex = 0;
            this.lblIvaConditionLabel.Text = "IVA:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(97, 38);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(131, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Libertad 2057, godoy Cruz";
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Location = new System.Drawing.Point(7, 38);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(52, 13);
            this.lblAddressLabel.TabIndex = 0;
            this.lblAddressLabel.Text = "Domicilio:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(97, 20);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(170, 13);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "FRAGAPANE HERMANOS S.R.L.";
            // 
            // lblClientNameLabel
            // 
            this.lblClientNameLabel.AutoSize = true;
            this.lblClientNameLabel.Location = new System.Drawing.Point(7, 20);
            this.lblClientNameLabel.Name = "lblClientNameLabel";
            this.lblClientNameLabel.Size = new System.Drawing.Size(42, 13);
            this.lblClientNameLabel.TabIndex = 0;
            this.lblClientNameLabel.Text = "Cliente:";
            // 
            // mtxtReceiptNumber
            // 
            this.mtxtReceiptNumber.Location = new System.Drawing.Point(158, 15);
            this.mtxtReceiptNumber.Mask = "00000000";
            this.mtxtReceiptNumber.Name = "mtxtReceiptNumber";
            this.mtxtReceiptNumber.PromptChar = ' ';
            this.mtxtReceiptNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mtxtReceiptNumber.Size = new System.Drawing.Size(55, 20);
            this.mtxtReceiptNumber.TabIndex = 26;
            this.mtxtReceiptNumber.Text = "00000000";
            this.mtxtReceiptNumber.Click += new System.EventHandler(this.mtxtReceiptNumber_OnClick);
            this.mtxtReceiptNumber.Enter += new System.EventHandler(this.mtxtReceiptNumber_OnEnter);
            this.mtxtReceiptNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_OnKeyPress);
            this.mtxtReceiptNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxt_OnKeyUp);
            this.mtxtReceiptNumber.Leave += new System.EventHandler(this.mtxtReceiptNumber_OnLeave);
            // 
            // mtxtMasterNumber
            // 
            this.mtxtMasterNumber.Location = new System.Drawing.Point(115, 15);
            this.mtxtMasterNumber.Mask = "0000";
            this.mtxtMasterNumber.Name = "mtxtMasterNumber";
            this.mtxtMasterNumber.PromptChar = ' ';
            this.mtxtMasterNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mtxtMasterNumber.Size = new System.Drawing.Size(31, 20);
            this.mtxtMasterNumber.TabIndex = 25;
            this.mtxtMasterNumber.Text = "0002";
            this.mtxtMasterNumber.Click += new System.EventHandler(this.mtxtMasterNumber_OnClick);
            this.mtxtMasterNumber.Enter += new System.EventHandler(this.mtxtMasterNumber_OnEnter);
            this.mtxtMasterNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_OnKeyPress);
            this.mtxtMasterNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxt_OnKeyUp);
            this.mtxtMasterNumber.Leave += new System.EventHandler(this.mtxtMasterNumber_OnLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "-";
            // 
            // epNumber
            // 
            this.epNumber.ContainerControl = this;
            // 
            // epReceiverName
            // 
            this.epReceiverName.ContainerControl = this;
            // 
            // txtReceiverName
            // 
            this.txtReceiverName.Location = new System.Drawing.Point(468, 15);
            this.txtReceiverName.Name = "txtReceiverName";
            this.txtReceiverName.Size = new System.Drawing.Size(145, 20);
            this.txtReceiverName.TabIndex = 28;
            this.txtReceiverName.Visible = false;
            // 
            // lblReceiverName
            // 
            this.lblReceiverName.AutoSize = true;
            this.lblReceiverName.Location = new System.Drawing.Point(354, 18);
            this.lblReceiverName.Name = "lblReceiverName";
            this.lblReceiverName.Size = new System.Drawing.Size(108, 13);
            this.lblReceiverName.TabIndex = 29;
            this.lblReceiverName.Text = "Nombre de Cobrador:";
            this.lblReceiverName.Visible = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(430, 364);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(135, 20);
            this.txtDiscount.TabIndex = 28;
            this.txtDiscount.Text = "0,00";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyUp);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(320, 365);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(90, 17);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.Text = "Descuento:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(19, 384);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(81, 13);
            this.lblNotes.TabIndex = 29;
            this.lblNotes.Text = "Observaciones:";
            this.lblNotes.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(22, 400);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(925, 97);
            this.txtNotes.TabIndex = 28;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "InvoiceNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nº";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "InvoiceRemainder";
            this.dataGridViewTextBoxColumn2.HeaderText = "Saldo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PaymentAmount";
            this.dataGridViewTextBoxColumn3.HeaderText = "Pago";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InvoiceId";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "InvoiceId";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PaymentType";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 241;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Import";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "InvoiceId";
            this.dataGridViewTextBoxColumn7.HeaderText = "InvoiceId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PaymentType";
            this.dataGridViewTextBoxColumn8.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Import";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn9.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // PaymentType
            // 
            this.PaymentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PaymentType.DataPropertyName = "PaymentType";
            this.PaymentType.HeaderText = "Tipo";
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.ReadOnly = true;
            // 
            // PaymentAmount
            // 
            this.PaymentAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PaymentAmount.DataPropertyName = "Import";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.PaymentAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.PaymentAmount.HeaderText = "Monto";
            this.PaymentAmount.Name = "PaymentAmount";
            this.PaymentAmount.ReadOnly = true;
            this.PaymentAmount.Width = 90;
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvoiceNumber.DataPropertyName = "Number";
            this.InvoiceNumber.HeaderText = "Nº";
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "CreationDate";
            this.Date.HeaderText = "Fecha";
            this.Date.Name = "Date";
            this.Date.Width = 70;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "VoucherTypeDisplay";
            this.Type.HeaderText = "Tipo";
            this.Type.Name = "Type";
            this.Type.Width = 50;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle1;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.Width = 90;
            // 
            // InvoiceRemainder
            // 
            this.InvoiceRemainder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InvoiceRemainder.DataPropertyName = "Balance";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.InvoiceRemainder.DefaultCellStyle = dataGridViewCellStyle2;
            this.InvoiceRemainder.HeaderText = "Saldo";
            this.InvoiceRemainder.Name = "InvoiceRemainder";
            this.InvoiceRemainder.ReadOnly = true;
            this.InvoiceRemainder.Width = 90;
            // 
            // Payment
            // 
            this.Payment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Payment.DataPropertyName = "PaymentAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Payment.DefaultCellStyle = dataGridViewCellStyle3;
            this.Payment.HeaderText = "Pago";
            this.Payment.Name = "Payment";
            this.Payment.Width = 90;
            // 
            // InvoiceId
            // 
            this.InvoiceId.DataPropertyName = "Id";
            this.InvoiceId.HeaderText = "InvoiceId";
            this.InvoiceId.Name = "InvoiceId";
            this.InvoiceId.ReadOnly = true;
            this.InvoiceId.Visible = false;
            // 
            // FrmCreateReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 545);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblReceiverName);
            this.Controls.Add(this.txtReceiverName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtMasterNumber);
            this.Controls.Add(this.mtxtReceiptNumber);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.lblReceiptNumberLabel);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbPaymentTypes);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.gvPayments);
            this.Controls.Add(this.gvInvoices);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateReceipt";
            this.Text = "Crear Recibo";
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPayments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReceiverName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvInvoices;
        private System.Windows.Forms.DataGridView gvPayments;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.ComboBox cbPaymentTypes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lblTotalInvoices;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label lblTotalInvoiceValue;
        private System.Windows.Forms.Label lblTotalPaymentsValue;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblReceiptNumberLabel;
        private GroupBox gbHeader;
        private Label lblClientNumber;
        private Label lblClientNumberLabel;
        private Label lblCUIT;
        private Label lblCUITLabel;
        private Label lblIvaCondition;
        private Label lblIvaConditionLabel;
        private Label lblAddress;
        private Label lblAddressLabel;
        private Label lblClientName;
        private Label lblClientNameLabel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private MaskedTextBox mtxtReceiptNumber;
        private MaskedTextBox mtxtMasterNumber;
        private Label label1;
        private System.Windows.Forms.ErrorProvider epNumber;
        private System.Windows.Forms.ErrorProvider epReceiverName;
        private Label lblReceiverName;
        private TextBox txtReceiverName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn PaymentType;
        private DataGridViewTextBoxColumn PaymentAmount;
        private DataGridViewTextBoxColumn InvoiceNumber;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn InvoiceRemainder;
        private DataGridViewTextBoxColumn Payment;
        private DataGridViewTextBoxColumn InvoiceId;
        private Label lblDiscount;
        private TextBox txtNotes;
        private TextBox txtDiscount;
        private Label lblNotes;
    }
}