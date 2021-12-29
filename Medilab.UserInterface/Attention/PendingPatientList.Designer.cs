namespace Medilab.UserInterface.Attention
{
    partial class PendingPatientList
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
            this.gvPendingPatients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendingPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPendingPatients
            // 
            this.gvPendingPatients.AllowUserToAddRows = false;
            this.gvPendingPatients.AllowUserToDeleteRows = false;
            this.gvPendingPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPendingPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PatientId,
            this.DocumentNumber,
            this.PatientName,
            this.Number});
            this.gvPendingPatients.Location = new System.Drawing.Point(12, 12);
            this.gvPendingPatients.Name = "gvPendingPatients";
            this.gvPendingPatients.ReadOnly = true;
            this.gvPendingPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPendingPatients.Size = new System.Drawing.Size(744, 313);
            this.gvPendingPatients.TabIndex = 1;
            this.gvPendingPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPendingPatients_CellDoubleClick);
            this.gvPendingPatients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvPendingPatients_KeyDown); 
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ClinicalHistoryId";
            this.Id.HeaderText = "ClinicalHistoryId";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 10;
            // 
            // PatientId
            // 
            this.PatientId.DataPropertyName = "PatientId";
            this.PatientId.HeaderText = "PatientId";
            this.PatientId.Name = "PatientId";
            this.PatientId.ReadOnly = true;
            this.PatientId.Visible = false;
            this.PatientId.Width = 300;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.DataPropertyName = "DocumentNumber";
            this.DocumentNumber.HeaderText = "DNI";
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            this.DocumentNumber.Width = 150;
            // 
            // PatientName
            // 
            this.PatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Paciente";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "PatientNumber";
            this.Number.HeaderText = "Número";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(680, 332);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(599, 332);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Actualizar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(12, 332);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(142, 17);
            this.chkShowAll.TabIndex = 2;
            this.chkShowAll.Text = "Ver todos los pendientes";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // PendingPatientList
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 364);
            this.Controls.Add(this.chkShowAll);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvPendingPatients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PendingPatientList";
            this.Text = "Pacientes Pendientes";
            this.Load += new System.EventHandler(this.PendingPatientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPendingPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPendingPatients;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
    }
}