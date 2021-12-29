namespace Medilab.UserInterface.Configuration
{
    partial class frmNextDebitNoteNumber
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNoteNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSalePoint = new System.Windows.Forms.TextBox();
            this.lblMasterNumber = new System.Windows.Forms.Label();
            this.cbNoteType = new System.Windows.Forms.ComboBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.epNextNumber = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epNextNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 95);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(64, 95);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNoteNumber
            // 
            this.txtNoteNumber.Location = new System.Drawing.Point(101, 58);
            this.txtNoteNumber.Name = "txtNoteNumber";
            this.txtNoteNumber.Size = new System.Drawing.Size(120, 20);
            this.txtNoteNumber.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Siguiente número";
            // 
            // txtSalePoint
            // 
            this.txtSalePoint.Location = new System.Drawing.Point(101, 32);
            this.txtSalePoint.Name = "txtSalePoint";
            this.txtSalePoint.Size = new System.Drawing.Size(120, 20);
            this.txtSalePoint.TabIndex = 19;
            // 
            // lblMasterNumber
            // 
            this.lblMasterNumber.AutoSize = true;
            this.lblMasterNumber.Location = new System.Drawing.Point(12, 35);
            this.lblMasterNumber.Name = "lblMasterNumber";
            this.lblMasterNumber.Size = new System.Drawing.Size(81, 13);
            this.lblMasterNumber.TabIndex = 17;
            this.lblMasterNumber.Text = "Punto de Venta";
            // 
            // cbNoteType
            // 
            this.cbNoteType.FormattingEnabled = true;
            this.cbNoteType.Location = new System.Drawing.Point(100, 6);
            this.cbNoteType.Name = "cbNoteType";
            this.cbNoteType.Size = new System.Drawing.Size(121, 21);
            this.cbNoteType.TabIndex = 15;
            this.cbNoteType.SelectedIndexChanged += new System.EventHandler(this.cbNoteType_SelectedIndexChanged);
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(12, 9);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(69, 13);
            this.lblInvoiceType.TabIndex = 14;
            this.lblInvoiceType.Text = "Tipo de Nota";
            // 
            // epNextNumber
            // 
            this.epNextNumber.ContainerControl = this;
            // 
            // frmNextDebitNoteNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 128);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNoteNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSalePoint);
            this.Controls.Add(this.lblMasterNumber);
            this.Controls.Add(this.cbNoteType);
            this.Controls.Add(this.lblInvoiceType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNextDebitNoteNumber";
            this.Text = "Número Nota de Débito";
            this.Load += new System.EventHandler(this.frmNextDebitNoteNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epNextNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNoteNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSalePoint;
        private System.Windows.Forms.Label lblMasterNumber;
        private System.Windows.Forms.ComboBox cbNoteType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.ErrorProvider epNextNumber;
    }
}