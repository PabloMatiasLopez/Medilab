namespace Medilab.UserInterface.Invoice
{
    partial class CreateInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtFilterClient = new System.Windows.Forms.TextBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.gbSelectClient = new System.Windows.Forms.GroupBox();
            this.rdbClientsPendingItems = new System.Windows.Forms.RadioButton();
            this.rdbAllClients = new System.Windows.Forms.RadioButton();
            this.btnFilterClient = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.lblClientNumber = new System.Windows.Forms.Label();
            this.lblClientNumberLabel = new System.Windows.Forms.Label();
            this.lblSaleCondition = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblSaleConditionLabel = new System.Windows.Forms.Label();
            this.lblCUITLabel = new System.Windows.Forms.Label();
            this.lblIvaCondition = new System.Windows.Forms.Label();
            this.lblIvaConditionLabel = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientNameLabel = new System.Windows.Forms.Label();
            this.gvDetails = new System.Windows.Forms.DataGridView();
            this.btnLoadInvoiceItems = new System.Windows.Forms.Button();
            this.bntViewInvoice = new System.Windows.Forms.Button();
            this.chkFreeDetails = new System.Windows.Forms.CheckBox();
            this.panelFreeText = new System.Windows.Forms.Panel();
            this.txtFreeText = new System.Windows.Forms.TextBox();
            this.lblFreeText = new System.Windows.Forms.Label();
            this.btnAdditionaltem = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkIncludeInvoiceDetail = new System.Windows.Forms.CheckBox();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PatientDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PracticeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSelectClient.SuspendLayout();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).BeginInit();
            this.panelFreeText.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(15, 22);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Cliente";
            // 
            // txtFilterClient
            // 
            this.txtFilterClient.Location = new System.Drawing.Point(425, 47);
            this.txtFilterClient.Name = "txtFilterClient";
            this.txtFilterClient.Size = new System.Drawing.Size(221, 20);
            this.txtFilterClient.TabIndex = 1;
            // 
            // cbClient
            // 
            this.cbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(60, 19);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(359, 21);
            this.cbClient.TabIndex = 2;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            this.cbClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClient_KeyDown);
            // 
            // gbSelectClient
            // 
            this.gbSelectClient.Controls.Add(this.rdbClientsPendingItems);
            this.gbSelectClient.Controls.Add(this.rdbAllClients);
            this.gbSelectClient.Controls.Add(this.btnFilterClient);
            this.gbSelectClient.Controls.Add(this.lblArea);
            this.gbSelectClient.Controls.Add(this.lblClient);
            this.gbSelectClient.Controls.Add(this.cbArea);
            this.gbSelectClient.Controls.Add(this.cbClient);
            this.gbSelectClient.Controls.Add(this.txtFilterClient);
            this.gbSelectClient.Location = new System.Drawing.Point(12, 5);
            this.gbSelectClient.Name = "gbSelectClient";
            this.gbSelectClient.Size = new System.Drawing.Size(774, 73);
            this.gbSelectClient.TabIndex = 3;
            this.gbSelectClient.TabStop = false;
            this.gbSelectClient.Text = "Seleccionar Cliente";
            // 
            // rdbClientsPendingItems
            // 
            this.rdbClientsPendingItems.AutoSize = true;
            this.rdbClientsPendingItems.Location = new System.Drawing.Point(486, 20);
            this.rdbClientsPendingItems.Name = "rdbClientsPendingItems";
            this.rdbClientsPendingItems.Size = new System.Drawing.Size(160, 17);
            this.rdbClientsPendingItems.TabIndex = 5;
            this.rdbClientsPendingItems.Text = "Con movimientos pendientes";
            this.rdbClientsPendingItems.UseVisualStyleBackColor = true;
            this.rdbClientsPendingItems.Click += new System.EventHandler(this.rdbClientsPendingItems_Click);
            // 
            // rdbAllClients
            // 
            this.rdbAllClients.AutoSize = true;
            this.rdbAllClients.Checked = true;
            this.rdbAllClients.Location = new System.Drawing.Point(425, 20);
            this.rdbAllClients.Name = "rdbAllClients";
            this.rdbAllClients.Size = new System.Drawing.Size(55, 17);
            this.rdbAllClients.TabIndex = 4;
            this.rdbAllClients.TabStop = true;
            this.rdbAllClients.Text = "Todos";
            this.rdbAllClients.UseVisualStyleBackColor = true;
            this.rdbAllClients.Click += new System.EventHandler(this.rdbAllClients_Click);
            // 
            // btnFilterClient
            // 
            this.btnFilterClient.Location = new System.Drawing.Point(652, 44);
            this.btnFilterClient.Name = "btnFilterClient";
            this.btnFilterClient.Size = new System.Drawing.Size(75, 23);
            this.btnFilterClient.TabIndex = 3;
            this.btnFilterClient.Text = "Filtrar";
            this.btnFilterClient.UseVisualStyleBackColor = true;
            this.btnFilterClient.Click += new System.EventHandler(this.btnFilterClient_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(15, 49);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(29, 13);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Área";
            // 
            // cbArea
            // 
            this.cbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbArea.Enabled = false;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(60, 46);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(359, 21);
            this.cbArea.TabIndex = 2;
            this.cbArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbClient_KeyDown);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.btnEditClient);
            this.gbHeader.Controls.Add(this.lblClientNumber);
            this.gbHeader.Controls.Add(this.lblClientNumberLabel);
            this.gbHeader.Controls.Add(this.lblSaleCondition);
            this.gbHeader.Controls.Add(this.lblCUIT);
            this.gbHeader.Controls.Add(this.lblSaleConditionLabel);
            this.gbHeader.Controls.Add(this.lblCUITLabel);
            this.gbHeader.Controls.Add(this.lblIvaCondition);
            this.gbHeader.Controls.Add(this.lblIvaConditionLabel);
            this.gbHeader.Controls.Add(this.lblAddress);
            this.gbHeader.Controls.Add(this.lblAddressLabel);
            this.gbHeader.Controls.Add(this.lblClientName);
            this.gbHeader.Controls.Add(this.lblClientNameLabel);
            this.gbHeader.Location = new System.Drawing.Point(12, 84);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(774, 99);
            this.gbHeader.TabIndex = 4;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "Datos Cliente";
            // 
            // lblClientNumber
            // 
            this.lblClientNumber.AutoSize = true;
            this.lblClientNumber.Location = new System.Drawing.Point(447, 77);
            this.lblClientNumber.Name = "lblClientNumber";
            this.lblClientNumber.Size = new System.Drawing.Size(0, 13);
            this.lblClientNumber.TabIndex = 0;
            // 
            // lblClientNumberLabel
            // 
            this.lblClientNumberLabel.AutoSize = true;
            this.lblClientNumberLabel.Location = new System.Drawing.Point(372, 77);
            this.lblClientNumberLabel.Name = "lblClientNumberLabel";
            this.lblClientNumberLabel.Size = new System.Drawing.Size(72, 13);
            this.lblClientNumberLabel.TabIndex = 0;
            this.lblClientNumberLabel.Text = "Nº de Cliente:";
            // 
            // lblSaleCondition
            // 
            this.lblSaleCondition.AutoSize = true;
            this.lblSaleCondition.Location = new System.Drawing.Point(97, 77);
            this.lblSaleCondition.Name = "lblSaleCondition";
            this.lblSaleCondition.Size = new System.Drawing.Size(0, 13);
            this.lblSaleCondition.TabIndex = 0;
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(447, 58);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(0, 13);
            this.lblCUIT.TabIndex = 0;
            // 
            // lblSaleConditionLabel
            // 
            this.lblSaleConditionLabel.AutoSize = true;
            this.lblSaleConditionLabel.Location = new System.Drawing.Point(7, 77);
            this.lblSaleConditionLabel.Name = "lblSaleConditionLabel";
            this.lblSaleConditionLabel.Size = new System.Drawing.Size(84, 13);
            this.lblSaleConditionLabel.TabIndex = 0;
            this.lblSaleConditionLabel.Text = "Cond. de Venta:";
            // 
            // lblCUITLabel
            // 
            this.lblCUITLabel.AutoSize = true;
            this.lblCUITLabel.Location = new System.Drawing.Point(372, 58);
            this.lblCUITLabel.Name = "lblCUITLabel";
            this.lblCUITLabel.Size = new System.Drawing.Size(47, 13);
            this.lblCUITLabel.TabIndex = 0;
            this.lblCUITLabel.Text = "C.U.I.T.:";
            // 
            // lblIvaCondition
            // 
            this.lblIvaCondition.AutoSize = true;
            this.lblIvaCondition.Location = new System.Drawing.Point(97, 58);
            this.lblIvaCondition.Name = "lblIvaCondition";
            this.lblIvaCondition.Size = new System.Drawing.Size(0, 13);
            this.lblIvaCondition.TabIndex = 0;
            // 
            // lblIvaConditionLabel
            // 
            this.lblIvaConditionLabel.AutoSize = true;
            this.lblIvaConditionLabel.Location = new System.Drawing.Point(7, 58);
            this.lblIvaConditionLabel.Name = "lblIvaConditionLabel";
            this.lblIvaConditionLabel.Size = new System.Drawing.Size(27, 13);
            this.lblIvaConditionLabel.TabIndex = 0;
            this.lblIvaConditionLabel.Text = "IVA:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(97, 38);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(0, 13);
            this.lblAddress.TabIndex = 0;
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Location = new System.Drawing.Point(7, 38);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(52, 13);
            this.lblAddressLabel.TabIndex = 0;
            this.lblAddressLabel.Text = "Domicilio:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(97, 20);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(0, 13);
            this.lblClientName.TabIndex = 0;
            // 
            // lblClientNameLabel
            // 
            this.lblClientNameLabel.AutoSize = true;
            this.lblClientNameLabel.Location = new System.Drawing.Point(7, 20);
            this.lblClientNameLabel.Name = "lblClientNameLabel";
            this.lblClientNameLabel.Size = new System.Drawing.Size(42, 13);
            this.lblClientNameLabel.TabIndex = 0;
            this.lblClientNameLabel.Text = "Cliente:";
            // 
            // gvDetails
            // 
            this.gvDetails.AllowDrop = true;
            this.gvDetails.AllowUserToAddRows = false;
            this.gvDetails.AllowUserToDeleteRows = false;
            this.gvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.PatientDocument,
            this.PatientName,
            this.Date,
            this.PracticeCode,
            this.PracticeName,
            this.Price});
            this.gvDetails.Location = new System.Drawing.Point(12, 218);
            this.gvDetails.Name = "gvDetails";
            this.gvDetails.Size = new System.Drawing.Size(774, 282);
            this.gvDetails.TabIndex = 5;
            this.gvDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvDetails_CellBeginEdit);
            // 
            // btnLoadInvoiceItems
            // 
            this.btnLoadInvoiceItems.Enabled = false;
            this.btnLoadInvoiceItems.Location = new System.Drawing.Point(12, 190);
            this.btnLoadInvoiceItems.Name = "btnLoadInvoiceItems";
            this.btnLoadInvoiceItems.Size = new System.Drawing.Size(120, 23);
            this.btnLoadInvoiceItems.TabIndex = 6;
            this.btnLoadInvoiceItems.Text = "Cargar movimientos";
            this.btnLoadInvoiceItems.UseVisualStyleBackColor = true;
            this.btnLoadInvoiceItems.Click += new System.EventHandler(this.btnLoadInvoiceItems_Click);
            // 
            // bntViewInvoice
            // 
            this.bntViewInvoice.Enabled = false;
            this.bntViewInvoice.Location = new System.Drawing.Point(340, 191);
            this.bntViewInvoice.Name = "bntViewInvoice";
            this.bntViewInvoice.Size = new System.Drawing.Size(116, 23);
            this.bntViewInvoice.TabIndex = 7;
            this.bntViewInvoice.Text = "Ver Factura";
            this.bntViewInvoice.UseVisualStyleBackColor = true;
            this.bntViewInvoice.Click += new System.EventHandler(this.bntViewInvoice_Click);
            // 
            // chkFreeDetails
            // 
            this.chkFreeDetails.AutoSize = true;
            this.chkFreeDetails.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFreeDetails.Enabled = false;
            this.chkFreeDetails.Location = new System.Drawing.Point(711, 195);
            this.chkFreeDetails.Name = "chkFreeDetails";
            this.chkFreeDetails.Size = new System.Drawing.Size(75, 17);
            this.chkFreeDetails.TabIndex = 8;
            this.chkFreeDetails.Text = "Texto libre";
            this.chkFreeDetails.UseVisualStyleBackColor = true;
            this.chkFreeDetails.CheckedChanged += new System.EventHandler(this.chkFreeDetails_CheckedChanged);
            // 
            // panelFreeText
            // 
            this.panelFreeText.Controls.Add(this.txtFreeText);
            this.panelFreeText.Controls.Add(this.lblFreeText);
            this.panelFreeText.Location = new System.Drawing.Point(12, 218);
            this.panelFreeText.Name = "panelFreeText";
            this.panelFreeText.Size = new System.Drawing.Size(774, 294);
            this.panelFreeText.TabIndex = 9;
            this.panelFreeText.Visible = false;
            // 
            // txtFreeText
            // 
            this.txtFreeText.Location = new System.Drawing.Point(13, 32);
            this.txtFreeText.Multiline = true;
            this.txtFreeText.Name = "txtFreeText";
            this.txtFreeText.Size = new System.Drawing.Size(750, 251);
            this.txtFreeText.TabIndex = 1;
            // 
            // lblFreeText
            // 
            this.lblFreeText.AutoSize = true;
            this.lblFreeText.Location = new System.Drawing.Point(12, 11);
            this.lblFreeText.Name = "lblFreeText";
            this.lblFreeText.Size = new System.Drawing.Size(40, 13);
            this.lblFreeText.TabIndex = 0;
            this.lblFreeText.Text = "Detalle";
            // 
            // btnAdditionaltem
            // 
            this.btnAdditionaltem.Enabled = false;
            this.btnAdditionaltem.Location = new System.Drawing.Point(223, 191);
            this.btnAdditionaltem.Name = "btnAdditionaltem";
            this.btnAdditionaltem.Size = new System.Drawing.Size(111, 23);
            this.btnAdditionaltem.TabIndex = 10;
            this.btnAdditionaltem.Text = "Item Adicional";
            this.btnAdditionaltem.UseVisualStyleBackColor = true;
            this.btnAdditionaltem.Click += new System.EventHandler(this.btnAdditionaltem_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.Location = new System.Drawing.Point(59, 222);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 11;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkIncludeInvoiceDetail
            // 
            this.chkIncludeInvoiceDetail.AutoSize = true;
            this.chkIncludeInvoiceDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludeInvoiceDetail.Enabled = false;
            this.chkIncludeInvoiceDetail.Location = new System.Drawing.Point(620, 195);
            this.chkIncludeInvoiceDetail.Name = "chkIncludeInvoiceDetail";
            this.chkIncludeInvoiceDetail.Size = new System.Drawing.Size(88, 17);
            this.chkIncludeInvoiceDetail.TabIndex = 12;
            this.chkIncludeInvoiceDetail.Text = "Incluir detalle";
            this.chkIncludeInvoiceDetail.UseVisualStyleBackColor = true;
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(688, 67);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(75, 23);
            this.btnEditClient.TabIndex = 1;
            this.btnEditClient.Text = "Detalles";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Selected";
            this.dataGridViewCheckBoxColumn1.FalseValue = "False";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "True";
            this.dataGridViewCheckBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PatientDocumentNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FullName";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn4.HeaderText = "Código";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn5.HeaderText = "Práctica";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.FalseValue = "False";
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.TrueValue = "True";
            this.Selected.Width = 25;
            // 
            // PatientDocument
            // 
            this.PatientDocument.DataPropertyName = "PatientDocumentNumber";
            this.PatientDocument.HeaderText = "Documento";
            this.PatientDocument.Name = "PatientDocument";
            this.PatientDocument.ReadOnly = true;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "FullName";
            this.PatientName.HeaderText = "Nombre";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.Width = 150;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.Date.HeaderText = "Fecha";
            this.Date.Name = "Date";
            this.Date.Width = 70;
            // 
            // PracticeCode
            // 
            this.PracticeCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PracticeCode.DataPropertyName = "Code";
            this.PracticeCode.HeaderText = "Código";
            this.PracticeCode.Name = "PracticeCode";
            this.PracticeCode.ReadOnly = true;
            this.PracticeCode.Width = 65;
            // 
            // PracticeName
            // 
            this.PracticeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PracticeName.DataPropertyName = "Description";
            this.PracticeName.HeaderText = "Práctica";
            this.PracticeName.Name = "PracticeName";
            this.PracticeName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle2;
            this.Price.HeaderText = "Precio";
            this.Price.Name = "Price";
            // 
            // CreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 526);
            this.Controls.Add(this.chkIncludeInvoiceDetail);
            this.Controls.Add(this.panelFreeText);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnAdditionaltem);
            this.Controls.Add(this.chkFreeDetails);
            this.Controls.Add(this.bntViewInvoice);
            this.Controls.Add(this.btnLoadInvoiceItems);
            this.Controls.Add(this.gvDetails);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.gbSelectClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateInvoice";
            this.Text = "Crear Factura";
            this.Load += new System.EventHandler(this.CreateInvoice_Load);
            this.gbSelectClient.ResumeLayout(false);
            this.gbSelectClient.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).EndInit();
            this.panelFreeText.ResumeLayout(false);
            this.panelFreeText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtFilterClient;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.GroupBox gbSelectClient;
        private System.Windows.Forms.Button btnFilterClient;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.Label lblClientNumber;
        private System.Windows.Forms.Label lblClientNumberLabel;
        private System.Windows.Forms.Label lblSaleCondition;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblSaleConditionLabel;
        private System.Windows.Forms.Label lblCUITLabel;
        private System.Windows.Forms.Label lblIvaCondition;
        private System.Windows.Forms.Label lblIvaConditionLabel;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddressLabel;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblClientNameLabel;
        private System.Windows.Forms.DataGridView gvDetails;
        private System.Windows.Forms.Button btnLoadInvoiceItems;
        private System.Windows.Forms.Button bntViewInvoice;
        private System.Windows.Forms.CheckBox chkFreeDetails;
        private System.Windows.Forms.Panel panelFreeText;
        private System.Windows.Forms.Label lblFreeText;
        private System.Windows.Forms.Button btnAdditionaltem;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckBox chkIncludeInvoiceDetail;
        private System.Windows.Forms.TextBox txtFreeText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PracticeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PracticeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.RadioButton rdbClientsPendingItems;
        private System.Windows.Forms.RadioButton rdbAllClients;
        private System.Windows.Forms.Button btnEditClient;
    }
}