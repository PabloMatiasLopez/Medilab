namespace Medilab.UserInterface.PaymentTypes
{
    partial class frmRetention
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
            this.txtCertificateNumber = new System.Windows.Forms.TextBox();
            this.lblCertificateNumber = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblRetentionType = new System.Windows.Forms.Label();
            this.cbRetentionType = new System.Windows.Forms.ComboBox();
            this.epRetention = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epRetention)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(164, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(245, 155);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(58, 92);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(262, 57);
            this.txtNotes.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(10, 95);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = "Notas";
            // 
            // txtCertificateNumber
            // 
            this.txtCertificateNumber.Location = new System.Drawing.Point(58, 66);
            this.txtCertificateNumber.Name = "txtCertificateNumber";
            this.txtCertificateNumber.Size = new System.Drawing.Size(262, 20);
            this.txtCertificateNumber.TabIndex = 2;
            // 
            // lblCertificateNumber
            // 
            this.lblCertificateNumber.AutoSize = true;
            this.lblCertificateNumber.Location = new System.Drawing.Point(10, 69);
            this.lblCertificateNumber.Name = "lblCertificateNumber";
            this.lblCertificateNumber.Size = new System.Drawing.Size(44, 13);
            this.lblCertificateNumber.TabIndex = 8;
            this.lblCertificateNumber.Text = "Número";
            // 
            // txtImport
            // 
            this.txtImport.Location = new System.Drawing.Point(58, 12);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(100, 20);
            this.txtImport.TabIndex = 0;
            this.txtImport.Leave += new System.EventHandler(this.txtImport_Leave);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(10, 15);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(42, 13);
            this.lblImport.TabIndex = 6;
            this.lblImport.Text = "Importe";
            // 
            // lblRetentionType
            // 
            this.lblRetentionType.AutoSize = true;
            this.lblRetentionType.Location = new System.Drawing.Point(10, 42);
            this.lblRetentionType.Name = "lblRetentionType";
            this.lblRetentionType.Size = new System.Drawing.Size(28, 13);
            this.lblRetentionType.TabIndex = 7;
            this.lblRetentionType.Text = "Tipo";
            // 
            // cbRetentionType
            // 
            this.cbRetentionType.FormattingEnabled = true;
            this.cbRetentionType.Location = new System.Drawing.Point(58, 39);
            this.cbRetentionType.Name = "cbRetentionType";
            this.cbRetentionType.Size = new System.Drawing.Size(262, 21);
            this.cbRetentionType.TabIndex = 1;
            // 
            // epRetention
            // 
            this.epRetention.ContainerControl = this;
            // 
            // frmRetention
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(357, 197);
            this.Controls.Add(this.cbRetentionType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtCertificateNumber);
            this.Controls.Add(this.lblCertificateNumber);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.lblRetentionType);
            this.Controls.Add(this.lblImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRetention";
            this.Text = "Certificados de Retención";
            this.Load += new System.EventHandler(this.frmRetention_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epRetention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtCertificateNumber;
        private System.Windows.Forms.Label lblCertificateNumber;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label lblRetentionType;
        private System.Windows.Forms.ComboBox cbRetentionType;
        private System.Windows.Forms.ErrorProvider epRetention;
    }
}