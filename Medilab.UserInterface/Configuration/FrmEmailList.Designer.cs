namespace Medilab.UserInterface.Configuration
{
    partial class FrmEmailList
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
            this.txtEmailList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtEmailList
            // 
            this.txtEmailList.Location = new System.Drawing.Point(12, 12);
            this.txtEmailList.Multiline = true;
            this.txtEmailList.Name = "txtEmailList";
            this.txtEmailList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailList.Size = new System.Drawing.Size(529, 214);
            this.txtEmailList.ReadOnly = true;
            this.txtEmailList.TabIndex = 0;
            // 
            // FrmEmailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 238);
            this.Controls.Add(this.txtEmailList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmailList";
            this.Text = "Lista De Emails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmailList;
    }
}