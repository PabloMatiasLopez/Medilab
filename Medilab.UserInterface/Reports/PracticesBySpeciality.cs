using System.ComponentModel;
using System.Data;
using System.Globalization;
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
    public partial class PracticesBySpeciality : Form
    {
        public PracticesBySpeciality()
        {
            InitializeComponent();
            foreach (DataGridViewTextBoxColumn column in gvReportContent.Columns)
            {
                string headerText = column.HeaderText;
                column.HeaderCell = new CustomColumnHeaderCell();
                column.HeaderText = headerText;
            }
        }
        #region Variables

        private PendingExamFilterCriteria _filterCriteria;
        private string _mainSortfield;
        private ListSortDirection _mainSortOrder;

        #endregion

        #region Events
        // ReSharper disable InconsistentNaming
        private void PracticesBySpeciality_Load(object sender, EventArgs e)
        {
            //Set filter dates
            dtpFilterFromDate.Value = DateTime.Now.Date;
            dtpFilterToDate.Value = DateTime.Now.Date;

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

        private void ApplyFilters()
        {
            ResetSort();
            _filterCriteria = null;
            var filter = new PendingExamFilterCriteria
                             {
                                 FilterByFromDate = dtpFilterFromDate.Value,
                                 FilterByToDate = dtpFilterToDate.Value.AddDays(1).AddSeconds(-1)
                             };
            _filterCriteria = filter;
            var medicalHistoryList = AttentionWorkflow.GetPracticesByProfessional(filter);
            LoadGrid(medicalHistoryList);
        }

        private void LoadGrid(IEnumerable<PendingPracticePatientClientDto> medicalHistoryList)
        {
            btnExport.Enabled = false;
            gvReportContent.AutoGenerateColumns = false;
            if (medicalHistoryList != null)
            {
                gvReportContent.DataSource = DataTableConverter.BuildDataTable(medicalHistoryList.OrderBy(p => p.PatientName).ToList()).DefaultView;
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
                        int counter = 9;
                        var worksheet = workBook.Worksheets.First();
                        foreach (DataRowView rowView in searchResults)
                        {
                            DataRow row = rowView.Row;
                            if(counter == 9)
                            {
                                worksheet.Cells["b4"].Value = string.Format("{0}, {1}", currentUser.LastName, currentUser.FirstName);
                                worksheet.Cells["c5"].Value = _filterCriteria.FilterByFromDate.ToShortDateString();
                                worksheet.Cells["c6"].Value = _filterCriteria.FilterByToDate.ToShortDateString();
                                
                            }
                            ExcelHandler.AddBorders(worksheet, "A" + counter + ":" + "I" + counter);

                            worksheet.Cells["A" + counter].Value = row["Date"];
                            worksheet.Cells["B" + counter].Value = row["Code"];
                            worksheet.Cells["D" + counter].Value = row["Name"];
                            worksheet.Cells["F" + counter].Value = row["DocumentNumber"];
                            worksheet.Cells["H" + counter].Value = string.Format("{0} ({1})", rowView["PatientName"], rowView["PatientNumber"]);
                            worksheet.Cells["I" + counter].Value = row["ClientName"];
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
