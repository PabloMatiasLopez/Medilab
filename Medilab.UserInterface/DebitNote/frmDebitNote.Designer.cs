namespace Medilab.UserInterface.DebitNote
{
    partial class frmDebitNote
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
            this.txtSalePoint = new System.Windows.Forms.TextBox();
            this.txtNoteNumber = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNoteDate = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.chkIncludeIVA = new System.Windows.Forms.CheckBox();
            this.txtNoteImport = new System.Windows.Forms.TextBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtNoteDetails = new System.Windows.Forms.TextBox();
            this.lblNoteDetails = new System.Windows.Forms.Label();
            this.lblCreditNoteDetails = new System.Windows.Forms.Label();
            this.txtCreditNoteNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.gbNoteType = new System.Windows.Forms.GroupBox();
            this.rbTypeB = new System.Windows.Forms.RadioButton();
            this.rbTypeA = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.epDebitNote = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbNoteType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epDebitNote)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSalePoint
            // 
            this.txtSalePoint.Location = new System.Drawing.Point(83, 98);
            this.txtSalePoint.Name = "txtSalePoint";
            this.txtSalePoint.Size = new System.Drawing.Size(61, 20);
            this.txtSalePoint.TabIndex = 22;
            // 
            // txtNoteNumber
            // 
            this.txtNoteNumber.Location = new System.Drawing.Point(150, 98);
            this.txtNoteNumber.Name = "txtNoteNumber";
            this.txtNoteNumber.Size = new System.Drawing.Size(141, 20);
            this.txtNoteNumber.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(320, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(401, 343);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNoteDate
            // 
            this.lblNoteDate.AutoSize = true;
            this.lblNoteDate.Location = new System.Drawing.Point(59, 9);
            this.lblNoteDate.Name = "lblNoteDate";
            this.lblNoteDate.Size = new System.Drawing.Size(35, 13);
            this.lblNoteDate.TabIndex = 19;
            this.lblNoteDate.Text = "label8";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 18;
            this.lblDate.Text = "Fecha";
            // 
            // chkIncludeIVA
            // 
            this.chkIncludeIVA.AutoSize = true;
            this.chkIncludeIVA.Location = new System.Drawing.Point(290, 309);
            this.chkIncludeIVA.Name = "chkIncludeIVA";
            this.chkIncludeIVA.Size = new System.Drawing.Size(81, 17);
            this.chkIncludeIVA.TabIndex = 33;
            this.chkIncludeIVA.Text = "Genera IVA";
            this.chkIncludeIVA.UseVisualStyleBackColor = true;
            // 
            // txtNoteImport
            // 
            this.txtNoteImport.Location = new System.Drawing.Point(83, 307);
            this.txtNoteImport.Name = "txtNoteImport";
            this.txtNoteImport.Size = new System.Drawing.Size(176, 20);
            this.txtNoteImport.TabIndex = 32;
            this.txtNoteImport.Leave += new System.EventHandler(this.txtNoteImport_Leave);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(12, 310);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(42, 13);
            this.lblImport.TabIndex = 31;
            this.lblImport.Text = "Importe";
            // 
            // txtNoteDetails
            // 
            this.txtNoteDetails.Location = new System.Drawing.Point(83, 209);
            this.txtNoteDetails.Multiline = true;
            this.txtNoteDetails.Name = "txtNoteDetails";
            this.txtNoteDetails.Size = new System.Drawing.Size(393, 92);
            this.txtNoteDetails.TabIndex = 30;
            // 
            // lblNoteDetails
            // 
            this.lblNoteDetails.AutoSize = true;
            this.lblNoteDetails.Location = new System.Drawing.Point(12, 212);
            this.lblNoteDetails.Name = "lblNoteDetails";
            this.lblNoteDetails.Size = new System.Drawing.Size(45, 13);
            this.lblNoteDetails.TabIndex = 29;
            this.lblNoteDetails.Text = "Detalles";
            // 
            // lblCreditNoteDetails
            // 
            this.lblCreditNoteDetails.AutoSize = true;
            this.lblCreditNoteDetails.Location = new System.Drawing.Point(80, 177);
            this.lblCreditNoteDetails.Name = "lblCreditNoteDetails";
            this.lblCreditNoteDetails.Size = new System.Drawing.Size(0, 13);
            this.lblCreditNoteDetails.TabIndex = 28;
            // 
            // txtCreditNoteNumber
            // 
            this.txtCreditNoteNumber.Location = new System.Drawing.Point(83, 154);
            this.txtCreditNoteNumber.Mask = "0000-00000000";
            this.txtCreditNoteNumber.Name = "txtCreditNoteNumber";
            this.txtCreditNoteNumber.Size = new System.Drawing.Size(209, 20);
            this.txtCreditNoteNumber.TabIndex = 27;
            this.txtCreditNoteNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCreditNoteNumber_KeyUp);
            this.txtCreditNoteNumber.Leave += new System.EventHandler(this.txtCreditNoteNumber_Leave);
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(12, 157);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(65, 13);
            this.lblInvoice.TabIndex = 26;
            this.lblInvoice.Text = "Nota crédito";
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(83, 127);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(393, 21);
            this.cbClient.TabIndex = 25;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(12, 130);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 24;
            this.lblClient.Text = "Cliente";
            // 
            // gbNoteType
            // 
            this.gbNoteType.Controls.Add(this.rbTypeB);
            this.gbNoteType.Controls.Add(this.rbTypeA);
            this.gbNoteType.Location = new System.Drawing.Point(15, 40);
            this.gbNoteType.Name = "gbNoteType";
            this.gbNoteType.Size = new System.Drawing.Size(118, 48);
            this.gbNoteType.TabIndex = 20;
            this.gbNoteType.TabStop = false;
            this.gbNoteType.Text = "Tipo de Nota";
            // 
            // rbTypeB
            // 
            this.rbTypeB.AutoSize = true;
            this.rbTypeB.Location = new System.Drawing.Point(47, 19);
            this.rbTypeB.Name = "rbTypeB";
            this.rbTypeB.Size = new System.Drawing.Size(32, 17);
            this.rbTypeB.TabIndex = 1;
            this.rbTypeB.Text = "B";
            this.rbTypeB.UseVisualStyleBackColor = true;
            this.rbTypeB.CheckedChanged += new System.EventHandler(this.rbTypeB_CheckedChanged);
            // 
            // rbTypeA
            // 
            this.rbTypeA.AutoSize = true;
            this.rbTypeA.Checked = true;
            this.rbTypeA.Location = new System.Drawing.Point(9, 19);
            this.rbTypeA.Name = "rbTypeA";
            this.rbTypeA.Size = new System.Drawing.Size(32, 17);
            this.rbTypeA.TabIndex = 0;
            this.rbTypeA.TabStop = true;
            this.rbTypeA.Text = "A";
            this.rbTypeA.UseVisualStyleBackColor = true;
            this.rbTypeA.CheckedChanged += new System.EventHandler(this.rbTypeA_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Número";
            // 
            // epDebitNote
            // 
            this.epDebitNote.ContainerControl = this;
            // 
            // frmDebitNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 386);
            this.Controls.Add(this.txtSalePoint);
            this.Controls.Add(this.txtNoteNumber);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNoteDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.chkIncludeIVA);
            this.Controls.Add(this.txtNoteImport);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.txtNoteDetails);
            this.Controls.Add(this.lblNoteDetails);
            this.Controls.Add(this.lblCreditNoteDetails);
            this.Controls.Add(this.txtCreditNoteNumber);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.gbNoteType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDebitNote";
            this.Text = "Nota de Débito";
            this.Load += new System.EventHandler(this.frmDebitNote_Load);
            this.gbNoteType.ResumeLayout(false);
            this.gbNoteType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epDebitNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalePoint;
        private System.Windows.Forms.TextBox txtNoteNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNoteDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.CheckBox chkIncludeIVA;
        private System.Windows.Forms.TextBox txtNoteImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtNoteDetails;
        private System.Windows.Forms.Label lblNoteDetails;
        private System.Windows.Forms.Label lblCreditNoteDetails;
        private System.Windows.Forms.MaskedTextBox txtCreditNoteNumber;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.GroupBox gbNoteType;
        private System.Windows.Forms.RadioButton rbTypeB;
        private System.Windows.Forms.RadioButton rbTypeA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epDebitNote;
    }
}