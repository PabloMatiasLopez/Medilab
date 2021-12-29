using System.ComponentModel;
using System.Data;
using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
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
    public partial class LaboratoryReport : Form
    {
        #region Variables

        private string _mainSortfield;
        private ListSortDirection _mainSortOrder;

        #endregion

        public LaboratoryReport()
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
        // ReSharper disable InconsistentNaming
        private void PracticesBySpeciality_Load(object sender, EventArgs e)
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

        private void ApplyFilters()
        {
            ResetSort();
            var filter = new PendingExamFilterCriteria
                             {
                                 FilterByFromDate = DateTime.Now.Date,
                                 FilterByToDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1)
                             };
            var medicalHistoryList = AttentionWorkflow.GetPracticesByProfessional(filter);
            LoadGrid(medicalHistoryList);
        }

        private void LoadGrid(IEnumerable<PendingPracticePatientClientDto> medicalHistoryList)
        {
            btnExport.Enabled = false;
            gvReportContent.AutoGenerateColumns = false;
            if (medicalHistoryList != null)
            {
                gvReportContent.DataSource = DataTableConverter.BuildDataTable(medicalHistoryList.OrderBy(p => p.PatientNumber).ToList()).DefaultView;
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
            var searchResults = (DataView)gvReportContent.DataSource;

            var currentUser = User.GetUser(Security.GetCurrentUser());
            var excel = new MSExcel();
            // Get the file we are going to process
            string filename = string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                            "Reporte_", String.Format("{0}_{1}", currentUser.LastName, DateTime.Now.ToString("dd-MM-yy")), ".xlsx");

            File.Copy(string.Concat(
                ConfigurationManager.AppSettings["ExcelPathTemplates"],
                ConfigurationManager.AppSettings["ReportLaboratory"]),
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
                        int counter = 9;
                        List<string> documentNumbers = searchResults.ToTable().AsEnumerable()
                                                                     .Select(row => row.Field<string>("DocumentNumber"))
                                                                     .Distinct()
                                                                     .ToList();
                        var worksheet = workBook.Worksheets.First();
                        foreach (string documentNumber in documentNumbers)
                        {
                            if(counter == 9)
                            {
                                worksheet.Cells["d4"].Value = string.Format("{0}, {1}", currentUser.LastName, currentUser.FirstName);
                                worksheet.Cells["c5"].Value = DateTime.Now.ToShortDateString();
                            }

                            ExcelHandler.AddBorders(worksheet, "A" + counter + ":" + "H" + counter);

                            string number = documentNumber;
                            EnumerableRowCollection<DataRow> practices = searchResults.ToTable().AsEnumerable().Where(p => p.Field<string>("DocumentNumber") == number);
                            worksheet.Cells["A" + counter].Value = practices.First()["PatientNumber"];
                            worksheet.Cells["D" + counter].Value = String.Format("{0} ({1})", practices.First()["PatientName"], number);
                            worksheet.Cells["F" + counter].Value = practices.First()["ClientName"];
                            worksheet.Cells["H" + counter].Value = GetPracticesString(practices);
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

        private string GetPracticesString(IEnumerable<DataRow> practices)
        {
            return practices.Aggregate(String.Empty, (current, practice) => String.Format("{0}.{1}{2}", current, practice["Name"], Environment.NewLine));
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
