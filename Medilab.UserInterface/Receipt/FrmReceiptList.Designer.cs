using System.Windows.Forms;

namespace Medilab.UserInterface.Receipt
{
    partial class FrmReceiptList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvReceipt = new System.Windows.Forms.DataGridView();
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtmDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblReceiptNumber = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchByInvoice = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.btnSearchByReceipt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.btnCombinedSearch = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvReceipt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvReceipt
            // 
            this.gvReceipt.AllowUserToAddRows = false;
            this.gvReceipt.AllowUserToDeleteRows = false;
            this.gvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptId,
            this.Cliente,
            this.ReceiptNumber,
            this.Fecha,
            this.Total});
            this.gvReceipt.Location = new System.Drawing.Point(13, 147);
            this.gvReceipt.Name = "gvReceipt";
            this.gvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvReceipt.Size = new System.Drawing.Size(886, 312);
            this.gvReceipt.TabIndex = 0;
            this.gvReceipt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvReceipt_CellDoubleClick);
            this.gvReceipt.SelectionChanged += new System.EventHandler(this.gvReceipt_SelectionChanged);
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Location = new System.Drawing.Point(107, 27);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Size = new System.Drawing.Size(127, 20);
            this.txtReceiptNumber.TabIndex = 1;
            this.txtReceiptNumber.TextChanged += new System.EventHandler(this.txtReceiptNumber_TextChanged);
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(5, 42);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(326, 21);
            this.cbClient.TabIndex = 2;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(483, 42);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // dtmDateTo
            // 
            this.dtmDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateTo.Location = new System.Drawing.Point(628, 42);
            this.dtmDateTo.Name = "dtmDateTo";
            this.dtmDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtmDateTo.TabIndex = 5;
            // 
            // lblReceiptNumber
            // 
            this.lblReceiptNumber.AutoSize = true;
            this.lblReceiptNumber.Location = new System.Drawing.Point(6, 30);
            this.lblReceiptNumber.Name = "lblReceiptNumber";
            this.lblReceiptNumber.Size = new System.Drawing.Size(91, 13);
            this.lblReceiptNumber.TabIndex = 6;
            this.lblReceiptNumber.Text = "Número de recibo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchByInvoice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInvoiceNumber);
            this.groupBox1.Controls.Add(this.btnSearchByReceipt);
            this.groupBox1.Controls.Add(this.lblReceiptNumber);
            this.groupBox1.Controls.Add(this.txtReceiptNumber);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(886, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por número de recibo";
            // 
            // btnSearchByInvoice
            // 
            this.btnSearchByInvoice.Enabled = false;
            this.btnSearchByInvoice.Location = new System.Drawing.Point(663, 25);
            this.btnSearchByInvoice.Name = "btnSearchByInvoice";
            this.btnSearchByInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnSearchByInvoice.TabIndex = 10;
            this.btnSearchByInvoice.Text = "Buscar";
            this.btnSearchByInvoice.UseVisualStyleBackColor = true;
            this.btnSearchByInvoice.Click += new System.EventHandler(this.btnSearchByInvoice_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Número de comprobante";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(530, 27);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(127, 20);
            this.txtInvoiceNumber.TabIndex = 8;
            this.txtInvoiceNumber.TextChanged += new System.EventHandler(this.txtInvoiceNumber_TextChanged);
            // 
            // btnSearchByReceipt
            // 
            this.btnSearchByReceipt.Enabled = false;
            this.btnSearchByReceipt.Location = new System.Drawing.Point(240, 25);
            this.btnSearchByReceipt.Name = "btnSearchByReceipt";
            this.btnSearchByReceipt.Size = new System.Drawing.Size(100, 23);
            this.btnSearchByReceipt.TabIndex = 7;
            this.btnSearchByReceipt.Text = "Buscar";
            this.btnSearchByReceipt.UseVisualStyleBackColor = true;
            this.btnSearchByReceipt.Click += new System.EventHandler(this.btnSearchByReceipt_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(14, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(885, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda combinada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Número de Cliente";
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Location = new System.Drawing.Point(337, 42);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(140, 20);
            this.txtClientNumber.TabIndex = 10;
            this.txtClientNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientNumber_KeyPress);
            // 
            // btnCombinedSearch
            // 
            this.btnCombinedSearch.Location = new System.Drawing.Point(774, 39);
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
            this.lblDateTo.Location = new System.Drawing.Point(629, 26);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(68, 13);
            this.lblDateTo.TabIndex = 9;
            this.lblDateTo.Text = "Fecha Hasta";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(480, 26);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(69, 13);
            this.lblDateFrom.TabIndex = 8;
            this.lblDateFrom.Text = "Fecha desde";
            // 
            // lblCLiente
            // 
            this.lblCLiente.AutoSize = true;
            this.lblCLiente.Location = new System.Drawing.Point(6, 26);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(94, 13);
            this.lblCLiente.TabIndex = 6;
            this.lblCLiente.Text = "Nombre de Cliente";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(788, 465);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 23);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(667, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ReceiptId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ReceiptId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ClientName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 440;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ReceiptNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "Número de recibo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DisplayDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Total";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // ReceiptId
            // 
            this.ReceiptId.DataPropertyName = "ReceiptId";
            this.ReceiptId.HeaderText = "ReceiptId";
            this.ReceiptId.Name = "ReceiptId";
            this.ReceiptId.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "ClientName";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 440;
            // 
            // ReceiptNumber
            // 
            this.ReceiptNumber.DataPropertyName = "ReceiptNumber";
            this.ReceiptNumber.HeaderText = "Número de recibo";
            this.ReceiptNumber.Name = "ReceiptNumber";
            this.ReceiptNumber.ReadOnly = true;
            this.ReceiptNumber.Width = 200;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "DisplayDate";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
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
            this.Total.ReadOnly = true;
            // 
            // FrmReceiptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 504);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReceiptList";
            this.Text = "Listado de Recibos";
            ((System.ComponentModel.ISupportInitialize)(this.gvReceipt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvReceipt;
        private System.Windows.Forms.TextBox txtReceiptNumber;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtmDateTo;
        private System.Windows.Forms.Label lblReceiptNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchByReceipt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCombinedSearch;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblCLiente;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private Button btnSearchByInvoice;
        private Label label2;
        private TextBox txtInvoiceNumber;
        private Button btnDelete;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}