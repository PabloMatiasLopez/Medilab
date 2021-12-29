using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmFiscalRetentionProfile : Form
    {
        #region Properties
        private Guid _selectedId;
        private bool _isEditMode;
        private byte[] _lastUpdated;
        #endregion 
        
        public FrmFiscalRetentionProfile()
        {
            InitializeComponent();
        }
        #region Events
        private void FrmFiscalRetentionProfile_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadRetentions();
        }
        private void gvProfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvProfiles[0, e.RowIndex].Value;
            LoadProfile(id);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                CleanForm();
            }
            else
            {
                Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    SaveProfile();
                }
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format(@"Ha ocurrido un error: {0}.", ex.Message);
                MessageBox.Show(errorMessage, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        #endregion
        #region Methods
        private void LoadGrid()
        {
            CleanForm();
            var profiles = ClientInvoiceProfile.GetAllInvoiceProfile();
            gvProfiles.AutoGenerateColumns = false;
            gvProfiles.DataSource = profiles;
        }
        private void LoadRetentions()
        {
            var retentions = (from r in FiscalRetention.GetAllRetentions() select new ListItemDto<Guid> { Id = r.Id, Value = r.Name }).ToList();
            chklstRetentions.Items.Clear();
            foreach (var item in retentions)
            {
                chklstRetentions.Items.Add(item);
            }
        }      
        private void CleanForm()
        {
            btnCancel.Text = Resources.CloseButtonText;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsDefault.Checked = false;
            btnDelete.Visible = false;
            _isEditMode = false;
            _selectedId = Guid.Empty;
            LoadRetentions();
        }
        private void SaveProfile()
        {
            var profile = new ClientInvoiceProfile(_selectedId)
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                IsDefault = chkIsDefault.Checked,
                LastUpdated = _lastUpdated
            };
            var retentions = new List<FiscalRetention>();
            foreach (var checkedItem in chklstRetentions.CheckedItems)
            {
                var item = (ListItemDto<Guid>)checkedItem;
                retentions.Add(new FiscalRetention(item.Id));
            }
            profile.Retentions= retentions;
            profile.Save();
            LoadGrid();
        }
        private bool ValidateForm()
        {
            return Validator.RequiredFieldValidator(txtName, epRetentionProfile) &
                                       Validator.RequiredFieldValidator(txtDescription, epRetentionProfile) &
                                       (Validator.RequiredFieldValidator(chklstRetentions, epRetentionProfile) && 
                                       Validator.MaxNumberOfItemsValidator(chklstRetentions, 8, epRetentionProfile));
        }
        private void LoadProfile(Guid id)
        {
            var retention = ClientInvoiceProfile.GetInviceProfile(id);
            if (retention == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                _selectedId = retention.Id;
                txtName.Text = retention.Name;
                txtDescription.Text = retention.Description;
                _lastUpdated = retention.LastUpdated;
                chkIsDefault.Checked = retention.IsDefault;
                MarkSelectedRetentions(retention.Retentions);
                btnDelete.Visible = true;
                btnCancel.Text = Resources.CancelButtonText;
                _isEditMode = true;
            }
        }
        private void MarkSelectedRetentions(IEnumerable<FiscalRetention> retentions)
        {
            LoadRetentions();
            foreach (var retention in retentions)
            {
                foreach (var item in chklstRetentions.Items)
                {
                    var actualItem = (ListItemDto<Guid>)item;
                    if (actualItem.Id == retention.Id)
                    {
                        var index = chklstRetentions.Items.IndexOf(item);
                        chklstRetentions.SetItemCheckState(index, CheckState.Checked);
                        break;
                    }
                }
                
            }
        }
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText, Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var retention = ClientInvoiceProfile.GetInviceProfile(_selectedId);
                retention.Delete();
                LoadGrid();
            }
        }
        #endregion
    }
}
