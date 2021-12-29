using System.Windows.Forms;

namespace Medilab.UserInterface.Invoice
{
    partial class InvoicePreview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInvoiceTypeLabel = new System.Windows.Forms.Label();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.lblInvoiceNumberLable = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblClientNameLabel = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblIVALabel = new System.Windows.Forms.Label();
            this.lblCUITLabel = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblSellConditionLabel = new System.Windows.Forms.Label();
            this.lblClientNumberLabel = new System.Windows.Forms.Label();
            this.lblSellCondition = new System.Windows.Forms.Label();
            this.lblClientNumber = new System.Windows.Forms.Label();
            this.lblInvoiceDateLabel = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSubTotlaLabel = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gvRetentions = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetentionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetentions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInvoiceTypeLabel
            // 
            this.lblInvoiceTypeLabel.AutoSize = true;
            this.lblInvoiceTypeLabel.Location = new System.Drawing.Point(117, 21);
            this.lblInvoiceTypeLabel.Name = "lblInvoiceTypeLabel";
            this.lblInvoiceTypeLabel.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceTypeLabel.TabIndex = 0;
            this.lblInvoiceTypeLabel.Text = "Tipo de factura:";
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceType.Location = new System.Drawing.Point(205, 19);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(18, 17);
            this.lblInvoiceType.TabIndex = 0;
            this.lblInvoiceType.Text = "A";
            // 
            // lblInvoiceNumberLable
            // 
            this.lblInvoiceNumberLable.AutoSize = true;
            this.lblInvoiceNumberLable.Location = new System.Drawing.Point(49, 7);
            this.lblInvoiceNumberLable.Name = "lblInvoiceNumberLable";
            this.lblInvoiceNumberLable.Size = new System.Drawing.Size(98, 13);
            this.lblInvoiceNumberLable.TabIndex = 0;
            this.lblInvoiceNumberLable.Text = "Número de factura:";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNumber.Location = new System.Drawing.Point(153, 5);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(122, 17);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "0001-00018545";
            // 
            // lblClientNameLabel
            // 
            this.lblClientNameLabel.AutoSize = true;
            this.lblClientNameLabel.Location = new System.Drawing.Point(36, 7);
            this.lblClientNameLabel.Name = "lblClientNameLabel";
            this.lblClientNameLabel.Size = new System.Drawing.Size(39, 13);
            this.lblClientNameLabel.TabIndex = 0;
            this.lblClientNameLabel.Text = "Sr/es: ";
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Location = new System.Drawing.Point(36, 29);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(52, 13);
            this.lblAddressLabel.TabIndex = 0;
            this.lblAddressLabel.Text = "Domicilio:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(94, 5);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(96, 17);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "Skanka S.A.";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(94, 27);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(256, 17);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Call 123, Lujan de Cuyo, Mendoza";
            // 
            // lblIVALabel
            // 
            this.lblIVALabel.AutoSize = true;
            this.lblIVALabel.Location = new System.Drawing.Point(36, 50);
            this.lblIVALabel.Name = "lblIVALabel";
            this.lblIVALabel.Size = new System.Drawing.Size(36, 13);
            this.lblIVALabel.TabIndex = 0;
            this.lblIVALabel.Text = "I.V.A.:";
            // 
            // lblCUITLabel
            // 
            this.lblCUITLabel.AutoSize = true;
            this.lblCUITLabel.Location = new System.Drawing.Point(383, 46);
            this.lblCUITLabel.Name = "lblCUITLabel";
            this.lblCUITLabel.Size = new System.Drawing.Size(47, 13);
            this.lblCUITLabel.TabIndex = 0;
            this.lblCUITLabel.Text = "C.U.I.T.:";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.Location = new System.Drawing.Point(94, 48);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(169, 17);
            this.lblIVA.TabIndex = 0;
            this.lblIVA.Text = "Responsable Inscripto";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUIT.Location = new System.Drawing.Point(436, 44);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(119, 17);
            this.lblCUIT.TabIndex = 0;
            this.lblCUIT.Text = "30-12345678-9";
            // 
            // lblSellConditionLabel
            // 
            this.lblSellConditionLabel.AutoSize = true;
            this.lblSellConditionLabel.Location = new System.Drawing.Point(36, 73);
            this.lblSellConditionLabel.Name = "lblSellConditionLabel";
            this.lblSellConditionLabel.Size = new System.Drawing.Size(103, 13);
            this.lblSellConditionLabel.TabIndex = 0;
            this.lblSellConditionLabel.Text = "Condición de Venta:";
            // 
            // lblClientNumberLabel
            // 
            this.lblClientNumberLabel.AutoSize = true;
            this.lblClientNumberLabel.Location = new System.Drawing.Point(383, 72);
            this.lblClientNumberLabel.Name = "lblClientNumberLabel";
            this.lblClientNumberLabel.Size = new System.Drawing.Size(57, 13);
            this.lblClientNumberLabel.TabIndex = 0;
            this.lblClientNumberLabel.Text = "Cliente Nº:";
            // 
            // lblSellCondition
            // 
            this.lblSellCondition.AutoSize = true;
            this.lblSellCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellCondition.Location = new System.Drawing.Point(145, 71);
            this.lblSellCondition.Name = "lblSellCondition";
            this.lblSellCondition.Size = new System.Drawing.Size(68, 17);
            this.lblSellCondition.TabIndex = 0;
            this.lblSellCondition.Text = "Contado";
            // 
            // lblClientNumber
            // 
            this.lblClientNumber.AutoSize = true;
            this.lblClientNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientNumber.Location = new System.Drawing.Point(436, 70);
            this.lblClientNumber.Name = "lblClientNumber";
            this.lblClientNumber.Size = new System.Drawing.Size(26, 17);
            this.lblClientNumber.TabIndex = 0;
            this.lblClientNumber.Text = "15";
            // 
            // lblInvoiceDateLabel
            // 
            this.lblInvoiceDateLabel.AutoSize = true;
            this.lblInvoiceDateLabel.Location = new System.Drawing.Point(91, 30);
            this.lblInvoiceDateLabel.Name = "lblInvoiceDateLabel";
            this.lblInvoiceDateLabel.Size = new System.Drawing.Size(40, 13);
            this.lblInvoiceDateLabel.TabIndex = 0;
            this.lblInvoiceDateLabel.Text = "Fecha:";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.Location = new System.Drawing.Point(137, 28);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(90, 17);
            this.lblInvoiceDate.TabIndex = 0;
            this.lblInvoiceDate.Text = "03/08/2013";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(607, 629);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInvoiceTypeLabel);
            this.panel1.Controls.Add(this.lblInvoiceType);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 55);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblInvoiceDateLabel);
            this.panel2.Controls.Add(this.lblInvoiceDate);
            this.panel2.Controls.Add(this.lblInvoiceNumberLable);
            this.panel2.Controls.Add(this.lblInvoiceNumber);
            this.panel2.Location = new System.Drawing.Point(337, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 55);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblClientName);
            this.panel3.Controls.Add(this.lblAddress);
            this.panel3.Controls.Add(this.lblClientNameLabel);
            this.panel3.Controls.Add(this.lblClientNumber);
            this.panel3.Controls.Add(this.lblIVALabel);
            this.panel3.Controls.Add(this.lblCUIT);
            this.panel3.Controls.Add(this.lblSellConditionLabel);
            this.panel3.Controls.Add(this.lblCUITLabel);
            this.panel3.Controls.Add(this.lblSellCondition);
            this.panel3.Controls.Add(this.lblAddressLabel);
            this.panel3.Controls.Add(this.lblIVA);
            this.panel3.Controls.Add(this.lblClientNumberLabel);
            this.panel3.Location = new System.Drawing.Point(12, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(676, 93);
            this.panel3.TabIndex = 4;
            // 
            // lblSubTotlaLabel
            // 
            this.lblSubTotlaLabel.AutoSize = true;
            this.lblSubTotlaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotlaLabel.Location = new System.Drawing.Point(602, 417);
            this.lblSubTotlaLabel.Name = "lblSubTotlaLabel";
            this.lblSubTotlaLabel.Size = new System.Drawing.Size(80, 16);
            this.lblSubTotlaLabel.TabIndex = 5;
            this.lblSubTotlaLabel.Text = "SUBTOTAL";
            this.lblSubTotlaLabel.Visible = false;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(593, 439);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(88, 16);
            this.lblSubTotal.TabIndex = 6;
            this.lblSubTotal.Text = "$ 100000,00";
            this.lblSubTotal.Visible = false;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLabel.Location = new System.Drawing.Point(618, 569);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(64, 20);
            this.lblTotalLabel.TabIndex = 15;
            this.lblTotalLabel.Text = "TOTAL";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(595, 597);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(88, 16);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "$ 200000,00";
            // 
            // gvRetentions
            // 
            this.gvRetentions.AllowUserToAddRows = false;
            this.gvRetentions.AllowUserToDeleteRows = false;
            this.gvRetentions.AllowUserToResizeColumns = false;
            this.gvRetentions.AllowUserToResizeRows = false;
            this.gvRetentions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gvRetentions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRetentions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Value,
            this.RetentionValue});
            this.gvRetentions.Location = new System.Drawing.Point(12, 470);
            this.gvRetentions.Name = "gvRetentions";
            this.gvRetentions.ReadOnly = true;
            this.gvRetentions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRetentions.Size = new System.Drawing.Size(676, 0);
            this.gvRetentions.TabIndex = 20;
            this.gvRetentions.TabStop = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Retención";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 470;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "%";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // RetentionValue
            // 
            this.RetentionValue.DataPropertyName = "RetentionValue";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.RetentionValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.RetentionValue.HeaderText = "Valor";
            this.RetentionValue.Name = "RetentionValue";
            this.RetentionValue.ReadOnly = true;
            this.RetentionValue.Width = 80;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(526, 629);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // InvoicePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 661);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gvRetentions);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblSubTotlaLabel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoicePreview";
            this.Text = "Vista previa factura";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InvoicePreview_FormClosed);
            this.Load += new System.EventHandler(this.InvoicePreview_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetentions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInvoiceTypeLabel;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.Label lblInvoiceNumberLable;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblClientNameLabel;
        private System.Windows.Forms.Label lblAddressLabel;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblIVALabel;
        private System.Windows.Forms.Label lblCUITLabel;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblSellConditionLabel;
        private System.Windows.Forms.Label lblClientNumberLabel;
        private System.Windows.Forms.Label lblSellCondition;
        private System.Windows.Forms.Label lblClientNumber;
        private System.Windows.Forms.Label lblInvoiceDateLabel;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Button btnPrint;
        private ucFreeTextPreview ucFreeTextPreview1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSubTotlaLabel;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView gvRetentions;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn RetentionValue;
        private Button btnGuardar;
    }
}