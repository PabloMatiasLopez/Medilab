namespace Medilab.UserInterface.Configuration
{
    partial class FrmNextInvoiceNumber
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
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.cbInvoiceType = new System.Windows.Forms.ComboBox();
            this.lblMasterNumber = new System.Windows.Forms.Label();
            this.txtMasterNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.epInvoiceNumber = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epInvoiceNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(10, 21);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(109, 13);
            this.lblInvoiceType.TabIndex = 0;
            this.lblInvoiceType.Text = "Tipo de Comprobante";
            // 
            // cbInvoiceType
            // 
            this.cbInvoiceType.FormattingEnabled = true;
            this.cbInvoiceType.Location = new System.Drawing.Point(117, 17);
            this.cbInvoiceType.Name = "cbInvoiceType";
            this.cbInvoiceType.Size = new System.Drawing.Size(121, 21);
            this.cbInvoiceType.TabIndex = 1;
            this.cbInvoiceType.SelectedIndexChanged += new System.EventHandler(this.cbInvoiceType_SelectedIndexChanged);
            // 
            // lblMasterNumber
            // 
            this.lblMasterNumber.AutoSize = true;
            this.lblMasterNumber.Location = new System.Drawing.Point(10, 47);
            this.lblMasterNumber.Name = "lblMasterNumber";
            this.lblMasterNumber.Size = new System.Drawing.Size(83, 13);
            this.lblMasterNumber.TabIndex = 2;
            this.lblMasterNumber.Text = "Número primario";
            // 
            // txtMasterNumber
            // 
            this.txtMasterNumber.Location = new System.Drawing.Point(117, 44);
            this.txtMasterNumber.Name = "txtMasterNumber";
            this.txtMasterNumber.Size = new System.Drawing.Size(120, 20);
            this.txtMasterNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Siguiente número";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(117, 70);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(120, 20);
            this.txtInvoiceNumber.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(62, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(143, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epInvoiceNumber
            // 
            this.epInvoiceNumber.ContainerControl = this;
            // 
            // FrmNextInvoiceNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 144);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMasterNumber);
            this.Controls.Add(this.lblMasterNumber);
            this.Controls.Add(this.cbInvoiceType);
            this.Controls.Add(this.lblInvoiceType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNextInvoiceNumber";
            this.Text = "Número de Comprobante";
            this.Load += new System.EventHandler(this.FrmNextInvoiceNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epInvoiceNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.ComboBox cbInvoiceType;
        private System.Windows.Forms.Label lblMasterNumber;
        private System.Windows.Forms.TextBox txtMasterNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider epInvoiceNumber;
    }
}