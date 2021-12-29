namespace Medilab.UserInterface.Configuration
{
    partial class FrmPrivateMedicineCompany
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
            this.gvPrivateMedicineCompanies = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epPrivateMedicineCompany = new System.Windows.Forms.ErrorProvider(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivateMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivateMedicineCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrivateMedicineCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPrivateMedicineCompanies
            // 
            this.gvPrivateMedicineCompanies.AllowUserToAddRows = false;
            this.gvPrivateMedicineCompanies.AllowUserToDeleteRows = false;
            this.gvPrivateMedicineCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrivateMedicineCompanies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PrivateMedicineName,
            this.Description});
            this.gvPrivateMedicineCompanies.Location = new System.Drawing.Point(12, 12);
            this.gvPrivateMedicineCompanies.Name = "gvPrivateMedicineCompanies";
            this.gvPrivateMedicineCompanies.ReadOnly = true;
            this.gvPrivateMedicineCompanies.Size = new System.Drawing.Size(592, 150);
            this.gvPrivateMedicineCompanies.TabIndex = 0;
            this.gvPrivateMedicineCompanies.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPrivateMedicineCompanies_CellDoubleClick);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(127, 219);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(477, 64);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(8, 226);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(108, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Información Adicional";
            // 
            // txtName
            // 
            this.txtName.CausesValidation = false;
            this.epPrivateMedicineCompany.SetError(this.txtName, "Debe Ingresar un nombre de obra social");
            this.txtName.Location = new System.Drawing.Point(127, 180);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(477, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 187);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Obra Social";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(366, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(528, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(447, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epPrivateMedicineCompany
            // 
            this.epPrivateMedicineCompany.ContainerControl = this;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // PrivateMedicineName
            // 
            this.PrivateMedicineName.DataPropertyName = "Name";
            this.PrivateMedicineName.HeaderText = "Obra Social";
            this.PrivateMedicineName.Name = "PrivateMedicineName";
            this.PrivateMedicineName.ReadOnly = true;
            this.PrivateMedicineName.Width = 125;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Información Adicional";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // FrmPrivateMedicineCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 335);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvPrivateMedicineCompanies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrivateMedicineCompany";
            this.Text = "Obra Social";
            this.Load += new System.EventHandler(this.FrmPrivateMedicineCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivateMedicineCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrivateMedicineCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPrivateMedicineCompanies;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider epPrivateMedicineCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}