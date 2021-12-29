using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utils;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Attention
{
    public partial class ClinicalHistoryResume : Form
    {
        public ClinicalHistoryResume()
        {
            InitializeComponent();
        }

        public ClinicalHistoryResume(Guid clinicalHistoryId)
        {
            _clinicalHistoryId = clinicalHistoryId;
            InitializeComponent();
        }


        #region Properties

        private Guid _clinicalHistoryId;
        private ExamType _clinicalHistoryType;

        #endregion

        #region Events
        private void ClinicalHistoryResume_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadData();
            if (_clinicalHistoryId != Guid.Empty)
            {
                var medicalHistory = MedicalHistory.GetMedicalHistory(_clinicalHistoryId);
                LoadMedicalHistory(medicalHistory);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            var medicalHistory = MedicalHistory.GetMedicalHistory(_clinicalHistoryId);
            _clinicalHistoryType = medicalHistory.TypeOfExam;

            txtFullName.Text = medicalHistory.Patient.FullName;
            txtDocumentNumber.Text =
                string.Concat(EnumUtils.AddSpaceInCapitalLetter(medicalHistory.Patient.DocumentType.ToString()), " ",
                              medicalHistory.Patient.DocumentNumber);
            var photoPath = ConfigurationManager.AppSettings["filePhotoServerPath"];
            if (FileDirectoryHandler.CheckIfDirectoryExist(photoPath))
            {
                if (!string.IsNullOrEmpty(medicalHistory.Patient.Photo))
                {
                    pbPhoto.ImageLocation = Path.Combine(photoPath, medicalHistory.Patient.Photo);
                }
            }
            else
            {
                pbPhoto.ImageLocation = string.Empty;
            }
            
            txtResultObservations.Text = medicalHistory.ResultObservations;
            var savedResult = EnumUtils.AddSpaceInCapitalLetter(medicalHistory.Result.ToString());
            foreach (var item in cbResult.Items)
            {
                var result = item.ToString();
                if (result == savedResult)
                {
                    cbResult.SelectedItem = item;
                    break;
                }
            }
        }
        private void LoadMedicalHistory(MedicalHistory medicalHistory)
        {
            _clinicalHistoryId = medicalHistory.Id;
            if (medicalHistory.MedicalExam != null)
            {
                LoadClinicalExam(medicalHistory.MedicalExam);
            }
        }
        private void LoadClinicalExam(ClinicalExam exam)
        {
            //Personal history
            LoadPersonalHistory(exam);
            //Habits
            LoadHabits(exam);
            //View
            LoadView(exam);
            //Medical Exam
            LoadMedicalExamHeader(exam);
            LoadMedicalExamDetails(exam);
            LoadPracticeResults();
        }

        private void LoadPracticeResults()
        {
            var practiceResults = MedicalHistoryPractice.GetPracticeResults(_clinicalHistoryId);
            gvPracticeResult.AutoGenerateColumns = false;
            gvPracticeResult.DataSource = practiceResults;
        }
        private void LoadMedicalExamHeader(ClinicalExam exam)
        {
            txtSize.Text = exam.Size.ToString();
            txtWeigth.Text = exam.Weight.ToString(CultureInfo.InstalledUICulture);
            txtImc.Text = exam.BodyMassIndex.ToString();
            txtAbdominalCircunference.Text = exam.AbdominalCircunference.HasValue
                                                 ? exam.AbdominalCircunference.Value.ToString(CultureInfo.InstalledUICulture)
                                                 : string.Empty;
            txtBloodPressureHight.Text = exam.BloodPressureHight.ToString(CultureInfo.InstalledUICulture);
            txtBloodPressureLow.Text = exam.BloodPressureLow.ToString(CultureInfo.InstalledUICulture);
            txtPulse.Text = exam.Pulse.ToString(CultureInfo.InstalledUICulture);
            txtCervicalPerimeter.Text = exam.CervicalPerimeter.HasValue ? exam.CervicalPerimeter.Value.ToString(CultureInfo.InstalledUICulture) : string.Empty;
        }

        private void LoadView(ClinicalExam exam)
        {
            chkUseEyeglasses.Checked = exam.UseEyeglasses;
            txtFncRigthValue.Text = exam.EyeFarNoCorrectionRight.HasValue ? exam.EyeFarNoCorrectionRight.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
            txtFncLeftValue.Text = exam.EyeFarNoCorrectionLeft.HasValue ? exam.EyeFarNoCorrectionLeft.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
            txtViewNNCR.Text = exam.EyeNearNoCorrectionRight.HasValue
                                  ? "V = " + exam.EyeNearNoCorrectionRight.Value.ToString("0.00") + " D."
                                  : string.Empty;
                       
            txtViewNNCL.Text = exam.EyeNearNoCorrectionLeft.HasValue
                                   ? "V = " + exam.EyeNearNoCorrectionLeft.Value.ToString("0.00") + " D."
                                   : string.Empty;
            if (exam.UseEyeglasses)
            {
                if (exam.EyeFarWithCorrectionRight.HasValue)
                {
                    txtFwcRightValue.Text = exam.EyeFarWithCorrectionRight.Value.ToString(CultureInfo.InvariantCulture);
                }
                if (exam.EyeFarWithCorrectionLeft.HasValue)
                {
                    txtFwcLeftValue.Text = exam.EyeFarWithCorrectionLeft.Value.ToString(CultureInfo.InvariantCulture);
                }
                txtViewNWCR.Text = exam.EyeNearWithCorrectionRight.HasValue
                                           ? "V = " + exam.EyeNearWithCorrectionRight.Value.ToString("0.00") + " D."
                                           : string.Empty;

                txtViewNWCL.Text = exam.EyeNearWithCorrectionLeft.HasValue
                                           ? "V = " + exam.EyeNearWithCorrectionLeft.Value.ToString("0.00") + " D."
                                           : string.Empty;
            }
            else
            {
                txtFwcRightValue.Visible = false;
                txtFwcLeftValue.Visible = false;
                txtViewNWCR.Visible = false;
                txtViewNWCL.Visible = false;
                lblFarWithCorrection.Visible = false;
                lblFwcRight.Visible = false;
                lblFwcrValue.Visible = false;
                lblFwcLeft.Visible = false;
                lblFwclValue.Visible = false;
                lblNearWithCorrection.Visible = false;
                lblNwcRight.Visible = false;
                lblNwcLeft.Visible = false;
            }
            txtColorVision.Text = exam.ColorVision;
            txtFunduscopicRightValue.Text = exam.FunduscopicRight;
            txtFunduscopicLeftValue.Text = exam.FunduscopicLeft;
            txtViewObservations.Text = exam.ViewObservations;
        }
        private void LoadHabits(ClinicalExam exam)
        {
            txtSmokeYesNo.Text = exam.Smoke ? Constants.Yes : Constants.No;
            txtSmokeCount.Text = exam.SmokeCount;
            txtAlcoholYesNo.Text = exam.Alcohol ? Constants.Yes : Constants.No;
            txtAlcoholCount.Text = exam.AlcoholCount;
            txtSleepYesNo.Text = exam.NormalSleep ? Constants.Yes : Constants.No;
            txtSleepHours.Text = exam.SleepHours;
            txtDietYesNo.Text = exam.Diet ? Constants.Yes : Constants.No;
            txtDietDetails.Text = exam.DietDetails;
            txtSportsYesNo.Text = exam.Sports ? Constants.Yes : Constants.No;
            txtSportDetails.Text = exam.SportsDetails;
        }
        private void LoadPersonalHistory(ClinicalExam exam)
        {
            txtHereditary.Text = exam.HereditaryRecords;
            txtPathological.Text = exam.PathologicalRecords;
            txtSurgical.Text = exam.SurgicalRecords;
            txtTrauma.Text = exam.TraumaRecors;
            txtObstetrical.Text = exam.ObstetricalRecords;
            txtOthers.Text = exam.OtherRecords;
        }
        private void LoadMedicalExamDetails(ClinicalExam exam)
        {
            txtHeadValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Head.ToString());
            txtHead.Text = exam.HeadDetails;
            txtEyesValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Eyes.ToString());
            txtEyes.Text = exam.EyesDetails;
            txtEarValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Ear.ToString());
            txtEar.Text = exam.EarDetails;
            txtNoseValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Nose.ToString());
            txtNose.Text = exam.NoseDetails;
            txtMouthValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Mouth.ToString());
            txtMouth.Text = exam.MouthDetails;
            txtNeckValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Neck.ToString());
            txtNeck.Text = exam.NeckDetails;
            txtChestValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Chest.ToString());
            txtChest.Text = exam.ChestDetails;
            txtLunValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Lung.ToString());
            txtLung.Text = exam.LungDetails;
            txtHeartValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Heart.ToString());
            txtHeart.Text = exam.HeartDetails;
            txtPeripheralVeinsValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.PeripheralVeins.ToString());
            txtPeripheralVeins.Text = exam.PeripheralVeinsDetails;
            txtPeripheralArteriesValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.PeripheralArteries.ToString());
            txtPeripheralArteries.Text = exam.PeripheralArteriesDetails;
            txtAbdomenValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Abdomen.ToString());
            txtAbdomen.Text = exam.AbdomenDetails;
            txtHerniaValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Hernia.ToString());
            txtHernia.Text = exam.HerniaDetails;
            txtGenitalsValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Genitals.ToString());
            txtGenitals.Text = exam.GenitalsDetails;
            txtSubcutaneousCellularTissueValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.SubcutaneousCellularTissue.ToString());
            txtSubcutaneousCellularTissue.Text = exam.SubcutaneousCellularTissueDetails;
            txtKidneysValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Kidneys.ToString());
            txtKidneys.Text = exam.KidneysDetails;
            txtAnusValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Anus.ToString());
            txtAnus.Text = exam.AnusDetails;
            txtTipsValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Tips.ToString());
            txtTips.Text = exam.TipsDetails;
            txtBackboneValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Backbone.ToString());
            txtBackbone.Text = exam.BackboneDetails;
            txtSkinValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Skin.ToString());
            txtSkin.Text = exam.SkinDetails;
            txtLymphNodesValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.LympNodes.ToString());
            txtLymphNodes.Text = exam.LympNodesDetails;
            txtNervousSystemValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.NervousSystem.ToString());
            txtNervousSystem.Text = exam.NervousSystemDetails;
            txtMotionValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Motion.ToString());
            txtMotion.Text = exam.MotionDetails;
            txtPsychicTestValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.PsychicTest.ToString());
            txtPsychicTest.Text = exam.PsychicTestDetails;
            txtScarsValue.Text = EnumUtils.AddSpaceInCapitalLetter(exam.Scars.ToString());
            txtScars.Text = exam.ScarsDetails;
            txtClinicalExamObservations.Text = exam.Observations;
        }
        private void LoadDropdowns()
        {
            cbResult.Items.Clear();
            var results = EnumUtils.GetDisplayNames(Enum.GetNames(typeof(ClinicaHistoryResult))).ToArray();
            cbResult.Items.AddRange(results);
            if(_clinicalHistoryType != ExamType.Periódico)
            {
                cbResult.Items.RemoveAt(0);
            }
            cbResult.Text = EnumUtils.AddSpaceInCapitalLetter(ClinicaHistoryResult.Apto.ToString());
        }
        #endregion
    }
}
