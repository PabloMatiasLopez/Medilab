using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Patient;
using Medilab.UserInterface.Utils;
using System.Configuration;

namespace Medilab.UserInterface.Pacientes
{
    public partial class FrmPatientList : Form
    {
        public FrmPatientList()
        {
            InitializeComponent();
        }

        #region Properties

        private Guid _selectedId;

        #endregion

        // ReSharper disable InconsistentNaming

        #region Events

        private void FrmPatientList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void gvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedId = (Guid) gvPatient[0, e.RowIndex].Value;
            btnEdit.Enabled = true;
            btnDelete.Visible = true;
        }

        private void gvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedId = (Guid) gvPatient[0, e.RowIndex].Value;
            Editar();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedId = Guid.Empty;
            Editar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Search();
        }
        #endregion

        #region Methods

        private void LoadGrid()
        {
            var patients = Patient.GetList();
            gvPatient.AutoGenerateColumns = false;
            gvPatient.DataSource = patients;
            if (gvPatient.Rows.Count > 0)
            {
                _selectedId = (Guid) gvPatient[0, 0].Value;
                btnEdit.Enabled = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Visible = false;
            }
        }

        private void Editar()
        {
            var frmAddEdit = new FrmAddEditPatient(_selectedId) {StartPosition = FormStartPosition.CenterScreen};
            frmAddEdit.ShowDialog();
            LoadGrid();
        }

        private void Delete()
        {
            var rta = MessageBox.Show(@"Esta seguro que desea eliminar el registro seleccionado?",
                                      @"Confirmar eliminacion",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var patient = Patient.GetPatient(_selectedId);
                FileDirectoryHandler.DeleteFile(ConfigurationManager.AppSettings["filePhotoServerPath"], string.Concat(patient.DocumentNumber, ".jpg"));
                patient.Delete();
                LoadGrid();
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadGrid();
            }
            else
            {
                var patients = Patient.SearchPatient(txtSearch.Text);
                gvPatient.AutoGenerateColumns = false;
                gvPatient.DataSource = patients;
                if (gvPatient.Rows.Count > 0)
                {
                    _selectedId = (Guid) gvPatient[0, 0].Value;
                    btnEdit.Enabled = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Visible = false;
                }
            }
        }
        #endregion
    }
}
