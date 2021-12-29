using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medilab.BusinessObjects.Invoice;

namespace Medilab.UserInterface.Invoice
{
    public partial class FrmSelectAdditionalItem : Form
    {
        private string _criteria;

        public InvoiceDetails SelectedItem { private set; get; }

        public FrmSelectAdditionalItem(string criteria)
        {
            _criteria = criteria;
            InitializeComponent();
        }

        #region Events

        private void FrmSelectAdditionalItem_Load(object sender, EventArgs e)
        {
            txtSearchCriteria.Text = _criteria;
            SearchAdditionalItems();
        }
        private void gvAdditionalItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvAdditionalItems[0, e.RowIndex].Value;
            var item = AditionalItem.GetAditionalItem(id);
            SelectedItem = new InvoiceDetails
            {
                Code = item.Code,
                Price = item.Price,
                Description = string.Concat(item.Name, "\n\r", item.Description),
                ItemId = item.Id,
                Selected = true,
                Quantity = (int)nudQuantity.Value
            };
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _criteria = txtSearchCriteria.Text;
            SearchAdditionalItems();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                SelectedItem.Quantity = (int) nudQuantity.Value;
            }
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SelectedItem = null;
            Close();
        }

        private void gvAdditionalItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvAdditionalItems[0, e.RowIndex].Value;
            var item = AditionalItem.GetAditionalItem(id);
            SelectedItem = new InvoiceDetails
            {
                Code = item.Code,
                Price = item.Price,
                Description = string.Concat(item.Name, "\n\r", item.Description),
                ItemId = item.Id,
                Selected = true,
                Quantity = (int)nudQuantity.Value
            }; 
        }

        #endregion

        #region Methods
        private void SearchAdditionalItems()
        {
            var items = (List<AditionalItem>)AditionalItem.SearchAdditionalItems(txtSearchCriteria.Text); 
            gvAdditionalItems.AutoGenerateColumns = false;
            gvAdditionalItems.DataSource = items;
        }
        #endregion
    }
}
