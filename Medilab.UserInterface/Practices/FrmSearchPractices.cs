using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medilab.BusinessObjects.ClinicalHistory;

namespace Medilab.UserInterface.Practices
{
    public partial class FrmSearchPractices : Form
    {
        private string _criteria;

        public Practice SelectedPractice { private set; get; }

        public FrmSearchPractices(string criteria)
        {
            _criteria = criteria;
            InitializeComponent();
        }
        #region Events
        // ReSharper disable InconsistentNaming
        private void FrmSearchPractices_Load(object sender, EventArgs e)
        {
            txtSearchCriteria.Text = _criteria;
            SearchPractices();
        }
        private void gvPractices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvPractices[0, e.RowIndex].Value;
            var practice = Practice.GetPractice(id);
            SelectedPractice = practice;
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _criteria = txtSearchCriteria.Text;
            SearchPractices();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SelectedPractice = null;
            Close();
        }

        private void gvPractices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvPractices[0, e.RowIndex].Value;
            var practice = Practice.GetPractice(id);
            SelectedPractice = practice;
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Methods
        private void SearchPractices()
        {
            int practiceCode;
            var practices = new object();
            if (!string.IsNullOrEmpty(_criteria) && int.TryParse(_criteria, out practiceCode))
            {
                 practices = Practice.SearchPractice(practiceCode);
            }
            else
            {
                practices = Practice.SearchPractice(_criteria);
            }
           
            gvPractices.AutoGenerateColumns = false;
            gvPractices.DataSource = practices;
        }
        #endregion
    }
}
