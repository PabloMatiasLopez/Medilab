using System.Windows.Forms;

namespace Medilab.UserInterface.Reports
{
    partial class LaboratoryReport
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
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContent)).BeginInit();
            this.SuspendLayout();
            // 
            // gvReportContent
            // 
            this.gvReportContent.AllowUserToAddRows = false;
            this.gvReportContent.AllowUserToDeleteRows = false;
            this.gvReportContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReportContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.DocumentNumber,
            this.PatientName,
            this.PracticeName,
            this.ClientName});
            this.gvReportContent.Location = new System.Drawing.Point(12, 44);
            this.gvReportContent.Name = "gvReportContent";
            this.gvReportContent.ReadOnly = true;
            this.gvReportContent.Size = new System.Drawing.Size(902, 397);
            this.gvReportContent.TabIndex = 2;
            this.gvReportContent.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvReportContent_ColumnHeaderMouseClick);
            // 
            // Number
            // 
            this.Number.DataPropertyName = "PatientNumber";
            this.Number.HeaderText = "Número";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 50;
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
            this.PatientName.HeaderText = "Nombre";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // PracticeName
            // 
            this.PracticeName.DataPropertyName = "Name";
            this.PracticeName.HeaderText = "Práctica Realizada";
            this.PracticeName.Name = "PracticeName";
            this.PracticeName.ReadOnly = true;
            this.PracticeName.Width = 200;
            // 
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Empresa";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(746, 448);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Imprimir";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.Location = new System.Drawing.Point(839, 448);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(75, 23);
            this.btnCLose.TabIndex = 4;
            this.btnCLose.Text = "Cerrar";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(814, 13);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 23);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Generar Reporte";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // LaboratoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 483);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gvReportContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LaboratoryReport";
            this.Text = "Reporte de laboratorio";
            this.Load += new System.EventHandler(this.PracticesBySpeciality_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvReportContent;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PracticeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private Button btnReport;
    }
}