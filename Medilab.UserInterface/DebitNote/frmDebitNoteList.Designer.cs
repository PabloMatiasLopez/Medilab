namespace Medilab.UserInterface.DebitNote
{
    partial class frmDebitNoteList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.btnCombinedSearch = new System.Windows.Forms.Button();
            this.lblCLiente = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.gvDebitNotes = new System.Windows.Forms.DataGridView();
            this.CreditNoteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Import = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncludeIVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDebitNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(819, 413);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 23);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtClientNumber);
            this.groupBox2.Controls.Add(this.btnCombinedSearch);
            this.groupBox2.Controls.Add(this.lblCLiente);
            this.groupBox2.Controls.Add(this.cbClient);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(922, 70);
            this.groupBox2.TabIndex = 12;
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
            // gvDebitNotes
            // 
            this.gvDebitNotes.AllowUserToAddRows = false;
            this.gvDebitNotes.AllowUserToDeleteRows = false;
            this.gvDebitNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDebitNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreditNoteId,
            this.Number,
            this.CreationDate,
            this.Import,
            this.IncludeIVA,
            this.Details});
            this.gvDebitNotes.Location = new System.Drawing.Point(11, 88);
            this.gvDebitNotes.Name = "gvDebitNotes";
            this.gvDebitNotes.ReadOnly = true;
            this.gvDebitNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDebitNotes.Size = new System.Drawing.Size(923, 312);
            this.gvDebitNotes.TabIndex = 11;
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
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreationDate.DefaultCellStyle = dataGridViewCellStyle16;
            this.CreationDate.HeaderText = "Fecha";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Width = 62;
            // 
            // Import
            // 
            this.Import.DataPropertyName = "Import";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C2";
            dataGridViewCellStyle17.NullValue = null;
            this.Import.DefaultCellStyle = dataGridViewCellStyle17;
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
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Details.DefaultCellStyle = dataGridViewCellStyle18;
            this.Details.HeaderText = "Detalles";
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            // 
            // frmDebitNoteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 445);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gvDebitNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDebitNoteList";
            this.Text = "Notas de Débito";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDebitNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientNumber;
        private System.Windows.Forms.Button btnCombinedSearch;
        private System.Windows.Forms.Label lblCLiente;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.DataGridView gvDebitNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNoteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Import;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IncludeIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
    }
}