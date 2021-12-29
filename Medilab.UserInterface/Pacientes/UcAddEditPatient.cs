using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Patient;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using Medilab.UserInterface.Utils;
using System.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.UserInterface.Properties;

namespace Medilab.UserInterface.Pacientes
{
    public partial class UcAddEditPatient : UserControl
    {
        #region Properties

        private Guid _selectedId;
        private byte[] _lastUpdated;
        public string NewCreatedPhotoName {get; set;}
        public string ImageLocation
        {
            get { return pbPhoto.ImageLocation; }
            set { pbPhoto.ImageLocation = value; }
        }
        public Patient SavedPatient { get; private set; }

        #endregion

        public UcAddEditPatient(Guid patientId)
        {
            _selectedId = patientId;
            InitializeComponent();
        }

        #region Events

        // ReSharper disable InconsistentNaming
        private void btnDetails_Click(object sender, EventArgs e)
        {
            //var h = Height > 90 ? 90 : 450;
            //Height = h;
        }

        private void UcAddEditPatient_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;
            LoadDropdowns();
            txtNationality.Text = @"Argentino";
            if(_selectedId != Guid.Empty)
            {
                var patient = Patient.GetPatient(_selectedId);
                LoadPatient(patient);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePatient();
        }

        private void txtDocumentNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var documentType = (DocumentType)((ListItemDto<int>)cbDocumentType.SelectedItem).Id;
            try
            {
                var patient = Patient.GetPatient(documentType, txtDocumentNumber.Text);
                LoadPatient(patient);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Paciente no encontrado", @"Paciente no encontrado", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
        }

        private void dtpBirthDate_Leave(object sender, EventArgs e)
        {
            txtAge.Text = UiUtils.GetAge(dtpBirthDate.Value).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HandleCancelButtonPressed(this, new EventArgs());
        }
        // ReSharper restore InconsistentNaming
        #endregion

        #region Methods
        private void LoadDropdowns()
        {
            //Docuemt types
            cbDocumentType.Items.Clear();
            var documentTypes = EnumUtils.GetDocumentTypeNames();
            var dni = documentTypes.Where(d=>d.Value == "DNI").First();
            cbDocumentType.DataSource = documentTypes;
            cbDocumentType.DisplayMember = "Value";
            cbDocumentType.SelectedItem = cbDocumentType.Items[cbDocumentType.Items.IndexOf(dni)];
            //Birth place
            cbBirthState.Items.Clear();
            var birthStates = State.GetList().ToArray();
            var birthStateDefault = birthStates.Where(s => s.Name == "Mendoza").First();
            cbBirthState.DataSource = birthStates;
            cbBirthState.DisplayMember = "Name";
            cbBirthState.SelectedItem = cbBirthState.Items[cbBirthState.Items.IndexOf(birthStateDefault)];
            //Private Medicine
            cbPrivateMedicine.Items.Clear();
            var privateMedicineList = PrivateMedicineCompany.GetPrivateMedicineCompanyList();
            cbPrivateMedicine.DataSource = privateMedicineList;
            cbPrivateMedicine.DisplayMember = "Name";
            cbPrivateMedicine.SelectedItem = null;
            //Work Risk Insurance
            cbRiskInsurance.Items.Clear();
            var workRiskInsurance = WorkRiskInsurance.GetWorkRiskInsuranceList();
            cbRiskInsurance.DataSource = workRiskInsurance;
            cbRiskInsurance.DisplayMember = "Name";
            cbRiskInsurance.SelectedItem = null;
        }

