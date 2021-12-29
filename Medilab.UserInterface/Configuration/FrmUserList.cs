using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Utilities;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmUserList : Form
    {
        #region Properties
        private Guid _selectedId;
        #endregion
        // ReSharper disable InconsistentNaming
        #region Events
        public FrmUserList()
        {
            InitializeComponent();
        }


        private void FrmUserList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void gvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedId = (Guid)gvUser[0, e.RowIndex].Value;
            btnEdit.Enabled = true;
            btnDelete.Visible = true;
        }

        private void gvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedId = (Guid)gvUser[0, e.RowIndex].Value;
            Editar();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedId = Guid.Empty;
            Editar();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        // ReSharper restore InconsistentNaming
        #region Methods
        private void LoadGrid()
        {
            var users = User.GetList();
            gvUser.AutoGenerateColumns = false;
            gvUser.DataSource = users;
            if (gvUser.Rows.Count > 0)
            {
                _selectedId = (Guid)gvUser[0, 0].Value;
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
            var frmAddEdit = new FrmAddEditUser(_selectedId);
            frmAddEdit.StartPosition = FormStartPosition.CenterScreen;
            frmAddEdit.ShowDialog();
            LoadGrid();
        }
        private void Delete()
        {
            var rta = MessageBox.Show(@"Esta seguro que desea eliminar el registro seleccionado?", @"Confirmar eliminacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if(rta == DialogResult.Yes)
            {
                var user = User.GetUser(_selectedId);
                user.Delete();
                LoadGrid();
            }
        }
        #endregion 
    }
}
