using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Invoice;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medilab.UserInterface.Invoice
{
    public partial class FrmAditionalItem : Form
    {
        #region Variables
        protected Guid SelectedId { set; get; }
        private bool _isEditing;
        private List<AditionalItem> _items;

        #endregion

        public FrmAditionalItem()
        {
            InitializeComponent();
        }
        #region Events
        private void FrmAditionalItem_Load(object sender, EventArgs e)
        {
            _items = new List<AditionalItem>();
            LoadGrid();
            CleanForm();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                LoadGrid();
            }
            else
            {
                Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid)gvItems[0, e.RowIndex].Value;
            LoadItem(id);
        }
        private void txtcontrol_TextChanged(object sender, EventArgs e)
        {
            _isEditing = true;
            btnCancel.Text = Resources.CancelButtonText;
        }
        private void txtSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void btnNewPractice_Click(object sender, EventArgs e)
        {
            NewPractice();
        }
        #endregion

        #region Methods
        private void NewPractice()
        {
            EnableForm();
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
            txtCode.Text = (BusinessObjects.Configuration.Utilities.MaxCodeNumber() + 1).ToString();
        }
        private void Search()
        {
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                FilterList(txtSearchText.Text.ToLower().Trim());
            }
            else
            {
                gvItems.AutoGenerateColumns = false;
                gvItems.DataSource = _items;
            }
        }
        private void FilterList(string filterText)
        {
            var filteredList =
                (from i in _items where i.Name.ToLower().Contains(filterText) || i.Description.ToLower().Contains(filterText) select i).ToList();
            gvItems.AutoGenerateColumns = false;
            gvItems.DataSource = filteredList;
        }
        private void LoadItem(Guid id)
        {
            var item = AditionalItem.GetAditionalItem(id);
            if (item == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = item.Id;
                txtName.Text = item.Name;
                txtCode.Text = item.Code.ToString();
                txtDescription.Text = item.Description;
                txtPrice.Text = item.Price.ToString("0.00");
                btnDelete.Visible = true;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
                EnableForm();
            }
        }
        private void EnableForm()
        {
            txtName.Enabled = true;
            txtCode.Enabled = true;
            txtDescription.Enabled = true;
            txtPrice.Enabled = true;
            btnNewPractice.Enabled = false;
            btnSave.Enabled = true;
        }
        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            try
            {
                var item = new AditionalItem(SelectedId)
                {
                    Name = txtName.Text,
                    Code = int.Parse(txtCode.Text),
                    Description = txtDescription.Text,
                    Price = double.Parse(txtPrice.Text)
                };
                item.Save();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateForm()
        {
            var isRequiredFieldsValid = Validator.RequiredFieldValidator(txtName, epAditionalItems) &
                Validator.RequiredFieldValidator(txtDescription, epAditionalItems);

            var isCodeValid = Validator.CheckIntType(txtCode, epAditionalItems);
            bool existCode = true;
            if (isCodeValid)
            {
                existCode = BusinessObjects.Configuration.Utilities.ExistCode(int.Parse(txtCode.Text), SelectedId);
                if (existCode)
                {
                    epAditionalItems.SetError(txtCode, Resources.CodeMustBeUnique);
                }
            }
            var priceIsValid = Validator.RequiredFieldValidator(txtPrice, epAditionalItems);
            if (priceIsValid)
            {
                priceIsValid = Validator.CheckDoubleType(txtPrice, epAditionalItems);
                if (priceIsValid)
                {
                    priceIsValid = Validator.GraterThanValidator(double.Parse(txtPrice.Text), 0, txtPrice, epAditionalItems);
                }
            }
            return isRequiredFieldsValid && isCodeValid && !existCode && priceIsValid;
        }
        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                      Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var practice = AditionalItem.GetAditionalItem(SelectedId);
                practice.Delete();
                LoadGrid();
            }
        }
        private void CleanForm()
        {
            SelectedId = Guid.Empty;
            txtName.Text = string.Empty;
            txtName.Enabled = false;
            txtCode.Text = string.Empty;
            txtCode.Enabled = false;
            txtDescription.Text = string.Empty;
            txtDescription.Enabled = false;
            btnDelete.Visible = false;
            epAditionalItems.Clear();
            txtPrice.Text = string.Empty;
            txtPrice.Enabled = false;
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
            btnNewPractice.Enabled = true;
            btnSave.Enabled = false;
        }
        private void LoadGrid()
        {
            CleanForm();
            _items = (List<AditionalItem>) AditionalItem.GetAllAditionalItems();
            gvItems.AutoGenerateColumns = false;
            gvItems.DataSource = _items;
        }
        #endregion
    }
}
