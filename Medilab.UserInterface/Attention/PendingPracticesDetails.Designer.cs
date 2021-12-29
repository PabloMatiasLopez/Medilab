namespace Medilab.UserInterface.Attention
{
    partial class PendingPracticesDetails
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
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.lblDocument = new System.Windows.Forms.Label();
            this.gbPatientInformation = new System.Windows.Forms.GroupBox();
            this.txtPatientNumber = new System.Windows.Forms.TextBox();
            this.lblPatientNumber = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.gvPractices = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeDone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMarkAsIncomplete = new System.Windows.Forms.Button();
            this.btnMarkAsDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.gbPatientInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(393, 30);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(128, 96);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 44;
            this.pbPhoto.TabStop = false;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(8, 81);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(44, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Nombre";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(92, 78);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(286, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.Location = new System.Drawing.Point(92, 53);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.ReadOnly = true;
            this.txtDocumentNumber.Size = new System.Drawing.Size(286, 20);
            this.txtDocumentNumber.TabIndex = 1;
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(8, 56);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(62, 13);
            this.lblDocument.TabIndex = 0;
            this.lblDocument.Text = "Documento";
            // 
            // gbPatientInformation
            // 
            this.gbPatientInformation.Controls.Add(this.txtPatientNumber);
            this.gbPatientInformation.Controls.Add(this.lblPatientNumber);
            this.gbPatientInformation.Controls.Add(this.txtDocumentNumber);
            this.gbPatientInformation.Controls.Add(this.pbPhoto);
            this.gbPatientInformation.Controls.Add(this.lblDocument);
            this.gbPatientInformation.Controls.Add(this.lblObservaciones);
            this.gbPatientInformation.Controls.Add(this.lblClient);
            this.gbPatientInformation.Controls.Add(this.lblFirstName);
            this.gbPatientInformation.Controls.Add(this.txtObservations);
            this.gbPatientInformation.Controls.Add(this.txtClient);
            this.gbPatientInformation.Controls.Add(this.txtFullName);
            this.gbPatientInformation.Location = new System.Drawing.Point(12, 12);
            this.gbPatientInformation.Name = "gbPatientInformation";
            this.gbPatientInformation.Size = new System.Drawing.Size(527, 189);
            this.gbPatientInformation.TabIndex = 3;
            this.gbPatientInformation.TabStop = false;
            this.gbPatientInformation.Text = "Información del Paciente";
            // 
            // txtPatientNumber
            // 
            this.txtPatientNumber.AccessibleRole = System.Windows.Forms.AccessibleRole.Row;
            this.txtPatientNumber.Location = new System.Drawing.Point(92, 27);
            this.txtPatientNumber.Name = "txtPatientNumber";
            this.txtPatientNumber.ReadOnly = true;
            this.txtPatientNumber.Size = new System.Drawing.Size(32, 20);
            this.txtPatientNumber.TabIndex = 46;
            // 
            // lblPatientNumber
            // 
            this.lblPatientNumber.AutoSize = true;
            this.lblPatientNumber.Location = new System.Drawing.Point(8, 30);
            this.lblPatientNumber.Name = "lblPatientNumber";
            this.lblPatientNumber.Size = new System.Drawing.Size(44, 13);
            this.lblPatientNumber.TabIndex = 45;
            this.lblPatientNumber.Text = "Número";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(8, 133);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(78, 13);
            this.lblObservaciones.TabIndex = 2;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(8, 107);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(48, 13);
            this.lblClient.TabIndex = 2;
            this.lblClient.Text = "Empresa";
            // 
            // txtObservations
            // 
            this.txtObservations.Location = new System.Drawing.Point(92, 130);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.ReadOnly = true;
            this.txtObservations.Size = new System.Drawing.Size(286, 40);
            this.txtObservations.TabIndex = 3;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(92, 104);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(286, 20);
            this.txtClient.TabIndex = 3;
            // 
            // gvPractices
            // 
            this.gvPractices.AllowUserToAddRows = false;
            this.gvPractices.AllowUserToDeleteRows = false;
            this.gvPractices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPractices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Code,
            this.PracticeName,
            this.Description,
            this.PracticeDone,
            this.Status});
            this.gvPractices.Location = new System.Drawing.Point(12, 207);
            this.gvPractices.Name = "gvPractices";
            this.gvPractices.ReadOnly = true;
            this.gvPractices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPractices.Size = new System.Drawing.Size(527, 194);
            this.gvPractices.TabIndex = 0;
            this.gvPractices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPractices_CellContentClick);
            this.gvPractices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPractices_CellDoubleClick);
            this.gvPractices.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvPractices_CurrentCellDirtyStateChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 10;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Código";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // PracticeName
            // 
            this.PracticeName.DataPropertyName = "Name";
            this.PracticeName.HeaderText = "Nombre";
            this.PracticeName.Name = "PracticeName";
            this.PracticeName.ReadOnly = true;
            this.PracticeName.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Descripción";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // PracticeDone
            // 
            this.PracticeDone.DataPropertyName = "IsDone";
            this.PracticeDone.FalseValue = "False";
            this.PracticeDone.HeaderText = "Realizada";
            this.PracticeDone.Name = "PracticeDone";
            this.PracticeDone.ReadOnly = true;
            this.PracticeDone.TrueValue = "True";
            this.PracticeDone.Width = 80;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Estado";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            this.Status.Width = 80;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(315, 407);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(109, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Atendido";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(430, 407);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMarkAsIncomplete
            // 
            this.btnMarkAsIncomplete.Location = new System.Drawing.Point(12, 407);
            this.btnMarkAsIncomplete.Name = "btnMarkAsIncomplete";
            this.btnMarkAsIncomplete.Size = new System.Drawing.Size(109, 23);
            this.btnMarkAsIncomplete.TabIndex = 1;
            this.btnMarkAsIncomplete.Text = "No Realizada";
            this.btnMarkAsIncomplete.UseVisualStyleBackColor = true;
            this.btnMarkAsIncomplete.Visible = false;
            this.btnMarkAsIncomplete.Click += new System.EventHandler(this.btnMarkAsIncomplete_Click);
            // 
            // btnMarkAsDone
            // 
            this.btnMarkAsDone.Location = new System.Drawing.Point(127, 407);
            this.btnMarkAsDone.Name = "btnMarkAsDone";
            this.btnMarkAsDone.Size = new System.Drawing.Size(109, 23);
            this.btnMarkAsDone.TabIndex = 1;
            this.btnMarkAsDone.Text = "Realizada";
            this.btnMarkAsDone.UseVisualStyleBackColor = true;
            this.btnMarkAsDone.Visible = false;
            this.btnMarkAsDone.Click += new System.EventHandler(this.btnMarkAsDone_Click);
            // 
            // PendingPracticesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 441);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMarkAsDone);
            this.Controls.Add(this.btnMarkAsIncomplete);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.gvPractices);
            this.Controls.Add(this.gbPatientInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PendingPracticesDetails";
            this.Text = "Prácticas pendientes";
            this.Load += new System.EventHandler(this.PendingPracticesDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.gbPatientInformation.ResumeLayout(false);
            this.gbPatientInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.GroupBox gbPatientInformation;
        private System.Windows.Forms.DataGridView gvPractices;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn PracticeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PracticeDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.TextBox txtPatientNumber;
        private System.Windows.Forms.Label lblPatientNumber;
        private System.Windows.Forms.Button btnMarkAsIncomplete;
        private System.Windows.Forms.Button btnMarkAsDone;
    }
}