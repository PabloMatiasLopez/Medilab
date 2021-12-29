using System;

namespace Medilab.UserInterface.CreditNote
{
    partial class frmCreditNote
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbNoteType = new System.Windows.Forms.GroupBox();
            this.rbTypeB = new System.Windows.Forms.RadioButton();
            this.rbTypeA = new System.Windows.Forms.RadioButton();
            this.lblClient = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblInvoiceDetails = new System.Windows.Forms.Label();
            this.lblNoteDetails = new System.Windows.Forms.Label();
            this.txtNoteDetails = new System.Windows.Forms.TextBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtNoteImport = new System.Windows.Forms.TextBox();
            this.chkIncludeIVA = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNoteDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNoteNumber = new System.Windows.Forms.TextBox();
            this.epCreditNote = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtSalePoint = new System.Windows.Forms.TextBox();
            this.gbNoteType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCreditNote)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número";
            // 
            // gbNoteType
            // 
            this.gbNoteType.Controls.Add(this.rbTypeB);
            this.gbNoteType.Controls.Add(this.rbTypeA);
            this.gbNoteType.Location = new System.Drawing.Point(28, 44);
            this.gbNoteType.Name = "gbNoteType";
            this.gbNoteType.Size = new System.Drawing.Size(118, 48);
            this.gbNoteType.TabIndex = 2;
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
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(25, 134);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 6;
            this.lblClient.Text = "Cliente";
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(74, 131);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(415, 21);
            this.cbClient.TabIndex = 7;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(25, 161);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(43, 13);
            this.lblInvoice.TabIndex = 8;
            this.lblInvoice.Text = "Factura";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(74, 158);
            this.txtInvoiceNumber.Mask = "0000-00000000";
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(148, 20);
            this.txtInvoiceNumber.TabIndex = 9;
            this.txtInvoiceNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNumber_KeyUp);
            this.txtInvoiceNumber.Leave += new System.EventHandler(this.txtInvoiceNumber_Leave);
            // 
            // lblInvoiceDetails
            // 
            this.lblInvoiceDetails.AutoSize = true;
            this.lblInvoiceDetails.Location = new System.Drawing.Point(71, 181);
            this.lblInvoiceDetails.Name = "lblInvoiceDetails";
            this.lblInvoiceDetails.Size = new System.Drawing.Size(0, 13);
            this.lblInvoiceDetails.TabIndex = 10;
            // 
            // lblNoteDetails
            // 
            this.lblNoteDetails.AutoSize = true;
            this.lblNoteDetails.Location = new System.Drawing.Point(25, 216);
            this.lblNoteDetails.Name = "lblNoteDetails";
            this.lblNoteDetails.Size = new System.Drawing.Size(45, 13);
            this.lblNoteDetails.TabIndex = 11;
            this.lblNoteDetails.Text = "Detalles";
            // 
            // txtNoteDetails
            // 
            this.txtNoteDetails.Location = new System.Drawing.Point(74, 213);
            this.txtNoteDetails.Multiline = true;
            this.txtNoteDetails.Name = "txtNoteDetails";
            this.txtNoteDetails.Size = new System.Drawing.Size(415, 92);
            this.txtNoteDetails.TabIndex = 12;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(25, 314);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(42, 13);
            this.lblImport.TabIndex = 13;
            this.lblImport.Text = "Importe";
            // 
            // txtNoteImport
            // 
            this.txtNoteImport.Location = new System.Drawing.Point(74, 311);
            this.txtNoteImport.Name = "txtNoteImport";
            this.txtNoteImport.Size = new System.Drawing.Size(198, 20);
            this.txtNoteImport.TabIndex = 14;
            this.txtNoteImport.Leave += new System.EventHandler(this.txtNoteImport_Leave);
            // 
            // chkIncludeIVA
            // 
            this.chkIncludeIVA.AutoSize = true;
            this.chkIncludeIVA.Location = new System.Drawing.Point(303, 313);
            this.chkIncludeIVA.Name = "chkIncludeIVA";
            this.chkIncludeIVA.Size = new System.Drawing.Size(81, 17);
            this.chkIncludeIVA.TabIndex = 15;
            this.chkIncludeIVA.Text = "Genera IVA";
            this.chkIncludeIVA.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(25, 13);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Fecha";
            // 
            // lblNoteDate
            // 
            this.lblNoteDate.AutoSize = true;
            this.lblNoteDate.Location = new System.Drawing.Point(72, 13);
            this.lblNoteDate.Name = "lblNoteDate";
            this.lblNoteDate.Size = new System.Drawing.Size(35, 13);
            this.lblNoteDate.TabIndex = 1;
            this.lblNoteDate.Text = "label8";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(414, 347);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(333, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNoteNumber
            // 
            this.txtNoteNumber.Location = new System.Drawing.Point(142, 102);
            this.txtNoteNumber.Name = "txtNoteNumber";
            this.txtNoteNumber.Size = new System.Drawing.Size(141, 20);
            this.txtNoteNumber.TabIndex = 5;
            // 
            // epCreditNote
            // 
            this.epCreditNote.ContainerControl = this;
            // 
            // txtSalePoint
            // 
            this.txtSalePoint.Location = new System.Drawing.Point(75, 102);
            this.txtSalePoint.Name = "txtSalePoint";
            this.txtSalePoint.Size = new System.Drawing.Size(61, 20);
            this.txtSalePoint.TabIndex = 4;
            // 
            // frmCreditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 387);
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
            this.Controls.Add(this.lblInvoiceDetails);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.gbNoteType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreditNote";
            this.Text = "Nota de Crédito";
            this.Load += new System.EventHandler(this.frmCreditNote_Load);
            this.gbNoteType.ResumeLayout(false);
            this.gbNoteType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCreditNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbNoteType;
        private System.Windows.Forms.RadioButton rbTypeB;
        private System.Windows.Forms.RadioButton rbTypeA;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.MaskedTextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceDetails;
        private System.Windows.Forms.Label lblNoteDetails;
        private System.Windows.Forms.TextBox txtNoteDetails;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtNoteImport;
        private System.Windows.Forms.CheckBox chkIncludeIVA;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNoteDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNoteNumber;
        private System.Windows.Forms.ErrorProvider epCreditNote;
        private System.Windows.Forms.TextBox txtSalePoint;
    }
}