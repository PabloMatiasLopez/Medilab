namespace Medilab.UserInterface.Practices
{
    partial class FrmPractices
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gvPractices = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speciality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblSpeciality = new System.Windows.Forms.Label();
            this.cbSpeciality = new System.Windows.Forms.ComboBox();
            this.epPractice = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkIsExternal = new System.Windows.Forms.CheckBox();
            this.btnNewPractice = new System.Windows.Forms.Button();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.cbSpecialityFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPractice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(360, 529);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(603, 529);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(522, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(109, 412);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(383, 55);
            this.txtDescription.TabIndex = 13;
            this.txtDescription.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(109, 334);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(383, 20);
            this.txtName.TabIndex = 7;
            this.txtName.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 415);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Descripcion";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 337);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Nombre";
            // 
            // gvPractices
            // 
            this.gvPractices.AllowUserToAddRows = false;
            this.gvPractices.AllowUserToDeleteRows = false;
            this.gvPractices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPractices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Code,
            this.Description,
            this.Speciality});
            this.gvPractices.Location = new System.Drawing.Point(15, 63);
            this.gvPractices.Name = "gvPractices";
            this.gvPractices.ReadOnly = true;
            this.gvPractices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPractices.Size = new System.Drawing.Size(663, 262);
            this.gvPractices.TabIndex = 5;
            this.gvPractices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPractices_CellDoubleClick);
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
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Código";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Descripcion";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // Speciality
            // 
            this.Speciality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Speciality.DataPropertyName = "SpecialityName";
            this.Speciality.HeaderText = "Especialidad";
            this.Speciality.Name = "Speciality";
            this.Speciality.ReadOnly = true;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 389);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 13);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Código";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(109, 386);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(383, 20);
            this.txtCode.TabIndex = 11;
            this.txtCode.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // lblSpeciality
            // 
            this.lblSpeciality.AutoSize = true;
            this.lblSpeciality.Location = new System.Drawing.Point(12, 474);
            this.lblSpeciality.Name = "lblSpeciality";
            this.lblSpeciality.Size = new System.Drawing.Size(67, 13);
            this.lblSpeciality.TabIndex = 14;
            this.lblSpeciality.Text = "Especialidad";
            // 
            // cbSpeciality
            // 
            this.cbSpeciality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSpeciality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSpeciality.FormattingEnabled = true;
            this.cbSpeciality.Location = new System.Drawing.Point(109, 474);
            this.cbSpeciality.Name = "cbSpeciality";
            this.cbSpeciality.Size = new System.Drawing.Size(183, 21);
            this.cbSpeciality.TabIndex = 15;
            this.cbSpeciality.SelectedIndexChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // epPractice
            // 
            this.epPractice.ContainerControl = this;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 504);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Precio";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(109, 501);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(383, 20);
            this.txtPrice.TabIndex = 18;
            this.txtPrice.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Buscar";
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(85, 6);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(509, 20);
            this.txtSearchText.TabIndex = 1;
            this.txtSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchText_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(600, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkIsExternal
            // 
            this.chkIsExternal.AutoSize = true;
            this.chkIsExternal.Location = new System.Drawing.Point(298, 476);
            this.chkIsExternal.Name = "chkIsExternal";
            this.chkIsExternal.Size = new System.Drawing.Size(62, 17);
            this.chkIsExternal.TabIndex = 16;
            this.chkIsExternal.Text = "Externa";
            this.chkIsExternal.UseVisualStyleBackColor = true;
            // 
            // btnNewPractice
            // 
            this.btnNewPractice.Location = new System.Drawing.Point(441, 529);
            this.btnNewPractice.Name = "btnNewPractice";
            this.btnNewPractice.Size = new System.Drawing.Size(75, 23);
            this.btnNewPractice.TabIndex = 21;
            this.btnNewPractice.Text = "Nueva";
            this.btnNewPractice.UseVisualStyleBackColor = true;
            this.btnNewPractice.Click += new System.EventHandler(this.btnNewPractice_Click);
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(109, 360);
            this.txtReportName.MaxLength = 21;
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(383, 20);
            this.txtReportName.TabIndex = 9;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(12, 363);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(72, 13);
            this.lblReportName.TabIndex = 8;
            this.lblReportName.Text = "Nombre Corto";
            // 
            // cbSpecialityFilter
            // 
            this.cbSpecialityFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSpecialityFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSpecialityFilter.FormattingEnabled = true;
            this.cbSpecialityFilter.Location = new System.Drawing.Point(85, 36);
            this.cbSpecialityFilter.Name = "cbSpecialityFilter";
            this.cbSpecialityFilter.Size = new System.Drawing.Size(283, 21);
            this.cbSpecialityFilter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Especialidad";
            // 
            // FrmPractices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 561);
            this.Controls.Add(this.cbSpecialityFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReportName);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.chkIsExternal);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbSpeciality);
            this.Controls.Add(this.btnNewPractice);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblSpeciality);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvPractices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPractices";
            this.Text = "Prácticas";
            this.Load += new System.EventHandler(this.Practices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPractice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView gvPractices;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblSpeciality;
        private System.Windows.Forms.ComboBox cbSpeciality;
        private System.Windows.Forms.ErrorProvider epPractice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speciality;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkIsExternal;
        private System.Windows.Forms.Button btnNewPractice;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.ComboBox cbSpecialityFilter;
        private System.Windows.Forms.Label label1;
    }
}