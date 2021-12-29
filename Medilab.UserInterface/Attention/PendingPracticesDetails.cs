using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utils;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Attention
{
    public partial class PendingPracticesDetails : Form
    {
        public PendingPracticesDetails()
        {
            InitializeComponent();
        }

        public PendingPracticesDetails(Guid medicalHistoryId, bool allPractices = false)
        {
            _medicalHistoryId = medicalHistoryId;
            _allPractices = allPractices;
            InitializeComponent();
        }

        #region Properties

        private Guid _medicalHistoryId;
        private bool _allPractices;
        #endregion

        #region Events

        private void PendingPracticesDetails_Load(object sender, EventArgs e)
        {
            SetupForm();
            LoadData();
        }

        private void gvPractices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (gvPractices.Columns[e.ColumnIndex].Name == "PracticeDone")
            {
                var row = gvPractices.Rows[e.RowIndex];
                var cellSelecion = row.Cells["PracticeDone"] as DataGridViewCheckBoxCell;
                if (cellSelecion != null)
                {
                    var selected = Convert.ToBoolean(cellSelecion.Value);
                    cellSelecion.Value = !selected;
                }
            }
        }

        private void gvPractices_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvPractices.IsCurrentCellDirty)
            {
                gvPractices.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            MarkAsDone();
            Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void gvPractices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_allPractices) return;
            if (e.RowIndex == -1) return;
            var id = (Guid)gvPractices[0, e.RowIndex].Value;
            if (id == Constants.ClinicalExamId)
            {
                var clinicalExamForm = new ClinicalHistoryResults(_medicalHistoryId);
                clinicalExamForm.ShowDialog(this);
                LoadData();
            }
        }

        private void btnMarkAsIncomplete_Click(object sender, EventArgs e)
        {
            var practices = GetCheckedItems();
            foreach (var item in practices)
            {
                MedicalHistoryPractice.UpdatePracticeStatus(_medicalHistoryId, item.Id, ClinicalExamStatus.Incompleto);   
            }
            LoadData();
        }

        private void btnMarkAsDone_Click(object sender, EventArgs e)
        {
            var practices = GetCheckedItems();
            foreach (var item in practices)
            {
                MedicalHistoryPractice.UpdatePracticeStatus(_medicalHistoryId, item.Id, ClinicalExamStatus.Realizada);
            }
            LoadData();
        }
        #endregion

        #region Methods
        private void SetupForm()
        {
            if (_allPractices)
            {
                Text = @"Prácticas";
                btnDone.Visible = false;
                btnMarkAsIncomplete.Visible = Security.IsAuthozired(SecurityAreas.MedicalAttention);
                btnMarkAsDone.Visible = Security.IsAuthozired(SecurityAreas.Administration);
            }
        }
        private void LoadData()
        {
            PatientPracticesDto pendingPractices;
            if(_allPractices)
            {
                pendingPractices = AttentionWorkflow.GetPractices(_medicalHistoryId);
            }
            else
            {
                Guid specialityId = User.GetUser(Security.GetCurrentUser()).Speciality.Id;
                pendingPractices = AttentionWorkflow.GetPendingPractices(_medicalHistoryId, specialityId);
                if (pendingPractices!=null)
                {
                    foreach (var practice in pendingPractices.Practices)
                    {
                        practice.IsDone = false;
                    } 
                }
            }
            if (pendingPractices != null)
            {
                txtFullName.Text = string.Format("{0}, {1}", pendingPractices.PatientInformation.LastName, pendingPractices.PatientInformation.FirstName);
                txtDocumentNumber.Text =
                    string.Concat(EnumUtils.AddSpaceInCapitalLetter(pendingPractices.PatientInformation.DocumentType), " ",
                                  pendingPractices.PatientInformation.DocumentNumber);
                if (FileDirectoryHandler.CheckIfDirectoryExist(ConfigurationManager.AppSettings["filePhotoServerPath"]))
                {
                    if (!string.IsNullOrEmpty(pendingPractices.PatientInformation.Photo))
                    {
                        pbPhoto.ImageLocation = Path.Combine(ConfigurationManager.AppSettings["filePhotoServerPath"],
                                                             pendingPractices.PatientInformation.Photo);
                    }
                }
                else
                {
                    pbPhoto.ImageLocation = string.Empty;
                }
                txtPatientNumber.Text = pendingPractices.PatientNumber.ToString(CultureInfo.InvariantCulture);
                txtClient.Text = pendingPractices.ClientName;
                txtObservations.Text = pendingPractices.Observations;
            }
            gvPractices.AutoGenerateColumns = false;
            if (_allPractices)
            {
                var gridViewColumn = gvPractices.Columns["PracticeDone"];
                if (gridViewColumn != null) gridViewColumn.HeaderText = "Completar";
                var dataGridViewColumn = gvPractices.Columns["Status"];
                if (dataGridViewColumn != null) dataGridViewColumn.Visible = true;
            }
            if (pendingPractices != null)
            {
                gvPractices.DataSource = pendingPractices.Practices;
            }
            else
            {
                gvPractices.DataSource = null;
            }
        }

        private List<PendingPracticeDto> GetCheckedItems()
        {
            var practices = new List<PendingPracticeDto>();
            foreach (var row in gvPractices.Rows)
            {
                var currentRow = (DataGridViewRow)row;
                var cellSelecion = currentRow.Cells["PracticeDone"] as DataGridViewCheckBoxCell;
                if (cellSelecion != null && Convert.ToBoolean(cellSelecion.Value))
                {
                    practices.Add(new PendingPracticeDto
                    {
                        Id = (Guid)currentRow.Cells["Id"].Value,
                        Code = (int)currentRow.Cells["Code"].Value,
                        Name = currentRow.Cells["PracticeName"].Value.ToString(),
                        Description = currentRow.Cells["Description"].Value.ToString(),
                        IsDone = true
                    });
                }
            }
            return practices;
        }

        private void MarkAsDone()
        {
            var practicesDone = new PatientPracticesDto {ClinicalHistoryId = _medicalHistoryId};
            var practices = GetCheckedItems();
            practicesDone.Practices = practices;
            if( AttentionWorkflow.MarkAsDone(practicesDone))
            {
                MessageBox.Show(Resources.ClinicalHistoryCompleted, Resources.AllExamsCompleted,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion 

        
    }
}
