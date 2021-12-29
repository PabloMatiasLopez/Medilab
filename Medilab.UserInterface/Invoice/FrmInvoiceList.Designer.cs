using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.Invoice
{
    partial class FrmInvoiceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvInvoice = new System.Windows.Forms.DataGridView();
            this.InvoiceHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtmDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbInvoiceType = new System.Windows.Forms.ComboBox();
            this.btnSearchByInvoice = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.btnCombinedSearch = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkIncludeInvoiceDetail = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvInvoice
            // 
            this.gvInvoice.AllowUserToAddRows = false;
            this.gvInvoice.AllowUserToDeleteRows = false;
            this.gvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceHeaderId,
            this.Cliente,
            this.InvoiceNumber,
            this.Fecha,
            this.InvoiceType,
            this.Estado,
            this.Subtotal,
            this.Total,
            this.CreateUser,
            this.UpdateUser});
            this.gvInvoice.Location = new System.Drawing.Point(13, 147);
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.Size = new System.Drawing.Size(986, 312);
            this.gvInvoice.TabIndex = 0;
            this.gvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvInvoice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInvoice_CellDoubleClick);
            this.gvInvoice.SelectionChanged += new System.EventHandler(this.gvInvoice_SelectionChanged);
            // 
            // InvoiceHeaderId
            // 
            this.InvoiceHeaderId.DataPropertyName = "InvoiceId";
            this.InvoiceHeaderId.HeaderText = "HeaderID";
            this.InvoiceHeaderId.Name = "InvoiceHeaderId";
            this.InvoiceHeaderId.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "ClientName";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.DataPropertyName = "InvoiceNumberDisplay";
            this.InvoiceNumber.HeaderText = "Número de factura";
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "InvoiceDate";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // InvoiceType
            // 
            this.InvoiceType.DataPropertyName = "InvoiceType";
            this.InvoiceType.HeaderText = "Tipo";
            this.InvoiceType.Name = "InvoiceType";
            this.InvoiceType.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Status";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // CreateUser
            // 
            this.CreateUser.DataPropertyName = "CreateUser";
            this.CreateUser.HeaderText = "Creado Por";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.ReadOnly = true;
            // 
            // UpdateUser
            // 
            this.UpdateUser.DataPropertyName = "UpdateUser";
            this.UpdateUser.HeaderText = "Actualizado por";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.ReadOnly = true;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(107, 27);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(127, 20);
            this.txtInvoiceNumber.TabIndex = 1;
            this.txtInvoiceNumber.TextChanged += new System.EventHandler(this.txtInvoiceNumber_TextChanged);
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(9, 39);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(373, 21);
            this.cbClient.TabIndex = 2;
            this.cbClient.KeyDown += new KeyEventHandler(cbClient_OnKeyPress);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(510, 39);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(116, 21);
            this.cbStatus.TabIndex = 3;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(632, 40);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(116, 20);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // dtmDateTo
            // 
            this.dtmDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateTo.Location = new System.Drawing.Point(754, 39);
            this.dtmDateTo.Name = "dtmDateTo";
            this.dtmDateTo.Size = new System.Drawing.Size(116, 20);
            this.dtmDateTo.TabIndex = 5;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(6, 30);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(95, 13);
            this.lblInvoiceNumber.TabIndex = 6;
            this.lblInvoiceNumber.Text = "Número de factura";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbInvoiceType);
            this.groupBox1.Controls.Add(this.btnSearchByInvoice);
            this.groupBox1.Controls.Add(this.lblInvoiceNumber);
            this.groupBox1.Controls.Add(this.txtInvoiceNumber);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por número de factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // cbInvoiceType
            // 
            this.cbInvoiceType.FormattingEnabled = true;
            this.cbInvoiceType.Location = new System.Drawing.Point(284, 27);
            this.cbInvoiceType.Name = "cbInvoiceType";
            this.cbInvoiceType.Size = new System.Drawing.Size(35, 21);
            this.cbInvoiceType.TabIndex = 8;
            // 
            // btnSearchByInvoice
            // 
            this.btnSearchByInvoice.Enabled = false;
            this.btnSearchByInvoice.Location = new System.Drawing.Point(344, 25);
            this.btnSearchByInvoice.Name = "btnSearchByInvoice";
            this.btnSearchByInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnSearchByInvoice.TabIndex = 7;
            this.btnSearchByInvoice.Text = "Buscar";
            this.btnSearchByInvoice.UseVisualStyleBackColor = true;
            this.btnSearchByInvoice.Click += new System.EventHandler(this.btnSearchByInvoice_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtClientNumber);
            this.groupBox2.Controls.Add(this.btnCombinedSearch);
            this.groupBox2.Controls.Add(this.lblDateTo);
            this.groupBox2.Controls.Add(this.lblDateFrom);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.lblCLiente);
            this.groupBox2.Controls.Add(this.cbClient);
            this.groupBox2.Controls.Add(this.cbStatus);
            this.groupBox2.Controls.Add(this.dtmDateTo);
            this.groupBox2.Controls.Add(this.dtpDateFrom);
            this.groupBox2.Location = new System.Drawing.Point(14, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(985, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda combinada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Número de Cliente";
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Location = new System.Drawing.Point(388, 39);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(116, 20);
            this.txtClientNumber.TabIndex = 10;
            this.txtClientNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientNumber_KeyPress);
            // 
            // btnCombinedSearch
            // 
            this.btnCombinedSearch.Location = new System.Drawing.Point(876, 37);
            this.btnCombinedSearch.Name = "btnCombinedSearch";
            this.btnCombinedSearch.Size = new System.Drawing.Size(100, 23);
            this.btnCombinedSearch.TabIndex = 8;
            this.btnCombinedSearch.Text = "Buscar";
            this.btnCombinedSearch.UseVisualStyleBackColor = true;
            this.btnCombinedSearch.Click += new System.EventHandler(this.btnCombinedSearch_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(754, 25);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(68, 13);
            this.lblDateTo.TabIndex = 9;
            this.lblDateTo.Text = "Fecha Hasta";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(629, 25);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(69, 13);
            this.lblDateFrom.TabIndex = 8;
            this.lblDateFrom.Text = "Fecha desde";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(507, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Estado";
            // 
            // lblCLiente
            // 
            this.lblCLiente.AutoSize = true;
            this.lblCLiente.Location = new System.Drawing.Point(6, 25);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(94, 13);
            this.lblCLiente.TabIndex = 6;
            this.lblCLiente.Text = "Nombre de Cliente";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(884, 469);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 23);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkIncludeInvoiceDetail
            // 
            this.chkIncludeInvoiceDetail.AutoSize = true;
            this.chkIncludeInvoiceDetail.Location = new System.Drawing.Point(596, 473);
            this.chkIncludeInvoiceDetail.Name = "chkIncludeInvoiceDetail";
            this.chkIncludeInvoiceDetail.Size = new System.Drawing.Size(139, 17);
            this.chkIncludeInvoiceDetail.TabIndex = 10;
            this.chkIncludeInvoiceDetail.Text = "Incluir detalle de factura";
            this.chkIncludeInvoiceDetail.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Location = new System.Drawing.Point(763, 469);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(115, 23);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "Vista Previa";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // FrmInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 504);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.chkIncludeInvoiceDetail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInvoiceList";
            this.Text = "Listado de Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvInvoice;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtmDateTo;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchByInvoice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCombinedSearch;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCLiente;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkIncludeInvoiceDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientNumber;
        private DataGridViewTextBoxColumn InvoiceHeaderId;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn InvoiceNumber;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn InvoiceType;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn CreateUser;
        private DataGridViewTextBoxColumn UpdateUser;
        private Label label2;
        private ComboBox cbInvoiceType;
        private Button btnPreview;
    }
}