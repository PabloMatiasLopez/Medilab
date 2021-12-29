using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Excel;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Attention
{
    public partial class FrmClinicalHistoryResult : Form
    {
        #region Properties
        private Guid _medicalHistoryId;
        private Guid _resultId;
        private bool _isReadOnly;

        private const string msj = "Hay practicas incompletas";
        #endregion
        #region Events
        public FrmClinicalHistoryResult(Guid clinicalHistoryId, bool isReadOnly = false)
        {
            _medicalHistoryId = clinicalHistoryId;
            _isReadOnly = isReadOnly;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmClinicalHistoryResult_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadResults();
            if(_isReadOnly)
            {
                DisableForm();
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsResultsValid()) return;
                SaveResults();
                SaveEvaluation();
                btnPrintCompExam.Enabled = ArePracticesCompleted();
            }
            catch (Exception ex)
            {
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintCompExam_Click(object sender, EventArgs e)
        {
            try
            {
                LaboMedExcelnHandler.GenerateComplementaryExams(_medicalHistoryId);
                Close();
            }
            catch (Exception ex)
            {
                var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
                MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Methods
        private void SaveResults()
        {
            var historyResults = new MedicalHistoryResult(_resultId)
            {
                MedicalHistoryId = _medicalHistoryId,
                ChestXRay = UiUtils.GetCheckedResult(panelChestXRay),
                ChestXRayDetails = txtChestXRay.Text,
                ColumnXRay = UiUtils.GetCheckedResult(panelColumnXRay),
                ColumnXRayDetails = txtColumnXRay.Text,
                Laboratory = UiUtils.GetCheckedResult(panelLaboratory),
                LaboratoryDetails = txtLaboratory.Text,
                Electrocardiogram = UiUtils.GetCheckedResult(panelElectrocardiogram),
                ElectrocardiogramDetails = txtElectrocardiogram.Text,
                Audiometry = UiUtils.GetCheckedResult(panelAudiometry),
                AudiometryDetails = txtAudiometry.Text,
                Spirometry = UiUtils.GetCheckedResult(panelSpirometry),
                SpirometryDetails = txtSpirometry.Text,
                PsychologicalExam = UiUtils.GetCheckedResult(panelPsychologicalExam),
                PsychologicalExamDetails = txtPsychologicalExam.Text,
                Electroencephalogram = UiUtils.GetCheckedResult(panelElectroencephalogram),
                ElectroencephalogramDetails = txtElectroencephalogram.Text,
                Ergometry = UiUtils.GetCheckedResult(panelErgometry),
                ErgometryDetails = txtErgometry.Text,
                Ophthalmology = UiUtils.GetCheckedResult(panelOphthalmology),
                OphthalmologyDetails = txtOphthalmology.Text,
                Cardiology = UiUtils.GetCheckedResult(panelCardiology),
                CardiologyDetails = txtCardiology.Text,
                NeurologicalConsultation = UiUtils.GetCheckedResult(panelNeurological),
                NeurologicalConsultationDetails = txtNeurological.Text,
                Neumonology = UiUtils.GetCheckedResult(panelNeumonology),
                NeumonologyDetails = txtNeumonology.Text,
                Dental = UiUtils.GetCheckedResult(panelDental),
                DentalDetails = txtDental.Text,
                ORL = UiUtils.GetCheckedResult(panelORL),
                ORLDetails = txtORL.Text,
                VestibularExam = UiUtils.GetCheckedResult(panelVestibularExam),
                VestibularExamDetails = txtVestibularExam.Text,
                MagneticResonance = UiUtils.GetCheckedResult(panelMagneticResonance),
                MagneticResonanceDetails = txtMagneticResonance.Text,
                Ultrasound = UiUtils.GetCheckedResult(panelUltrasound),
                UltrasoundDetails = txtUltrasound.Text,
                Others = txtOthers.Text
            };
            historyResults.Save();
        }

        private bool IsResultsValid()
        {
            return Validator.RequiredCommentValidator(panelChestXRay, epResults, txtChestXRay) &
                Validator.RequiredCommentValidator(panelColumnXRay, epResults, txtColumnXRay) &
                Validator.RequiredCommentValidator(panelLaboratory, epResults, txtLaboratory) &
                Validator.RequiredCommentValidator(panelElectrocardiogram, epResults, txtElectrocardiogram) &
                Validator.RequiredCommentValidator(panelAudiometry, epResults, txtAudiometry) &
                Validator.RequiredCommentValidator(panelSpirometry, epResults, txtSpirometry) &
                Validator.RequiredCommentValidator(panelPsychologicalExam, epResults, txtPsychologicalExam) &
                Validator.RequiredCommentValidator(panelElectroencephalogram, epResults, txtElectroencephalogram) &
                Validator.RequiredCommentValidator(panelErgometry, epResults, txtErgometry) &
                Validator.RequiredCommentValidator(panelOphthalmology, epResults, txtOphthalmology) &
                Validator.RequiredCommentValidator(panelCardiology, epResults, txtCardiology) &
                Validator.RequiredCommentValidator(panelNeurological, epResults, txtNeurological) &
                Validator.RequiredCommentValidator(panelNeumonology, epResults, txtNeumonology) &
                Validator.RequiredCommentValidator(panelDental, epResults, txtDental) &
                Validator.RequiredCommentValidator(panelORL, epResults, txtORL) &
                Validator.RequiredCommentValidator(panelVestibularExam, epResults, txtVestibularExam) &
                Validator.RequiredCommentValidator(panelMagneticResonance, epResults, txtMagneticResonance) &
                Validator.RequiredCommentValidator(panelUltrasound, epResults, txtUltrasound);
        }

        private void LoadDropdowns()
        {
            cbResult.Items.Clear();
            var results = EnumUtils.GetDisplayNames(Enum.GetNames(typeof(ClinicaHistoryResult))).ToArray();
            cbResult.Items.AddRange(results);
            var historyType = MedicalHistory.GetMedicalHistory(_medicalHistoryId).TypeOfExam;
            if (historyType != ExamType.Periódico)
            {
                cbResult.Items.RemoveAt(0);
            }
            cbResult.Text = EnumUtils.AddSpaceInCapitalLetter(ClinicaHistoryResult.Apto.ToString());
        }

        private void SaveEvaluation()
        {
            var result = (ClinicaHistoryResult)
                         Enum.Parse(typeof(ClinicaHistoryResult), cbResult.Text.Replace(" ", ""));
            MedicalHistory.UpdateMedicalHistoryResult(_medicalHistoryId, result, txtResultObservations.Text);
        }

        private void LoadResults()
        {
            MedicalHistory medicalHistory = MedicalHistory.GetMedicalHistory(_medicalHistoryId);
            var historyResult = new MedicalHistoryResult();
            historyResult = historyResult.GetMedicalHistory(_medicalHistoryId);
            this.Text = this.Text + " - " + medicalHistory.Patient.FullName;
            if (medicalHistory.MedicalExam != null)
            {
                lblProfessionalName.Text = string.Format("Médico Clínico: {0}", medicalHistory.MedicalExam.ProfessionalName);   
            }
            if (historyResult != null)
            {
                lblProffesonalFinalEvaluation.Text = string.Format("Evaluado por: {0}", historyResult.EvaluatedByName);
            }
            if (historyResult != null)
            {
                _resultId = historyResult.Id;
                UiUtils.CheckExamResult(panelChestXRay, historyResult.ChestXRay);
                txtChestXRay.Text = historyResult.ChestXRayDetails;
                UiUtils.CheckExamResult(panelColumnXRay, historyResult.ColumnXRay);
                txtColumnXRay.Text = historyResult.ColumnXRayDetails;
                UiUtils.CheckExamResult(panelLaboratory, historyResult.Laboratory);
                txtLaboratory.Text = historyResult.LaboratoryDetails;
                UiUtils.CheckExamResult(panelElectrocardiogram, historyResult.Electrocardiogram);
                txtElectrocardiogram.Text = historyResult.ElectrocardiogramDetails;
                UiUtils.CheckExamResult(panelAudiometry, historyResult.Audiometry);
                txtAudiometry.Text = historyResult.AudiometryDetails;
                UiUtils.CheckExamResult(panelSpirometry, historyResult.Spirometry);
                txtSpirometry.Text = historyResult.SpirometryDetails;
                UiUtils.CheckExamResult(panelPsychologicalExam, historyResult.PsychologicalExam);
                txtPsychologicalExam.Text = historyResult.PsychologicalExamDetails;
                UiUtils.CheckExamResult(panelElectroencephalogram, historyResult.Electroencephalogram);
                txtElectroencephalogram.Text = historyResult.ElectroencephalogramDetails;
                UiUtils.CheckExamResult(panelErgometry, historyResult.Ergometry);
                txtErgometry.Text = historyResult.ErgometryDetails;
                UiUtils.CheckExamResult(panelOphthalmology, historyResult.Ophthalmology);
                txtOphthalmology.Text = historyResult.OphthalmologyDetails;
                UiUtils.CheckExamResult(panelCardiology, historyResult.Cardiology);
                txtCardiology.Text = historyResult.CardiologyDetails;
                UiUtils.CheckExamResult(panelNeurological, historyResult.NeurologicalConsultation);
                txtNeurological.Text = historyResult.NeurologicalConsultationDetails;
                UiUtils.CheckExamResult(panelNeumonology, historyResult.Neumonology);
                txtNeumonology.Text = historyResult.NeumonologyDetails;
                UiUtils.CheckExamResult(panelDental, historyResult.Dental);
                txtDental.Text = historyResult.DentalDetails;
                UiUtils.CheckExamResult(panelORL, historyResult.ORL);
                txtORL.Text = historyResult.ORLDetails;
                UiUtils.CheckExamResult(panelVestibularExam, historyResult.VestibularExam);
                txtVestibularExam.Text = historyResult.VestibularExamDetails;
                UiUtils.CheckExamResult(panelMagneticResonance, historyResult.MagneticResonance);
                txtMagneticResonance.Text = historyResult.MagneticResonanceDetails;
                UiUtils.CheckExamResult(panelUltrasound, historyResult.Ultrasound);
                txtUltrasound.Text = historyResult.UltrasoundDetails;
                txtOthers.Text = historyResult.Others;
                txtResultObservations.Text = medicalHistory.ResultObservations;
                cbResult.Text = EnumUtils.AddSpaceInCapitalLetter(medicalHistory.Result.ToString());
                btnPrintCompExam.Enabled = ArePracticesCompleted();
            }
            else
            {
                if (medicalHistory.MedicalExam != null)
                {
                    txtResultObservations.Text = medicalHistory.MedicalExam.Observations;
                }
            }
        }

        private bool ArePracticesCompleted()
        {
            var medicalHistory = MedicalHistory.GetMedicalHistory(_medicalHistoryId);
            foreach (var practice in medicalHistory.PracticeDisplayList)
            {
                if (practice.Status == ClinicalExamStatus.Incompleto && !practice.IsExternal)
                {
                    lblIncompletePractices.Text = msj;
                    return false;

                }
            }
            lblIncompletePractices.Text = string.Empty;
            return true;
        }

        private void DisableForm()
        {
            gbEvaluation.Enabled = false;
            gbResults.Enabled = false;
            btnEvaluate.Visible = false;
            btnPrintCompExam.Visible = false;
        }
        #endregion
    }
}
