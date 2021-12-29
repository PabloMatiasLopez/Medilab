using System;

namespace Medilab.UserInterface.PaymentTypes
{
    partial class frmCreditNotePayment
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.epCreditNote = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbNoteType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.epCreditNote)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(12, 9);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Número";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(62, 6);
            this.txtNumber.Mask = "0000-00000000";
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyUp);
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(12, 35);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(42, 13);
            this.lblImport.TabIndex = 2;
            this.lblImport.Text = "Importe";
            // 
            // txtImport
            // 
            this.txtImport.Location = new System.Drawing.Point(62, 32);
            this.txtImport.Name = "txtImport";
            this.txtImport.ReadOnly = true;
            this.txtImport.Size = new System.Drawing.Size(100, 20);
            this.txtImport.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Notas";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(62, 58);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(262, 57);
            this.txtNotes.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(249, 121);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epCreditNote
            // 
            this.epCreditNote.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tipo";
            // 
            // cbNoteType
            // 
            this.cbNoteType.FormattingEnabled = true;
            this.cbNoteType.Location = new System.Drawing.Point(219, 6);
            this.cbNoteType.Name = "cbNoteType";
            this.cbNoteType.Size = new System.Drawing.Size(35, 21);
            this.cbNoteType.TabIndex = 10;
            this.cbNoteType.SelectedIndexChanged += new EventHandler(cbNoteType_SelectedIndexChanged);
            // 
            // frmCreditNotePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 160);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNoteType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreditNotePayment";
            this.Text = "Nota de Crédito";
            this.Load += new System.EventHandler(this.frmCreditNotePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCreditNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.MaskedTextBox txtNumber;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider epCreditNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNoteType;
    }
}