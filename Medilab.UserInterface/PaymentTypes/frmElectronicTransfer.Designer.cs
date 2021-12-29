namespace Medilab.UserInterface.PaymentTypes
{
    partial class frmElectronicTransfer
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.epElectronicTransfer = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.dtpTransferDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransferDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epElectronicTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(246, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(59, 118);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(262, 57);
            this.txtNotes.TabIndex = 9;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(11, 121);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Notas";
            // 
            // txtImport
            // 
            this.txtImport.Location = new System.Drawing.Point(59, 12);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(100, 20);
            this.txtImport.TabIndex = 1;
            this.txtImport.Leave += new System.EventHandler(this.txtImport_Leave);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(11, 15);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(42, 13);
            this.lblImport.TabIndex = 0;
            this.lblImport.Text = "Importe";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(11, 41);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(38, 13);
            this.lblBankName.TabIndex = 2;
            this.lblBankName.Text = "Banco";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(59, 38);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(262, 20);
            this.txtBankName.TabIndex = 3;
            // 
            // epElectronicTransfer
            // 
            this.epElectronicTransfer.ContainerControl = this;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(11, 67);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(41, 13);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Cuenta";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(59, 64);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(262, 20);
            this.txtAccount.TabIndex = 5;
            // 
            // dtpTransferDate
            // 
            this.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransferDate.Location = new System.Drawing.Point(59, 90);
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTransferDate.TabIndex = 7;
            // 
            // lblTransferDate
            // 
            this.lblTransferDate.AutoSize = true;
            this.lblTransferDate.Location = new System.Drawing.Point(12, 93);
            this.lblTransferDate.Name = "lblTransferDate";
            this.lblTransferDate.Size = new System.Drawing.Size(37, 13);
            this.lblTransferDate.TabIndex = 6;
            this.lblTransferDate.Text = "Fecha";
            // 
            // frmElectronicTransfer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(365, 218);
            this.Controls.Add(this.dtpTransferDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.lblTransferDate);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.lblImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmElectronicTransfer";
            this.Text = "Transferencia Electrónica";
            this.Load += new System.EventHandler(this.frmElectronicTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epElectronicTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.ErrorProvider epElectronicTransfer;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.DateTimePicker dtpTransferDate;
        private System.Windows.Forms.Label lblTransferDate;
    }
}