namespace Medilab.UserInterface.Configuration
{
    partial class frmCAEConfiguration
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
            this.lblSleepTime = new System.Windows.Forms.Label();
            this.txtSleepTime = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epCAEConfiguration = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblRetryTimes = new System.Windows.Forms.Label();
            this.txtRetryTimes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epCAEConfiguration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSleepTime
            // 
            this.lblSleepTime.AutoSize = true;
            this.lblSleepTime.Location = new System.Drawing.Point(13, 24);
            this.lblSleepTime.Name = "lblSleepTime";
            this.lblSleepTime.Size = new System.Drawing.Size(141, 13);
            this.lblSleepTime.TabIndex = 0;
            this.lblSleepTime.Text = "Tiempo procesamiento CAE:";
            // 
            // txtSleepTime
            // 
            this.txtSleepTime.Location = new System.Drawing.Point(160, 21);
            this.txtSleepTime.Name = "txtSleepTime";
            this.txtSleepTime.Size = new System.Drawing.Size(100, 20);
            this.txtSleepTime.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(184, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(103, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epCAEConfiguration
            // 
            this.epCAEConfiguration.ContainerControl = this;
            // 
            // lblRetryTimes
            // 
            this.lblRetryTimes.AutoSize = true;
            this.lblRetryTimes.Location = new System.Drawing.Point(12, 50);
            this.lblRetryTimes.Name = "lblRetryTimes";
            this.lblRetryTimes.Size = new System.Drawing.Size(108, 13);
            this.lblRetryTimes.TabIndex = 0;
            this.lblRetryTimes.Text = "Número de reintentos";
            // 
            // txtRetryTimes
            // 
            this.txtRetryTimes.Location = new System.Drawing.Point(159, 47);
            this.txtRetryTimes.Name = "txtRetryTimes";
            this.txtRetryTimes.Size = new System.Drawing.Size(100, 20);
            this.txtRetryTimes.TabIndex = 1;
            // 
            // frmCAEConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 134);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtRetryTimes);
            this.Controls.Add(this.lblRetryTimes);
            this.Controls.Add(this.txtSleepTime);
            this.Controls.Add(this.lblSleepTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCAEConfiguration";
            this.Text = "Configuración CAE ";
            this.Load += new System.EventHandler(this.frmCAEConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCAEConfiguration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSleepTime;
        private System.Windows.Forms.TextBox txtSleepTime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider epCAEConfiguration;
        private System.Windows.Forms.TextBox txtRetryTimes;
        private System.Windows.Forms.Label lblRetryTimes;
    }
}