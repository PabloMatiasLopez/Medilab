namespace Medilab.UserInterface.Configuration
{
    partial class FrmClient
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
            this.gvClients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AditionalInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.txtAditionalInformation = new System.Windows.Forms.TextBox();
            this.lblAditionalInformation = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.epClient = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblFaxNumber = new System.Windows.Forms.Label();
            this.txtFaxNumber = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.tabClient = new System.Windows.Forms.TabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.imgboxLogo = new System.Windows.Forms.PictureBox();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.cbRetentionProfile = new System.Windows.Forms.ComboBox();
            this.cbIvaCondition = new System.Windows.Forms.ComboBox();
            this.clientAddress = new Medilab.UserInterface.Pacientes.UcAddress();
            this.lblRetentionProfile = new System.Windows.Forms.Label();
            this.lblIvaCondition = new System.Windows.Forms.Label();
            this.lblClientNumber = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.tabPageArea = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.gvAreas = new System.Windows.Forms.DataGridView();
            this.AreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEmailList = new System.Windows.Forms.Button();
            this.btnNewClient = new System.Windows.Forms.Button();
            this.ttipImageSize = new System.Windows.Forms.ToolTip(this.components);
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epClient)).BeginInit();
            this.tabClient.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxLogo)).BeginInit();
            this.tabPageArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAreas)).BeginInit();
            this.SuspendLayout();
            // 
            // gvClients
            // 
            this.gvClients.AllowUserToAddRows = false;
            this.gvClients.AllowUserToDeleteRows = false;
            this.gvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Number,
            this.ClientName,
            this.Cuit,
            this.AditionalInformation});
            this.gvClients.Location = new System.Drawing.Point(17, 33);
            this.gvClients.Name = "gvClients";
            this.gvClients.ReadOnly = true;
            this.gvClients.Size = new System.Drawing.Size(639, 113);
            this.gvClients.TabIndex = 0;
            this.gvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvClients_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "ClientNumber";
            this.Number.HeaderText = "Número";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 60;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "Name";
            this.ClientName.HeaderText = "Razon Social";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 125;
            // 
            // Cuit
            // 
            this.Cuit.DataPropertyName = "Cuit";
            this.Cuit.HeaderText = "CUIT";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            this.Cuit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cuit.Width = 125;
            // 
            // AditionalInformation
            // 
            this.AditionalInformation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AditionalInformation.DataPropertyName = "AditionalInformation";
            this.AditionalInformation.HeaderText = "Informacion Adicional";
            this.AditionalInformation.Name = "AditionalInformation";
            this.AditionalInformation.ReadOnly = true;
            this.AditionalInformation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Razón Social";
            // 
            // txtName
            // 
            this.epClient.SetError(this.txtName, "Debe ingresar la razón social de la empresa cliente");
            this.txtName.Location = new System.Drawing.Point(133, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(477, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtCuit
            // 
            this.epClient.SetError(this.txtCuit, "Debe ingresar un CUIT");
            this.txtCuit.Location = new System.Drawing.Point(423, 31);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(187, 20);
            this.txtCuit.TabIndex = 7;
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(373, 34);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(44, 13);
            this.lblCuit.TabIndex = 6;
            this.lblCuit.Text = "Número";
            // 
            // txtAditionalInformation
            // 
            this.txtAditionalInformation.Location = new System.Drawing.Point(132, 319);
            this.txtAditionalInformation.Multiline = true;
            this.txtAditionalInformation.Name = "txtAditionalInformation";
            this.txtAditionalInformation.Size = new System.Drawing.Size(477, 43);
            this.txtAditionalInformation.TabIndex = 23;
            // 
            // lblAditionalInformation
            // 
            this.lblAditionalInformation.AutoSize = true;
            this.lblAditionalInformation.Location = new System.Drawing.Point(13, 328);
            this.lblAditionalInformation.Name = "lblAditionalInformation";
            this.lblAditionalInformation.Size = new System.Drawing.Size(108, 13);
            this.lblAditionalInformation.TabIndex = 22;
            this.lblAditionalInformation.Text = "Informacion Adicional";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(334, 554);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(577, 554);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(496, 554);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epClient
            // 
            this.epClient.ContainerControl = this;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(13, 270);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(49, 13);
            this.lblPhoneNumber.TabIndex = 16;
            this.lblPhoneNumber.Text = "Teléfono";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(84, 267);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(253, 20);
            this.txtPhoneNumber.TabIndex = 17;
            // 
            // lblFaxNumber
            // 
            this.lblFaxNumber.AutoSize = true;
            this.lblFaxNumber.Location = new System.Drawing.Point(343, 270);
            this.lblFaxNumber.Name = "lblFaxNumber";
            this.lblFaxNumber.Size = new System.Drawing.Size(24, 13);
            this.lblFaxNumber.TabIndex = 18;
            this.lblFaxNumber.Text = "Fax";
            // 
            // txtFaxNumber
            // 
            this.txtFaxNumber.Location = new System.Drawing.Point(381, 267);
            this.txtFaxNumber.Name = "txtFaxNumber";
            this.txtFaxNumber.Size = new System.Drawing.Size(229, 20);
            this.txtFaxNumber.TabIndex = 19;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(13, 296);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(32, 13);
            this.lblEmailAddress.TabIndex = 20;
            this.lblEmailAddress.Text = "Email";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(84, 293);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(375, 20);
            this.txtEmailAddress.TabIndex = 21;
            // 
            // tabClient
            // 
            this.tabClient.Controls.Add(this.tabPageDetails);
            this.tabClient.Controls.Add(this.tabPageArea);
            this.tabClient.Location = new System.Drawing.Point(13, 152);
            this.tabClient.Name = "tabClient";
            this.tabClient.SelectedIndex = 0;
            this.tabClient.Size = new System.Drawing.Size(643, 396);
            this.tabClient.TabIndex = 1;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.lblDocumentType);
            this.tabPageDetails.Controls.Add(this.cbDocumentType);
            this.tabPageDetails.Controls.Add(this.imgboxLogo);
            this.tabPageDetails.Controls.Add(this.btnImageBrowse);
            this.tabPageDetails.Controls.Add(this.txtImageName);
            this.tabPageDetails.Controls.Add(this.lblImage);
            this.tabPageDetails.Controls.Add(this.cbRetentionProfile);
            this.tabPageDetails.Controls.Add(this.cbIvaCondition);
            this.tabPageDetails.Controls.Add(this.lblName);
            this.tabPageDetails.Controls.Add(this.clientAddress);
            this.tabPageDetails.Controls.Add(this.lblRetentionProfile);
            this.tabPageDetails.Controls.Add(this.txtName);
            this.tabPageDetails.Controls.Add(this.lblIvaCondition);
            this.tabPageDetails.Controls.Add(this.lblClientNumber);
            this.tabPageDetails.Controls.Add(this.lblCuit);
            this.tabPageDetails.Controls.Add(this.txtClientNumber);
            this.tabPageDetails.Controls.Add(this.txtCuit);
            this.tabPageDetails.Controls.Add(this.lblPhoneNumber);
            this.tabPageDetails.Controls.Add(this.txtPhoneNumber);
            this.tabPageDetails.Controls.Add(this.txtAditionalInformation);
            this.tabPageDetails.Controls.Add(this.lblFaxNumber);
            this.tabPageDetails.Controls.Add(this.lblAditionalInformation);
            this.tabPageDetails.Controls.Add(this.txtFaxNumber);
            this.tabPageDetails.Controls.Add(this.txtEmailAddress);
            this.tabPageDetails.Controls.Add(this.lblEmailAddress);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(635, 370);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Información General";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Location = new System.Drawing.Point(130, 34);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(28, 13);
            this.lblDocumentType.TabIndex = 4;
            this.lblDocumentType.Text = "Tipo";
            // 
            // cbDocumentType
            // 
            this.cbDocumentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDocumentType.FormattingEnabled = true;
            this.cbDocumentType.Items.AddRange(new object[] {
            "D.N.I.",
            "L.E.",
            "L.C.",
            "D.U.",
            "PASS",
            "C.I.",
            "C.E.",
            "Otro"});
            this.cbDocumentType.Location = new System.Drawing.Point(164, 30);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(173, 21);
            this.cbDocumentType.TabIndex = 5;
            // 
            // imgboxLogo
            // 
            this.imgboxLogo.Location = new System.Drawing.Point(478, 164);
            this.imgboxLogo.Name = "imgboxLogo";
            this.imgboxLogo.Size = new System.Drawing.Size(131, 97);
            this.imgboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgboxLogo.TabIndex = 25;
            this.imgboxLogo.TabStop = false;
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Location = new System.Drawing.Point(478, 109);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(131, 23);
            this.btnImageBrowse.TabIndex = 14;
            this.btnImageBrowse.Tag = "";
            this.btnImageBrowse.Text = "Seleccionar imagen";
            this.btnImageBrowse.UseVisualStyleBackColor = true;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            this.btnImageBrowse.MouseHover += new System.EventHandler(this.btnImageBrowse_MouseHover);
            // 
            // txtImageName
            // 
            this.txtImageName.Enabled = false;
            this.txtImageName.Location = new System.Drawing.Point(478, 138);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(131, 20);
            this.txtImageName.TabIndex = 15;
            this.txtImageName.TextChanged += new System.EventHandler(this.txtImageName_TextChanged);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(475, 93);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(31, 13);
            this.lblImage.TabIndex = 13;
            this.lblImage.Text = "Logo";
            // 
            // cbRetentionProfile
            // 
            this.cbRetentionProfile.FormattingEnabled = true;
            this.cbRetentionProfile.Location = new System.Drawing.Point(423, 57);
            this.cbRetentionProfile.Name = "cbRetentionProfile";
            this.cbRetentionProfile.Size = new System.Drawing.Size(187, 21);
            this.cbRetentionProfile.TabIndex = 11;
            // 
            // cbIvaCondition
            // 
            this.cbIvaCondition.FormattingEnabled = true;
            this.cbIvaCondition.Location = new System.Drawing.Point(91, 57);
            this.cbIvaCondition.Name = "cbIvaCondition";
            this.cbIvaCondition.Size = new System.Drawing.Size(187, 21);
            this.cbIvaCondition.TabIndex = 9;
            // 
            // clientAddress
            // 
            this.clientAddress.Location = new System.Drawing.Point(6, 84);
            this.clientAddress.Name = "clientAddress";
            this.clientAddress.Size = new System.Drawing.Size(482, 178);
            this.clientAddress.TabIndex = 12;
            // 
            // lblRetentionProfile
            // 
            this.lblRetentionProfile.AutoSize = true;
            this.lblRetentionProfile.Location = new System.Drawing.Point(314, 60);
            this.lblRetentionProfile.Name = "lblRetentionProfile";
            this.lblRetentionProfile.Size = new System.Drawing.Size(103, 13);
            this.lblRetentionProfile.TabIndex = 10;
            this.lblRetentionProfile.Text = "Perfil de retenciones";
            // 
            // lblIvaCondition
            // 
            this.lblIvaCondition.AutoSize = true;
            this.lblIvaCondition.Location = new System.Drawing.Point(11, 60);
            this.lblIvaCondition.Name = "lblIvaCondition";
            this.lblIvaCondition.Size = new System.Drawing.Size(74, 13);
            this.lblIvaCondition.TabIndex = 8;
            this.lblIvaCondition.Text = "Condición IVA";
            // 
            // lblClientNumber
            // 
            this.lblClientNumber.AutoSize = true;
            this.lblClientNumber.Location = new System.Drawing.Point(11, 34);
            this.lblClientNumber.Name = "lblClientNumber";
            this.lblClientNumber.Size = new System.Drawing.Size(44, 13);
            this.lblClientNumber.TabIndex = 2;
            this.lblClientNumber.Text = "Número";
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Location = new System.Drawing.Point(60, 30);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(49, 20);
            this.txtClientNumber.TabIndex = 3;
            // 
            // tabPageArea
            // 
            this.tabPageArea.Controls.Add(this.btnAdd);
            this.tabPageArea.Controls.Add(this.txtAreaName);
            this.tabPageArea.Controls.Add(this.lblAreaName);
            this.tabPageArea.Controls.Add(this.gvAreas);
            this.tabPageArea.Location = new System.Drawing.Point(4, 22);
            this.tabPageArea.Name = "tabPageArea";
            this.tabPageArea.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArea.Size = new System.Drawing.Size(635, 370);
            this.tabPageArea.TabIndex = 1;
            this.tabPageArea.Text = "Áreas";
            this.tabPageArea.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(554, 253);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(103, 255);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(384, 20);
            this.txtAreaName.TabIndex = 1;
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(12, 258);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(85, 13);
            this.lblAreaName.TabIndex = 1;
            this.lblAreaName.Text = "Nombre del área";
            // 
            // gvAreas
            // 
            this.gvAreas.AllowUserToAddRows = false;
            this.gvAreas.AllowUserToDeleteRows = false;
            this.gvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAreas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AreaId,
            this.AreaName});
            this.gvAreas.Location = new System.Drawing.Point(7, 7);
            this.gvAreas.Name = "gvAreas";
            this.gvAreas.ReadOnly = true;
            this.gvAreas.Size = new System.Drawing.Size(622, 232);
            this.gvAreas.TabIndex = 0;
            this.gvAreas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAreas_CellDoubleClick);
            // 
            // AreaId
            // 
            this.AreaId.DataPropertyName = "Id";
            this.AreaId.HeaderText = "ID";
            this.AreaId.Name = "AreaId";
            this.AreaId.ReadOnly = true;
            this.AreaId.Visible = false;
            // 
            // AreaName
            // 
            this.AreaName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AreaName.DataPropertyName = "Value";
            this.AreaName.HeaderText = "Nombre";
            this.AreaName.MinimumWidth = 500;
            this.AreaName.Name = "AreaName";
            this.AreaName.ReadOnly = true;
            // 
            // btnEmailList
            // 
            this.btnEmailList.Location = new System.Drawing.Point(24, 554);
            this.btnEmailList.Name = "btnEmailList";
            this.btnEmailList.Size = new System.Drawing.Size(103, 23);
            this.btnEmailList.TabIndex = 6;
            this.btnEmailList.Text = "Lista De Emails";
            this.btnEmailList.UseVisualStyleBackColor = true;
            this.btnEmailList.Click += new System.EventHandler(this.btnEmailList_Click);
            // 
            // btnNewClient
            // 
            this.btnNewClient.Location = new System.Drawing.Point(415, 554);
            this.btnNewClient.Name = "btnNewClient";
            this.btnNewClient.Size = new System.Drawing.Size(75, 23);
            this.btnNewClient.TabIndex = 4;
            this.btnNewClient.Text = "Nuevo";
            this.btnNewClient.UseVisualStyleBackColor = true;
            this.btnNewClient.Click += new System.EventHandler(this.btnNewClient_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(14, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 22;
            this.lblSearch.Text = "Buscar";
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(69, 6);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(502, 20);
            this.txtSearchText.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(581, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 585);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNewClient);
            this.Controls.Add(this.btnEmailList);
            this.Controls.Add(this.tabClient);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gvClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClient";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epClient)).EndInit();
            this.tabClient.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxLogo)).EndInit();
            this.tabPageArea.ResumeLayout(false);
            this.tabPageArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAreas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvClients;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtAditionalInformation;
        private System.Windows.Forms.Label lblAditionalInformation;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider epClient;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox txtFaxNumber;
        private System.Windows.Forms.Label lblFaxNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private Pacientes.UcAddress clientAddress;
        private System.Windows.Forms.TabControl tabClient;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageArea;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.DataGridView gvAreas;
        private System.Windows.Forms.ComboBox cbIvaCondition;
        private System.Windows.Forms.Label lblIvaCondition;
        private System.Windows.Forms.Label lblClientNumber;
        private System.Windows.Forms.TextBox txtClientNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.ComboBox cbRetentionProfile;
        private System.Windows.Forms.Label lblRetentionProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn AditionalInformation;
        private System.Windows.Forms.Button btnEmailList;
        private System.Windows.Forms.Button btnNewClient;
        private System.Windows.Forms.PictureBox imgboxLogo;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.ToolTip ttipImageSize;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
    }
}