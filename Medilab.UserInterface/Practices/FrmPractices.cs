using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Configuration;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Practices
{
    public partial class FrmPractices : Form
    {
        #region Variables

        protected Guid SelectedId { set; get; }
        private byte[] _lastUpdated;
        private bool _isEditing;
        private List<PracticeDto> _practices;
        #endregion

        public FrmPractices()
        {
            InitializeComponent();
        }

        #region Events

        private void Practices_Load(object sender, EventArgs e)
        {
            _practices = new List<PracticeDto>();
            LoadDropdown();
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

        private void gvPractices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = (Guid) gvPractices[0, e.RowIndex].Value;
            LoadPractice(id);
        }

        private void control_TextChanged(object sender, EventArgs e)
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

        private void LoadGrid()
        {
            CleanForm();
            _practices = (List<PracticeDto>) Practice.GetList();
            gvPractices.AutoGenerateColumns = false;
            gvPractices.DataSource = gvPractices.DataSource = new SortableBindingList<PracticeDto>(_practices); 
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
            cbSpeciality.Text = string.Empty;
            cbSpeciality.Enabled = false;
            cbSpeciality.SelectedItem = null;
            epPractice.Clear();
            txtPrice.Text = string.Empty;
            txtPrice.Enabled = false;
            _isEditing = false;
            btnCancel.Text = Resources.CloseButtonText;
            chkIsExternal.Checked = false;
            chkIsExternal.Enabled = false;
            btnNewPractice.Enabled = true;
            btnSave.Enabled = false;
            txtReportName.Text = string.Empty;
            txtReportName.Enabled = false;
        }

        private void Delete()
        {
            var rta = MessageBox.Show(Resources.QuestionDeleteRecordText,
                                      Resources.ConfirmationDialogDeleteTitle,
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.Yes)
            {
                var practice = Practice.GetPractice(SelectedId);
                practice.Delete();
                LoadGrid();
            }
        }

        private void Save()
        {
            if (!ValidateForm())
            {
                return;
            }
            try
            {
                var practice = new Practice(SelectedId)
                {
                    Name = txtName.Text,
                    Code = int.Parse(txtCode.Text),
                    Description = txtDescription.Text,
                    Speciality = (Speciality)cbSpeciality.SelectedItem,
                    LastUpdated = _lastUpdated,
                    Price = double.Parse(txtPrice.Text),
                    IsExternal = chkIsExternal.Checked,
                    ReportName = txtReportName.Text,
                };
                practice.Save();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            var isRequiredFieldsValid = Validator.RequiredFieldValidator(txtName, epPractice) &
                                        Validator.RequiredFieldValidator(txtReportName, epPractice) &
                                        Validator.CheckNotNullValidator(cbSpeciality, epPractice,
                                                                        cbSpeciality.SelectedItem);

            var isCodeValid = Validator.CheckIntType(txtCode, epPractice);
            bool existCode = true;
            if (isCodeValid)
            {
                existCode = BusinessObjects.Configuration.Utilities.ExistCode(int.Parse(txtCode.Text), SelectedId);
                if (existCode)
                {
                    epPractice.SetError(txtCode, Resources.CodeMustBeUnique);
                }
            }
            var priceIsValid = Validator.RequiredFieldValidator(txtPrice, epPractice);
            if (priceIsValid)
            {
                priceIsValid = Validator.CheckDoubleType(txtPrice, epPractice);
                if (priceIsValid)
                {
                    priceIsValid = Validator.GraterThanValidator(double.Parse(txtPrice.Text), 0, txtPrice, epPractice);
                }
            }
            return isRequiredFieldsValid && isCodeValid && !existCode && priceIsValid;
        }

        private void LoadPractice(Guid id)
        {
            var practice = Practice.GetPractice(id);
            if (practice == null)
            {
                MessageBox.Show(Resources.RecordNotFoundErrorText, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
            else
            {
                SelectedId = practice.Id;
                txtName.Text = practice.Name;
                txtCode.Text = practice.Code.ToString();
                txtDescription.Text = practice.Description;
                txtPrice.Text = practice.Price.ToString("0.00");
                chkIsExternal.Checked = practice.IsExternal;
                txtReportName.Text = practice.ReportName;
                foreach (var item in cbSpeciality.Items)
                {
                    var spec = (Speciality) item;
                    if (spec.Id == practice.Speciality.Id)
                    {
                        cbSpeciality.SelectedItem = item;
                        break;
                    }
                }
                _lastUpdated = practice.LastUpdated;
                btnDelete.Visible = true;
                _isEditing = true;
                btnCancel.Text = Resources.CancelButtonText;
                EnableForm();
            }
        }
        private void LoadDropdown()
        {
            cbSpeciality.Items.Clear();
            var specialities = BusinessObjects.Configuration.Speciality.GetList();
            var specialitiesForFilter = specialities.ToList();

            cbSpeciality.DataSource = specialities;
            cbSpeciality.DisplayMember = "Name";

            //Speciality filter
            cbSpecialityFilter.Items.Clear();
            //BusinessObjects.Configuration.Speciality.GetList().ToList();
            specialitiesForFilter.Insert(0, new BusinessObjects.Configuration.Speciality(Guid.Empty)
            {
                Name = "Todas",
                Description = "Todas"
            });
            cbSpecialityFilter.DataSource = specialitiesForFilter;
            cbSpecialityFilter.DisplayMember = "Name";
        }

        private void FilterList(string filterText)
        {
            var speciality = (Speciality)cbSpecialityFilter.SelectedItem;
            IEnumerable<PracticeDto> query;
            var filteredList = new List<PracticeDto>();
            if (string.IsNullOrWhiteSpace(filterText) && speciality.Id != Guid.Empty)
            {
                query = (from p in _practices where p.SpecialityId == speciality.Id select p);
            }
            else
            {
                query = (from p in _practices
                         where p.Name.ToLower().Contains(filterText) ||
                             p.Description.ToLower().Contains(filterText) ||
                             p.Code.ToString().Contains(filterText)
                         select p);

                if (speciality.Id != Guid.Empty)
                {
                    query = (from p in query where p.SpecialityId == speciality.Id select p);
                }
            }
            filteredList = query.ToList();
            gvPractices.AutoGenerateColumns = false;
            gvPractices.DataSource = new SortableBindingList<PracticeDto>(filteredList);
        }
        private void EnableForm()
        {
            txtName.Enabled = true;
            txtCode.Enabled = true;
            txtDescription.Enabled = true;
            cbSpeciality.Enabled = true;
            txtPrice.Enabled = true;
            chkIsExternal.Enabled = true;
            btnNewPractice.Enabled = false;
            btnSave.Enabled = true;
            txtReportName.Enabled = true;
        }
        private void NewPractice()
        {
            EnableForm();
            btnCancel.Text = Resources.CancelButtonText;
            _isEditing = true;
            txtCode.Text = (BusinessObjects.Configuration.Utilities.MaxCodeNumber() + 1).ToString();
        }
        private void Search()
        {
            var speciality = (Speciality)cbSpecialityFilter.SelectedItem;
            if (!string.IsNullOrEmpty(txtSearchText.Text) | speciality.Id != Guid.Empty)
            {
                FilterList(txtSearchText.Text.ToLower().Trim());
            }
            else
            {
                gvPractices.AutoGenerateColumns = false;
                gvPractices.DataSource = new SortableBindingList<PracticeDto>(_practices);
            }
        }

        #endregion        
    }
}
