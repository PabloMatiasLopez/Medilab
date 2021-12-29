namespace Medilab.UserInterface.Invoice
{
    partial class ucFreeTextPreview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInvoiceText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInvoiceText
            // 
            this.txtInvoiceText.Location = new System.Drawing.Point(4, 4);
            this.txtInvoiceText.Multiline = true;
            this.txtInvoiceText.Name = "txtInvoiceText";
            this.txtInvoiceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInvoiceText.Size = new System.Drawing.Size(684, 203);
            this.txtInvoiceText.TabIndex = 0;
            // 
            // ucFreeTextPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInvoiceText);
            this.Name = "ucFreeTextPreview";
            this.Size = new System.Drawing.Size(691, 211);
            this.Load += new System.EventHandler(this.ucFreeTextPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoiceText;
    }
}
