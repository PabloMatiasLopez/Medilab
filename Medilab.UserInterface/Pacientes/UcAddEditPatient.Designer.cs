namespace Medilab.UserInterface.Pacientes
{
    partial class UcAddEditPatient
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
            this.components = new System.ComponentModel.Container();
            this.lblDocument = new System.Windows.Forms.Label();
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.cbBirthState = new System.Windows.Forms.ComboBox();
            this.gbCivilState = new System.Windows.Forms.GroupBox();
            this.rbWidowed = new System.Windows.Forms.RadioButton();
            this.rbDivorced = new System.Windows.Forms.RadioButton();
            this.rbMarried = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.gbInstruction = new System.Windows.Forms.GroupBox();
            this.rbUniversity = new System.Windows.Forms.RadioButton();
            this.rbTertiary = new System.Windows.Forms.RadioButton();
            this.rbSecondary = new System.Windows.Forms.RadioButton();
            this.rbPrimary = new System.Windows.Forms.RadioButton();
            this.lblTitule = new System.Windows.Forms.Label();
            this.txtInstructionTitle = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.txtChildrenNumber = new System.Windows.Forms.TextBox();
            this.lblChildren = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.gbPhone = new System.Windows.Forms.GroupBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.patientErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.gbPrivateMedicine = new System.Windows.Forms.GroupBox();
            this.lblPrivateMedicine = new System.Windows.Forms.Label();
            this.cbPrivateMedicine = new System.Windows.Forms.ComboBox();
            this.txtPrivateMedicineNumber = new System.Windows.Forms.TextBox();
            this.lblPrivateMedicineNumber = new System.Windows.Forms.Label();
            this.gbRiskInsurance = new System.Windows.Forms.GroupBox();
            this.lblRiskInsuranceName = new System.Windows.Forms.Label();
            this.cbRiskInsurance = new System.Windows.Forms.ComboBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.patientAddress = new Medilab.UserInterface.Pacientes.UcAddress();
            this.gbCivilState.SuspendLayout();
            this.gbInstruction.SuspendLayout();
            this.gbGender.SuspendLayout();
            this.gbPhone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.gbPrivateMedicine.SuspendLayout();
            this.gbRiskInsurance.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(17, 12);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(62, 13);
            this.lblDocument.TabIndex = 0;
            this.lblDocument.Text = "Documento";
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
            this.cbDocumentType.Location = new System.Drawing.Point(83, 8);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(142, 21);
            this.cbDocumentType.TabIndex = 1;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.Location = new System.Drawing.Point(231, 8);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(180, 20);
            this.txtDocumentNumber.TabIndex = 2;
            this.txtDocumentNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDocumentNumber_KeyUp);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(17, 35);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Apellido";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(83, 35);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(410, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(83, 61);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(410, 20);
            this.txtFirstName.TabIndex = 6;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 64);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(44, 13);
            this.lblFirstName.TabIndex = 5;
            this.lblFirstName.Text = "Nombre";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(335, 93);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(34, 13);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "Lugar";
            // 
            // cbBirthState
            // 
            this.cbBirthState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBirthState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBirthState.FormattingEnabled = true;
            this.cbBirthState.Location = new System.Drawing.Point(375, 90);
            this.cbBirthState.Name = "cbBirthState";
            this.cbBirthState.Size = new System.Drawing.Size(118, 21);
            this.cbBirthState.TabIndex = 12;
            // 
            // gbCivilState
            // 
            this.gbCivilState.Controls.Add(this.rbWidowed);
            this.gbCivilState.Controls.Add(this.rbDivorced);
            this.gbCivilState.Controls.Add(this.rbMarried);
            this.gbCivilState.Controls.Add(this.rbSingle);
            this.gbCivilState.Location = new System.Drawing.Point(522, 123);
            this.gbCivilState.Name = "gbCivilState";
            this.gbCivilState.Size = new System.Drawing.Size(352, 54);
            this.gbCivilState.TabIndex = 20;
            this.gbCivilState.TabStop = false;
            this.gbCivilState.Text = "Estado Civil";
            // 
            // rbWidowed
            // 
            this.rbWidowed.AutoSize = true;
            this.rbWidowed.Location = new System.Drawing.Point(223, 19);
            this.rbWidowed.Name = "rbWidowed";
            this.rbWidowed.Size = new System.Drawing.Size(52, 17);
            this.rbWidowed.TabIndex = 3;
            this.rbWidowed.Tag = "4";
            this.rbWidowed.Text = "Viudo";
            this.rbWidowed.UseVisualStyleBackColor = true;
            // 
            // rbDivorced
            // 
            this.rbDivorced.AutoSize = true;
            this.rbDivorced.Location = new System.Drawing.Point(138, 19);
            this.rbDivorced.Name = "rbDivorced";
            this.rbDivorced.Size = new System.Drawing.Size(76, 17);
            this.rbDivorced.TabIndex = 2;
            this.rbDivorced.Tag = "3";
            this.rbDivorced.Text = "Divorciado";
            this.rbDivorced.UseVisualStyleBackColor = true;
            // 
            // rbMarried
            // 
            this.rbMarried.AutoSize = true;
            this.rbMarried.Location = new System.Drawing.Point(71, 19);
            this.rbMarried.Name = "rbMarried";
            this.rbMarried.Size = new System.Drawing.Size(61, 17);
            this.rbMarried.TabIndex = 1;
            this.rbMarried.Tag = "2";
            this.rbMarried.Text = "Casado";
            this.rbMarried.UseVisualStyleBackColor = true;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Checked = true;
            this.rbSingle.Location = new System.Drawing.Point(7, 20);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(58, 17);
            this.rbSingle.TabIndex = 0;
            this.rbSingle.TabStop = true;
            this.rbSingle.Tag = "1";
            this.rbSingle.Text = "Soltero";
            this.rbSingle.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(281, 93);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(47, 20);
            this.txtAge.TabIndex = 10;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(243, 93);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 13);
            this.lblAge.TabIndex = 9;
            this.lblAge.Text = "Edad";
            // 
            // gbInstruction
            // 
            this.gbInstruction.Controls.Add(this.rbUniversity);
            this.gbInstruction.Controls.Add(this.rbTertiary);
            this.gbInstruction.Controls.Add(this.rbSecondary);
            this.gbInstruction.Controls.Add(this.rbPrimary);
            this.gbInstruction.Controls.Add(this.lblTitule);
            this.gbInstruction.Controls.Add(this.txtInstructionTitle);
            this.gbInstruction.Location = new System.Drawing.Point(17, 207);
            this.gbInstruction.Name = "gbInstruction";
            this.gbInstruction.Size = new System.Drawing.Size(473, 83);
            this.gbInstruction.TabIndex = 18;
            this.gbInstruction.TabStop = false;
            this.gbInstruction.Text = "Escolaridad Completa";
            // 
            // rbUniversity
            // 
            this.rbUniversity.AutoSize = true;
            this.rbUniversity.Location = new System.Drawing.Point(231, 20);
            this.rbUniversity.Name = "rbUniversity";
            this.rbUniversity.Size = new System.Drawing.Size(83, 17);
            this.rbUniversity.TabIndex = 3;
            this.rbUniversity.Tag = "4";
            this.rbUniversity.Text = "Universitaria";
            this.rbUniversity.UseVisualStyleBackColor = true;
            // 
            // rbTertiary
            // 
            this.rbTertiary.AutoSize = true;
            this.rbTertiary.Location = new System.Drawing.Point(159, 20);
            this.rbTertiary.Name = "rbTertiary";
            this.rbTertiary.Size = new System.Drawing.Size(66, 17);
            this.rbTertiary.TabIndex = 2;
            this.rbTertiary.Tag = "3";
            this.rbTertiary.Text = "Terciaria";
            this.rbTertiary.UseVisualStyleBackColor = true;
            // 
            // rbSecondary
            // 
            this.rbSecondary.AutoSize = true;
            this.rbSecondary.Location = new System.Drawing.Point(74, 20);
            this.rbSecondary.Name = "rbSecondary";
            this.rbSecondary.Size = new System.Drawing.Size(79, 17);
            this.rbSecondary.TabIndex = 1;
            this.rbSecondary.Tag = "2";
            this.rbSecondary.Text = "Secundaria";
            this.rbSecondary.UseVisualStyleBackColor = true;
            // 
            // rbPrimary
            // 
            this.rbPrimary.AutoSize = true;
            this.rbPrimary.Checked = true;
            this.rbPrimary.Location = new System.Drawing.Point(7, 20);
            this.rbPrimary.Name = "rbPrimary";
            this.rbPrimary.Size = new System.Drawing.Size(62, 17);
            this.rbPrimary.TabIndex = 0;
            this.rbPrimary.TabStop = true;
            this.rbPrimary.Tag = "1";
            this.rbPrimary.Text = "Primaria";
            this.rbPrimary.UseVisualStyleBackColor = true;
            // 
            // lblTitule
            // 
            this.lblTitule.AutoSize = true;
            this.lblTitule.Location = new System.Drawing.Point(9, 50);
            this.lblTitule.Name = "lblTitule";
            this.lblTitule.Size = new System.Drawing.Size(35, 13);
            this.lblTitule.TabIndex = 4;
            this.lblTitule.Text = "Título";
            // 
            // txtInstructionTitle
            // 
            this.txtInstructionTitle.Location = new System.Drawing.Point(50, 50);
            this.txtInstructionTitle.Name = "txtInstructionTitle";
            this.txtInstructionTitle.Size = new System.Drawing.Size(346, 20);
            this.txtInstructionTitle.TabIndex = 5;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Location = new System.Drawing.Point(53, 24);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(185, 20);
            this.txtHomePhone.TabIndex = 1;
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.AutoSize = true;
            this.lblHomePhone.Location = new System.Drawing.Point(11, 24);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(23, 13);
            this.lblHomePhone.TabIndex = 0;
            this.lblHomePhone.Text = "Fijo";
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Location = new System.Drawing.Point(54, 50);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(184, 20);
            this.txtCellPhone.TabIndex = 3;
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.AutoSize = true;
            this.lblCellPhone.Location = new System.Drawing.Point(9, 53);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(39, 13);
            this.lblCellPhone.TabIndex = 2;
            this.lblCellPhone.Text = "Celular";
            // 
            // gbGender
            // 
            this.gbGender.Controls.Add(this.rbFemale);
            this.gbGender.Controls.Add(this.rbMale);
            this.gbGender.Location = new System.Drawing.Point(17, 145);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(147, 49);
            this.gbGender.TabIndex = 15;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Sexo";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(75, 19);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(51, 17);
            this.rbFemale.TabIndex = 1;
            this.rbFemale.Tag = "2";
            this.rbFemale.Text = "Mujer";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(7, 18);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(62, 17);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Tag = "1";
            this.rbMale.Text = "Hombre";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // txtChildrenNumber
            // 
            this.txtChildrenNumber.Location = new System.Drawing.Point(260, 162);
            this.txtChildrenNumber.Name = "txtChildrenNumber";
            this.txtChildrenNumber.Size = new System.Drawing.Size(106, 20);
            this.txtChildrenNumber.TabIndex = 17;
            // 
            // lblChildren
            // 
            this.lblChildren.AutoSize = true;
            this.lblChildren.Location = new System.Drawing.Point(170, 165);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(88, 13);
            this.lblChildren.TabIndex = 16;
            this.lblChildren.Text = "Cantidad de hijos";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(17, 93);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(93, 13);
            this.lblBirthDate.TabIndex = 7;
            this.lblBirthDate.Text = "Fecha Nacimiento";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(119, 93);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(106, 20);
            this.dtpBirthDate.TabIndex = 8;
            this.dtpBirthDate.Leave += new System.EventHandler(this.dtpBirthDate_Leave);
            // 
            // gbPhone
            // 
            this.gbPhone.Controls.Add(this.lblHomePhone);
            this.gbPhone.Controls.Add(this.txtHomePhone);
            this.gbPhone.Controls.Add(this.txtCellPhone);
            this.gbPhone.Controls.Add(this.lblCellPhone);
            this.gbPhone.Location = new System.Drawing.Point(522, 183);
            this.gbPhone.Name = "gbPhone";
            this.gbPhone.Size = new System.Drawing.Size(352, 82);
            this.gbPhone.TabIndex = 22;
            this.gbPhone.TabStop = false;
            this.gbPhone.Text = "Teléfono";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(418, 5);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 0;
            this.btnDetails.Text = "Detalles";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Visible = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(781, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(862, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // patientErrorProvider
            // 
            this.patientErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.patientErrorProvider.ContainerControl = this;
            // 
            // txtObservations
            // 
            this.txtObservations.Location = new System.Drawing.Point(522, 435);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(352, 44);
            this.txtObservations.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Observaciones";
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(522, 12);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(128, 96);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 25;
            this.pbPhoto.TabStop = false;
            // 
            // gbPrivateMedicine
            // 
            this.gbPrivateMedicine.Controls.Add(this.lblPrivateMedicine);
            this.gbPrivateMedicine.Controls.Add(this.cbPrivateMedicine);
            this.gbPrivateMedicine.Controls.Add(this.txtPrivateMedicineNumber);
            this.gbPrivateMedicine.Controls.Add(this.lblPrivateMedicineNumber);
            this.gbPrivateMedicine.Location = new System.Drawing.Point(522, 271);
            this.gbPrivateMedicine.Name = "gbPrivateMedicine";
            this.gbPrivateMedicine.Size = new System.Drawing.Size(352, 76);
            this.gbPrivateMedicine.TabIndex = 23;
            this.gbPrivateMedicine.TabStop = false;
            this.gbPrivateMedicine.Text = "Obra Social";
            // 
            // lblPrivateMedicine
            // 
            this.lblPrivateMedicine.AutoSize = true;
            this.lblPrivateMedicine.Location = new System.Drawing.Point(11, 24);
            this.lblPrivateMedicine.Name = "lblPrivateMedicine";
            this.lblPrivateMedicine.Size = new System.Drawing.Size(62, 13);
            this.lblPrivateMedicine.TabIndex = 0;
            this.lblPrivateMedicine.Text = "Obra Social";
            // 
            // cbPrivateMedicine
            // 
            this.cbPrivateMedicine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPrivateMedicine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPrivateMedicine.FormattingEnabled = true;
            this.cbPrivateMedicine.Location = new System.Drawing.Point(107, 20);
            this.cbPrivateMedicine.Name = "cbPrivateMedicine";
            this.cbPrivateMedicine.Size = new System.Drawing.Size(227, 21);
            this.cbPrivateMedicine.TabIndex = 1;
            // 
            // txtPrivateMedicineNumber
            // 
            this.txtPrivateMedicineNumber.Location = new System.Drawing.Point(107, 49);
            this.txtPrivateMedicineNumber.Name = "txtPrivateMedicineNumber";
            this.txtPrivateMedicineNumber.Size = new System.Drawing.Size(227, 20);
            this.txtPrivateMedicineNumber.TabIndex = 3;
            // 
            // lblPrivateMedicineNumber
            // 
            this.lblPrivateMedicineNumber.AutoSize = true;
            this.lblPrivateMedicineNumber.Location = new System.Drawing.Point(11, 52);
            this.lblPrivateMedicineNumber.Name = "lblPrivateMedicineNumber";
            this.lblPrivateMedicineNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPrivateMedicineNumber.TabIndex = 2;
            this.lblPrivateMedicineNumber.Text = "Numero Afiliado";
            // 
            // gbRiskInsurance
            // 
            this.gbRiskInsurance.Controls.Add(this.lblRiskInsuranceName);
            this.gbRiskInsurance.Controls.Add(this.cbRiskInsurance);
            this.gbRiskInsurance.Location = new System.Drawing.Point(522, 353);
            this.gbRiskInsurance.Name = "gbRiskInsurance";
            this.gbRiskInsurance.Size = new System.Drawing.Size(352, 60);
            this.gbRiskInsurance.TabIndex = 24;
            this.gbRiskInsurance.TabStop = false;
            this.gbRiskInsurance.Text = "Aseguradora de Riesgos del Trabajo (ART)";
            // 
            // lblRiskInsuranceName
            // 
            this.lblRiskInsuranceName.AutoSize = true;
            this.lblRiskInsuranceName.Location = new System.Drawing.Point(11, 24);
            this.lblRiskInsuranceName.Name = "lblRiskInsuranceName";
            this.lblRiskInsuranceName.Size = new System.Drawing.Size(69, 13);
            this.lblRiskInsuranceName.TabIndex = 0;
            this.lblRiskInsuranceName.Text = "Nombre ART";
            // 
            // cbRiskInsurance
            // 
            this.cbRiskInsurance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRiskInsurance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRiskInsurance.FormattingEnabled = true;
            this.cbRiskInsurance.Location = new System.Drawing.Point(107, 21);
            this.cbRiskInsurance.Name = "cbRiskInsurance";
            this.cbRiskInsurance.Size = new System.Drawing.Size(227, 21);
            this.cbRiskInsurance.TabIndex = 1;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(119, 119);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(209, 20);
            this.txtNationality.TabIndex = 14;
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(17, 123);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(69, 13);
            this.lblNationality.TabIndex = 13;
            this.lblNationality.Text = "Nacionalidad";
            // 
            // patientAddress
            // 
            this.patientAddress.Location = new System.Drawing.Point(17, 303);
            this.patientAddress.Name = "patientAddress";
            this.patientAddress.Size = new System.Drawing.Size(482, 178);
            this.patientAddress.TabIndex = 19;
            // 
            // UcAddEditPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patientAddress);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtObservations);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.gbRiskInsurance);
            this.Controls.Add(this.gbPrivateMedicine);
            this.Controls.Add(this.gbPhone);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.gbInstruction);
            this.Controls.Add(this.gbCivilState);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblChildren);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtChildrenNumber);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtDocumentNumber);
            this.Controls.Add(this.cbBirthState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.cbDocumentType);
            this.Controls.Add(this.lblDocument);
            this.Name = "UcAddEditPatient";
            this.Size = new System.Drawing.Size(940, 530);
            this.Load += new System.EventHandler(this.UcAddEditPatient_Load);
            this.gbCivilState.ResumeLayout(false);
            this.gbCivilState.PerformLayout();
            this.gbInstruction.ResumeLayout(false);
            this.gbInstruction.PerformLayout();
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.gbPhone.ResumeLayout(false);
            this.gbPhone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.gbPrivateMedicine.ResumeLayout(false);
            this.gbPrivateMedicine.PerformLayout();
            this.gbRiskInsurance.ResumeLayout(false);
            this.gbRiskInsurance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cbBirthState;
        private System.Windows.Forms.GroupBox gbCivilState;
        private System.Windows.Forms.RadioButton rbWidowed;
        private System.Windows.Forms.RadioButton rbDivorced;
        private System.Windows.Forms.RadioButton rbMarried;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.GroupBox gbInstruction;
        private System.Windows.Forms.RadioButton rbUniversity;
        private System.Windows.Forms.RadioButton rbTertiary;
        private System.Windows.Forms.RadioButton rbSecondary;
        private System.Windows.Forms.RadioButton rbPrimary;
        private System.Windows.Forms.TextBox txtInstructionTitle;
        private System.Windows.Forms.Label lblTitule;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox txtChildrenNumber;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.GroupBox gbPhone;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider patientErrorProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.GroupBox gbPrivateMedicine;
        private System.Windows.Forms.Label lblPrivateMedicine;
        private System.Windows.Forms.ComboBox cbPrivateMedicine;
        private System.Windows.Forms.GroupBox gbRiskInsurance;
        private System.Windows.Forms.Label lblRiskInsuranceName;
        private System.Windows.Forms.ComboBox cbRiskInsurance;
        private System.Windows.Forms.TextBox txtPrivateMedicineNumber;
        private System.Windows.Forms.Label lblPrivateMedicineNumber;
        private UcAddress patientAddress;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.TextBox txtNationality;
    }
}
