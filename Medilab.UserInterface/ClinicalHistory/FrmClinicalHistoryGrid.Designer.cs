using System.Windows.Forms;

namespace Medilab.UserInterface.ClinicalHistory
{
    partial class FrmClinicalHistoryGrid
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gvClinicalHistory = new System.Windows.Forms.DataGridView();
            this.txtFilterByPatient = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lblFilterByPatient = new System.Windows.Forms.Label();
            this.txtFilterByClient = new System.Windows.Forms.TextBox();
            this.lblFilterByClient = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.dtpFilterToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterFromDate = new System.Windows.Forms.DateTimePicker();
            this.cbFilterbyStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterToDate = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblFilterFromDate = new System.Windows.Forms.Label();
            this.lblFilterByStatus = new System.Windows.Forms.Label();
            this.txtFilterByDocumentNumber = new System.Windows.Forms.TextBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnLoadResults = new System.Windows.Forms.Button();
            this.btnChangePracticeStatus = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvClinicalHistory)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(948, 408);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(867, 408);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvClinicalHistory
            // 
            this.gvClinicalHistory.AllowUserToAddRows = false;
            this.gvClinicalHistory.AllowUserToDeleteRows = false;
            this.gvClinicalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClinicalHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Version,
            this.PatientNumber,
            this.DocumentNumber,
            this.PatientName,
            this.ClientName,
            this.Status,
            this.LastUpdateDate});
            this.gvClinicalHistory.Location = new System.Drawing.Point(12, 89);
            this.gvClinicalHistory.Name = "gvClinicalHistory";
            this.gvClinicalHistory.ReadOnly = true;
            this.gvClinicalHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvClinicalHistory.Size = new System.Drawing.Size(1011, 313);
            this.gvClinicalHistory.TabIndex = 1;
            this.gvClinicalHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvClinicalHistory_CellClick);
            this.gvClinicalHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvClinicalHistory_CellDoubleClick);
            this.gvClinicalHistory.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(gvClinicalHistory_ColumnHeaderMouseClick); 
            // 
            // txtFilterByPatient
            // 
            this.txtFilterByPatient.Location = new System.Drawing.Point(169, 38);
            this.txtFilterByPatient.Name = "txtFilterByPatient";
            this.txtFilterByPatient.Size = new System.Drawing.Size(154, 20);
            this.txtFilterByPatient.TabIndex = 3;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApplyFilter.Location = new System.Drawing.Point(849, 35);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFilter.TabIndex = 12;
            this.btnApplyFilter.Text = "Filtrar";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lblFilterByPatient
            // 
            this.lblFilterByPatient.AutoSize = true;
            this.lblFilterByPatient.Location = new System.Drawing.Point(170, 19);
            this.lblFilterByPatient.Name = "lblFilterByPatient";
            this.lblFilterByPatient.Size = new System.Drawing.Size(49, 13);
            this.lblFilterByPatient.TabIndex = 2;
            this.lblFilterByPatient.Text = "Paciente";
            // 
            // txtFilterByClient
            // 
            this.txtFilterByClient.Location = new System.Drawing.Point(327, 38);
            this.txtFilterByClient.Name = "txtFilterByClient";
            this.txtFilterByClient.Size = new System.Drawing.Size(154, 20);
            this.txtFilterByClient.TabIndex = 5;
            // 
            // lblFilterByClient
            // 
            this.lblFilterByClient.AutoSize = true;
            this.lblFilterByClient.Location = new System.Drawing.Point(328, 19);
            this.lblFilterByClient.Name = "lblFilterByClient";
            this.lblFilterByClient.Size = new System.Drawing.Size(48, 13);
            this.lblFilterByClient.TabIndex = 4;
            this.lblFilterByClient.Text = "Empresa";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.dtpFilterToDate);
            this.gbFilter.Controls.Add(this.dtpFilterFromDate);
            this.gbFilter.Controls.Add(this.cbFilterbyStatus);
            this.gbFilter.Controls.Add(this.lblFilterToDate);
            this.gbFilter.Controls.Add(this.lblDNI);
            this.gbFilter.Controls.Add(this.lblFilterByPatient);
            this.gbFilter.Controls.Add(this.lblFilterFromDate);
            this.gbFilter.Controls.Add(this.lblFilterByStatus);
            this.gbFilter.Controls.Add(this.txtFilterByDocumentNumber);
            this.gbFilter.Controls.Add(this.lblFilterByClient);
            this.gbFilter.Controls.Add(this.txtFilterByPatient);
            this.gbFilter.Controls.Add(this.btnClearFilter);
            this.gbFilter.Controls.Add(this.btnApplyFilter);
            this.gbFilter.Controls.Add(this.txtFilterByClient);
            this.gbFilter.Location = new System.Drawing.Point(12, 12);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1011, 71);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filtro";
            // 
            // dtpFilterToDate
            // 
            this.dtpFilterToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterToDate.Location = new System.Drawing.Point(739, 38);
            this.dtpFilterToDate.Name = "dtpFilterToDate";
            this.dtpFilterToDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFilterToDate.TabIndex = 11;
            // 
            // dtpFilterFromDate
            // 
            this.dtpFilterFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterFromDate.Location = new System.Drawing.Point(630, 37);
            this.dtpFilterFromDate.Name = "dtpFilterFromDate";
            this.dtpFilterFromDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFilterFromDate.TabIndex = 9;
            // 
            // cbFilterbyStatus
            // 
            this.cbFilterbyStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFilterbyStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFilterbyStatus.FormattingEnabled = true;
            this.cbFilterbyStatus.Location = new System.Drawing.Point(490, 36);
            this.cbFilterbyStatus.Name = "cbFilterbyStatus";
            this.cbFilterbyStatus.Size = new System.Drawing.Size(131, 21);
            this.cbFilterbyStatus.TabIndex = 7;
            // 
            // lblFilterToDate
            // 
            this.lblFilterToDate.AutoSize = true;
            this.lblFilterToDate.Location = new System.Drawing.Point(736, 20);
            this.lblFilterToDate.Name = "lblFilterToDate";
            this.lblFilterToDate.Size = new System.Drawing.Size(35, 13);
            this.lblFilterToDate.TabIndex = 10;
            this.lblFilterToDate.Text = "Hasta";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(15, 19);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI";
            // 
            // lblFilterFromDate
            // 
            this.lblFilterFromDate.AutoSize = true;
            this.lblFilterFromDate.Location = new System.Drawing.Point(627, 19);
            this.lblFilterFromDate.Name = "lblFilterFromDate";
            this.lblFilterFromDate.Size = new System.Drawing.Size(38, 13);
            this.lblFilterFromDate.TabIndex = 8;
            this.lblFilterFromDate.Text = "Desde";
            // 
            // lblFilterByStatus
            // 
            this.lblFilterByStatus.AutoSize = true;
            this.lblFilterByStatus.Location = new System.Drawing.Point(487, 19);
            this.lblFilterByStatus.Name = "lblFilterByStatus";
            this.lblFilterByStatus.Size = new System.Drawing.Size(40, 13);
            this.lblFilterByStatus.TabIndex = 6;
            this.lblFilterByStatus.Text = "Estado";
            // 
            // txtFilterByDocumentNumber
            // 
            this.txtFilterByDocumentNumber.Location = new System.Drawing.Point(14, 38);
            this.txtFilterByDocumentNumber.Name = "txtFilterByDocumentNumber";
            this.txtFilterByDocumentNumber.Size = new System.Drawing.Size(149, 20);
            this.txtFilterByDocumentNumber.TabIndex = 1;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClearFilter.Location = new System.Drawing.Point(930, 34);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 13;
            this.btnClearFilter.Text = "Limpiar";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnLoadResults
            // 
            this.btnLoadResults.Location = new System.Drawing.Point(751, 408);
            this.btnLoadResults.Name = "btnLoadResults";
            this.btnLoadResults.Size = new System.Drawing.Size(110, 23);
            this.btnLoadResults.TabIndex = 2;
            this.btnLoadResults.Text = "Completar y evaluar";
            this.btnLoadResults.UseVisualStyleBackColor = true;
            this.btnLoadResults.Click += new System.EventHandler(this.btnLoadResults_Click);
            // 
            // btnChangePracticeStatus
            // 
            this.btnChangePracticeStatus.Location = new System.Drawing.Point(599, 408);
            this.btnChangePracticeStatus.Name = "btnChangePracticeStatus";
            this.btnChangePracticeStatus.Size = new System.Drawing.Size(146, 23);
            this.btnChangePracticeStatus.TabIndex = 3;
            this.btnChangePracticeStatus.Text = "Cambiar estado prácticas";
            this.btnChangePracticeStatus.UseVisualStyleBackColor = true;
            this.btnChangePracticeStatus.Click += new System.EventHandler(this.btnChangePracticeStatus_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 5;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Visible = false;
            // 
            // PatientNumber
            // 
            this.PatientNumber.DataPropertyName = "PatientNumber";
            this.PatientNumber.HeaderText = "N°";
            this.PatientNumber.Name = "PatientNumber";
            this.PatientNumber.ReadOnly = true;
            this.PatientNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PatientNumber.Width = 40;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.DataPropertyName = "DocumentNumber";
            this.DocumentNumber.HeaderText = "DNI";
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            this.DocumentNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Paciente";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PatientName.Width = 300;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Cliente";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ClientName.Width = 300;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Estado";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Status.Width = 70;
            // 
            // LastUpdateDate
            // 
            this.LastUpdateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastUpdateDate.DataPropertyName = "LastUpdatedDate";
            this.LastUpdateDate.HeaderText = "Fecha";
            this.LastUpdateDate.Name = "LastUpdateDate";
            this.LastUpdateDate.ReadOnly = true;
            this.LastUpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FrmClinicalHistoryGrid
            // 
            this.AcceptButton = this.btnApplyFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 441);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLoadResults);
            this.Controls.Add(this.btnChangePracticeStatus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvClinicalHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClinicalHistoryGrid";
            this.Text = "Historias Clínicas";
            this.Load += new System.EventHandler(this.FrmClinicalHistoryGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvClinicalHistory)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gvClinicalHistory;
        private System.Windows.Forms.TextBox txtFilterByPatient;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label lblFilterByPatient;
        private System.Windows.Forms.TextBox txtFilterByClient;
        private System.Windows.Forms.Label lblFilterByClient;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.ComboBox cbFilterbyStatus;
        private System.Windows.Forms.Label lblFilterByStatus;
        private System.Windows.Forms.DateTimePicker dtpFilterFromDate;
        private System.Windows.Forms.Label lblFilterFromDate;
        private System.Windows.Forms.DateTimePicker dtpFilterToDate;
        private System.Windows.Forms.Label lblFilterToDate;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtFilterByDocumentNumber;
        private System.Windows.Forms.Button btnLoadResults;
        private System.Windows.Forms.Button btnChangePracticeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateDate;
    }
}