        private void SavePatient()
        {
            if (!ValidateForm()) return;
            //Get Gender, Civil State, Instruction
            var selectedGender =
                // ReSharper disable PossibleNullReferenceException
                gbGender.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
            var selectedCivilState =
                gbCivilState.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
            var selectedInstruction =
                gbInstruction.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
            // ReSharper restore PossibleNullReferenceException
            var birthPlace = (State) cbBirthState.SelectedItem;
            var documentType = (ListItemDto<int>)cbDocumentType.SelectedItem;
            var patient = new Patient(_selectedId)
                              {
                                  DocumentType = (DocumentType)documentType.Id,
                                  DocumentNumber = txtDocumentNumber.Text,
                                  LastName = txtLastName.Text,
                                  FirstName = txtFirstName.Text,
                                  BirthDay = dtpBirthDate.Value,
                                  BirthPlace = birthPlace,
                                  Gender = (Gender)Enum.Parse(typeof(Gender), selectedGender),
                                  ChildrenNumber =
                                      string.IsNullOrEmpty(txtChildrenNumber.Text)
                                          ? 0
                                          : int.Parse(txtChildrenNumber.Text),
                                  CivilState = (CivilState)Enum.Parse(typeof(CivilState), selectedCivilState),
                                  InstructionLevel =
                                      (Instruction)Enum.Parse(typeof(Instruction), selectedInstruction),
                                  InstructionTitle = txtInstructionTitle.Text,
                                  HomePhone = txtHomePhone.Text,
                                  CellPhone = txtCellPhone.Text,
                                  Observations = txtObservations.Text,
                                  LastUpdated = _lastUpdated,
                                  Photo = !string.IsNullOrEmpty(pbPhoto.ImageLocation) || !string.IsNullOrEmpty(NewCreatedPhotoName) ? string.Concat(txtDocumentNumber.Text, ".jpg") : string.Empty,
                                  AffiliateNumber = txtPrivateMedicineNumber.Text,
                                  Nationality = txtNationality.Text
                              };
            if (!string.IsNullOrEmpty(NewCreatedPhotoName))
            {
                string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    path = Directory.GetParent(path).FullName;
                }
                var filePath = path + ConfigurationManager.AppSettings["filePhotoPath"];
                FileDirectoryHandler.CopyFile(Path.Combine(filePath, NewCreatedPhotoName),
                    ConfigurationManager.AppSettings["filePhotoServerPath"], string.Concat(txtDocumentNumber.Text, ".jpg"));
                FileDirectoryHandler.DeleteFile(ConfigurationManager.AppSettings["filePhotoPath"], NewCreatedPhotoName);
            }
            if (cbPrivateMedicine.SelectedItem != null)
            {
                var privateMedecine = (PrivateMedicineCompany) cbPrivateMedicine.SelectedItem;
                patient.PrivateMedicine = privateMedecine;
            }

            if (cbRiskInsurance.SelectedItem != null)
            {
                var workRiskInsurance = (WorkRiskInsurance)cbRiskInsurance.SelectedItem;
                patient.RiskInsurance = workRiskInsurance;
            }
            patient.Addresses = patientAddress.GetAddress();
            patient = patient.Save();
            _selectedId = patient.Id;
            SavedPatient = patient;
            MessageBox.Show(@"Registro guardado", @"Registro guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HandleSaveButtonPressed(this, new EventArgs());
        }

        private bool ValidateForm()
        {
            var isPatientValid = Validator.RequiredFieldValidator(txtDocumentNumber, patientErrorProvider) &
                   Validator.RequiredFieldValidator(txtFirstName, patientErrorProvider) &
                   Validator.RequiredFieldValidator(txtLastName, patientErrorProvider) &
                   patientAddress.IsValid;
            var birthPlace = (State)cbBirthState.SelectedItem;
            if(birthPlace == null)
            {
                patientErrorProvider.SetError(cbBirthState, Resources.SelectAtLeastOneState);
                isPatientValid = false;
            }
            else
            {
                patientErrorProvider.SetError(cbBirthState, string.Empty);
            }
            return isPatientValid;
        }

