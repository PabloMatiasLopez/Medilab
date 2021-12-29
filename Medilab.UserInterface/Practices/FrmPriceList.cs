using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.ListOfPrice;

namespace Medilab.UserInterface.Practices
{
    public partial class FrmPriceList : Form
    {
        private List<PriceListItemDto> _priceList;
        public FrmPriceList()
        {
            InitializeComponent();
            _priceList = new List<PriceListItemDto>();
        }
        #region Events
        // ReSharper disable InconsistentNaming
        private void FrmPriceList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                FilterList(txtSearchText.Text.ToLower().Trim());
            }
            else
            {
                gvPriceList.AutoGenerateColumns = false;
                gvPriceList.DataSource = _priceList;
                lblCountResult.Text = string.Format("Total: {0} prácticas.", _priceList.Count.ToString(CultureInfo.InvariantCulture));
            }
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Methods
        private void LoadGrid()
        {
            _priceList = (List<PriceListItemDto>) PracticePrice.GetList();
            gvPriceList.AutoGenerateColumns = false;
            gvPriceList.DataSource = _priceList;
            lblCountResult.Text = string.Format("Total: {0} prácticas.", _priceList.Count.ToString(CultureInfo.InvariantCulture));
        }
        private void FilterList(string filterText)
        {
            var filteredList =
                (from p in _priceList where p.Name.ToLower().Contains(filterText) || p.Code.ToString().Contains(filterText) select p).ToList();
            gvPriceList.AutoGenerateColumns = false;
            gvPriceList.DataSource = filteredList;
            lblCountResult.Text = string.Format("Total: {0} prácticas.", filteredList.Count.ToString(CultureInfo.InvariantCulture));
        }
        #endregion    
    }
}
