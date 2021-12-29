namespace Medilab.UserInterface.Configuration
{
    partial class FrmRole
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
            this.gvRoles = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.roleErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chklstPrivileges = new System.Windows.Forms.CheckedListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPrivileges = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gvRoles
            // 
            this.gvRoles.AllowUserToAddRows = false;
            this.gvRoles.AllowUserToDeleteRows = false;
            this.gvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Description});
            this.gvRoles.Location = new System.Drawing.Point(13, 13);
            this.gvRoles.Name = "gvRoles";
            this.gvRoles.ReadOnly = true;
            this.gvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRoles.Size = new System.Drawing.Size(456, 150);
            this.gvRoles.TabIndex = 0;
            this.gvRoles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvRolesCellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Descripcion";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 173);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Nombre";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 200);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Descripcion";
            // 
            // txtName
            // 
            this.roleErrorProvider.SetError(this.txtName, "Debe ingresar el nombre");
            this.txtName.Location = new System.Drawing.Point(86, 170);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(383, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(86, 197);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(383, 55);
            this.txtDescription.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(394, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // roleErrorProvider
            // 
            this.roleErrorProvider.ContainerControl = this;
            // 
            // chklstPrivileges
            // 
            this.chklstPrivileges.CheckOnClick = true;
            this.roleErrorProvider.SetError(this.chklstPrivileges, "Debe seleccionar al menos una opcion");
            this.chklstPrivileges.FormattingEnabled = true;
            this.chklstPrivileges.Location = new System.Drawing.Point(86, 259);
            this.chklstPrivileges.Name = "chklstPrivileges";
            this.chklstPrivileges.Size = new System.Drawing.Size(383, 124);
            this.chklstPrivileges.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 393);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPrivileges
            // 
            this.lblPrivileges.AutoSize = true;
            this.lblPrivileges.Location = new System.Drawing.Point(13, 259);
            this.lblPrivileges.Name = "lblPrivileges";
            this.lblPrivileges.Size = new System.Drawing.Size(54, 13);
            this.lblPrivileges.TabIndex = 10;
            this.lblPrivileges.Text = "Privilegios";
            // 
            // FrmRole
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 428);
            this.Controls.Add(this.chklstPrivileges);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrivileges);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRole";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.FrmRoleLoad);
            ((System.ComponentModel.ISupportInitialize)(this.gvRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvRoles;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider roleErrorProvider;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckedListBox chklstPrivileges;
        private System.Windows.Forms.Label lblPrivileges;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}