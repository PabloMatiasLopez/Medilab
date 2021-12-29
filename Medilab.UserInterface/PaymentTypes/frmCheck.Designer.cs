namespace Medilab.UserInterface.PaymentTypes
{
    partial class frmCheck
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
            this.txtCheckNumber = new System.Windows.Forms.TextBox();
            this.lblCertificateNumber = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.lblIssuanceDate = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.dtpIssuanceDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsOwner = new System.Windows.Forms.CheckBox();
            this.epCheck = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(301, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(114, 195);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(262, 57);
            this.txtNotes.TabIndex = 7;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(19, 198);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 16;
            this.lblNotes.Text = "Notas";
            // 
            // txtCheckNumber
            // 
            this.txtCheckNumber.Location = new System.Drawing.Point(114, 66);
            this.txtCheckNumber.Name = "txtCheckNumber";
            this.txtCheckNumber.Size = new System.Drawing.Size(262, 20);
            this.txtCheckNumber.TabIndex = 2;
            // 
            // lblCertificateNumber
            // 
            this.lblCertificateNumber.AutoSize = true;
            this.lblCertificateNumber.Location = new System.Drawing.Point(16, 69);
            this.lblCertificateNumber.Name = "lblCertificateNumber";
            this.lblCertificateNumber.Size = new System.Drawing.Size(44, 13);
            this.lblCertificateNumber.TabIndex = 12;
            this.lblCertificateNumber.Text = "Número";
            // 
            // txtImport
            // 
            this.txtImport.Location = new System.Drawing.Point(114, 13);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(127, 20);
            this.txtImport.TabIndex = 0;
            this.txtImport.Leave += new System.EventHandler(this.txtImport_Leave);
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(16, 42);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(38, 13);
            this.lblBankName.TabIndex = 11;
            this.lblBankName.Text = "Banco";
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(16, 15);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(42, 13);
            this.lblImport.TabIndex = 10;
            this.lblImport.Text = "Importe";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(114, 39);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(262, 20);
            this.txtBankName.TabIndex = 1;
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.AutoSize = true;
            this.lblOwnerName.Location = new System.Drawing.Point(16, 148);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(36, 13);
            this.lblOwnerName.TabIndex = 15;
            this.lblOwnerName.Text = "Titular";
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(114, 145);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(262, 20);
            this.txtOwnerName.TabIndex = 5;
            // 
            // lblIssuanceDate
            // 
            this.lblIssuanceDate.AutoSize = true;
            this.lblIssuanceDate.Location = new System.Drawing.Point(16, 99);
            this.lblIssuanceDate.Name = "lblIssuanceDate";
            this.lblIssuanceDate.Size = new System.Drawing.Size(92, 13);
            this.lblIssuanceDate.TabIndex = 13;
            this.lblIssuanceDate.Text = "Fecha Expedición";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(16, 125);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(68, 13);
            this.lblExpirationDate.TabIndex = 14;
            this.lblExpirationDate.Text = "Fecha Cobro";
            // 
            // dtpIssuanceDate
            // 
            this.dtpIssuanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssuanceDate.Location = new System.Drawing.Point(114, 93);
            this.dtpIssuanceDate.Name = "dtpIssuanceDate";
            this.dtpIssuanceDate.Size = new System.Drawing.Size(127, 20);
            this.dtpIssuanceDate.TabIndex = 3;
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpirationDate.Location = new System.Drawing.Point(114, 119);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(127, 20);
            this.dtpExpirationDate.TabIndex = 4;
            // 
            // chkIsOwner
            // 
            this.chkIsOwner.AutoSize = true;
            this.chkIsOwner.Checked = true;
            this.chkIsOwner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsOwner.Location = new System.Drawing.Point(114, 172);
            this.chkIsOwner.Name = "chkIsOwner";
            this.chkIsOwner.Size = new System.Drawing.Size(56, 17);
            this.chkIsOwner.TabIndex = 6;
            this.chkIsOwner.Text = "Propio";
            this.chkIsOwner.UseVisualStyleBackColor = true;
            // 
            // epCheck
            // 
            this.epCheck.ContainerControl = this;
            // 
            // frmCheck
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(414, 291);
            this.Controls.Add(this.chkIsOwner);
            this.Controls.Add(this.dtpExpirationDate);
            this.Controls.Add(this.dtpIssuanceDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.txtOwnerName);
            this.Controls.Add(this.lblExpirationDate);
            this.Controls.Add(this.lblIssuanceDate);
            this.Controls.Add(this.lblOwnerName);
            this.Controls.Add(this.txtCheckNumber);
            this.Controls.Add(this.lblCertificateNumber);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.lblImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheck";
            this.Text = "Cheque";
            this.Load += new System.EventHandler(this.frmCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtCheckNumber;
        private System.Windows.Forms.Label lblCertificateNumber;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblOwnerName;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.Label lblIssuanceDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.DateTimePicker dtpIssuanceDate;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.CheckBox chkIsOwner;
        private System.Windows.Forms.ErrorProvider epCheck;
    }
}