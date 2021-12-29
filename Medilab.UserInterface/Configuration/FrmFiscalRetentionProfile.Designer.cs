namespace Medilab.UserInterface.Configuration
{
    partial class FrmFiscalRetentionProfile
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
            this.chkIsDefault = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chklstRetentions = new System.Windows.Forms.CheckedListBox();
            this.lblRetention = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gvProfiles = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.epRetentionProfile = new System.Windows.Forms.ErrorProvider(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRetentionProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Location = new System.Drawing.Point(132, 220);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(83, 17);
            this.chkIsDefault.TabIndex = 21;
            this.chkIsDefault.Text = "Por Defecto";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(132, 194);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(383, 20);
            this.txtDescription.TabIndex = 20;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 197);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 24;
            this.lblDescription.Text = "Descripción";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(132, 168);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(383, 20);
            this.txtName.TabIndex = 19;
            // 
            // chklstRetentions
            // 
            this.chklstRetentions.CheckOnClick = true;
            this.chklstRetentions.FormattingEnabled = true;
            this.chklstRetentions.Location = new System.Drawing.Point(132, 243);
            this.chklstRetentions.Name = "chklstRetentions";
            this.chklstRetentions.Size = new System.Drawing.Size(383, 124);
            this.chklstRetentions.TabIndex = 22;
            // 
            // lblRetention
            // 
            this.lblRetention.AutoSize = true;
            this.lblRetention.Location = new System.Drawing.Point(13, 243);
            this.lblRetention.Name = "lblRetention";
            this.lblRetention.Size = new System.Drawing.Size(67, 13);
            this.lblRetention.TabIndex = 25;
            this.lblRetention.Text = "Retenciones";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 171);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "Nombre";
            // 
            // gvProfiles
            // 
            this.gvProfiles.AllowUserToAddRows = false;
            this.gvProfiles.AllowUserToDeleteRows = false;
            this.gvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Description,
            this.IsDefault});
            this.gvProfiles.Location = new System.Drawing.Point(16, 12);
            this.gvProfiles.Name = "gvProfiles";
            this.gvProfiles.ReadOnly = true;
            this.gvProfiles.Size = new System.Drawing.Size(499, 150);
            this.gvProfiles.TabIndex = 26;
            this.gvProfiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProfiles_CellDoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(440, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(359, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(278, 373);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // epRetentionProfile
            // 
            this.epRetentionProfile.ContainerControl = this;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 150;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Nombre";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Descripción";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // IsDefault
            // 
            this.IsDefault.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsDefault.DataPropertyName = "IsDefault";
            this.IsDefault.FalseValue = "false";
            this.IsDefault.HeaderText = "Por defecto";
            this.IsDefault.Name = "IsDefault";
            this.IsDefault.ReadOnly = true;
            this.IsDefault.TrueValue = "true";
            this.IsDefault.Width = 68;
            // 
            // FrmFiscalRetentionProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 408);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gvProfiles);
            this.Controls.Add(this.chkIsDefault);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chklstRetentions);
            this.Controls.Add(this.lblRetention);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Perfil de retenciones";
            this.Load += new System.EventHandler(this.FrmFiscalRetentionProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRetentionProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsDefault;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckedListBox chklstRetentions;
        private System.Windows.Forms.Label lblRetention;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView gvProfiles;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider epRetentionProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDefault;
    }
}