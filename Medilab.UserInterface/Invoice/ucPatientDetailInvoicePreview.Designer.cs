namespace Medilab.UserInterface.Invoice
{
    partial class ucPatientDetailInvoicePreview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNameLabel = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gvItems = new System.Windows.Forms.DataGridView();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameLabel
            // 
            this.lblNameLabel.AutoSize = true;
            this.lblNameLabel.Location = new System.Drawing.Point(17, 15);
            this.lblNameLabel.Name = "lblNameLabel";
            this.lblNameLabel.Size = new System.Drawing.Size(47, 13);
            this.lblNameLabel.TabIndex = 0;
            this.lblNameLabel.Text = "Nombre:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(70, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Perez, Juan";
            // 
            // gvItems
            // 
            this.gvItems.AllowUserToAddRows = false;
            this.gvItems.AllowUserToDeleteRows = false;
            this.gvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Count,
            this.Item,
            this.UnitPrice,
            this.Total});
            this.gvItems.Location = new System.Drawing.Point(3, 40);
            this.gvItems.Name = "gvItems";
            this.gvItems.ReadOnly = true;
            this.gvItems.Size = new System.Drawing.Size(637, 69);
            this.gvItems.TabIndex = 1;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Quantity";
            this.Count.HeaderText = "Cant";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 50;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item.DataPropertyName = "Description";
            this.Item.HeaderText = "Descripción";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnitPrice.HeaderText = "Precio Unitario";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 75;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TotalPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 70;
            // 
            // ucPatientDetailInvoicePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvItems);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNameLabel);
            this.Name = "ucPatientDetailInvoicePreview";
            this.Size = new System.Drawing.Size(711, 125);
            this.Load += new System.EventHandler(this.ucPatientDetailInvoicePreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameLabel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView gvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}
