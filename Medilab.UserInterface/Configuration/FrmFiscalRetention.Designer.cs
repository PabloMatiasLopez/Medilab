namespace Medilab.UserInterface.Configuration
{
    partial class FrmFiscalRetention
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNewPractice = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gvRetentions = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.epRetention = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkIsIVA = new System.Windows.Forms.CheckBox();
            this.lblCAECode = new System.Windows.Forms.Label();
            this.cbCAECode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetentions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRetention)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 27;
            this.lblSearch.Text = "Buscar";
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(61, 8);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(533, 20);
            this.txtSearchText.TabIndex = 0;
            this.txtSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchText_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(600, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNewPractice
            // 
            this.btnNewPractice.Location = new System.Drawing.Point(438, 349);
            this.btnNewPractice.Name = "btnNewPractice";
            this.btnNewPractice.Size = new System.Drawing.Size(75, 23);
            this.btnNewPractice.TabIndex = 7;
            this.btnNewPractice.Text = "Nueva";
            this.btnNewPractice.UseVisualStyleBackColor = true;
            this.btnNewPractice.Click += new System.EventHandler(this.btnNewPractice_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(357, 349);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(600, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(519, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(109, 225);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(383, 55);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtcontrol_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(109, 199);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(383, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtcontrol_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 225);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Descripcion";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 202);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Nombre";
            // 
            // gvRetentions
            // 
            this.gvRetentions.AllowUserToAddRows = false;
            this.gvRetentions.AllowUserToDeleteRows = false;
            this.gvRetentions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRetentions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Description,
            this.Value});
            this.gvRetentions.Location = new System.Drawing.Point(12, 42);
            this.gvRetentions.Name = "gvRetentions";
            this.gvRetentions.ReadOnly = true;
            this.gvRetentions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRetentions.Size = new System.Drawing.Size(663, 150);
            this.gvRetentions.TabIndex = 19;
            this.gvRetentions.TabStop = false;
            this.gvRetentions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRetentions_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Descripcion";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "0.00";
            dataGridViewCellStyle1.NullValue = null;
            this.Value.DefaultCellStyle = dataGridViewCellStyle1;
            this.Value.HeaderText = "Valor";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 50;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 289);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(48, 13);
            this.lblValue.TabIndex = 18;
            this.lblValue.Text = "Valor (%)";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(109, 286);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(383, 20);
            this.txtValue.TabIndex = 4;
            this.txtValue.TextChanged += new System.EventHandler(this.txtcontrol_TextChanged);
            // 
            // epRetention
            // 
            this.epRetention.ContainerControl = this;
            // 
            // chkIsIVA
            // 
            this.chkIsIVA.AutoSize = true;
            this.chkIsIVA.Location = new System.Drawing.Point(449, 315);
            this.chkIsIVA.Name = "chkIsIVA";
            this.chkIsIVA.Size = new System.Drawing.Size(43, 17);
            this.chkIsIVA.TabIndex = 28;
            this.chkIsIVA.Text = "IVA";
            this.chkIsIVA.UseVisualStyleBackColor = true;
            // 
            // lblCAECode
            // 
            this.lblCAECode.AutoSize = true;
            this.lblCAECode.Location = new System.Drawing.Point(12, 316);
            this.lblCAECode.Name = "lblCAECode";
            this.lblCAECode.Size = new System.Drawing.Size(66, 13);
            this.lblCAECode.TabIndex = 29;
            this.lblCAECode.Text = "Código AFIP";
            // 
            // cbCAECode
            // 
            this.cbCAECode.FormattingEnabled = true;
            this.cbCAECode.Location = new System.Drawing.Point(109, 313);
            this.cbCAECode.Name = "cbCAECode";
            this.cbCAECode.Size = new System.Drawing.Size(334, 21);
            this.cbCAECode.TabIndex = 30;
            // 
            // FrmFiscalRetention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 393);
            this.Controls.Add(this.cbCAECode);
            this.Controls.Add(this.lblCAECode);
            this.Controls.Add(this.chkIsIVA);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNewPractice);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvRetentions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFiscalRetention";
            this.Text = "Retenciones";
            this.Load += new System.EventHandler(this.FrmFiscalRetention_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRetentions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRetention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNewPractice;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView gvRetentions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ErrorProvider epRetention;
        private System.Windows.Forms.ComboBox cbCAECode;
        private System.Windows.Forms.Label lblCAECode;
        private System.Windows.Forms.CheckBox chkIsIVA;
    }
}