namespace Medilab.UserInterface.Reports
{
    partial class frmReportTemplate
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
            this.gvReportContent = new System.Windows.Forms.DataGridView();
            this.btnReport = new System.Windows.Forms.Button();
            this.ddlCleanReport = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtpFilterFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ddlSpeciality = new System.Windows.Forms.ComboBox();
            this.lblSpeciality = new System.Windows.Forms.Label();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContent)).BeginInit();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvReportContent
            // 
            this.gvReportContent.AllowUserToAddRows = false;
            this.gvReportContent.AllowUserToDeleteRows = false;
            this.gvReportContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReportContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.PracticeName,
            this.DocumentNumber,
            this.PatientName,
            this.ClientName,
            this.Cuit});
            this.gvReportContent.Location = new System.Drawing.Point(21, 100);
            this.gvReportContent.Name = "gvReportContent";
            this.gvReportContent.ReadOnly = true;
            this.gvReportContent.Size = new System.Drawing.Size(903, 493);
            this.gvReportContent.TabIndex = 1;
            this.gvReportContent.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvReportContent_ColumnHeaderMouseClick);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(540, 39);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 22);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Generar Reporte";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // ddlCleanReport
            // 
            this.ddlCleanReport.Location = new System.Drawing.Point(739, 39);
            this.ddlCleanReport.Name = "ddlCleanReport";
            this.ddlCleanReport.Size = new System.Drawing.Size(92, 22);
            this.ddlCleanReport.TabIndex = 10;
            this.ddlCleanReport.Text = "Limpiar Reporte";
            this.ddlCleanReport.UseVisualStyleBackColor = true;
            this.ddlCleanReport.Click += new System.EventHandler(this.ddlCleanReport_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.Location = new System.Drawing.Point(789, 599);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(75, 23);
            this.btnCLose.TabIndex = 2;
            this.btnCLose.Text = "Cerrar";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(646, 39);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 22);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Imprimir";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dtpFilterFromDate
            // 
            this.dtpFilterFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterFromDate.Location = new System.Drawing.Point(19, 40);
            this.dtpFilterFromDate.Name = "dtpFilterFromDate";
            this.dtpFilterFromDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFilterFromDate.TabIndex = 1;
            // 
            // dtpFilterToDate
            // 
            this.dtpFilterToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterToDate.Location = new System.Drawing.Point(146, 41);
            this.dtpFilterToDate.Name = "dtpFilterToDate";
            this.dtpFilterToDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFilterToDate.TabIndex = 3;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(16, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(90, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Inicio de período:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(143, 25);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(87, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Final de período:";
            // 
            // ddlStatus
            // 
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(275, 40);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(121, 21);
            this.ddlStatus.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(272, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Estado:";
            // 
            // ddlSpeciality
            // 
            this.ddlSpeciality.FormattingEnabled = true;
            this.ddlSpeciality.Location = new System.Drawing.Point(413, 39);
            this.ddlSpeciality.Name = "ddlSpeciality";
            this.ddlSpeciality.Size = new System.Drawing.Size(121, 21);
            this.ddlSpeciality.TabIndex = 7;
            // 
            // lblSpeciality
            // 
            this.lblSpeciality.AutoSize = true;
            this.lblSpeciality.Location = new System.Drawing.Point(410, 24);
            this.lblSpeciality.Name = "lblSpeciality";
            this.lblSpeciality.Size = new System.Drawing.Size(70, 13);
            this.lblSpeciality.TabIndex = 6;
            this.lblSpeciality.Text = "Especialidad:";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.dtpFilterFromDate);
            this.gbFilters.Controls.Add(this.btnExport);
            this.gbFilters.Controls.Add(this.ddlCleanReport);
            this.gbFilters.Controls.Add(this.lblSpeciality);
            this.gbFilters.Controls.Add(this.lblFrom);
            this.gbFilters.Controls.Add(this.ddlSpeciality);
            this.gbFilters.Controls.Add(this.btnReport);
            this.gbFilters.Controls.Add(this.dtpFilterToDate);
            this.gbFilters.Controls.Add(this.lblStatus);
            this.gbFilters.Controls.Add(this.lblTo);
            this.gbFilters.Controls.Add(this.ddlStatus);
            this.gbFilters.Location = new System.Drawing.Point(21, 13);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(903, 81);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filtros";
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Código de práctica";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // PracticeName
            // 
            this.PracticeName.DataPropertyName = "Name";
            this.PracticeName.HeaderText = "Nombre de la práctica";
            this.PracticeName.Name = "PracticeName";
            this.PracticeName.ReadOnly = true;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.DataPropertyName = "DocumentNumber";
            this.DocumentNumber.HeaderText = "Número de documento";
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Nombre del Paciente";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Razón Social";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // Cuit
            // 
            this.Cuit.DataPropertyName = "Cuit";
            this.Cuit.HeaderText = "CUIT";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            // 
            // frmReportTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 634);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.gvReportContent);
            this.Name = "frmReportTemplate";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContent)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvReportContent;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button ddlCleanReport;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker dtpFilterFromDate;
        private System.Windows.Forms.DateTimePicker dtpFilterToDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox ddlSpeciality;
        private System.Windows.Forms.Label lblSpeciality;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn PracticeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
    }
}