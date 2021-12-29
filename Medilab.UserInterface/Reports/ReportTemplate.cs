using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.UserInterface.Excel;
using System.IO;
using System.Configuration;
using Medilab.UserInterface.Utilities;
using OfficeOpenXml;

namespace Medilab.UserInterface.Reports
{
    public partial class frmReportTemplate : Form
    {

        #region Variables
        private PendingExamFilterCriteria _filterCriteria;
        private string _mainSortfield;
        private ListSortDirection _mainSortOrder;

        #endregion

        #region Events
        // ReSharper disable InconsistentNaming
        private void btnReport_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void ddlCleanReport_Click(object sender, EventArgs e)
        {
            LoadDropdown();
            LoadGrid(null);
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        // ReSharper restore InconsistentNaming
        #endregion

        #region Methods

        public frmReportTemplate()
        {
            InitializeComponent();
            foreach (DataGridViewTextBoxColumn column in gvReportContent.Columns)
            {
                string headerText = column.HeaderText;
                column.HeaderCell = new CustomColumnHeaderCell();
                column.HeaderText = headerText;
            }
            LoadDropdown();
        }

        private void ApplyFilters()
        {
            ResetSort();
            _filterCriteria = null;
            var value = ddlSpeciality.SelectedItem;
            var filter = new PendingExamFilterCriteria
                             {
                                 FilterByStatus =
                                     (ClinicalExamStatus)
                                     Enum.Parse(typeof (ClinicalExamStatus), ddlStatus.Text.Replace(" ", "")),
                                 FilterByFromDate = dtpFilterFromDate.Value,
                                 FilterByToDate = dtpFilterToDate.Value.AddDays(1).AddSeconds(-1),
                                 Speciality = ((ListItemDto<Guid>) (value)).Id

                             };
            _filterCriteria = filter;
            var medicalHistoryList = AttentionWorkflow.GetPendingPractices(filter);
            LoadGrid(medicalHistoryList);
        }

        private void LoadGrid(IEnumerable<PendingPracticePatientClientDto> medicalHistoryList)
        {
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

        private void LoadDropdown()
        {
            #region Status

            ddlStatus.Items.Clear();
            var statusNames = EnumUtils.GetDisplayNames(Enum.GetNames(typeof (ClinicalExamStatus))).ToArray();
            ddlStatus.Items.AddRange(statusNames);
            ddlStatus.Text = ClinicalExamStatus.Incompleto.ToString();

            #endregion

            #region DateTimePickers

            //Set filter dates
            dtpFilterFromDate.Value = DateTime.Now.AddMonths(-12).Date;
            dtpFilterToDate.Value = DateTime.Now.Date;

            #endregion

            #region Speciality

            //Specialities
            ddlSpeciality.DataSource = null;
            var specialities = Speciality.GetList();
            var specList = specialities.Select(speciality => new ListItemDto<Guid>
                                                                 {
                                                                     Id = speciality.Id,
                                                                     Value = speciality.Name
                                                                 }).ToList();
            specList = (from s in specList orderby s.Value select s).ToList();
            var firstItem = (from s in specList where s.Id == Constants.NoSpecialityId select s).First();
            specList.Remove(firstItem);
            specList.Insert(0, firstItem);
            ddlSpeciality.DataSource = specList;
            ddlSpeciality.DisplayMember = "Value";

            #endregion
        }

        private void PrintReport()
        {
            var excel = new MSExcel();
            // Get the file we are going to process
            string filename = string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                            "Reporte_" + Guid.NewGuid().ToString() , ".xlsx");

            File.Copy(string.Concat(
                ConfigurationManager.AppSettings["ExcelPathTemplates"],
                ConfigurationManager.AppSettings["Report1"]),
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
                        
                        // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        currentWorksheet.Cells["c5"].Value = _filterCriteria.FilterByFromDate.ToShortDateString();
                        currentWorksheet.Cells["c6"].Value = _filterCriteria.FilterByToDate.ToShortDateString();
                        currentWorksheet.Cells["h5"].Value = _filterCriteria.FilterByStatus;
                        currentWorksheet.Cells["h6"].Value = Speciality.GetSpeciality(_filterCriteria.Speciality).Name;

                        int counter = 9;
                        var searchResults = (DataView)gvReportContent.DataSource;
                        foreach (DataRowView pendingExam in searchResults)
                        {
                            ExcelHandler.AddBorders(currentWorksheet, "A" + counter + ":" + "I" + counter);

                            currentWorksheet.Cells["A" + counter].Value = pendingExam["Code"];
                            currentWorksheet.Cells["B" + counter].Value = pendingExam["Name"];
                            currentWorksheet.Cells["D" + counter].Value = pendingExam["DocumentNumber"];
                            currentWorksheet.Cells["F" + counter].Value = pendingExam["PatientName"];
                            currentWorksheet.Cells["H" + counter].Value = pendingExam["ClientName"];
                            currentWorksheet.Cells["I" + counter].Value = pendingExam["Cuit"];
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