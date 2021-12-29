namespace Medilab.UserInterface.Pacientes
{
    partial class UcAddress
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbAddress = new System.Windows.Forms.GroupBox();
            this.btnViewArchive = new System.Windows.Forms.Button();
            this.btnArchiveAddress = new System.Windows.Forms.Button();
            this.chkIsDefault = new System.Windows.Forms.CheckBox();
            this.lblAddressType = new System.Windows.Forms.Label();
            this.cbAddressType = new System.Windows.Forms.ComboBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtOtherInformation = new System.Windows.Forms.TextBox();
            this.txtStreetOne = new System.Windows.Forms.TextBox();
            this.lblStateAddress = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cbAddressState = new System.Windows.Forms.ComboBox();
            this.addressErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAddress
            // 
            this.gbAddress.Controls.Add(this.btnViewArchive);
            this.gbAddress.Controls.Add(this.btnArchiveAddress);
            this.gbAddress.Controls.Add(this.chkIsDefault);
            this.gbAddress.Controls.Add(this.lblAddressType);
            this.gbAddress.Controls.Add(this.cbAddressType);
            this.gbAddress.Controls.Add(this.lblOther);
            this.gbAddress.Controls.Add(this.lblAddress);
            this.gbAddress.Controls.Add(this.txtOtherInformation);
            this.gbAddress.Controls.Add(this.txtStreetOne);
            this.gbAddress.Controls.Add(this.lblStateAddress);
            this.gbAddress.Controls.Add(this.txtNumber);
            this.gbAddress.Controls.Add(this.txtCity);
            this.gbAddress.Controls.Add(this.lblNumber);
            this.gbAddress.Controls.Add(this.lblLocation);
            this.gbAddress.Controls.Add(this.cbAddressState);
            this.gbAddress.Location = new System.Drawing.Point(3, 3);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Size = new System.Drawing.Size(467, 172);
            this.gbAddress.TabIndex = 0;
            this.gbAddress.TabStop = false;
            this.gbAddress.Text = "Dirección";
            // 
            // btnViewArchive
            // 
            this.btnViewArchive.Location = new System.Drawing.Point(380, 144);
            this.btnViewArchive.Name = "btnViewArchive";
            this.btnViewArchive.Size = new System.Drawing.Size(75, 23);
            this.btnViewArchive.TabIndex = 8;
            this.btnViewArchive.Text = "Ver";
            this.btnViewArchive.UseVisualStyleBackColor = true;
            this.btnViewArchive.Click += new System.EventHandler(this.btnViewArchive_Click);
            // 
            // btnArchiveAddress
            // 
            this.btnArchiveAddress.Location = new System.Drawing.Point(299, 144);
            this.btnArchiveAddress.Name = "btnArchiveAddress";
            this.btnArchiveAddress.Size = new System.Drawing.Size(75, 23);
            this.btnArchiveAddress.TabIndex = 7;
            this.btnArchiveAddress.Text = "Archivar";
            this.btnArchiveAddress.UseVisualStyleBackColor = true;
            this.btnArchiveAddress.Click += new System.EventHandler(this.btnArchiveAddress_Click);
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Location = new System.Drawing.Point(330, 19);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(100, 17);
            this.chkIsDefault.TabIndex = 1;
            this.chkIsDefault.Text = "Predeterminada";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            this.chkIsDefault.CheckedChanged += new System.EventHandler(this.chkIsDefault_CheckedChanged);
            // 
            // lblAddressType
            // 
            this.lblAddressType.AutoSize = true;
            this.lblAddressType.Location = new System.Drawing.Point(11, 20);
            this.lblAddressType.Name = "lblAddressType";
            this.lblAddressType.Size = new System.Drawing.Size(28, 13);
            this.lblAddressType.TabIndex = 0;
            this.lblAddressType.Text = "Tipo";
            // 
            // cbAddressType
            // 
            this.cbAddressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddressType.FormattingEnabled = true;
            this.cbAddressType.Location = new System.Drawing.Point(71, 16);
            this.cbAddressType.Name = "cbAddressType";
            this.cbAddressType.Size = new System.Drawing.Size(252, 21);
            this.cbAddressType.TabIndex = 0;
            this.cbAddressType.SelectedIndexChanged += new System.EventHandler(this.cbAddressType_SelectedIndexChanged);
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(11, 101);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(27, 13);
            this.lblOther.TabIndex = 3;
            this.lblOther.Text = "Otro";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(11, 49);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(30, 13);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Calle";
            // 
            // txtOtherInformation
            // 
            this.txtOtherInformation.Location = new System.Drawing.Point(71, 101);
            this.txtOtherInformation.Multiline = true;
            this.txtOtherInformation.Name = "txtOtherInformation";
            this.txtOtherInformation.Size = new System.Drawing.Size(388, 37);
            this.txtOtherInformation.TabIndex = 5;
            this.txtOtherInformation.TextChanged += new System.EventHandler(this.address_Change);
            this.txtOtherInformation.Leave += new System.EventHandler(this.txtOtherInformation_Leave);
            // 
            // txtStreetOne
            // 
            this.txtStreetOne.Location = new System.Drawing.Point(70, 46);
            this.txtStreetOne.Name = "txtStreetOne";
            this.txtStreetOne.Size = new System.Drawing.Size(388, 20);
            this.txtStreetOne.TabIndex = 2;
            this.txtStreetOne.TextChanged += new System.EventHandler(this.address_Change);
            this.txtStreetOne.Leave += new System.EventHandler(this.txtStreetOne_Leave);
            // 
            // lblStateAddress
            // 
            this.lblStateAddress.AutoSize = true;
            this.lblStateAddress.Location = new System.Drawing.Point(11, 149);
            this.lblStateAddress.Name = "lblStateAddress";
            this.lblStateAddress.Size = new System.Drawing.Size(51, 13);
            this.lblStateAddress.TabIndex = 7;
            this.lblStateAddress.Text = "Provincia";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(71, 75);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(110, 20);
            this.txtNumber.TabIndex = 3;
            this.txtNumber.TextChanged += new System.EventHandler(this.address_Change);
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(246, 75);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(212, 20);
            this.txtCity.TabIndex = 4;
            this.txtCity.TextChanged += new System.EventHandler(this.address_Change);
            this.txtCity.Leave += new System.EventHandler(this.txtCity_Leave);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(11, 78);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 5;
            this.lblNumber.Text = "Número";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(187, 78);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(53, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Localidad";
            // 
            // cbAddressState
            // 
            this.cbAddressState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAddressState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAddressState.FormattingEnabled = true;
            this.cbAddressState.Location = new System.Drawing.Point(68, 146);
            this.cbAddressState.Name = "cbAddressState";
            this.cbAddressState.Size = new System.Drawing.Size(225, 21);
            this.cbAddressState.TabIndex = 6;
            this.cbAddressState.TextChanged += new System.EventHandler(this.address_Change);
            this.cbAddressState.Leave += new System.EventHandler(this.cbAddressState_Leave);
            // 
            // addressErrorProvider
            // 
            this.addressErrorProvider.ContainerControl = this;
            // 
            // UcAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAddress);
            this.Name = "UcAddress";
            this.Size = new System.Drawing.Size(475, 179);
            this.Load += new System.EventHandler(this.UcAddress_Load);
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddress;
        private System.Windows.Forms.Label lblAddressType;
        private System.Windows.Forms.ComboBox cbAddressType;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtStreetOne;
        private System.Windows.Forms.Label lblStateAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cbAddressState;
        private System.Windows.Forms.ErrorProvider addressErrorProvider;
        private System.Windows.Forms.CheckBox chkIsDefault;
        private System.Windows.Forms.Button btnViewArchive;
        private System.Windows.Forms.Button btnArchiveAddress;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtOtherInformation;
    }
}
