using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Attention;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.ClinicalHistory
{
    public partial class FrmClinicalHistoryGrid : Form
    {
        #region Properties

        private Guid _selectedId;
        private int? _version;
        private string _mainSortfield;
        private ListSortDirection _mainSortOrder;

        #endregion

        public FrmClinicalHistoryGrid()
        {
            InitializeComponent();
            foreach (DataGridViewTextBoxColumn column in gvClinicalHistory.Columns)
            {
                string headerText = column.HeaderText;
                column.HeaderCell = new CustomColumnHeaderCell();
                column.HeaderText = headerText;
            }
        }

        #region Events
        private void FrmClinicalHistoryGrid_Load(object sender, EventArgs e)
        {
            LoadDropdown();
            FilterGrid();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedId = Guid.Empty;
            Editar();
        }
        private void gvClinicalHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedId = (Guid) gvClinicalHistory[0, e.RowIndex].Value;
            Editar();
        }
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            FilterGrid();
        }
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterByPatient.Text = string.Empty;
            txtFilterByClient.Text = string.Empty;
            txtFilterByDocumentNumber.Text = string.Empty;
            LoadDropdown();
            FilterGrid();

        }
        private void btnLoadResults_Click(object sender, EventArgs e)
        {
            if (_version.HasValue && _version.Value == 1)
            {
                var detailResults = new ClinicalHistoryResume(_selectedId);
                detailResults.ShowDialog();
            }
            else
            {
                var results = new FrmClinicalHistoryResult(_selectedId) { StartPosition = FormStartPosition.CenterScreen };
                results.ShowDialog();
            }
            FilterGrid();
        }
        private void gvClinicalHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int version;
            _selectedId = (Guid)gvClinicalHistory[0, e.RowIndex].Value;
            Int32.TryParse(gvClinicalHistory[1, e.RowIndex].Value.ToString(), out version);
            _version = version;
        }
        private void btnChangePracticeStatus_Click(object sender, EventArgs e)
        {
            var frmAddResults = new PendingPracticesDetails(_selectedId, true) { StartPosition = FormStartPosition.CenterScreen };
            frmAddResults.ShowDialog();
            FilterGrid();
        }
        private void gvClinicalHistory_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = gvClinicalHistory.Columns[e.ColumnIndex];

            if (_mainSortfield == null || _mainSortfield == clickedColumn.DataPropertyName)
            {
                _mainSortfield = clickedColumn.DataPropertyName;
                _mainSortOrder = ((CustomColumnHeaderCell)clickedColumn.HeaderCell).SortOrderDirection;

                foreach (DataGridViewTextBoxColumn columnItem in gvClinicalHistory.Columns.Cast<DataGridViewTextBoxColumn>().Where(columnItem => columnItem.DataPropertyName != _mainSortfield))
                {
                    ((CustomColumnHeaderCell)columnItem.HeaderCell).ResetSortDirection();
                }

                DataGridViewColumn column = gvClinicalHistory.Columns[_mainSortfield];
                if (column != null)
                {
                    gvClinicalHistory.Sort(column, _mainSortOrder);
                }
            }
            else
            {
                string mainSortOrder = _mainSortOrder == ListSortDirection.Ascending ? "ASC" : "DESC";
                string secondarySortfield = clickedColumn.DataPropertyName;
                string secondarySortOrder = ((CustomColumnHeaderCell)clickedColumn.HeaderCell).SortOrderDirection == ListSortDirection.Ascending ? "ASC" : "DESC";

                foreach (DataGridViewTextBoxColumn columnItem in gvClinicalHistory.Columns.Cast<DataGridViewTextBoxColumn>().Where(columnItem => columnItem.DataPropertyName != _mainSortfield && columnItem.DataPropertyName != secondarySortfield))
                {
                    ((CustomColumnHeaderCell)columnItem.HeaderCell).ResetSortDirection();
                }

                var data = (DataView)gvClinicalHistory.DataSource;
                data.Sort = string.Format("{0} {1}, {2} {3}", _mainSortfield, mainSortOrder, secondarySortfield, secondarySortOrder);
                gvClinicalHistory.DataSource = data;
            }
        }
        #endregion

        #region Methods

        private void LoadGrid(IEnumerable<MedicalHistoryDto> medicalHistories)
        {
            gvClinicalHistory.AutoGenerateColumns = false;
            gvClinicalHistory.DataSource = DataTableConverter.BuildDataTable(medicalHistories.OrderBy(h => h.PatientName).ToList()).DefaultView; 
            EnableDisableButtons();
            if (gvClinicalHistory.Rows.Count > 0)
            {
                _selectedId = (Guid)gvClinicalHistory[0, 0].Value;
                int version;
                Int32.TryParse(gvClinicalHistory[1, 0].Value.ToString(), out version);
                _version = version;
            }
        }

        private void Editar()
        {
            var frmAddEdit = new FrmAddClinicalHistory(_selectedId) {StartPosition = FormStartPosition.CenterScreen};
            frmAddEdit.ShowDialog();
            FilterGrid();
        }

        private void LoadDropdown()
        {
            cbFilterbyStatus.Items.Clear();
            List<String> statusNames = EnumUtils.GetDisplayNames(Enum.GetNames(typeof(ClinicalHistoryStatus))).ToList();
            statusNames.Add(Resources.StatusFilterAll);
            cbFilterbyStatus.Items.AddRange(statusNames.ToArray());
            cbFilterbyStatus.Text = ClinicalHistoryStatus.Incompleta.ToString();
            //Set filter dates
            dtpFilterFromDate.Value = DateTime.Now;
            dtpFilterToDate.Value = DateTime.Now;
        }

        private void FilterGrid()
        {
            if (string.IsNullOrEmpty(cbFilterbyStatus.Text)) return;
            ClinicalHistoryStatus filterByStatus = 0;
            if (cbFilterbyStatus.Text != Resources.StatusFilterAll)
            {
                filterByStatus = (ClinicalHistoryStatus)Enum.Parse(typeof (ClinicalHistoryStatus), cbFilterbyStatus.Text.Replace(" ", ""));
            }
            var filter = new ClinicalExamFilterCriteria
            {
                FilterByPatient = txtFilterByPatient.Text,
                FilterByClient = txtFilterByClient.Text,
                FilterByDocumentNumber = txtFilterByDocumentNumber.Text,
                FilterByStatus = filterByStatus,
                FilterByFromDate = dtpFilterFromDate.Value,
                FilterByToDate = dtpFilterToDate.Value
            };
            var medicalHistoryList = MedicalHistory.GetMedicalHistoryList(filter);
            LoadGrid(medicalHistoryList);
            ResetSort();
        }

        private void ResetSort()
        {
            foreach (DataGridViewTextBoxColumn column in gvClinicalHistory.Columns)
            {
                ((CustomColumnHeaderCell) column.HeaderCell).ResetSortDirection();
            }
            _mainSortfield = null;
        }

        private void EnableDisableButtons()
        {
            if (gvClinicalHistory.Rows.Count > 0)
            {
                btnEdit.Enabled = true;
                btnLoadResults.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnLoadResults.Enabled = false;
            }
        }
        #endregion
    }
}