        private void LoadPatient(Patient patient)
        {
            _selectedId = patient.Id;
            txtLastName.Text = patient.LastName;
            txtFirstName.Text = patient.FirstName;
            dtpBirthDate.Value = patient.BirthDay;
            txtDocumentNumber.Text = patient.DocumentNumber;
            if (FileDirectoryHandler.CheckIfDirectoryExist(ConfigurationManager.AppSettings["filePhotoServerPath"]))
            {
                pbPhoto.ImageLocation = Path.Combine(ConfigurationManager.AppSettings["filePhotoServerPath"], patient.Photo);
            }
            else
            {
                pbPhoto.ImageLocation = string.Empty;
            }
            foreach (var item in cbBirthState.Items)
            {
                var state = (State) item;
                if (state.Id == patient.BirthPlace.Id)
                {
                    cbBirthState.SelectedItem = item;
                    break;
                }
            }
            //Sex
            switch (patient.Gender)
            {
                case Gender.Male:
                    rbMale.Checked = true;
                    break;
                case Gender.Female:
                    rbFemale.Checked = true;
                    break;
                default:
                    rbMale.Checked = true;
                    break;
            }
            txtChildrenNumber.Text = patient.ChildrenNumber > 0 ? patient.ChildrenNumber.ToString() : string.Empty;
            //Civil state
            switch (patient.CivilState)
            {
                case CivilState.Soltero:
                    rbSingle.Checked = true;
                    break;
                case CivilState.Casado:
                    rbMarried.Checked = true;
                    break;
                case CivilState.Divorciado:
                    rbDivorced.Checked = true;
                    break;
                case CivilState.Viudo:
                    rbWidowed.Checked = true;
                    break;
                default:
                    rbSingle.Checked = true;
                    break;
            }
            //Instruction level
            switch (patient.InstructionLevel)
            {
                case Instruction.Primario:
                    rbPrimary.Checked = true;
                    break;
                case Instruction.Secundario:
                    rbSecondary.Checked = true;
                    break;
                case Instruction.Terciario:
                    rbTertiary.Checked = true;
                    break;
                case Instruction.Universitario:
                    rbUniversity.Checked = true;
                    break;
                default:
                    rbPrimary.Checked = true;
                    break;
            }
            txtInstructionTitle.Text = patient.InstructionTitle;
            txtHomePhone.Text = patient.HomePhone;
            txtCellPhone.Text = patient.CellPhone;
            txtObservations.Text = patient.Observations;
            txtAge.Text = UiUtils.GetAge(patient.BirthDay).ToString();
            //Address
            patientAddress.LoadAddress(patient.Addresses);
            patientAddress.OwnerId = patient.Id;
            //Private Medicine
            if (patient.PrivateMedicine != null)
            {
                foreach (var item in cbPrivateMedicine.Items)
                {
                    var privateMedicine = (PrivateMedicineCompany)item;
                    if (privateMedicine.Id == patient.PrivateMedicine.Id)
                    {
                        cbPrivateMedicine.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                cbPrivateMedicine.SelectedItem = null;
            }
            txtPrivateMedicineNumber.Text = patient.AffiliateNumber;
            txtNationality.Text = patient.Nationality;
            //Work Risk Insurance
            if (patient.RiskInsurance != null)
            {
                foreach (var item in cbRiskInsurance.Items)
                {
                    var workRiskInsurance = (WorkRiskInsurance)item;
                    if (workRiskInsurance.Id == patient.RiskInsurance.Id)
                    {
                        cbRiskInsurance.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                cbRiskInsurance.SelectedItem = null;
            }
            _lastUpdated = patient.LastUpdated;
        }
        #endregion

        #region Custom Events
        public event EventHandler CancelButtonPressed;
        public event EventHandler SaveButtonPressed;

        private void HandleCancelButtonPressed(object sender, EventArgs e)
        {
            OnCancelButtonPressed(EventArgs.Empty);
        }

        private void HandleSaveButtonPressed(object sender, EventArgs e)
        {
            OnSaveButtonPressed(EventArgs.Empty);
        }

        protected virtual void OnCancelButtonPressed(EventArgs e)
        {
            EventHandler handler = CancelButtonPressed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSaveButtonPressed(EventArgs e)
        {
            EventHandler handler = SaveButtonPressed;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }
}
