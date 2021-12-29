using Medilab.BusinessObjects.ClinicalHistory;
using System;
using System.Windows.Forms;

namespace Medilab.UserInterface.Attention
{
    public partial class PendingPatientList : Form
    {
        public PendingPatientList()
        {
            InitializeComponent();
        }
        #region Properties

        private Guid _selectedId;

        #endregion
        #region Events 
        private void PendingPatientList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void gvPendingPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvPendingPatients[0, e.RowIndex].Value;
            ShowDetails(id);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        #endregion
        #region Methods
        private void LoadGrid()
        {
            var pendigPatients = AttentionWorkflow.GetPendingPractices(chkShowAll.Checked);
            gvPendingPatients.AutoGenerateColumns = false;
            gvPendingPatients.DataSource = pendigPatients;
            if (gvPendingPatients.Rows.Count > 0)
            {
                _selectedId = (Guid)gvPendingPatients[0, 0].Value;
            }
        }
        private void ShowDetails(Guid medicalHistoryId)
        {
            var detailsForm = new PendingPracticesDetails(medicalHistoryId);
            detailsForm.ShowDialog(this);
            LoadGrid();
        }
        private void gvPendingPatients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRefresh.PerformClick();
            }
        }
        #endregion  
    }
}
