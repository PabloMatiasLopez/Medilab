namespace Medilab.UserInterface.Configuration
{
    partial class FrmCompanyInformation
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
            this.gvCompanyInformation = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.epCompanyInformation = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.ddlFormato = new System.Windows.Forms.ComboBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.imgboxLogo = new System.Windows.Forms.PictureBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OwnCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanyInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCompanyInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gvCompanyInformation
            // 
            this.gvCompanyInformation.AllowUserToAddRows = false;
            this.gvCompanyInformation.AllowUserToDeleteRows = false;
            this.gvCompanyInformation.CausesValidation = false;
            this.gvCompanyInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCompanyInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IsActive,
            this.OwnCompanyName,
            this.Email,
            this.Address,
            this.PostalCode,
            this.Country,
            this.Province,
            this.Phone,
            this.Fax,
            this.Cuit,
            this.Image});
            this.gvCompanyInformation.Location = new System.Drawing.Point(13, 13);
            this.gvCompanyInformation.Name = "gvCompanyInformation";
            this.gvCompanyInformation.ReadOnly = true;
            this.gvCompanyInformation.Size = new System.Drawing.Size(1188, 150);
            this.gvCompanyInformation.TabIndex = 0;
            this.gvCompanyInformation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCompanyInformation_CellDoubleClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 178);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Razón Social";
            // 
            // txtName
            // 
            this.txtName.CausesValidation = false;
            this.epCompanyInformation.SetError(this.txtName, "Debe ingresar la razon social");
            this.txtName.Location = new System.Drawing.Point(109, 175);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(478, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.CausesValidation = false;
            this.epCompanyInformation.SetError(this.txtEmail, "Debe ingresar un corre electronico");
            this.txtEmail.Location = new System.Drawing.Point(109, 201);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(478, 20);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 204);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(94, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Correo Electrónico";
            // 
            // txtAddress
            // 
            this.epCompanyInformation.SetError(this.txtAddress, "Debe ingresar una direccion");
            this.txtAddress.Location = new System.Drawing.Point(109, 227);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(478, 20);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(10, 232);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 13);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Dirección";
            // 
            // txtPostalCode
            // 
            this.epCompanyInformation.SetError(this.txtPostalCode, "Debe ingresar un codigo postal");
            this.txtPostalCode.Location = new System.Drawing.Point(109, 253);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(478, 20);
            this.txtPostalCode.TabIndex = 8;
            this.txtPostalCode.TextChanged += new System.EventHandler(this.txtPostalCode_TextChanged);
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(10, 256);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(72, 13);
            this.lblPostalCode.TabIndex = 7;
            this.lblPostalCode.Text = "Código Postal";
            // 
            // txtCountry
            // 
            this.epCompanyInformation.SetError(this.txtCountry, "Debe ingresar un pais");
            this.txtCountry.Location = new System.Drawing.Point(109, 279);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(478, 20);
            this.txtCountry.TabIndex = 10;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(10, 282);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(29, 13);
            this.lblCountry.TabIndex = 9;
            this.lblCountry.Text = "País";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(647, 178);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(51, 13);
            this.lblProvince.TabIndex = 13;
            this.lblProvince.Text = "Provincia";
            // 
            // txtPhone
            // 
            this.epCompanyInformation.SetError(this.txtPhone, "Debe ingresar al menos un telefono");
            this.txtPhone.Location = new System.Drawing.Point(704, 201);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(478, 20);
            this.txtPhone.TabIndex = 16;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(647, 204);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(54, 13);
            this.lblPhone.TabIndex = 15;
            this.lblPhone.Text = "Teléfonos";
            // 
            // txtFax
            // 
            this.epCompanyInformation.SetError(this.txtFax, "Debe ingresar al menos un numero fax");
            this.txtFax.Location = new System.Drawing.Point(704, 227);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(478, 20);
            this.txtFax.TabIndex = 18;
            this.txtFax.TextChanged += new System.EventHandler(this.txtFax_TextChanged);
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(647, 232);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 17;
            this.lblFax.Text = "Fax";
            // 
            // txtCuit
            // 
            this.epCompanyInformation.SetError(this.txtCuit, "Debe ingresar un Cuit");
            this.txtCuit.Location = new System.Drawing.Point(704, 253);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(478, 20);
            this.txtCuit.TabIndex = 20;
            this.txtCuit.TextChanged += new System.EventHandler(this.txtCuit_TextChanged);
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(646, 256);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(32, 13);
            this.lblCuit.TabIndex = 19;
            this.lblCuit.Text = "CUIT";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(646, 282);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(31, 13);
            this.lblImage.TabIndex = 21;
            this.lblImage.Text = "Logo";
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.Location = new System.Drawing.Point(13, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(942, 363);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1032, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(1119, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // epCompanyInformation
            // 
            this.epCompanyInformation.ContainerControl = this;
            // 
            // txtImageName
            // 
            this.txtImageName.Enabled = false;
            this.epCompanyInformation.SetError(this.txtImageName, "Selecciona un logo de empresa.");
            this.txtImageName.Location = new System.Drawing.Point(704, 279);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(236, 20);
            this.txtImageName.TabIndex = 22;
            this.txtImageName.TextChanged += new System.EventHandler(this.txtImageName_TextChanged);
            // 
            // ddlFormato
            // 
            this.epCompanyInformation.SetError(this.ddlFormato, "Seleccione un formato de Impresion");
            this.ddlFormato.FormattingEnabled = true;
            this.ddlFormato.Location = new System.Drawing.Point(109, 305);
            this.ddlFormato.Name = "ddlFormato";
            this.ddlFormato.Size = new System.Drawing.Size(478, 21);
            this.ddlFormato.TabIndex = 12;
            this.ddlFormato.SelectedIndexChanged += new System.EventHandler(this.ddlFormato_SelectedIndexChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(704, 307);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(127, 17);
            this.chkIsActive.TabIndex = 24;
            this.chkIsActive.Text = "Activar Configuración";
            this.chkIsActive.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Location = new System.Drawing.Point(960, 277);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(125, 23);
            this.btnImageBrowse.TabIndex = 23;
            this.btnImageBrowse.Text = "Seleccionar imagen";
            this.btnImageBrowse.UseVisualStyleBackColor = true;
            this.btnImageBrowse.Click += new System.EventHandler(this.btn_Click);
            // 
            // imgboxLogo
            // 
            this.imgboxLogo.Location = new System.Drawing.Point(1100, 279);
            this.imgboxLogo.Name = "imgboxLogo";
            this.imgboxLogo.Size = new System.Drawing.Size(82, 78);
            this.imgboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgboxLogo.TabIndex = 22;
            this.imgboxLogo.TabStop = false;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(10, 308);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(45, 13);
            this.lblFormato.TabIndex = 11;
            this.lblFormato.Text = "Formato";
            // 
            // cbState
            // 
            this.cbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(704, 175);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(246, 21);
            this.cbState.TabIndex = 14;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "Configuracion Activa";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // OwnCompanyName
            // 
            this.OwnCompanyName.DataPropertyName = "Name";
            this.OwnCompanyName.HeaderText = "Razón Social";
            this.OwnCompanyName.Name = "OwnCompanyName";
            this.OwnCompanyName.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Correo Electrónico";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Dirección";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // PostalCode
            // 
            this.PostalCode.DataPropertyName = "PostalCode";
            this.PostalCode.HeaderText = "Codigo Postal";
            this.PostalCode.Name = "PostalCode";
            this.PostalCode.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "País";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Province
            // 
            this.Province.DataPropertyName = "Province";
            this.Province.HeaderText = "Provincia";
            this.Province.Name = "Province";
            this.Province.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Teléfonos";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            // 
            // Cuit
            // 
            this.Cuit.DataPropertyName = "Cuit";
            this.Cuit.HeaderText = "CUIT";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Image.DataPropertyName = "image";
            this.Image.HeaderText = "Logo";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // FrmCompanyInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1212, 395);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.ddlFormato);
            this.Controls.Add(this.imgboxLogo);
            this.Controls.Add(this.btnImageBrowse);
            this.Controls.Add(this.txtImageName);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.lblPostalCode);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvCompanyInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyInformation";
            this.Text = "Configuración de datos de la empresa";
            this.Load += new System.EventHandler(this.CompanyInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanyInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCompanyInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvCompanyInformation;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider epCompanyInformation;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.PictureBox imgboxLogo;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.ComboBox ddlFormato;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Province;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
    }
}