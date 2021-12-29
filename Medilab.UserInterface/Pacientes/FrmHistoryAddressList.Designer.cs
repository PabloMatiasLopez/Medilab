namespace Medilab.UserInterface.Pacientes
{
    partial class FrmHistoryAddressList
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
            this.gvAddresses = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.StreetLineOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreetLineTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // gvAddresses
            // 
            this.gvAddresses.AllowUserToAddRows = false;
            this.gvAddresses.AllowUserToDeleteRows = false;
            this.gvAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StreetLineOne,
            this.StreetLineTwo,
            this.State,
            this.AddressType,
            this.ArchiveDate});
            this.gvAddresses.Location = new System.Drawing.Point(12, 12);
            this.gvAddresses.Name = "gvAddresses";
            this.gvAddresses.ReadOnly = true;
            this.gvAddresses.Size = new System.Drawing.Size(664, 238);
            this.gvAddresses.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // StreetLineOne
            // 
            this.StreetLineOne.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreetLineOne.DataPropertyName = "StreetLineOne";
            this.StreetLineOne.HeaderText = "Dirección";
            this.StreetLineOne.Name = "StreetLineOne";
            this.StreetLineOne.ReadOnly = true;
            // 
            // StreetLineTwo
            // 
            this.StreetLineTwo.DataPropertyName = "Number";
            this.StreetLineTwo.HeaderText = "Número";
            this.StreetLineTwo.Name = "StreetLineTwo";
            this.StreetLineTwo.ReadOnly = true;
            this.StreetLineTwo.Width = 150;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.State.DataPropertyName = "StateName";
            this.State.HeaderText = "Provincia";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 76;
            // 
            // AddressType
            // 
            this.AddressType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AddressType.DataPropertyName = "AddressType";
            this.AddressType.HeaderText = "Tipo";
            this.AddressType.Name = "AddressType";
            this.AddressType.ReadOnly = true;
            this.AddressType.Width = 53;
            // 
            // ArchiveDate
            // 
            this.ArchiveDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ArchiveDate.DataPropertyName = "ArchiveDate";
            this.ArchiveDate.HeaderText = "Fecha";
            this.ArchiveDate.Name = "ArchiveDate";
            this.ArchiveDate.ReadOnly = true;
            this.ArchiveDate.Width = 62;
            // 
            // FrmHistoryAddressList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 289);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvAddresses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHistoryAddressList";
            this.Text = "Direcciones Anteriores";
            this.Load += new System.EventHandler(this.FrmHistoryAddressList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAddresses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvAddresses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetLineOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetLineTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchiveDate;
    }
}