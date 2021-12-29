using System.ComponentModel;
using System.Data;
using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Excel;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Reports
{
    public partial class PracticesByClient : Form
    {

        #region Variables

        private PendingExamFilterCriteria _filterCriteria;
        private Client _client;
        private string _mainSortfield;
        private ListSortDirection _mainSortOrder;

        #endregion

        public PracticesByClient()
        {
            InitializeComponent();
            foreach (DataGridViewTextBoxColumn column in gvReportContent.Columns)
            {
                string headerText = column.HeaderText;
                column.HeaderCell = new CustomColumnHeaderCell();
                column.HeaderText = headerText;
            }
        }

        #region Events
        private void PracticesByClient_Load(object sender, EventArgs e)
        {
            //Set filter dates
            dtpFilterFromDate.Value = DateTime.Now.AddMonths(-12).Date;
            dtpFilterToDate.Value = DateTime.Now.Date;
            LoadDropdowns();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                PrintReportMultiPage();
            }
            catch (Exception ex)
            {
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyFilters();
            }
            catch (Exception ex)
            {
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gvReportContent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = gvReportContent.Columns[e.ColumnIndex];

            if (_mainSortfield == null || _mainSortfield == clickedColumn.DataPropertyName)
            {
                _mainSortfield = clickedColumn.DataPropertyName;
                _mainSortOrder = ((CustomColumnHeaderCell)clickedColumn.HeaderCell).SortOrderDirection;

                foreach (DataGridViewTextBoxColumn columnItem in gvReportContent.Columns.Cast<DataGridViewTextBoxColumn>().Where(columnItem => columnItem.DataPropertyName != _mainSortfield))
                {
                    ((CustomColumnHeaderCell)columnItem.HeaderCell).ResetSortDirection();
                }

                DataGridViewColumn column = gvReportContent.Columns[_mainSortfield];
                if (column != null)
                {
                    gvReportContent.Sort(column, _mainSortOrder);
                }
            }
            else
            {
                string mainSortOrder = _mainSortOrder == ListSortDirection.Ascending ? "ASC" : "DESC";
                string secondarySortfield = clickedColumn.DataPropertyName;
                string secondarySortOrder = ((CustomColumnHeaderCell)clickedColumn.HeaderCell).SortOrderDirection == ListSortDirection.Ascending ? "ASC" : "DESC";

                foreach (DataGridViewTextBoxColumn columnItem in gvReportContent.Columns.Cast<DataGridViewTextBoxColumn>().Where(columnItem => columnItem.DataPropertyName != _mainSortfield && columnItem.DataPropertyName != secondarySortfield))
                {
                    ((CustomColumnHeaderCell)columnItem.HeaderCell).ResetSortDirection();
                }

                var data = (DataView)gvReportContent.DataSource;
                data.Sort = string.Format("{0} {1}, {2} {3}", _mainSortfield, mainSortOrder, secondarySortfield, secondarySortOrder);
                gvReportContent.DataSource = data;
            }
        }
        #endregion
        #region Methods
        private void LoadDropdowns()
        {
            cbClient.Items.Clear();
            var companies = Client.GetClientList().ToList();
            if (companies.Count > 0)
            {
                companies.Insert(0, new Client(Guid.Empty));
                cbClient.DataSource = companies;
                cbClient.DisplayMember = "Name";
                cbClient.Text = string.Empty;
            }
        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(cbClient, epPracticesByClient);
        }
        private void ApplyFilters()
        {
            if (!ValidateForm()) return;
            ResetSort();
            _filterCriteria = null;
            _client = (Client)cbClient.SelectedItem;
            var filter = new PendingExamFilterCriteria
            {
                FilterByFromDate =dtpFilterFromDate.Value,
                FilterByToDate = dtpFilterToDate.Value.AddDays(1).AddSeconds(-1),
                ClientId = _client.Id
            };
            _filterCriteria = filter;
            var practicesList = AttentionWorkflow.GetPracticesByClient(filter);
            LoadGrid(practicesList);
        }

        private void LoadGrid(IEnumerable<PendingPracticePatientClientDto> practicesList)
        {
            btnExport.Enabled = false;
            gvReportContent.AutoGenerateColumns = false;
            if (practicesList != null)
            {
                gvReportContent.DataSource = DataTableConverter.BuildDataTable(practicesList.OrderBy(p => p.PatientName).ToList()).DefaultView;
                if (gvReportContent.Rows.Count > 0)
                {
                    btnExport.Enabled = true;
                }
            }
            else
            {
                gvReportContent.DataSource = null;
            }
        }

        private void PrintReportMultiPage()
        {
            var excel = new MSExcel();
            // Get the file we are going to process
            string filename = string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                            "Reporte_", String.Format("{0}_{1}", _client.Name, DateTime.Now.ToString("dd-MM-yy")), ".xlsx");

            File.Copy(string.Concat(
                ConfigurationManager.AppSettings["ExcelPathTemplates"],
                ConfigurationManager.AppSettings["ReportPracticesByProfessional"]),
                      filename);

            var template = new FileInfo(filename);

            // Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        //Calculate de number of spreadsheets to be use in the excel file
                        var searchResults = (DataView)gvReportContent.DataSource; 

                        // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        //calculation of the number of pages
                        int counter = 9;

                        foreach (DataRowView pendingExam in searchResults)
                        {
                            if (counter == 9)
                            {
                                //report title
                                currentWorksheet.Cells["a2"].Value = Resources.PracticeByClientReportTitle;
                                //report name
                                currentWorksheet.Cells["a4"].Value = Resources.PracticeByClientReportName;
                                //client name
                                currentWorksheet.Cells["b4"].Value = _client.Name;
                                currentWorksheet.Cells["c5"].Value = _filterCriteria.FilterByFromDate.ToShortDateString();
                                currentWorksheet.Cells["c6"].Value = _filterCriteria.FilterByToDate.ToShortDateString();

                            }
                            ExcelHandler.AddBorders(currentWorksheet, "A" + counter + ":" + "I" + counter);
                            currentWorksheet.Cells["A" + counter].Value = pendingExam["Date"];
                            currentWorksheet.Cells["B" + counter].Value = pendingExam["Code"];
                            currentWorksheet.Cells["D" + counter].Value = pendingExam["Name"];
                            currentWorksheet.Cells["F" + counter].Value = pendingExam["DocumentNumber"];
                            currentWorksheet.Cells["H" + counter].Value = pendingExam["PatientName"];
                            currentWorksheet.Cells["I" + counter].Value = _client.Name;
                            counter++;
                        }
                    }

                    package.Save();
                    excel.Open(filename);
                    excel.Print();
                    excel.Close();
                    excel.Quit();
                    RemoveFile(filename);
                }
            }
        }

        private static void RemoveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        private void ResetSort()
        {
            foreach (DataGridViewTextBoxColumn column in gvReportContent.Columns)
            {
                ((CustomColumnHeaderCell)column.HeaderCell).ResetSortDirection();
            }
            _mainSortfield = null;
        }

        #endregion
    }
}
