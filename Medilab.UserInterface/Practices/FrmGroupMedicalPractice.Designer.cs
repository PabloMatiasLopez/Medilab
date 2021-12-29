namespace Medilab.UserInterface.Practices
{
    partial class FrmGroupMedicalPractice
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
            this.gvGroups = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblPracticeName = new System.Windows.Forms.Label();
            this.lblPracticeCode = new System.Windows.Forms.Label();
            this.txtPracticeCode = new System.Windows.Forms.TextBox();
            this.gbPractices = new System.Windows.Forms.GroupBox();
            this.cbPracticeName = new System.Windows.Forms.ComboBox();
            this.gvPractices = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnNewGroup = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGroup)).BeginInit();
            this.gbPractices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(298, 528);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(541, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(460, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(84, 247);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(532, 55);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 198);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(532, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 250);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Descripcion";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 201);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre";
            // 
            // gvGroups
            // 
            this.gvGroups.AllowUserToAddRows = false;
            this.gvGroups.AllowUserToDeleteRows = false;
            this.gvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Code,
            this.Nombre,
            this.Description});
            this.gvGroups.Location = new System.Drawing.Point(11, 41);
            this.gvGroups.Name = "gvGroups";
            this.gvGroups.ReadOnly = true;
            this.gvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvGroups.Size = new System.Drawing.Size(605, 150);
            this.gvGroups.TabIndex = 0;
            this.gvGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGroups_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Código";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Descripcion";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // epGroup
            // 
            this.epGroup.ContainerControl = this;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(11, 225);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 13);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Código";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(84, 222);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(532, 20);
            this.txtCode.TabIndex = 4;
            this.txtCode.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // lblPracticeName
            // 
            this.lblPracticeName.AutoSize = true;
            this.lblPracticeName.Location = new System.Drawing.Point(299, 22);
            this.lblPracticeName.Name = "lblPracticeName";
            this.lblPracticeName.Size = new System.Drawing.Size(44, 13);
            this.lblPracticeName.TabIndex = 2;
            this.lblPracticeName.Text = "Nombre";
            // 
            // lblPracticeCode
            // 
            this.lblPracticeCode.AutoSize = true;
            this.lblPracticeCode.Location = new System.Drawing.Point(10, 22);
            this.lblPracticeCode.Name = "lblPracticeCode";
            this.lblPracticeCode.Size = new System.Drawing.Size(40, 13);
            this.lblPracticeCode.TabIndex = 0;
            this.lblPracticeCode.Text = "Código";
            // 
            // txtPracticeCode
            // 
            this.txtPracticeCode.Location = new System.Drawing.Point(69, 19);
            this.txtPracticeCode.Name = "txtPracticeCode";
            this.txtPracticeCode.Size = new System.Drawing.Size(224, 20);
            this.txtPracticeCode.TabIndex = 1;
            this.txtPracticeCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPracticeCode_KeyUp);
            // 
            // gbPractices
            // 
            this.gbPractices.Controls.Add(this.cbPracticeName);
            this.gbPractices.Controls.Add(this.txtPracticeCode);
            this.gbPractices.Controls.Add(this.lblPracticeName);
            this.gbPractices.Controls.Add(this.lblPracticeCode);
            this.gbPractices.Controls.Add(this.gvPractices);
            this.gbPractices.Location = new System.Drawing.Point(14, 335);
            this.gbPractices.Name = "gbPractices";
            this.gbPractices.Size = new System.Drawing.Size(601, 187);
            this.gbPractices.TabIndex = 9;
            this.gbPractices.TabStop = false;
            this.gbPractices.Text = "Prácticas";
            // 
            // cbPracticeName
            // 
            this.cbPracticeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPracticeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPracticeName.FormattingEnabled = true;
            this.cbPracticeName.Location = new System.Drawing.Point(349, 19);
            this.cbPracticeName.Name = "cbPracticeName";
            this.cbPracticeName.Size = new System.Drawing.Size(246, 21);
            this.cbPracticeName.TabIndex = 3;
            this.cbPracticeName.SelectedIndexChanged += new System.EventHandler(this.cbPracticeName_SelectedIndexChanged);
            // 
            // gvPractices
            // 
            this.gvPractices.AllowUserToAddRows = false;
            this.gvPractices.AllowUserToDeleteRows = false;
            this.gvPractices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPractices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gvPractices.Location = new System.Drawing.Point(13, 45);
            this.gvPractices.Name = "gvPractices";
            this.gvPractices.ReadOnly = true;
            this.gvPractices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPractices.Size = new System.Drawing.Size(582, 136);
            this.gvPractices.TabIndex = 4;
            this.gvPractices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGroups_CellDoubleClick);
            this.gvPractices.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvPractices_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(11, 311);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Precio";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(84, 308);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(532, 20);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Location = new System.Drawing.Point(379, 528);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(75, 23);
            this.btnNewGroup.TabIndex = 12;
            this.btnNewGroup.Text = "Nuevo";
            this.btnNewGroup.UseVisualStyleBackColor = true;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(11, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 19;
            this.lblSearch.Text = "Buscar";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(66, 12);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(469, 20);
            this.txtSearchText.TabIndex = 18;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(541, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmGroupMedicalPractice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 562);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbPractices);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gvGroups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGroupMedicalPractice";
            this.Text = "Grupos";
            this.Load += new System.EventHandler(this.FrmGroupMedicalPractice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGroup)).EndInit();
            this.gbPractices.ResumeLayout(false);
            this.gbPractices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPractices)).EndInit();
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
        private System.Windows.Forms.DataGridView gvGroups;
        private System.Windows.Forms.ErrorProvider epGroup;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.GroupBox gbPractices;
        private System.Windows.Forms.ComboBox cbPracticeName;
        private System.Windows.Forms.TextBox txtPracticeCode;
        private System.Windows.Forms.Label lblPracticeName;
        private System.Windows.Forms.Label lblPracticeCode;
        private System.Windows.Forms.DataGridView gvPractices;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnNewGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
    }
}