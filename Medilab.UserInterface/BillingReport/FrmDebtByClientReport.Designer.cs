using System.Windows.Forms;

namespace Medilab.UserInterface.BillingReport
{
    partial class FrmDebtByClientReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvBillingMovements = new System.Windows.Forms.DataGridView();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtmDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbOnlyPending = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.btnCombinedSearch = new System.Windows.Forms.Button();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Import = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvBillingMovements)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvBillingMovements
            // 
            this.gvBillingMovements.AllowUserToAddRows = false;
            this.gvBillingMovements.AllowUserToDeleteRows = false;
            this.gvBillingMovements.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvBillingMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBillingMovements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Number,
            this.CreationDate,
            this.DocumentNumber,
            this.Notes,
            this.Import,
            this.Details});
            this.gvBillingMovements.Location = new System.Drawing.Point(12, 81);
            this.gvBillingMovements.Name = "gvBillingMovements";
            this.gvBillingMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBillingMovements.Size = new System.Drawing.Size(919, 369);
            this.gvBillingMovements.TabIndex = 0;
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(5, 35);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(336, 21);
            this.cbClient.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDateTo);
            this.groupBox2.Controls.Add(this.lblDateFrom);
            this.groupBox2.Controls.Add(this.dtmDateTo);
            this.groupBox2.Controls.Add(this.dtpDateFrom);
            this.groupBox2.Controls.Add(this.cbOnlyPending);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtClientNumber);
            this.groupBox2.Controls.Add(this.btnCombinedSearch);
            this.groupBox2.Controls.Add(this.lblCLiente);
            this.groupBox2.Controls.Add(this.cbClient);
            this.groupBox2.Location = new System.Drawing.Point(14, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(917, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(580, 20);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(68, 13);
            this.lblDateTo.TabIndex = 15;
            this.lblDateTo.Text = "Fecha Hasta";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(455, 20);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(69, 13);
            this.lblDateFrom.TabIndex = 14;
            this.lblDateFrom.Text = "Fecha desde";
            // 
            // dtmDateTo
            // 
            this.dtmDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateTo.Location = new System.Drawing.Point(580, 35);
            this.dtmDateTo.Name = "dtmDateTo";
            this.dtmDateTo.Size = new System.Drawing.Size(116, 20);
            this.dtmDateTo.TabIndex = 13;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(458, 35);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(116, 20);
            this.dtpDateFrom.TabIndex = 12;
            // 
            // cbOnlyPending
            // 
            this.cbOnlyPending.AutoSize = true;
            this.cbOnlyPending.Location = new System.Drawing.Point(702, 37);
            this.cbOnlyPending.Name = "cbOnlyPending";
            this.cbOnlyPending.Size = new System.Drawing.Size(103, 17);
            this.cbOnlyPending.TabIndex = 11;
            this.cbOnlyPending.Text = "Solo Pendientes";
            this.cbOnlyPending.UseVisualStyleBackColor = true;
            this.cbOnlyPending.CheckStateChanged += new System.EventHandler(this.cbOnlyPending_CheckStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Número de Cliente";
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Location = new System.Drawing.Point(347, 35);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(105, 20);
            this.txtClientNumber.TabIndex = 9;
            this.txtClientNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientNumber_KeyPress);
            // 
            // btnCombinedSearch
            // 
            this.btnCombinedSearch.Location = new System.Drawing.Point(811, 32);
            this.btnCombinedSearch.Name = "btnCombinedSearch";
            this.btnCombinedSearch.Size = new System.Drawing.Size(100, 23);
            this.btnCombinedSearch.TabIndex = 8;
            this.btnCombinedSearch.Text = "Buscar";
            this.btnCombinedSearch.UseVisualStyleBackColor = true;
            this.btnCombinedSearch.Click += new System.EventHandler(this.btnCombinedSearch_Click);
            // 
            // lblCLiente
            // 
            this.lblCLiente.AutoSize = true;
            this.lblCLiente.Location = new System.Drawing.Point(6, 19);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(39, 13);
            this.lblCLiente.TabIndex = 6;
            this.lblCLiente.Text = "Cliente";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(758, 458);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 9;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IncludeIVA";
            this.dataGridViewCheckBoxColumn1.HeaderText = "IVA";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CreditNoteId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ReceiptId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DisplayNumber";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Número";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CreationDate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Import";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Detail";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Detalles";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Total";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn6.HeaderText = "Total";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(62, 86);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 10;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 30;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Type";
            this.Number.HeaderText = "Tipo";
            this.Number.Name = "Number";
            this.Number.Width = 90;
            // 
            // CreationDate
            // 
            this.CreationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CreationDate.DataPropertyName = "Date";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.CreationDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreationDate.HeaderText = "Fecha";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.Width = 62;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.DataPropertyName = "DocumentNumber";
            this.DocumentNumber.HeaderText = "Numero de Comprobante";
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.Width = 150;
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Notes.DefaultCellStyle = dataGridViewCellStyle2;
            this.Notes.HeaderText = "Notas";
            this.Notes.Name = "Notes";
            this.Notes.Width = 250;
            // 
            // Import
            // 
            this.Import.DataPropertyName = "Remainder";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Import.DefaultCellStyle = dataGridViewCellStyle3;
            this.Import.HeaderText = "Saldo";
            this.Import.Name = "Import";
            // 
            // Details
            // 
            this.Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Details.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Details.DefaultCellStyle = dataGridViewCellStyle4;
            this.Details.HeaderText = "Total";
            this.Details.Name = "Details";
            // 
            // FrmDebtByClientReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 475);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gvBillingMovements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDebtByClientReport";
            this.Text = "Reporte de Deuda por Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.gvBillingMovements)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBillingMovements;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCombinedSearch;
        private System.Windows.Forms.Label lblCLiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientNumber;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Label lblTotal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private CheckBox cbOnlyPending;
        private Label lblDateTo;
        private Label lblDateFrom;
        private DateTimePicker dtmDateTo;
        private DateTimePicker dtpDateFrom;
        private CheckBox chkSelectAll;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn CreationDate;
        private DataGridViewTextBoxColumn DocumentNumber;
        private DataGridViewTextBoxColumn Notes;
        private DataGridViewTextBoxColumn Import;
        private DataGridViewTextBoxColumn Details;
    }
}