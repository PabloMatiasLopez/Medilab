namespace Medilab.UserInterface.ClinicalHistory
{
    partial class FrmAddClinicalHistory
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
            this.tabClinicalHistory = new System.Windows.Forms.TabControl();
            this.tabPageGeneralInformation = new System.Windows.Forms.TabPage();
            this.cbChargeToClient = new System.Windows.Forms.ComboBox();
            this.lblChargeToClient = new System.Windows.Forms.Label();
            this.btnUpdateCompaniesDropdown = new System.Windows.Forms.Button();
            this.txtAnotherTypeDescription = new System.Windows.Forms.TextBox();
            this.chkIsHighPriority = new System.Windows.Forms.CheckBox();
            this.btnEditPatient = new System.Windows.Forms.Button();
            this.lblObservationMessage = new System.Windows.Forms.Label();
            this.lblObservations = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.cbExamType = new System.Windows.Forms.ComboBox();
            this.lblExamType = new System.Windows.Forms.Label();
            this.cbClienArea = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblWorkArea = new System.Windows.Forms.Label();
            this.lblTasksToDo = new System.Windows.Forms.Label();
            this.lblCompanyPhone = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblCompanyCuit = new System.Windows.Forms.Label();
            this.lblCompanyAddress = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtCurrentDate = new System.Windows.Forms.TextBox();
            this.txtWorkArea = new System.Windows.Forms.TextBox();
            this.txtPatientBirthDay = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtTaskToDo = new System.Windows.Forms.TextBox();
            this.txtCompanyPhone = new System.Windows.Forms.TextBox();
            this.txtCompanyCuit = new System.Windows.Forms.TextBox();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.lblDocument = new System.Windows.Forms.Label();
            this.tabPagePractices = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbPracticeName = new System.Windows.Forms.ComboBox();
            this.txtPracticeCode = new System.Windows.Forms.TextBox();
            this.lblPracticeCode = new System.Windows.Forms.Label();
            this.lblPracticeName = new System.Windows.Forms.Label();
            this.gvPractices = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveClinicalExam = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tooltipExam = new System.Windows.Forms.ToolTip(this.components);
            this.epClinicalHistory = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrintPartial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReceptionUser = new System.Windows.Forms.Label();
            this.tabClinicalHistory.SuspendLayout();
            this.tabPageGeneralInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.tabPagePractices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epClinicalHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabClinicalHistory
            // 
            this.tabClinicalHistory.Controls.Add(this.tabPageGeneralInformation);
            this.tabClinicalHistory.Controls.Add(this.tabPagePractices);
            this.tabClinicalHistory.Location = new System.Drawing.Point(12, 12);
            this.tabClinicalHistory.Name = "tabClinicalHistory";
            this.tabClinicalHistory.SelectedIndex = 0;
            this.tabClinicalHistory.Size = new System.Drawing.Size(1154, 489);
            this.tabClinicalHistory.TabIndex = 0;
            // 
            // tabPageGeneralInformation
            // 
            this.tabPageGeneralInformation.Controls.Add(this.lblReceptionUser);
            this.tabPageGeneralInformation.Controls.Add(this.label1);
            this.tabPageGeneralInformation.Controls.Add(this.cbChargeToClient);
            this.tabPageGeneralInformation.Controls.Add(this.lblChargeToClient);
            this.tabPageGeneralInformation.Controls.Add(this.btnUpdateCompaniesDropdown);
            this.tabPageGeneralInformation.Controls.Add(this.txtAnotherTypeDescription);
            this.tabPageGeneralInformation.Controls.Add(this.chkIsHighPriority);
            this.tabPageGeneralInformation.Controls.Add(this.btnEditPatient);
            this.tabPageGeneralInformation.Controls.Add(this.lblObservationMessage);
            this.tabPageGeneralInformation.Controls.Add(this.lblObservations);
            this.tabPageGeneralInformation.Controls.Add(this.txtObservations);
            this.tabPageGeneralInformation.Controls.Add(this.cbExamType);
            this.tabPageGeneralInformation.Controls.Add(this.lblExamType);
            this.tabPageGeneralInformation.Controls.Add(this.cbClienArea);
            this.tabPageGeneralInformation.Controls.Add(this.lblArea);
            this.tabPageGeneralInformation.Controls.Add(this.cbCompany);
            this.tabPageGeneralInformation.Controls.Add(this.lblCompany);
            this.tabPageGeneralInformation.Controls.Add(this.pbPhoto);
            this.tabPageGeneralInformation.Controls.Add(this.lblFecha);
            this.tabPageGeneralInformation.Controls.Add(this.lblBirthDate);
            this.tabPageGeneralInformation.Controls.Add(this.lblAge);
            this.tabPageGeneralInformation.Controls.Add(this.lblWorkArea);
            this.tabPageGeneralInformation.Controls.Add(this.lblTasksToDo);
            this.tabPageGeneralInformation.Controls.Add(this.lblCompanyPhone);
            this.tabPageGeneralInformation.Controls.Add(this.lblFirstName);
            this.tabPageGeneralInformation.Controls.Add(this.lblCompanyCuit);
            this.tabPageGeneralInformation.Controls.Add(this.lblCompanyAddress);
            this.tabPageGeneralInformation.Controls.Add(this.lblLastName);
            this.tabPageGeneralInformation.Controls.Add(this.txtCurrentDate);
            this.tabPageGeneralInformation.Controls.Add(this.txtWorkArea);
            this.tabPageGeneralInformation.Controls.Add(this.txtPatientBirthDay);
            this.tabPageGeneralInformation.Controls.Add(this.txtAge);
            this.tabPageGeneralInformation.Controls.Add(this.txtTaskToDo);
            this.tabPageGeneralInformation.Controls.Add(this.txtCompanyPhone);
            this.tabPageGeneralInformation.Controls.Add(this.txtCompanyCuit);
            this.tabPageGeneralInformation.Controls.Add(this.txtCompanyAddress);
            this.tabPageGeneralInformation.Controls.Add(this.txtFirstName);
            this.tabPageGeneralInformation.Controls.Add(this.txtLastName);
            this.tabPageGeneralInformation.Controls.Add(this.txtDocumentNumber);
            this.tabPageGeneralInformation.Controls.Add(this.cbDocumentType);
            this.tabPageGeneralInformation.Controls.Add(this.lblDocument);
            this.tabPageGeneralInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneralInformation.Name = "tabPageGeneralInformation";
            this.tabPageGeneralInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralInformation.Size = new System.Drawing.Size(1146, 463);
            this.tabPageGeneralInformation.TabIndex = 0;
            this.tabPageGeneralInformation.Text = "Información General";
            this.tabPageGeneralInformation.UseVisualStyleBackColor = true;
            // 
            // cbChargeToClient
            // 
            this.cbChargeToClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbChargeToClient.FormattingEnabled = true;
            this.cbChargeToClient.Location = new System.Drawing.Point(407, 219);
            this.cbChargeToClient.Name = "cbChargeToClient";
            this.cbChargeToClient.Size = new System.Drawing.Size(217, 21);
            this.cbChargeToClient.TabIndex = 46;
            // 
            // lblChargeToClient
            // 
            this.lblChargeToClient.AutoSize = true;
            this.lblChargeToClient.Location = new System.Drawing.Point(334, 223);
            this.lblChargeToClient.Name = "lblChargeToClient";
            this.lblChargeToClient.Size = new System.Drawing.Size(55, 13);
            this.lblChargeToClient.TabIndex = 45;
            this.lblChargeToClient.Text = "Facturar a";
            // 
            // btnUpdateCompaniesDropdown
            // 
            this.btnUpdateCompaniesDropdown.Location = new System.Drawing.Point(335, 193);
            this.btnUpdateCompaniesDropdown.Name = "btnUpdateCompaniesDropdown";
            this.btnUpdateCompaniesDropdown.Size = new System.Drawing.Size(63, 23);
            this.btnUpdateCompaniesDropdown.TabIndex = 43;
            this.btnUpdateCompaniesDropdown.Text = "Actualizar";
            this.btnUpdateCompaniesDropdown.UseVisualStyleBackColor = true;
            this.btnUpdateCompaniesDropdown.Click += new System.EventHandler(this.btnUpdateCompaniesDropdown_Click);
            // 
            // txtAnotherTypeDescription
            // 
            this.txtAnotherTypeDescription.Enabled = false;
            this.txtAnotherTypeDescription.Location = new System.Drawing.Point(374, 40);
            this.txtAnotherTypeDescription.Name = "txtAnotherTypeDescription";
            this.txtAnotherTypeDescription.Size = new System.Drawing.Size(250, 20);
            this.txtAnotherTypeDescription.TabIndex = 42;
            // 
            // chkIsHighPriority
            // 
            this.chkIsHighPriority.AutoSize = true;
            this.chkIsHighPriority.Location = new System.Drawing.Point(107, 66);
            this.chkIsHighPriority.Name = "chkIsHighPriority";
            this.chkIsHighPriority.Size = new System.Drawing.Size(69, 17);
            this.chkIsHighPriority.TabIndex = 4;
            this.chkIsHighPriority.Text = "Prioritario";
            this.chkIsHighPriority.UseVisualStyleBackColor = true;
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Location = new System.Drawing.Point(374, 86);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(119, 23);
            this.btnEditPatient.TabIndex = 8;
            this.btnEditPatient.Text = "Detalles";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.btnEditPatient_Click);
            // 
            // lblObservationMessage
            // 
            this.lblObservationMessage.AutoSize = true;
            this.lblObservationMessage.ForeColor = System.Drawing.Color.Red;
            this.lblObservationMessage.Location = new System.Drawing.Point(92, 356);
            this.lblObservationMessage.Name = "lblObservationMessage";
            this.lblObservationMessage.Size = new System.Drawing.Size(244, 13);
            this.lblObservationMessage.TabIndex = 41;
            this.lblObservationMessage.Text = "(Sólo uso interno, no se imprime en el informe final)";
            // 
            // lblObservations
            // 
            this.lblObservations.AutoSize = true;
            this.lblObservations.Location = new System.Drawing.Point(17, 356);
            this.lblObservations.Name = "lblObservations";
            this.lblObservations.Size = new System.Drawing.Size(78, 13);
            this.lblObservations.TabIndex = 31;
            this.lblObservations.Text = "Observaciones";
            // 
            // txtObservations
            // 
            this.txtObservations.Location = new System.Drawing.Point(20, 372);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(604, 70);
            this.txtObservations.TabIndex = 32;
            // 
            // cbExamType
            // 
            this.cbExamType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbExamType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExamType.FormattingEnabled = true;
            this.cbExamType.Items.AddRange(new object[] {
            "D.N.I.",
            "L.E.",
            "L.C.",
            "D.U.",
            "PASS",
            "C.I.",
            "C.E.",
            "Otro"});
            this.cbExamType.Location = new System.Drawing.Point(107, 39);
            this.cbExamType.Name = "cbExamType";
            this.cbExamType.Size = new System.Drawing.Size(249, 21);
            this.cbExamType.TabIndex = 3;
            this.cbExamType.SelectedIndexChanged += new System.EventHandler(this.cbExamType_SelectedIndexChanged);
            // 
            // lblExamType
            // 
            this.lblExamType.AutoSize = true;
            this.lblExamType.Location = new System.Drawing.Point(17, 42);
            this.lblExamType.Name = "lblExamType";
            this.lblExamType.Size = new System.Drawing.Size(84, 13);
            this.lblExamType.TabIndex = 2;
            this.lblExamType.Text = "Tipo de Exámen";
            // 
            // cbClienArea
            // 
            this.cbClienArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClienArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClienArea.FormattingEnabled = true;
            this.cbClienArea.Location = new System.Drawing.Point(439, 193);
            this.cbClienArea.Name = "cbClienArea";
            this.cbClienArea.Size = new System.Drawing.Size(185, 21);
            this.cbClienArea.TabIndex = 20;
            this.cbClienArea.SelectedIndexChanged += new System.EventHandler(this.cbClienArea_SelectedIndexChanged);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(404, 197);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(29, 13);
            this.lblArea.TabIndex = 19;
            this.lblArea.Text = "Área";
            // 
            // cbCompany
            // 
            this.cbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(83, 193);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(245, 21);
            this.cbCompany.TabIndex = 18;
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(17, 197);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(48, 13);
            this.lblCompany.TabIndex = 17;
            this.lblCompany.Text = "Empresa";
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(499, 66);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(128, 96);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 37;
            this.pbPhoto.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(17, 12);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(17, 168);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(93, 13);
            this.lblBirthDate.TabIndex = 13;
            this.lblBirthDate.Text = "Fecha Nacimiento";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(243, 168);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 13);
            this.lblAge.TabIndex = 15;
            this.lblAge.Text = "Edad";
            // 
            // lblWorkArea
            // 
            this.lblWorkArea.AutoSize = true;
            this.lblWorkArea.Location = new System.Drawing.Point(17, 326);
            this.lblWorkArea.Name = "lblWorkArea";
            this.lblWorkArea.Size = new System.Drawing.Size(88, 13);
            this.lblWorkArea.TabIndex = 29;
            this.lblWorkArea.Text = "Sector de trabajo";
            // 
            // lblTasksToDo
            // 
            this.lblTasksToDo.AutoSize = true;
            this.lblTasksToDo.Location = new System.Drawing.Point(17, 299);
            this.lblTasksToDo.Name = "lblTasksToDo";
            this.lblTasksToDo.Size = new System.Drawing.Size(179, 13);
            this.lblTasksToDo.TabIndex = 27;
            this.lblTasksToDo.Text = "Tareas para las que ingresa (puesto)";
            // 
            // lblCompanyPhone
            // 
            this.lblCompanyPhone.AutoSize = true;
            this.lblCompanyPhone.Location = new System.Drawing.Point(17, 273);
            this.lblCompanyPhone.Name = "lblCompanyPhone";
            this.lblCompanyPhone.Size = new System.Drawing.Size(49, 13);
            this.lblCompanyPhone.TabIndex = 25;
            this.lblCompanyPhone.Text = "Teléfono";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 142);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(44, 13);
            this.lblFirstName.TabIndex = 11;
            this.lblFirstName.Text = "Nombre";
            // 
            // lblCompanyCuit
            // 
            this.lblCompanyCuit.AutoSize = true;
            this.lblCompanyCuit.Location = new System.Drawing.Point(17, 220);
            this.lblCompanyCuit.Name = "lblCompanyCuit";
            this.lblCompanyCuit.Size = new System.Drawing.Size(32, 13);
            this.lblCompanyCuit.TabIndex = 21;
            this.lblCompanyCuit.Text = "CUIT";
            // 
            // lblCompanyAddress
            // 
            this.lblCompanyAddress.AutoSize = true;
            this.lblCompanyAddress.Location = new System.Drawing.Point(17, 244);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(49, 13);
            this.lblCompanyAddress.TabIndex = 23;
            this.lblCompanyAddress.Text = "Domicilio";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(17, 113);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Apellido";
            // 
            // txtCurrentDate
            // 
            this.txtCurrentDate.Location = new System.Drawing.Point(107, 9);
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.ReadOnly = true;
            this.txtCurrentDate.Size = new System.Drawing.Size(87, 20);
            this.txtCurrentDate.TabIndex = 1;
            // 
            // txtWorkArea
            // 
            this.txtWorkArea.Location = new System.Drawing.Point(202, 323);
            this.txtWorkArea.Name = "txtWorkArea";
            this.txtWorkArea.Size = new System.Drawing.Size(422, 20);
            this.txtWorkArea.TabIndex = 30;
            // 
            // txtPatientBirthDay
            // 
            this.txtPatientBirthDay.Location = new System.Drawing.Point(116, 165);
            this.txtPatientBirthDay.Name = "txtPatientBirthDay";
            this.txtPatientBirthDay.ReadOnly = true;
            this.txtPatientBirthDay.Size = new System.Drawing.Size(121, 20);
            this.txtPatientBirthDay.TabIndex = 14;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(281, 165);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(47, 20);
            this.txtAge.TabIndex = 16;
            // 
            // txtTaskToDo
            // 
            this.txtTaskToDo.Location = new System.Drawing.Point(202, 296);
            this.txtTaskToDo.Name = "txtTaskToDo";
            this.txtTaskToDo.Size = new System.Drawing.Size(422, 20);
            this.txtTaskToDo.TabIndex = 28;
            // 
            // txtCompanyPhone
            // 
            this.txtCompanyPhone.Location = new System.Drawing.Point(83, 270);
            this.txtCompanyPhone.Name = "txtCompanyPhone";
            this.txtCompanyPhone.ReadOnly = true;
            this.txtCompanyPhone.Size = new System.Drawing.Size(541, 20);
            this.txtCompanyPhone.TabIndex = 26;
            // 
            // txtCompanyCuit
            // 
            this.txtCompanyCuit.Location = new System.Drawing.Point(83, 220);
            this.txtCompanyCuit.Name = "txtCompanyCuit";
            this.txtCompanyCuit.ReadOnly = true;
            this.txtCompanyCuit.Size = new System.Drawing.Size(245, 20);
            this.txtCompanyCuit.TabIndex = 22;
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(83, 244);
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.ReadOnly = true;
            this.txtCompanyAddress.Size = new System.Drawing.Size(541, 20);
            this.txtCompanyAddress.TabIndex = 24;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(83, 139);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(410, 20);
            this.txtFirstName.TabIndex = 12;
            // 
            // txtLastName
            // 
            this.txtLastName.CausesValidation = false;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.Location = new System.Drawing.Point(83, 113);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(410, 20);
            this.txtLastName.TabIndex = 10;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.Location = new System.Drawing.Point(176, 86);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(180, 20);
            this.txtDocumentNumber.TabIndex = 7;
            this.txtDocumentNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDocumentNumber_KeyUp);
            this.txtDocumentNumber.Leave += new System.EventHandler(this.txtDocumentNumber_Leave);
            // 
            // cbDocumentType
            // 
            this.cbDocumentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDocumentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbDocumentType.Location = new System.Drawing.Point(83, 86);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(87, 21);
            this.cbDocumentType.TabIndex = 6;
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(17, 90);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(62, 13);
            this.lblDocument.TabIndex = 5;
            this.lblDocument.Text = "Documento";
            // 
            // tabPagePractices
            // 
            this.tabPagePractices.Controls.Add(this.btnSearch);
            this.tabPagePractices.Controls.Add(this.cbPracticeName);
            this.tabPagePractices.Controls.Add(this.txtPracticeCode);
            this.tabPagePractices.Controls.Add(this.lblPracticeCode);
            this.tabPagePractices.Controls.Add(this.lblPracticeName);
            this.tabPagePractices.Controls.Add(this.gvPractices);
            this.tabPagePractices.Location = new System.Drawing.Point(4, 22);
            this.tabPagePractices.Name = "tabPagePractices";
            this.tabPagePractices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePractices.Size = new System.Drawing.Size(1146, 463);
            this.tabPagePractices.TabIndex = 4;
            this.tabPagePractices.Text = "Prácticas";
            this.tabPagePractices.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(705, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbPracticeName
            // 
            this.cbPracticeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPracticeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPracticeName.FormattingEnabled = true;
            this.cbPracticeName.Location = new System.Drawing.Point(332, 12);
            this.cbPracticeName.Name = "cbPracticeName";
            this.cbPracticeName.Size = new System.Drawing.Size(367, 21);
            this.cbPracticeName.TabIndex = 3;
            this.cbPracticeName.SelectedIndexChanged += new System.EventHandler(this.cbPracticeName_SelectedIndexChanged);
            // 
            // txtPracticeCode
            // 
            this.txtPracticeCode.Location = new System.Drawing.Point(52, 13);
            this.txtPracticeCode.Name = "txtPracticeCode";
            this.txtPracticeCode.Size = new System.Drawing.Size(224, 20);
            this.txtPracticeCode.TabIndex = 1;
            this.txtPracticeCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPracticeCode_KeyUp);
            // 
            // lblPracticeCode
            // 
            this.lblPracticeCode.AutoSize = true;
            this.lblPracticeCode.Location = new System.Drawing.Point(6, 16);
            this.lblPracticeCode.Name = "lblPracticeCode";
            this.lblPracticeCode.Size = new System.Drawing.Size(40, 13);
            this.lblPracticeCode.TabIndex = 0;
            this.lblPracticeCode.Text = "Código";
            // 
            // lblPracticeName
            // 
            this.lblPracticeName.AutoSize = true;
            this.lblPracticeName.Location = new System.Drawing.Point(282, 16);
            this.lblPracticeName.Name = "lblPracticeName";
            this.lblPracticeName.Size = new System.Drawing.Size(44, 13);
            this.lblPracticeName.TabIndex = 2;
            this.lblPracticeName.Text = "Nombre";
            // 
            // gvPractices
            // 
            this.gvPractices.AllowUserToAddRows = false;
            this.gvPractices.AllowUserToDeleteRows = false;
            this.gvPractices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPractices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.IsGroup,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Status});
            this.gvPractices.Location = new System.Drawing.Point(9, 39);
            this.gvPractices.Name = "gvPractices";
            this.gvPractices.ReadOnly = true;
            this.gvPractices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPractices.Size = new System.Drawing.Size(833, 402);
            this.gvPractices.TabIndex = 5;
            this.gvPractices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPractices_CellDoubleClick);
            this.gvPractices.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvPractices_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 2;
            // 
            // IsGroup
            // 
            this.IsGroup.DataPropertyName = "IsGroup";
            this.IsGroup.HeaderText = "IsGroup";
            this.IsGroup.Name = "IsGroup";
            this.IsGroup.ReadOnly = true;
            this.IsGroup.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Estado";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1092, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveClinicalExam
            // 
            this.btnSaveClinicalExam.Location = new System.Drawing.Point(869, 507);
            this.btnSaveClinicalExam.Name = "btnSaveClinicalExam";
            this.btnSaveClinicalExam.Size = new System.Drawing.Size(75, 23);
            this.btnSaveClinicalExam.TabIndex = 0;
            this.btnSaveClinicalExam.Text = "Guardar";
            this.btnSaveClinicalExam.UseVisualStyleBackColor = true;
            this.btnSaveClinicalExam.Click += new System.EventHandler(this.btnSaveClinicalExam_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(950, 507);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Imprimir Eval. Final";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // epClinicalHistory
            // 
            this.epClinicalHistory.ContainerControl = this;
            // 
            // btnPrintPartial
            // 
            this.btnPrintPartial.Location = new System.Drawing.Point(12, 507);
            this.btnPrintPartial.Name = "btnPrintPartial";
            this.btnPrintPartial.Size = new System.Drawing.Size(198, 23);
            this.btnPrintPartial.TabIndex = 3;
            this.btnPrintPartial.Text = "Imprimir DDJJ + H. Clínica";
            this.btnPrintPartial.UseVisualStyleBackColor = true;
            this.btnPrintPartial.Click += new System.EventHandler(this.btnPrintPartial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Recepcionado por:";
            // 
            // lblReceptionUser
            // 
            this.lblReceptionUser.AutoSize = true;
            this.lblReceptionUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceptionUser.Location = new System.Drawing.Point(478, 12);
            this.lblReceptionUser.Name = "lblReceptionUser";
            this.lblReceptionUser.Size = new System.Drawing.Size(0, 13);
            this.lblReceptionUser.TabIndex = 48;
            // 
            // FrmAddClinicalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 542);
            this.Controls.Add(this.btnPrintPartial);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSaveClinicalExam);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabClinicalHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddClinicalHistory";
            this.Text = "Historia Clínica";
            this.Load += new System.EventHandler(this.FrmAddClinicalHistory_Load);
            this.tabClinicalHistory.ResumeLayout(false);
            this.tabPageGeneralInformation.ResumeLayout(false);
            this.tabPageGeneralInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.tabPagePractices.ResumeLayout(false);
            this.tabPagePractices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epClinicalHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabClinicalHistory;
        private System.Windows.Forms.TabPage tabPageGeneralInformation;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtCurrentDate;
        private System.Windows.Forms.ComboBox cbExamType;
        private System.Windows.Forms.Label lblExamType;
        private System.Windows.Forms.Label lblCompanyPhone;
        private System.Windows.Forms.Label lblCompanyAddress;
        private System.Windows.Forms.TextBox txtCompanyPhone;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.Label lblTasksToDo;
        private System.Windows.Forms.TextBox txtTaskToDo;
        private System.Windows.Forms.Label lblObservations;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.Label lblWorkArea;
        private System.Windows.Forms.TextBox txtWorkArea;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCompanyCuit;
        private System.Windows.Forms.TextBox txtCompanyCuit;
        private System.Windows.Forms.TextBox txtPatientBirthDay;
        private System.Windows.Forms.Button btnEditPatient;
        private System.Windows.Forms.Button btnSaveClinicalExam;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolTip tooltipExam;
        private System.Windows.Forms.TabPage tabPagePractices;
        private System.Windows.Forms.ComboBox cbPracticeName;
        private System.Windows.Forms.TextBox txtPracticeCode;
        private System.Windows.Forms.Label lblPracticeCode;
        private System.Windows.Forms.Label lblPracticeName;
        private System.Windows.Forms.DataGridView gvPractices;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkIsHighPriority;
        private System.Windows.Forms.ErrorProvider epClinicalHistory;
        private System.Windows.Forms.Button btnPrintPartial;
        private System.Windows.Forms.Label lblObservationMessage;
        private System.Windows.Forms.ComboBox cbClienArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtAnotherTypeDescription;
        private System.Windows.Forms.Button btnUpdateCompaniesDropdown;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label lblChargeToClient;
        private System.Windows.Forms.ComboBox cbChargeToClient;
        private System.Windows.Forms.Label lblReceptionUser;
        private System.Windows.Forms.Label label1;
    }
}