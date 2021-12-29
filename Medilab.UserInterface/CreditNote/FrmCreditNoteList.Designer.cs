using System.Windows.Forms;

namespace Medilab.UserInterface.CreditNote
{
    partial class FrmCreditNoteList
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
            this.gvCreditNotes = new System.Windows.Forms.DataGridView();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.btnCombinedSearch = new System.Windows.Forms.Button();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.CreditNoteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Import = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncludeIVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvCreditNotes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvCreditNotes
            // 
            this.gvCreditNotes.AllowUserToAddRows = false;
            this.gvCreditNotes.AllowUserToDeleteRows = false;
            this.gvCreditNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCreditNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreditNoteId,
            this.Number,
            this.CreationDate,
            this.Import,
            this.IncludeIVA,
            this.Details});
            this.gvCreditNotes.Location = new System.Drawing.Point(13, 81);
            this.gvCreditNotes.Name = "gvCreditNotes";
            this.gvCreditNotes.ReadOnly = true;
            this.gvCreditNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCreditNotes.Size = new System.Drawing.Size(923, 312);
            this.gvCreditNotes.TabIndex = 0;
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(5, 42);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(664, 21);
            this.cbClient.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtClientNumber);
            this.groupBox2.Controls.Add(this.btnCombinedSearch);
            this.groupBox2.Controls.Add(this.lblCLiente);
            this.groupBox2.Controls.Add(this.cbClient);
            this.groupBox2.Location = new System.Drawing.Point(14, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(922, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Número de Cliente";
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Location = new System.Drawing.Point(675, 42);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(135, 20);
            this.txtClientNumber.TabIndex = 9;
            this.txtClientNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientNumber_KeyPress);
            // 
            // btnCombinedSearch
            // 
            this.btnCombinedSearch.Location = new System.Drawing.Point(816, 40);
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
            this.lblCLiente.Location = new System.Drawing.Point(6, 26);
            this.lblCLiente.Name = "lblCLiente";
            this.lblCLiente.Size = new System.Drawing.Size(39, 13);
            this.lblCLiente.TabIndex = 6;
            this.lblCLiente.Text = "Cliente";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CreditNoteId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ReceiptId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DisplayNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Número";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CreationDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Import";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IncludeIVA";
            this.dataGridViewCheckBoxColumn1.HeaderText = "IVA";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Detail";
            this.dataGridViewTextBoxColumn5.HeaderText = "Detalles";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(821, 406);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 23);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // CreditNoteId
            // 
            this.CreditNoteId.DataPropertyName = "Id";
            this.CreditNoteId.HeaderText = "CreditNoteId";
            this.CreditNoteId.Name = "CreditNoteId";
            this.CreditNoteId.ReadOnly = true;
            this.CreditNoteId.Visible = false;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "DisplayNumber";
            this.Number.HeaderText = "Número";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 90;
            // 
            // CreationDate
            // 
            this.CreationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CreationDate.DataPropertyName = "CreationDate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreationDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.CreationDate.HeaderText = "Fecha";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Width = 62;
            // 
            // Import
            // 
            this.Import.DataPropertyName = "Import";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.Import.DefaultCellStyle = dataGridViewCellStyle7;
            this.Import.HeaderText = "Importe";
            this.Import.Name = "Import";
            this.Import.ReadOnly = true;
            // 
            // IncludeIVA
            // 
            this.IncludeIVA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IncludeIVA.DataPropertyName = "IncludeIVA";
            this.IncludeIVA.HeaderText = "IVA";
            this.IncludeIVA.Name = "IncludeIVA";
            this.IncludeIVA.ReadOnly = true;
            this.IncludeIVA.Width = 30;
            // 
            // Details
            // 
            this.Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Details.DataPropertyName = "Detail";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Details.DefaultCellStyle = dataGridViewCellStyle8;
            this.Details.HeaderText = "Detalles";
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            // 
            // FrmCreditNoteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 441);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gvCreditNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreditNoteList";
            this.Text = "Notas de Credito";
            ((System.ComponentModel.ISupportInitialize)(this.gvCreditNotes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvCreditNotes;
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
        private Button btnPrint;
        private DataGridViewTextBoxColumn CreditNoteId;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn CreationDate;
        private DataGridViewTextBoxColumn Import;
        private DataGridViewCheckBoxColumn IncludeIVA;
        private DataGridViewTextBoxColumn Details;
    }
}