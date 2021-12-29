using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Patient;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Excel;
using Medilab.UserInterface.Pacientes;
using Medilab.UserInterface.Practices;
using Medilab.UserInterface.PrintUtilities;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using Medilab.UserInterface.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.ClinicalHistory
{
    public partial class FrmAddClinicalHistory : Form
    {
        #region Properties

        private ClinicalHistoryStatus _clinicalHistoryStatus = ClinicalHistoryStatus.Incompleta;
        private Patient _patient;
        private Client _client;
        private ClientArea _clientArea;
        private Guid _clinicalHistoryId;
        private ClinicaHistoryResult _clinicaHistoryResult;
        private byte[] _clinicalHistoryLastUpdate;
        private BindingList<MedicalHistoryPracticeDto> _practices;
        private BindingList<PracticeListDto> _practiceList;
        private List<Guid> _originalPracticeIdList;
        private Dictionary<Guid, Guid> _removePraciceIdList;
        private BindingSource _data;
        private readonly string _companyExcelFormat = CompanyInfo.GetCompanyExcelFormat();
        private string _resultObservations = string.Empty;
        private string _receptionUser;

        #endregion

        #region Events

        // ReSharper disable InconsistentNaming
        private void txtDocumentNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            GetPatient();
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cbCompany.DataSource != null)
                {
                    var client = (ListItemDto<Guid>) cbCompany.SelectedItem;
                    if (cbChargeToClient.SelectedItem != null)
                    {
                        if (((ListItemDto<Guid>)cbChargeToClient.SelectedItem).Id == Guid.Empty)
                        {
                            foreach (var item in cbChargeToClient.Items)
                            {
                                if (((ListItemDto<Guid>)item).Id == client.Id)
                                {
                                    cbChargeToClient.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    }
                    LoadClientDetails(client.Id);
                }
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            AddEditPatient();
            GetPatient();
        }

        private void FrmAddClinicalHistory_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentDate.Text))
            {
                txtCurrentDate.Text = DateTime.Today.ToShortDateString();
            }
            LoadDropdowns();
            btnEditPatient.Visible = false;
            _originalPracticeIdList = new List<Guid>();
            _removePraciceIdList = new Dictionary<Guid, Guid>();
            _practiceList = new BindingList<PracticeListDto>();
            _data = new BindingSource { DataSource = _practiceList };
            gvPractices.AutoGenerateColumns = false;
            gvPractices.DataSource = _data;
            if (_clinicalHistoryId != Guid.Empty)
            {
                MedicalHistory medicalHistory = MedicalHistory.GetMedicalHistory(_clinicalHistoryId);
                LoadMedicalHistory(medicalHistory);
                btnEditPatient.Visible = true;
            }
            cbPracticeName.Text = string.Empty;
        }

        private void txtDocumentNumber_Leave(object sender, EventArgs e)
        {
            if (_patient == null || (_patient.DocumentNumber != txtDocumentNumber.Text))
            {
                GetPatient();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveClinicalExam_Click(object sender, EventArgs e)
        {
            if (!IsClinicalHistoryValid()) return;
            SaveMedicalHistory();
            CloseForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_companyExcelFormat.Equals("Labomed"))
            {
                LaboMedExcelnHandler.GenerateExcel(_clinicalHistoryId, string.Concat(ConfigurationManager.AppSettings["ExcelPathTemplates"], ConfigurationManager.AppSettings["ComplementaryPractices"]), _companyExcelFormat);
            }
        }

        private void btnPrintPartial_Click(object sender, EventArgs e)
        {
            MedicalExamUtils.PrintAffidavit(_clinicalHistoryId);
        }

        private void txtPracticeCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int code = 0;
                if (int.TryParse(txtPracticeCode.Text, out code))
                {
                    GetPractices(code);
                }
            }
        }

        private void gvPractices_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            var id = Guid.Parse(gvPractices.SelectedRows[0].Cells[0].Value.ToString());
            foreach (var practice in _practiceList)
            {
                if (practice.Id != id) continue;
                var groupId = Guid.Empty;
                if (practice.IsGroup)
                {
                    groupId = id;
                }
                MarkForRemove(id, groupId);
                _practiceList.Remove(practice);
                _data.ResetBindings(false);
                return;
            }
        }

        private void gvPractices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var practice = (PracticeListDto)gvPractices.SelectedRows[0].DataBoundItem;
            if (practice.IsGroup)
            {
                practice.MedicalHistoryId = _clinicalHistoryId;
                var frmGroupPractices = new FrmGroupPractices(practice) { StartPosition = FormStartPosition.CenterScreen };
                frmGroupPractices.ShowDialog();
                frmGroupPractices.Dispose();
            }
        }

        private void cbPracticeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPractice = (ListItemDto<Guid>)cbPracticeName.SelectedItem;
            GetPractices(selectedPractice.Id);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frmSearchPractices = new FrmSearchPractices(string.Empty);
            frmSearchPractices.ShowDialog();
            var practice = frmSearchPractices.SelectedPractice;
            if (practice != null)
            {
                _practiceList.Add(new PracticeListDto
                {
                    Id = practice.Id,
                    Code = practice.Code,
                    Name = practice.Name,
                    Description = practice.Description,
                    Status = ClinicalExamStatus.Incompleto,
                    MedicalHistoryId = _clinicalHistoryId
                });
                _data.ResetBindings(false);
                cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
            }
        }

        private void cbClienArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var area = (ClientArea)cbClienArea.SelectedItem;
            if (area == null) return;
            _clientArea = area.Id != Guid.Empty ? area : null;
        }

        private void btnUpdateCompaniesDropdown_Click(object sender, EventArgs e)
        {
            LoadClientDropDowns();
        }

        private void cbExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExamType.SelectedItem.ToString() == ExamType.Otros.ToString())
            {
                txtAnotherTypeDescription.Enabled = true;
            }
            else
            {
                txtAnotherTypeDescription.Text = string.Empty;
                txtAnotherTypeDescription.Enabled = false;
            }
        }
        #endregion

        #region Methods

        public FrmAddClinicalHistory()
        {
            InitializeComponent();
            btnPrint.Enabled = false;
            btnPrintPartial.Enabled = false;
        }

        public FrmAddClinicalHistory(Guid clinicalHistoryId)
        {
            _clinicalHistoryId = clinicalHistoryId;
            InitializeComponent();
            if (_companyExcelFormat != Resources.NotAvailable)
            {
                if (_companyExcelFormat.Equals("Asismed"))
                {
                    btnPrintPartial.Visible = false;
                }
            }
            else
            {
                btnPrint.Enabled = false;
                btnPrintPartial.Enabled = false;
            }
            MedicalHistory clinicHistory = null;
            if (clinicalHistoryId != Guid.Empty)
            {
                clinicHistory = MedicalHistory.GetMedicalHistory(clinicalHistoryId);
            }
            if (clinicHistory == null || clinicHistory.MedicalExam == null)
            {
                btnPrint.Enabled = false;
                btnPrintPartial.Enabled = false;
            }
        }

        private void LoadDropdowns()
        {
            //Docuemt types
            cbDocumentType.Items.Clear();
            cbDocumentType.Items.AddRange(Enum.GetNames(typeof(DocumentType)));
            cbDocumentType.Text = DocumentType.DNI.ToString();
            //Exam Type
            cbExamType.Items.Clear();
            var examTypeNames = EnumUtils.GetDisplayNames(Enum.GetNames(typeof(ExamType))).ToArray();
            cbExamType.Items.AddRange(examTypeNames);
            cbExamType.Text = EnumUtils.AddSpaceInCapitalLetter(ExamType.PreIngreso.ToString());

            LoadClientDropDowns();

            //Practices & Groups
            cbPracticeName.Items.Clear();
            var practices = Practice.GetDisplayList();
            var groups = Group.GetDisplayList();
            var names = new List<ListItemDto<Guid>>();
            foreach (var practice in practices)
            {
                names.Add(new ListItemDto<Guid>
                              {
                                  Id = practice.Id,
                                  Value = practice.Value
                              });
            }
            foreach (var group in groups)
            {
                names.Add(new ListItemDto<Guid>
                              {
                                  Id = group.Id,
                                  Value = group.Value
                              });
            }
            cbPracticeName.DataSource = names;
            cbPracticeName.DisplayMember = "Value";
            cbPracticeName.Text = string.Empty;
        }

        private void LoadClientDropDowns()
        {
            //Clients
            cbCompany.DataSource = null;
            var companies = Client.GetClients().ToList();
            var companiesToBill = new List<ListItemDto<Guid>>();

            foreach (var item in companies)
            {
                companiesToBill.Add(new ListItemDto<Guid>
                {
                    Id = item.Id,
                    Value = item.Value
                });
            }
            if (companies.Count > 0)
            {

                companies.Insert(0, new ListItemDto<Guid> { Id = Guid.Empty, Value = string.Empty });
                cbCompany.DataSource = companies;
                cbCompany.DisplayMember = "Value";
                cbCompany.Text = string.Empty;

                companiesToBill.Insert(0, new ListItemDto<Guid> { Id = Guid.Empty, Value = string.Empty });
                cbChargeToClient.DataSource = companiesToBill;
                cbChargeToClient.DisplayMember = "Value";
                cbChargeToClient.Text = string.Empty;
            }
        }

        private void LoadPatient(Patient patient)
        {
            _patient = patient;
            txtLastName.Text = patient.LastName;
            txtFirstName.Text = patient.FirstName;
            cbDocumentType.Text = EnumUtils.AddSpaceInCapitalLetter(patient.DocumentType.ToString());
            if (patient.Id != Guid.Empty)
            {
                btnEditPatient.Visible = true;
                txtPatientBirthDay.Text = patient.BirthDay.ToShortDateString();
                txtAge.Text = UiUtils.GetAge(patient.BirthDay).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                btnEditPatient.Visible = false;
                txtPatientBirthDay.Text = string.Empty;
                txtAge.Text = string.Empty;
            }
            txtDocumentNumber.Text = patient.DocumentNumber;
            if (FileDirectoryHandler.CheckIfDirectoryExist(ConfigurationManager.AppSettings["filePhotoServerPath"]))
            {
                if (!string.IsNullOrEmpty(patient.Photo))
                {
                    pbPhoto.ImageLocation = Path.Combine(ConfigurationManager.AppSettings["filePhotoServerPath"],
                                                         patient.Photo);
                }
            }
            else
            {
                pbPhoto.ImageLocation = string.Empty;
            }
        }

        private void LoadClientDetails(Guid clientId)
        {
            if (clientId != Guid.Empty)
            {
                _client = Client.GetClient(clientId);
                var clientAddress = _client.Addresses.FirstOrDefault(c => c.IsDefault);
                if (clientAddress != null)
                {
                    txtCompanyAddress.Text = clientAddress.StreetLineOne;
                    if (!string.IsNullOrEmpty(clientAddress.Number))
                    {
                        txtCompanyAddress.Text += @", " + clientAddress.Number;
                    }
                }
                txtCompanyPhone.Text = _client.PhoneNumber ?? _client.PhoneNumber;
                txtCompanyCuit.Text = _client.Cuit;
                var areas = ClientArea.GetAreasByClient(_client.Id).ToList();
                if (areas.Any())
                {
                    areas.Insert(0, new ClientArea(Guid.Empty));
                    cbClienArea.Enabled = true;
                    cbClienArea.DataSource = areas;
                    cbClienArea.DisplayMember = "Name";
                    cbClienArea.Text = string.Empty;
                }
                else
                {
                    cbClienArea.DataSource = null;
                    cbClienArea.Enabled = false;
                }
            }
            else
            {
                txtCompanyAddress.Text = string.Empty;
                txtCompanyPhone.Text = string.Empty;
                txtCompanyCuit.Text = string.Empty;
                cbClienArea.DataSource = null;
                cbClienArea.Enabled = false;
            }
        }

        private void GetPatient()
        {
            var documentType = (DocumentType)Enum.Parse(typeof(DocumentType), cbDocumentType.Text);
            try
            {
                var patient = Patient.GetPatient(documentType, txtDocumentNumber.Text);
                LoadPatient(patient);
            }
            catch (Exception)
            {
                btnEditPatient.Visible = false;
                _patient = new Patient(Guid.Empty);
                AddEditPatient();
            }
        }

        private void AddEditPatient()
        {
            var frmPatientDetails = new FrmAddEditPatient(_patient.Id);
            frmPatientDetails.ShowDialog();
            if (frmPatientDetails.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            var patient = frmPatientDetails.UcPatient.SavedPatient;
            LoadPatient(patient ?? new Patient(Guid.Empty));
        }

        private bool IsClinicalHistoryValid()
        {
            return (Validator.RequiredFieldValidator(txtDocumentNumber, epClinicalHistory) &&
                    Validator.CheckNotNullValidator(txtDocumentNumber, epClinicalHistory, _patient)) &
                   (Validator.RequiredFieldValidator(cbCompany, epClinicalHistory) &&
                    Validator.CheckNotNullValidator(cbCompany, epClinicalHistory, _client));
        }

        private void LoadMedicalHistory(MedicalHistory medicalHistory)
        {
            _clinicalHistoryId = medicalHistory.Id;
            _clinicalHistoryLastUpdate = medicalHistory.LastUpdated;
            _clinicaHistoryResult = medicalHistory.Result;
            _clinicalHistoryStatus = medicalHistory.Status;
            chkIsHighPriority.Checked = medicalHistory.IsHighPriority;
            txtCurrentDate.Text = medicalHistory.CreatedDate.ToShortDateString();
            cbExamType.Text = EnumUtils.AddSpaceInCapitalLetter(medicalHistory.TypeOfExam.ToString());
            txtAnotherTypeDescription.Text = medicalHistory.AnotherTypeDescription;
            LoadPatient(medicalHistory.Patient);
            _receptionUser = medicalHistory.ReceptionUserName;
          
            foreach (var item in cbCompany.Items)
            {
                var company = (ListItemDto<Guid>)item;
                if (company.Id != medicalHistory.Client.Id) continue;
                cbCompany.SelectedItem = item;
                break;
            }
            if (medicalHistory.ChargeToClient != null)
            {
                foreach (var item in cbChargeToClient.Items)
                {
                    var company = (ListItemDto<Guid>)item;
                    if (company.Id != medicalHistory.ChargeToClient) continue;
                    cbChargeToClient.SelectedItem = item;
                    break;
                }
            }
            foreach (var item in cbClienArea.Items)
            {
                if (medicalHistory.Area != null)                
                    {
                        var area = (ClientArea) item;
                        if (area.Id != medicalHistory.Area.Id) continue;
                        cbClienArea.SelectedItem = item;
                        break;
                    }
            }
            lblReceptionUser.Text = _receptionUser;
            txtWorkArea.Text = medicalHistory.WorkArea;
            txtTaskToDo.Text = medicalHistory.TaskToDo;
            txtObservations.Text = medicalHistory.ClinicalHistoryObservations;
            _resultObservations = medicalHistory.ResultObservations;
            //Load Practices
            LoadPracticesAndGroups(medicalHistory.Practices.ToList(), medicalHistory.PracticeDisplayList.ToList());
        }

        private void LoadPracticesAndGroups(IEnumerable<MedicalHistoryPractice> practices, IEnumerable<MedicalHistoryPracticeDto> practiceDisplayList)
        {
            var lastGroupId = Guid.Empty;
            foreach (var practiceDto in practiceDisplayList.OrderBy(p => p.GroupId))
            {
                if (practiceDto.GroupId == null)
                {
                    var practice = new PracticeListDto
                                          {
                                              Id = practiceDto.MedicalPracticeId,
                                              Code = practiceDto.Code,
                                              Name = practiceDto.Name,
                                              Description = practiceDto.Description,
                                              IsGroup = false,
                                              Status = practiceDto.Status,
                                              MedicalHistoryId = practiceDto.ClinicalHistoryId
                                          };
                    _practiceList.Add(practice);
                    _originalPracticeIdList.Add(practice.Id);
                }
                else
                {
                    if (practiceDto.GroupId.Value != lastGroupId)
                    {
                        lastGroupId = practiceDto.GroupId.Value;
                        var group = Group.GetGroup(practiceDto.GroupId.Value);
                        var practice = new PracticeListDto
                                              {
                                                  Id = group.Id,
                                                  Code = group.Code,
                                                  Name = group.Name,
                                                  Description = group.Description,
                                                  IsGroup = true
                                              };
                        _practiceList.Add(practice);
                        _originalPracticeIdList.Add(practice.Id);
                    }
                }
            }
            //Update status for Groups
            foreach (var practiceListDto in _practiceList)
            {
                if (practiceListDto.IsGroup)
                {
                    var medicalHistoryPractices = practices as List<MedicalHistoryPractice> ?? practices.ToList();
                    var practicesInGroup = (from p in medicalHistoryPractices where p.GroupId == practiceListDto.Id select p).ToList();
                    if (practicesInGroup.Any(p => p.Status == ClinicalExamStatus.Incompleto))
                    {
                        practiceListDto.Status = ClinicalExamStatus.Incompleto;
                        continue;
                    }
                    if (practicesInGroup.Any(p => p.Status == ClinicalExamStatus.Realizada))
                    {
                        practiceListDto.Status = ClinicalExamStatus.Realizada;
                        continue;
                    }
                    practiceListDto.Status = ClinicalExamStatus.Completa;
                }
            }
        }

        private void SaveMedicalHistory()
        {
            MedicalHistory clinicalHistory;
            MainWindow frmMainWindow = new MainWindow();
           
            frmMainWindow = FormHandler.GetInstance<MainWindow>(this);
            clinicalHistory = new MedicalHistory(_clinicalHistoryId)
            {
                Patient = _patient,
                Client = _client,
                Area = _clientArea,
                ClinicalHistoryObservations = txtObservations.Text,
                Status = _clinicalHistoryStatus,
                TaskToDo = txtTaskToDo.Text,
                WorkArea = txtWorkArea.Text,
                IsHighPriority = chkIsHighPriority.Checked,
                TypeOfExam =
                    (ExamType)
                    Enum.Parse(typeof(ExamType),
                                cbExamType.Text.Replace(" ", string.Empty)),
                Result = _clinicaHistoryResult,
                LastUpdated = _clinicalHistoryLastUpdate,
                PracticeDisplayList = _practices,
                ResultObservations = _resultObservations,
                AnotherTypeDescription = txtAnotherTypeDescription.Text,
                ChargeToClient = cbChargeToClient.SelectedIndex > 0 ? ((ListItemDto<Guid>)cbChargeToClient.SelectedItem).Id : _client.Id
            };
          
            GetPracticesForSave();
            

            var practices = _practices.Select(p => new MedicalHistoryPractice(p.Id)
                                                       {
                                                           MedicalHistoryId = p.ClinicalHistoryId,
                                                           MedicalPracticeId = p.MedicalPracticeId,
                                                           Status = p.Status,
                                                           GroupId = p.GroupId,
                                                           IsNew = false,
                                                           MarkForDetele = false
                                                       }).ToList();
            if (practices.Count > 0)
            {
                foreach (var medicalHistoryPractice in practices)
                {
                    var practiceId = medicalHistoryPractice.MedicalPracticeId;
                    var groupId = medicalHistoryPractice.GroupId.HasValue ? medicalHistoryPractice.GroupId.Value : Guid.Empty;
                    if (_originalPracticeIdList.Contains(groupId))
                    {
                        medicalHistoryPractice.IsNew = false;
                    }
                    else if (!_originalPracticeIdList.Contains(practiceId))
                    {
                        medicalHistoryPractice.IsNew = true;
                    }
                    clinicalHistory.Practices.Add(medicalHistoryPractice);
                }
            }

            if (_removePraciceIdList.Count > 0)
            {
                foreach (var item in _removePraciceIdList)
                {
                    if (_originalPracticeIdList.Contains(item.Key))
                    {
                        Guid? groupId = null;
                        if (item.Value != Guid.Empty)
                        {
                            groupId = item.Value;
                        }
                        clinicalHistory.Practices.Add(new MedicalHistoryPractice()
                        {
                            MedicalHistoryId = _clinicalHistoryId,
                            MedicalPracticeId = item.Key,
                            IsNew = false,
                            GroupId = groupId,
                            MarkForDetele = true
                        });
                    }
                }
            }

            var savedClinicalHistory = clinicalHistory.Save();
            _clinicalHistoryId = savedClinicalHistory.Id;
            _clinicalHistoryLastUpdate = savedClinicalHistory.LastUpdated;
        }

        private void CloseForm()
        {
            MessageBox.Show(Resources.ClinicalHistorySaved, Resources.ClinicalHistorySaved, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void GetPractices(int code)
        {
            if (_practiceList == null || _practiceList.Any(item => item.Code == code))
            {
                cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
                return;
            }
            var practice = Practice.GetPractice(code);
            if (practice != null && CheckPracticeInGroups(code))
            {
                _practiceList.Add(new PracticeListDto
                                      {
                                          MedicalHistoryId = _clinicalHistoryId,
                                          Id = practice.Id,
                                          Code = practice.Code,
                                          Name = practice.Name,
                                          Description = practice.Description,
                                          Status = ClinicalExamStatus.Incompleto,
                                          IsGroup = false
                                      });
                _data.ResetBindings(false);
                cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
            }
            else
            {
                var practiceGroup = Group.GetGroup(code);
                if (practiceGroup != null)
                {
                    RemoveIncludedPractices(practiceGroup.Practices.ToList());
                    _practiceList.Add(new PracticeListDto
                                          {
                                              MedicalHistoryId = _clinicalHistoryId,
                                              Id = practiceGroup.Id,
                                              Code = practiceGroup.Code,
                                              Name = practiceGroup.Name,
                                              Description = practiceGroup.Description,
                                              Status = ClinicalExamStatus.Incompleto,
                                              IsGroup = true
                                          });
                    _data.ResetBindings(false);
                    cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
                }
            }
        }

        private void GetPracticesForSave()
        {
            _practices = new BindingList<MedicalHistoryPracticeDto>();
            foreach (var item in _practiceList)
            {
                if (item.IsGroup)
                {
                    var practiceGroup = Group.GetGroup(item.Id);
                    foreach (var practice in practiceGroup.Practices)
                    {
                        var currentPractice =
                            (from p in _practices where p.Code == practice.Code select p).FirstOrDefault();
                        if (currentPractice != null)
                        {
                            _practices[_practices.IndexOf(currentPractice)].GroupId = practiceGroup.Id;
                        }
                        else
                        {
                            _practices.Add(new MedicalHistoryPracticeDto
                            {
                                ClinicalHistoryId = _clinicalHistoryId,
                                MedicalPracticeId = practice.Id,
                                Code = practice.Code,
                                Name = practice.Name,
                                Description = practice.Description,
                                Status = ClinicalExamStatus.Incompleto,
                                GroupId = practiceGroup.Id
                            });
                        }
                    }
                }
                else
                {
                    if (_practices.Any(p => p.Code == item.Code)) continue;
                    _practices.Add(new MedicalHistoryPracticeDto
                                       {
                                           ClinicalHistoryId = item.MedicalHistoryId,
                                           Code = item.Code,
                                           Description = item.Description,
                                           MedicalPracticeId = item.Id,
                                           Status = item.Status,
                                           GroupId = null
                                       });
                }
            }

        }

        private void GetPractices(Guid id)
        {
            if (_practiceList == null || _practiceList.Any(item => item.Id == id))
            {
                cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
                return;
            }
            var practice = Practice.GetPractice(id);
            if (practice != null && CheckPracticeInGroups(practice.Code))
            {
                _practiceList.Add(new PracticeListDto
                                   {
                                       MedicalHistoryId = _clinicalHistoryId,
                                       Id = practice.Id,
                                       Code = practice.Code,
                                       Name = practice.Name,
                                       Description = practice.Description,
                                       Status = ClinicalExamStatus.Incompleto,
                                       IsGroup = false
                                   });
                _data.ResetBindings(false);
                cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
            }
            else
            {
                var practiceGroup = Group.GetGroup(id);
                if (practiceGroup != null)
                {
                    RemoveIncludedPractices(practiceGroup.Practices);
                    _practiceList.Add(new PracticeListDto
                    {
                        MedicalHistoryId = _clinicalHistoryId,
                        Id = practiceGroup.Id,
                        Code = practiceGroup.Code,
                        Name = practiceGroup.Name,
                        Description = practiceGroup.Description,
                        Status = ClinicalExamStatus.Incompleto,
                        IsGroup = true
                    });
                    _data.ResetBindings(false);
                    cbPracticeName.Text = txtPracticeCode.Text = string.Empty;
                }
            }

        }

        private void RemoveIncludedPractices(IEnumerable<Practice> practices)
        {
            foreach (var practiceDto in practices)
            {
                var practice = (from p in _practiceList where p.Code == practiceDto.Code select p).FirstOrDefault();
                if (practice != null)
                {
                    _practiceList.Remove(practice);
                }
            }
        }

        private bool CheckPracticeInGroups(int code)
        {
            if (_practiceList.Any(p => p.IsGroup))
            {
                var groups = (from p in _practiceList where p.IsGroup select p).ToList();
                foreach (var practiceListDto in groups)
                {
                    var group = Group.GetGroup(practiceListDto.Id);
                    if (group.Practices.Any(p => p.Code == code))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void MarkForRemove(Guid id, Guid groupId)
        {
            if (_originalPracticeIdList.Contains(id))
            {
                _removePraciceIdList.Add(id, groupId);
            }
        }
        #endregion
    }
}
