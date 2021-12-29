using System.Windows.Forms;

namespace Medilab.UserInterface.Invoice
{
    partial class FrmInvoiceListPaidRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.btnCombinedSearch = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.dtmDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchByInvoice = new System.Windows.Forms.Button();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.gvInvoice = new System.Windows.Forms.DataGridView();
            this.InvoiceHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remainder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPaymentRegistration = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegisterPaymentExistent = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtClientNumber);
            this.groupBox2.Controls.Add(this.btnCombinedSearch);
            this.groupBox2.Controls.Add(this.lblDateTo);
            this.groupBox2.Controls.Add(this.lblDateFrom);
            this.groupBox2.Controls.Add(this.lblCLiente);
            this.groupBox2.Controls.Add(this.cbClient);
            this.groupBox2.Controls.Add(this.dtmDateTo);
            this.groupBox2.Controls.Add(this.dtpDateFrom);
            this.groupBox2.Location = new System.Drawing.Point(13, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1116, 70);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda combinada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Número de Cliente";
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Location = new System.Drawing.Point(572, 40);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(140, 20);
            this.txtClientNumber.TabIndex = 10;
            this.txtClientNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientNumber_KeyPress);
            // 
            // btnCombinedSearch
            // 
            this.btnCombinedSearch.Location = new System.Drawing.Point(1010, 38);
            this.btnCombinedSearch.Name = "btnCombinedSearch";
            this.btnCombinedSearch.Size = new System.Drawing.Size(100, 23);
            this.btnCombinedSearch.TabIndex = 8;
            this.btnCombinedSearch.Text = "Buscar";
            this.btnCombinedSearch.UseVisualStyleBackColor = true;
            this.btnCombinedSearch.Click += new System.EventHandler(this.btnCombinedSearch_Click_1);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(861, 21);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(68, 13);
            this.lblDateTo.TabIndex = 9;
            this.lblDateTo.Text = "Fecha Hasta";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(715, 21);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(69, 13);
            this.lblDateFrom.TabIndex = 8;
            this.lblDateFrom.Text = "Fecha desde";
            // 
            // lblCLiente
            // 
            this.lblCLiente.AutoSize = true;
            this.lblCLiente.Location = new System.Drawing.Point(6, 21);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(94, 13);
            this.lblCLiente.TabIndex = 6;
            this.lblCLiente.Text = "Nombre de Cliente";
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(6, 39);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(560, 21);
            this.cbClient.TabIndex = 2;
            // 
            // dtmDateTo
            // 
            this.dtmDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateTo.Location = new System.Drawing.Point(864, 40);
            this.dtmDateTo.Name = "dtmDateTo";
            this.dtmDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtmDateTo.TabIndex = 5;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(718, 40);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchByInvoice);
            this.groupBox1.Controls.Add(this.lblInvoiceNumber);
            this.groupBox1.Controls.Add(this.txtInvoiceNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1117, 53);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por número de factura";
            // 
            // btnSearchByInvoice
            // 
            this.btnSearchByInvoice.Enabled = false;
            this.btnSearchByInvoice.Location = new System.Drawing.Point(240, 25);
            this.btnSearchByInvoice.Name = "btnSearchByInvoice";
            this.btnSearchByInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnSearchByInvoice.TabIndex = 7;
            this.btnSearchByInvoice.Text = "Buscar";
            this.btnSearchByInvoice.UseVisualStyleBackColor = true;
            this.btnSearchByInvoice.Click += new System.EventHandler(this.btnSearchByInvoice_Click_1);
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
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(107, 27);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(127, 20);
            this.txtInvoiceNumber.TabIndex = 1;
            this.txtInvoiceNumber.TextChanged += new System.EventHandler(this.txtInvoiceNumber_TextChanged_1);
            // 
            // gvInvoice
            // 
            this.gvInvoice.AllowUserToAddRows = false;
            this.gvInvoice.AllowUserToDeleteRows = false;
            this.gvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceHeaderId,
            this.Column1,
            this.Cliente,
            this.InvoiceNumber,
            this.Fecha,
            this.InvoiceType,
            this.Estado,
            this.Subtotal,
            this.Total,
            this.Remainder,
            this.CreateUser,
            this.UpdateUser});
            this.gvInvoice.Location = new System.Drawing.Point(12, 153);
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.Size = new System.Drawing.Size(1117, 312);
            this.gvInvoice.TabIndex = 9;
            // 
            // InvoiceHeaderId
            // 
            this.InvoiceHeaderId.DataPropertyName = "Id";
            this.InvoiceHeaderId.HeaderText = "HeaderID";
            this.InvoiceHeaderId.Name = "InvoiceHeaderId";
            this.InvoiceHeaderId.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 25;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cliente.DataPropertyName = "ClientName";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.DataPropertyName = "Number";
            this.InvoiceNumber.HeaderText = "Número de factura";
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "CreationDate";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 80;
            // 
            // InvoiceType
            // 
            this.InvoiceType.DataPropertyName = "VoucherTypeDisplay";
            this.InvoiceType.HeaderText = "Tipo";
            this.InvoiceType.Name = "InvoiceType";
            this.InvoiceType.ReadOnly = true;
            this.InvoiceType.Width = 60;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Status";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 80;
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
            this.Subtotal.Width = 90;
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
            this.Total.Width = 90;
            // 
            // Remainder
            // 
            this.Remainder.DataPropertyName = "Balance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Remainder.DefaultCellStyle = dataGridViewCellStyle3;
            this.Remainder.HeaderText = "Saldo";
            this.Remainder.Name = "Remainder";
            this.Remainder.ReadOnly = true;
            this.Remainder.Width = 90;
            // 
            // CreateUser
            // 
            this.CreateUser.DataPropertyName = "CreatedBy";
            this.CreateUser.HeaderText = "Creado Por";
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.ReadOnly = true;
            // 
            // UpdateUser
            // 
            this.UpdateUser.DataPropertyName = "UpdatedBy";
            this.UpdateUser.HeaderText = "Actualizado por";
            this.UpdateUser.Name = "UpdateUser";
            this.UpdateUser.ReadOnly = true;
            // 
            // btnPaymentRegistration
            // 
            this.btnPaymentRegistration.Location = new System.Drawing.Point(1014, 472);
            this.btnPaymentRegistration.Name = "btnPaymentRegistration";
            this.btnPaymentRegistration.Size = new System.Drawing.Size(115, 22);
            this.btnPaymentRegistration.TabIndex = 12;
            this.btnPaymentRegistration.Text = "Crear Recibo";
            this.btnPaymentRegistration.UseVisualStyleBackColor = true;
            this.btnPaymentRegistration.Click += new System.EventHandler(this.btnPaymentRegistration_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "InvoiceId";
            this.dataGridViewTextBoxColumn1.HeaderText = "HeaderID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ClientName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "InvoiceNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "Número de factura";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InvoiceDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "InvoiceType";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn6.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SubTotal";
            this.dataGridViewTextBoxColumn7.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Total";
            this.dataGridViewTextBoxColumn8.HeaderText = "Total";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CreateUser";
            this.dataGridViewTextBoxColumn9.HeaderText = "Creado Por";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "UpdateUser";
            this.dataGridViewTextBoxColumn10.HeaderText = "Actualizado por";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UpdateUser";
            this.dataGridViewTextBoxColumn11.HeaderText = "Actualizado por";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // btnRegisterPaymentExistent
            // 
            this.btnRegisterPaymentExistent.Location = new System.Drawing.Point(893, 472);
            this.btnRegisterPaymentExistent.Name = "btnRegisterPaymentExistent";
            this.btnRegisterPaymentExistent.Size = new System.Drawing.Size(115, 22);
            this.btnRegisterPaymentExistent.TabIndex = 13;
            this.btnRegisterPaymentExistent.Text = "Cargar recibo existente";
            this.btnRegisterPaymentExistent.UseVisualStyleBackColor = true;
            this.btnRegisterPaymentExistent.Click += new System.EventHandler(this.btnRegisterPaymentExistent_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(59, 164);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 14;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // FrmInvoiceListPaidRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 506);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnRegisterPaymentExistent);
            this.Controls.Add(this.btnPaymentRegistration);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInvoiceListPaidRecord";
            this.Text = "Registrar pago de Facturas";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCombinedSearch;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblCLiente;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.DateTimePicker dtmDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchByInvoice;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.DataGridView gvInvoice;
        private System.Windows.Forms.Button btnPaymentRegistration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Button btnRegisterPaymentExistent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientNumber;
        private CheckBox chkSelectAll;
        private DataGridViewTextBoxColumn InvoiceHeaderId;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn InvoiceNumber;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn InvoiceType;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Remainder;
        private DataGridViewTextBoxColumn CreateUser;
        private DataGridViewTextBoxColumn UpdateUser;
    }
}