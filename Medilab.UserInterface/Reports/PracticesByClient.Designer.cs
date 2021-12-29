namespace Medilab.UserInterface.Reports
{
    partial class PracticesByClient
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
            this.btnCLose = new System.Windows.Forms.Button();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.dtpFilterFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.dtpFilterToDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.gvReportContent = new System.Windows.Forms.DataGridView();
            this.epPracticesByClient = new System.Windows.Forms.ErrorProvider(this.components);
            this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPracticesByClient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCLose
            // 
            this.btnCLose.Location = new System.Drawing.Point(768, 438);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(75, 23);
            this.btnCLose.TabIndex = 7;
            this.btnCLose.Text = "Cerrar";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.cbClient);
            this.gbFilters.Controls.Add(this.dtpFilterFromDate);
            this.gbFilters.Controls.Add(this.btnExport);
            this.gbFilters.Controls.Add(this.lblClient);
            this.gbFilters.Controls.Add(this.lblFrom);
            this.gbFilters.Controls.Add(this.btnReport);
            this.gbFilters.Controls.Add(this.dtpFilterToDate);
            this.gbFilters.Controls.Add(this.lblTo);
            this.gbFilters.Location = new System.Drawing.Point(12, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(831, 81);
            this.gbFilters.TabIndex = 6;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filtros";
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(6, 37);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(341, 21);
            this.cbClient.TabIndex = 10;
            // 
            // dtpFilterFromDate
            // 
            this.dtpFilterFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterFromDate.Location = new System.Drawing.Point(374, 38);
            this.dtpFilterFromDate.Name = "dtpFilterFromDate";
            this.dtpFilterFromDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFilterFromDate.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(725, 36);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 22);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Imprimir";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(6, 21);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(42, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Cliente:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(371, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(90, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Inicio de período:";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(619, 37);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 22);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Generar Reporte";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dtpFilterToDate
            // 
            this.dtpFilterToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterToDate.Location = new System.Drawing.Point(501, 39);
            this.dtpFilterToDate.Name = "dtpFilterToDate";
            this.dtpFilterToDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFilterToDate.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(498, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(87, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Final de período:";
            // 
            // gvReportContent
            // 
            this.gvReportContent.AllowUserToAddRows = false;
            this.gvReportContent.AllowUserToDeleteRows = false;
            this.gvReportContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReportContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cuit,
            this.Code,
            this.PracticeName,
            this.DocumentNumber,
            this.PatientName});
            this.gvReportContent.Location = new System.Drawing.Point(12, 90);
            this.gvReportContent.Name = "gvReportContent";
            this.gvReportContent.ReadOnly = true;
            this.gvReportContent.Size = new System.Drawing.Size(831, 342);
            this.gvReportContent.TabIndex = 5;
            this.gvReportContent.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvReportContent_ColumnHeaderMouseClick);
            // 
            // epPracticesByClient
            // 
            this.epPracticesByClient.ContainerControl = this;
            // 
            // Cuit
            // 
            this.Cuit.DataPropertyName = "Date";
            this.Cuit.HeaderText = "Fecha";
            this.Cuit.Name = "Cuit";
            this.Cuit.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Código";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 50;
            // 
            // PracticeName
            // 
            this.PracticeName.DataPropertyName = "Name";
            this.PracticeName.HeaderText = "Nombre";
            this.PracticeName.Name = "PracticeName";
            this.PracticeName.ReadOnly = true;
            this.PracticeName.Width = 250;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.DataPropertyName = "DocumentNumber";
            this.DocumentNumber.HeaderText = "DNI";
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            this.DocumentNumber.Width = 75;
            // 
            // PatientName
            // 
            this.PatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Paciente";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // PracticesByClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 469);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.gvReportContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PracticesByClient";
            this.Text = "Prácticas por cliente";
            this.Load += new System.EventHandler(this.PracticesByClient_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPracticesByClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.DateTimePicker dtpFilterFromDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DateTimePicker dtpFilterToDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DataGridView gvReportContent;
        private System.Windows.Forms.ErrorProvider epPracticesByClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn PracticeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
    }
}