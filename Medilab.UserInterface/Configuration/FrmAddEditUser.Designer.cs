namespace Medilab.UserInterface.Configuration
{
    partial class FrmAddEditUser
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
            this.chklstRoles = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRetypePassword = new System.Windows.Forms.Label();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.userErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSpeciality = new System.Windows.Forms.Label();
            this.cbSpeciality = new System.Windows.Forms.ComboBox();
            this.chkResetPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.userErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // chklstRoles
            // 
            this.chklstRoles.CheckOnClick = true;
            this.chklstRoles.FormattingEnabled = true;
            this.chklstRoles.Location = new System.Drawing.Point(136, 199);
            this.chklstRoles.Name = "chklstRoles";
            this.chklstRoles.Size = new System.Drawing.Size(383, 124);
            this.chklstRoles.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(444, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(362, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUserName.Location = new System.Drawing.Point(136, 64);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(383, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(12, 199);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(34, 13);
            this.lblRoles.TabIndex = 18;
            this.lblRoles.Text = "Roles";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 15);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(44, 13);
            this.lblFirstName.TabIndex = 12;
            this.lblFirstName.Text = "Nombre";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 67);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(98, 13);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "Nombre de Usuario";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(136, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(383, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(136, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(383, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(136, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(383, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 41);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 13;
            this.lblLastName.Text = "Apellido";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 93);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // lblRetypePassword
            // 
            this.lblRetypePassword.AutoSize = true;
            this.lblRetypePassword.Location = new System.Drawing.Point(12, 168);
            this.lblRetypePassword.Name = "lblRetypePassword";
            this.lblRetypePassword.Size = new System.Drawing.Size(70, 13);
            this.lblRetypePassword.TabIndex = 17;
            this.lblRetypePassword.Text = "Repetir clave";
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(136, 165);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.Size = new System.Drawing.Size(383, 20);
            this.txtRetypePassword.TabIndex = 6;
            this.txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 139);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(383, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 142);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(34, 13);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Clave";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(136, 116);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(56, 17);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.Text = "Activo";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // userErrorProvider
            // 
            this.userErrorProvider.ContainerControl = this;
            // 
            // lblSpeciality
            // 
            this.lblSpeciality.AutoSize = true;
            this.lblSpeciality.Location = new System.Drawing.Point(12, 332);
            this.lblSpeciality.Name = "lblSpeciality";
            this.lblSpeciality.Size = new System.Drawing.Size(67, 13);
            this.lblSpeciality.TabIndex = 19;
            this.lblSpeciality.Text = "Especialidad";
            // 
            // cbSpeciality
            // 
            this.cbSpeciality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSpeciality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSpeciality.FormattingEnabled = true;
            this.cbSpeciality.Location = new System.Drawing.Point(136, 329);
            this.cbSpeciality.Name = "cbSpeciality";
            this.cbSpeciality.Size = new System.Drawing.Size(383, 21);
            this.cbSpeciality.TabIndex = 8;
            // 
            // chkResetPassword
            // 
            this.chkResetPassword.AutoSize = true;
            this.chkResetPassword.Location = new System.Drawing.Point(136, 356);
            this.chkResetPassword.Name = "chkResetPassword";
            this.chkResetPassword.Size = new System.Drawing.Size(93, 17);
            this.chkResetPassword.TabIndex = 9;
            this.chkResetPassword.Text = "Cambiar clave";
            this.chkResetPassword.UseVisualStyleBackColor = true;
            // 
            // FrmAddEditUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(548, 388);
            this.Controls.Add(this.chkResetPassword);
            this.Controls.Add(this.cbSpeciality);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.lblRetypePassword);
            this.Controls.Add(this.txtRetypePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.chklstRoles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblSpeciality);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditUser";
            this.Text = "Agregar Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.userErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklstRoles;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRetypePassword;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider userErrorProvider;
        private System.Windows.Forms.ComboBox cbSpeciality;
        private System.Windows.Forms.Label lblSpeciality;
        private System.Windows.Forms.CheckBox chkResetPassword;
    }
}