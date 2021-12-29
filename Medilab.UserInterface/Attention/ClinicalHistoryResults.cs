using Medilab.BusinessObjects.ClinicalHistory;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.PrintUtilities;
using Medilab.UserInterface.Properties;
using Medilab.UserInterface.Utilities;
using Medilab.UserInterface.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Medilab.UserInterface.Attention
{
	public partial class ClinicalHistoryResults : Form
	{
		public ClinicalHistoryResults()
		{
			InitializeComponent();
		}

		public ClinicalHistoryResults(Guid clinicalHistoryId)
		{
			_clinicalHistoryId = clinicalHistoryId;
			InitializeComponent();
		}

		#region Properties

		private Guid _clinicalHistoryId;
		private Guid _clinicalExamId;
		private byte[] _clinicalExamLastUpdate;
        private Guid _previousExamId;
		#endregion

		#region Events
		private void ClinicalHistoryResults_Load(object sender, EventArgs e)
		{
			LoadDropdowns();
			LoadData();
            btnPrintAffidavit.Enabled = false;
            btnPreviousEvaluation.Visible = false;
			if (_clinicalHistoryId != Guid.Empty)
			{
				var medicalHistory = MedicalHistory.GetMedicalHistory(_clinicalHistoryId);
				LoadMedicalHistory(medicalHistory);
			}
            _previousExamId = new MedicalHistoryResult().GetPreviousExamId(_clinicalHistoryId);
            if(_previousExamId != Guid.Empty)
            {
                btnPreviousEvaluation.Visible = true;
            }
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSaveClinicalExam_Click(object sender, EventArgs e)
		{
			try
			{
				if (!IsClinicalExamValid()) return;
				SaveClinicalExam();
				MarkAsDone();
				if (_clinicalExamId != Guid.Empty)
				{
                    btnPrintAffidavit.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				var error = string.Format("{0}\n{1}", Resources.GenericErrorMessage, ex.Message);
				MessageBox.Show(error, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}
		private void txtSize_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtSize.Text) || string.IsNullOrEmpty(txtWeigth.Text)) return;
			txtImc.Text = GetIcm(txtWeigth.Text, txtSize.Text).ToString("0.00");
		}

		private void txtWeigth_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtSize.Text) || string.IsNullOrEmpty(txtWeigth.Text)) return;
			txtImc.Text = GetIcm(txtWeigth.Text, txtSize.Text).ToString("0.00");
		}

        private void tabClinicalHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ((TabControl)sender).SelectedIndex;
            if (tabClinicalHistory.TabCount - 1 == index)
            {
                txtSize.Select();
            }
        }
        private void btnPrintAffidavit_Click(object sender, EventArgs e)
        {
            MedicalExamUtils.PrintAffidavit(_clinicalHistoryId);
        }
        private void btnPreviousEvaluation_Click(object sender, EventArgs e)
        {
            var clinicalHistoryResults = new FrmClinicalHistoryResult(_previousExamId, true);
            clinicalHistoryResults.ShowDialog(this);
        }
		#endregion

		#region Methods

		private void LoadDropdowns()
		{
			//View dropdowns
			cbNncRigt.Items.Clear();
			cbNncLeft.Items.Clear();
			cbNwcRight.Items.Clear();
			cbNwcLeft.Items.Clear();
			cbNncRigt.Items.Add(string.Empty);
			cbNncLeft.Items.Add(string.Empty);
			cbNwcRight.Items.Add(string.Empty);
			cbNwcLeft.Items.Add(string.Empty);
			var value = 0.5;
			for (var i = 0; i < 7; i++)
			{
				cbNncRigt.Items.Add(new ListItemDto<double> {Id = value, Value = "V = " + value.ToString("0.00") + " D."});
				cbNncLeft.Items.Add(new ListItemDto<double> { Id = value, Value = "V = " + value.ToString("0.00") + " D." });
				cbNwcRight.Items.Add(new ListItemDto<double> { Id = value, Value = "V = " + value.ToString("0.00") + " D." });
				cbNwcLeft.Items.Add(new ListItemDto<double> { Id = value, Value = "V = " + value.ToString("0.00") + " D." });
				value += 0.25;
			}
		}

		private double GetIcm(string weight, string size)
		{
			int convertedWeight;
			int convertedSize;
			if (int.TryParse(weight, out convertedWeight) && int.TryParse(size, out convertedSize))
			{
                double sizeInMeters = ((double)convertedSize) / 100;
                return convertedWeight / (sizeInMeters * sizeInMeters);
			}
			return 0;
		}

		private void LoadMedicalHistory(MedicalHistory medicalHistory)
		{
			_clinicalHistoryId = medicalHistory.Id;
			if (medicalHistory.MedicalExam != null)
			{
				LoadClinicalExam(medicalHistory.MedicalExam);
			}
		}

		private bool IsClinicalExamValid()
		{
			epMedicalExam.Clear();
			var personalHistoryValidation = ValidatePersonalHistory();
			var habitsValidation = ValidateHabits();
			var viewValidation = ValidateView();
			var clinicalExamValidation = ValidateClinicalExam();
			var practicesValidaton = ValidateExamPractices();
			var tabsWithErrors = new List<string>();
			if (!personalHistoryValidation)
			{
				tabsWithErrors.Add("Antecedentes personales");
			}
			if (!habitsValidation || !viewValidation)
			{
				tabsWithErrors.Add("Datos complementarios");
			}
			if (!clinicalExamValidation || !practicesValidaton)
			{
				tabsWithErrors.Add("Examen Clínico");
			}
			if (tabsWithErrors.Count > 0)
			{
				epMedicalExam.SetError(tabClinicalHistory,
									   string.Format("Errores en {0}", string.Join(",", tabsWithErrors)));
			}
			return ValidatePersonalHistory() & ValidateHabits() & ValidateView() & ValidateClinicalExam() &
				   ValidateExamPractices();
		}

		private bool ValidateExamPractices()
		{
			return Validator.RequiredCommentValidator(panelHead, epMedicalExam, txtHead) &
				   Validator.RequiredCommentValidator(panelEyes, epMedicalExam, txtEyes) &
				   Validator.RequiredCommentValidator(panelEar, epMedicalExam, txtEar) &
				   Validator.RequiredCommentValidator(panelNose, epMedicalExam, txtNose) &
				   Validator.RequiredCommentValidator(panelMouth, epMedicalExam, txtMouth) &
				   Validator.RequiredCommentValidator(panelNeck, epMedicalExam, txtNeck) &
				   Validator.RequiredCommentValidator(panelChest, epMedicalExam, txtChest) &
				   Validator.RequiredCommentValidator(panelLung, epMedicalExam, txtLung) &
				   Validator.RequiredCommentValidator(panelHeart, epMedicalExam, txtHeart) &
				   Validator.RequiredCommentValidator(panelPeripheralVeins, epMedicalExam,
													  txtPeripheralVeins) &
				   Validator.RequiredCommentValidator(panelPeripheralArteries, epMedicalExam,
													  txtPeripheralArteries) &
				   Validator.RequiredCommentValidator(panelAbdomen, epMedicalExam, txtAbdomen) &
				   Validator.RequiredCommentValidator(panelHernia, epMedicalExam, txtHernia) &
				   Validator.RequiredCommentValidator(panelGenitals, epMedicalExam, txtGenitals) &
				   Validator.RequiredCommentValidator(panelSubcutaneousCellularTissue,
													  epMedicalExam,
													  txtSubcutaneousCellularTissue) &
				   Validator.RequiredCommentValidator(panelKidneys, epMedicalExam, txtKidneys) &
				   Validator.RequiredCommentValidator(panelAnus, epMedicalExam, txtAnus) &
				   Validator.RequiredCommentValidator(panelTips, epMedicalExam, txtTips) &
				   Validator.RequiredCommentValidator(panelBackbone, epMedicalExam, txtBackbone) &
				   Validator.RequiredCommentValidator(panelSkin, epMedicalExam, txtSkin) &
				   Validator.RequiredCommentValidator(panelLymphNodes, epMedicalExam,
													  txtLymphNodes) &
				   Validator.RequiredCommentValidator(panelNervousSystem, epMedicalExam,
													  txtNervousSystem) &
				   Validator.RequiredCommentValidator(panelMotion, epMedicalExam, txtMotion) &
				   Validator.RequiredCommentValidator(panelPsychicTest, epMedicalExam,
													  txtPsychicTest) &
				   Validator.RequiredCommentValidator(panelBalanceTest, epMedicalExam, txtBalanceTest) &
				   Validator.RequiredCommentValidator(panelScars, epMedicalExam, txtScars) &
                   Validator.RequiredCommentValidator(panelIMC, epMedicalExam, txtIMCDetail) &
                   Validator.RequiredCommentValidator(panelArtTension , epMedicalExam, txtArtTenDetail);
		}

		private bool ValidateClinicalExam()
		{
			var isClinicalExamValid = (Validator.CheckIntType(txtSize, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtSize.Text), 100, 250, txtSize,
											 epMedicalExam)) &
				   (Validator.CheckIntType(txtWeigth, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtWeigth.Text), 45, 200, txtWeigth,
											 epMedicalExam)) &
				   (Validator.CheckIntType(txtBloodPressureHight, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtBloodPressureHight.Text), 50, 250,
											 txtBloodPressureHight,
											 epMedicalExam)) &
				   (Validator.CheckIntType(txtBloodPressureLow, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtBloodPressureLow.Text), 50, 250,
											 txtBloodPressureLow,
											 epMedicalExam)) &
				   (Validator.CheckIntType(txtPulse, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtPulse.Text), 40, 200, txtPulse,
											 epMedicalExam));
			var isAbdominalPerimeterValid = true;
			if (!string.IsNullOrEmpty(txtAbdominalCircunference.Text))
			{
				isAbdominalPerimeterValid = (Validator.CheckIntType(txtAbdominalCircunference, epMedicalExam) &&
						Validator.RangeValidator(int.Parse(txtAbdominalCircunference.Text), 40, 200, txtAbdominalCircunference,
												 epMedicalExam));
			}
			var isCervicalPerimeterValid = true;
			if (!string.IsNullOrEmpty( txtCervicalPerimeter.Text))
			{
				isCervicalPerimeterValid = (Validator.CheckIntType(txtCervicalPerimeter, epMedicalExam) &&
						Validator.RangeValidator(int.Parse(txtCervicalPerimeter.Text), 10, 100, txtCervicalPerimeter,
												 epMedicalExam));
			}
			return isClinicalExamValid && isAbdominalPerimeterValid && isCervicalPerimeterValid;
		}

		private bool ValidateView()
		{
			var fncRigthValueIsValid = true;
			if (!string.IsNullOrEmpty(txtFncRigthValue.Text))
			{
				fncRigthValueIsValid = (Validator.CheckIntType(txtFncRigthValue, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtFncRigthValue.Text), 0, 10, txtFncRigthValue,
											 epMedicalExam));
			}
			var fncLeftValueIsValid = true;
			if (!string.IsNullOrEmpty(txtFncLeftValue.Text))
			{
				fncLeftValueIsValid = (Validator.CheckIntType(txtFncLeftValue, epMedicalExam) &&
					Validator.RangeValidator(int.Parse(txtFncLeftValue.Text), 0, 10, txtFncLeftValue,
											 epMedicalExam));
			}
			var validView = fncRigthValueIsValid && fncLeftValueIsValid;
			var validCorrectionView = true;
			if (!string.IsNullOrEmpty(txtFwcRightValue.Text))
			{
				validCorrectionView = validCorrectionView & (Validator.CheckIntType(txtFwcRightValue, epMedicalExam) &&
				Validator.RangeValidator(int.Parse(txtFwcRightValue.Text), 0, 10, txtFwcRightValue,
											epMedicalExam));
			}
			if (!string.IsNullOrEmpty(txtFwcLeftValue.Text))
			{
				validCorrectionView = validCorrectionView & (Validator.CheckIntType(txtFwcLeftValue, epMedicalExam) &&
				Validator.RangeValidator(int.Parse(txtFwcLeftValue.Text), 0, 10, txtFwcLeftValue,
											epMedicalExam));
			}
			return validView & validCorrectionView;
		}

		private bool ValidateHabits()
		{
			return (!rbSmokeYes.Checked ||
					Validator.RequiredFieldValidator(txtSmokeCount, epMedicalExam)) &
				   (!rbAlcoholYes.Checked ||
					Validator.RequiredFieldValidator(txtAlcoholCount, epMedicalExam)) &
				   (!rbSleepNo.Checked || Validator.RequiredFieldValidator(txtSleepHours, epMedicalExam));
		}

		private bool ValidatePersonalHistory()
		{
			return Validator.RequiredFieldValidator(txtHereditary, epMedicalExam) &
				   Validator.RequiredFieldValidator(txtPathological, epMedicalExam) &
				   Validator.RequiredFieldValidator(txtSurgical, epMedicalExam) &
				   Validator.RequiredFieldValidator(txtTrauma, epMedicalExam) &
				   Validator.RequiredFieldValidator(txtOthers, epMedicalExam) &
				   Validator.RequiredFieldValidator(txtVaccinesGiven, epMedicalExam);
		}

		private void SaveClinicalExam()
		{
			//Check use eyeglasses
		    int? eyeFarWithCorrectionRightValue = txtFwcRightValue.Text != String.Empty ? int.Parse(txtFwcRightValue.Text) : (int?)null;
            int? eyeFarWithCorrectionLeftValue = txtFwcLeftValue.Text != string.Empty ? int.Parse(txtFwcLeftValue.Text) : (int?)null;

            double? eyeNearWithCorrectionRightValue = cbNwcRight.SelectedIndex <= 0 ? (double?)null : ((ListItemDto<double>)cbNwcRight.SelectedItem).Id;
            double? eyeNearWithCorrectionLeftValue = cbNwcLeft.SelectedIndex <= 0 ? (double?)null : ((ListItemDto<double>)cbNwcLeft.SelectedItem).Id;

            double? eyeNearNoCorrectionRightValue = cbNncRigt.SelectedIndex <= 0 ? (double?)null : ((ListItemDto<double>)cbNncRigt.SelectedItem).Id;
            double? eyeNearNoCorrectionLeftValue = cbNncLeft.SelectedIndex <= 0 ? (double?)null : ((ListItemDto<double>)cbNncLeft.SelectedItem).Id;

			int? fncRigthValue = null;
			if(!string.IsNullOrEmpty(txtFncRigthValue.Text))
			{
				fncRigthValue = int.Parse(txtFncRigthValue.Text);
			}

			int? cervicalPerimeter = null;
			if (!string.IsNullOrEmpty(txtCervicalPerimeter.Text))
			{
				cervicalPerimeter = int.Parse(txtCervicalPerimeter.Text);
			}
			int? abdominalCircunference = null;
			if (!string.IsNullOrEmpty(txtAbdominalCircunference.Text))
			{
				abdominalCircunference = int.Parse(txtAbdominalCircunference.Text);
			}
			int? fncLeftValue = null;
			if(!string.IsNullOrEmpty(txtFncLeftValue.Text))
			{
				fncLeftValue = int.Parse(txtFncLeftValue.Text);
			}
			var medicalExam = new ClinicalExam(_clinicalExamId)
								  {
									  MedicalHistoryId = _clinicalHistoryId,
									  LastUpdated = _clinicalExamLastUpdate,
									  HereditaryRecords = txtHereditary.Text,
									  PathologicalRecords = txtPathological.Text,
									  SurgicalRecords = txtSurgical.Text,
									  TraumaRecors = txtTrauma.Text,
									  ObstetricalRecords = txtObstetrical.Text,
									  OtherRecords = txtOthers.Text,
									  VaccinesRecords = txtVaccinesGiven.Text,
									  Smoke = rbSmokeYes.Checked,
									  SmokeCount = txtSmokeCount.Text,
									  Alcohol = rbAlcoholYes.Checked,
									  AlcoholCount = txtAlcoholCount.Text,
									  NormalSleep = rbSleepYes.Checked,
									  SleepHours = txtSleepHours.Text,
									  Diet = rbDietYes.Checked,
									  DietDetails = txtDietDetails.Text,
									  Sports = rbSportsYes.Checked,
									  SportsDetails = txtSportDetails.Text,
									  UseEyeglasses = rbUseEyeglassesYes.Checked,
									  EyeFarNoCorrectionRight = fncRigthValue,
									  EyeFarNoCorrectionLeft = fncLeftValue,
									  EyeFarWithCorrectionRight = eyeFarWithCorrectionRightValue,
									  EyeFarWithCorrectionLeft = eyeFarWithCorrectionLeftValue,
									  EyeNearNoCorrectionRight = eyeNearNoCorrectionRightValue,
									  EyeNearNoCorrectionLeft = eyeNearNoCorrectionLeftValue,
									  EyeNearWithCorrectionRight = eyeNearWithCorrectionRightValue,
									  EyeNearWithCorrectionLeft = eyeNearWithCorrectionLeftValue,
									  ColorVision = txtColorVision.Text,
									  FunduscopicRight = txtFunduscopicRightValue.Text,
									  FunduscopicLeft = txtFunduscopicLeftValue.Text,
									  ViewObservations = txtViewObservations.Text,
									  Size = int.Parse(txtSize.Text),
									  Weight = int.Parse(txtWeigth.Text),
									  AbdominalCircunference = abdominalCircunference,
									  BloodPressureHight = int.Parse(txtBloodPressureHight.Text),
									  BloodPressureLow = int.Parse(txtBloodPressureLow.Text),
									  Pulse = int.Parse(txtPulse.Text),
									  CervicalPerimeter = cervicalPerimeter,
									  Head = UiUtils.GetCheckedResult(panelHead),
									  HeadDetails = txtHead.Text,
									  Eyes = UiUtils.GetCheckedResult(panelEyes),
									  EyesDetails = txtEyes.Text,
									  Ear = UiUtils.GetCheckedResult(panelEar),
									  EarDetails = txtEar.Text,
									  Nose = UiUtils.GetCheckedResult(panelNose),
									  NoseDetails = txtNose.Text,
									  Mouth = UiUtils.GetCheckedResult(panelMouth),
									  MouthDetails = txtMouth.Text,
									  Neck = UiUtils.GetCheckedResult(panelNeck),
									  NeckDetails = txtNeck.Text,
									  Chest = UiUtils.GetCheckedResult(panelChest),
									  ChestDetails = txtChest.Text,
									  Lung = UiUtils.GetCheckedResult(panelLung),
									  LungDetails = txtLung.Text,
									  Heart = UiUtils.GetCheckedResult(panelHeart),
									  HeartDetails = txtHeart.Text,
                                      BloodPressureStatus =  UiUtils.GetCheckedResult(panelArtTension),
                                      BloodPressureStatusDetail =  txtArtTenDetail.Text,
									  PeripheralVeins = UiUtils.GetCheckedResult(panelPeripheralVeins),
									  PeripheralVeinsDetails = txtPeripheralVeins.Text,
									  PeripheralArteries = UiUtils.GetCheckedResult(panelPeripheralArteries),
									  PeripheralArteriesDetails = txtPeripheralArteries.Text,
									  Abdomen = UiUtils.GetCheckedResult(panelAbdomen),
									  AbdomenDetails = txtAbdomen.Text,
									  Hernia = UiUtils.GetCheckedResult(panelHernia),
									  HerniaDetails = txtHernia.Text,
									  Genitals = UiUtils.GetCheckedResult(panelGenitals),
									  GenitalsDetails = txtGenitals.Text,
                                      IMCStatus = UiUtils.GetCheckedResult(panelIMC),
                                      IMCStatusDetails = txtIMCDetail.Text,
									  SubcutaneousCellularTissue =
										  UiUtils.GetCheckedResult(panelSubcutaneousCellularTissue),
									  SubcutaneousCellularTissueDetails = txtSubcutaneousCellularTissue.Text,
									  Kidneys = UiUtils.GetCheckedResult(panelKidneys),
									  KidneysDetails = txtKidneys.Text,
									  Anus = UiUtils.GetCheckedResult(panelAnus),
									  AnusDetails = txtAnus.Text,
									  Tips = UiUtils.GetCheckedResult(panelTips),
									  TipsDetails = txtTips.Text,
									  Backbone = UiUtils.GetCheckedResult(panelBackbone),
									  BackboneDetails = txtBackbone.Text,
									  Skin = UiUtils.GetCheckedResult(panelSkin),
									  SkinDetails = txtSkin.Text,
									  LympNodes = UiUtils.GetCheckedResult(panelLymphNodes),
									  LympNodesDetails = txtLymphNodes.Text,
									  NervousSystem = UiUtils.GetCheckedResult(panelNervousSystem),
									  NervousSystemDetails = txtNervousSystem.Text,
									  Motion = UiUtils.GetCheckedResult(panelMotion),
									  MotionDetails = txtMotion.Text,
									  PsychicTest = UiUtils.GetCheckedResult(panelPsychicTest),
									  PsychicTestDetails = txtPsychicTest.Text,
                                      BalanceTest = UiUtils.GetCheckedResult(panelBalanceTest),
                                      BalanceTestDetails = txtBalanceTest.Text,
									  Scars = UiUtils.GetCheckedResult(panelScars),
									  ScarsDetails = txtScars.Text,
									  Status = ClinicalExamStatus.Completa,
									  Observations = txtClinicalExamObservations.Text
								  };
			var savedMedicalExam = medicalExam.Save();
			_clinicalExamId = savedMedicalExam.Id;
			_clinicalExamLastUpdate = savedMedicalExam.LastUpdated;
		}

		private void LoadClinicalExam(ClinicalExam exam)
		{
			_clinicalExamId = exam.Id;
			_clinicalExamLastUpdate = exam.LastUpdated;
			//Personal history
			LoadPersonalHistory(exam);
			//Habits
			LoadHabits(exam);
			//View
			LoadView(exam);
			//Medical Exam
			LoadMedicalExamHeader(exam);
			LoadMedicalExamDetails(exam);
            btnPrintAffidavit.Enabled = true;
		}

		private void LoadMedicalExamHeader(ClinicalExam exam)
		{
			txtSize.Text = exam.Size.ToString();
			txtWeigth.Text = exam.Weight.ToString(CultureInfo.InvariantCulture);
			txtImc.Text = exam.BodyMassIndex.ToString();
			if (exam.AbdominalCircunference.HasValue)
			{
				txtAbdominalCircunference.Text = exam.AbdominalCircunference.Value.ToString(CultureInfo.InvariantCulture);
			}
			txtBloodPressureHight.Text = exam.BloodPressureHight.ToString(CultureInfo.InvariantCulture);
			txtBloodPressureLow.Text = exam.BloodPressureLow.ToString(CultureInfo.InvariantCulture);
			txtPulse.Text = exam.Pulse.ToString(CultureInfo.InvariantCulture);
			if (exam.CervicalPerimeter.HasValue)
			{
				txtCervicalPerimeter.Text = exam.CervicalPerimeter.Value.ToString();
			}
		}

		private void LoadView(ClinicalExam exam)
		{
			rbUseEyeglassesYes.Checked = exam.UseEyeglasses;
			txtFncRigthValue.Text = exam.EyeFarNoCorrectionRight.HasValue ? exam.EyeFarNoCorrectionRight.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
			txtFncLeftValue.Text = exam.EyeFarNoCorrectionLeft.HasValue ? exam.EyeFarNoCorrectionLeft.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
			if (exam.EyeFarWithCorrectionRight.HasValue)
			{
				txtFwcRightValue.Text = exam.EyeFarWithCorrectionRight.Value.ToString(CultureInfo.InvariantCulture);    
			}
			if (exam.EyeFarWithCorrectionLeft.HasValue)
			{
				txtFwcLeftValue.Text = exam.EyeFarWithCorrectionLeft.Value.ToString(CultureInfo.InvariantCulture);    
			}
			if (exam.EyeNearNoCorrectionRight.HasValue)
			{
				foreach (var item in cbNncRigt.Items)
				{
					if (item is ListItemDto<double>)
					{
						var option = (ListItemDto<double>)item;
						if (option.Id.ToString("0.00") != exam.EyeNearNoCorrectionRight.Value.ToString("0.00")) continue;
						cbNncRigt.SelectedItem = item;
						break;
					}
				}
			}
			if (exam.EyeNearNoCorrectionLeft.HasValue)
			{
				foreach (var item in cbNncLeft.Items)
				{
					if (item is ListItemDto<double>)
					{
						var option = (ListItemDto<double>)item;
						if (option.Id.ToString("0.00") != exam.EyeNearNoCorrectionLeft.Value.ToString("0.00")) continue;
						cbNncLeft.SelectedItem = item;
						break;
					}
				}
			}
			
			if (exam.EyeNearWithCorrectionRight.HasValue)
			{
				foreach (var item in cbNwcRight.Items)
				{
					if (item is ListItemDto<double>)
					{
						var option = (ListItemDto<double>)item;
						if (option.Id.ToString("0.00") != exam.EyeNearWithCorrectionRight.Value.ToString("0.00")) continue;
						cbNwcRight.SelectedItem = item;
						break;
					}
				}
			}
			if (exam.EyeNearWithCorrectionLeft.HasValue)
			{
				foreach (var item in cbNwcLeft.Items)
				{
					if (item is ListItemDto<double>)
					{
						var option = (ListItemDto<double>)item;
						if (option.Id.ToString("0.00") != exam.EyeNearWithCorrectionLeft.Value.ToString("0.00")) continue;
						cbNwcLeft.SelectedItem = item;
						break;
					}
				}    
			}
			txtColorVision.Text = exam.ColorVision;
			txtFunduscopicRightValue.Text = exam.FunduscopicRight;
			txtFunduscopicLeftValue.Text = exam.FunduscopicLeft;
			txtViewObservations.Text = exam.ViewObservations;
		}

		private void LoadHabits(ClinicalExam exam)
		{
			rbSmokeYes.Checked = exam.Smoke;
			rbSmokeNo.Checked = !rbSmokeYes.Checked;
			txtSmokeCount.Text = exam.SmokeCount;
			rbAlcoholYes.Checked = exam.Alcohol;
			rbAlcoholNo.Checked = !rbAlcoholYes.Checked;
			txtAlcoholCount.Text = exam.AlcoholCount;
			rbSleepYes.Checked = exam.NormalSleep;
			rbSleepNo.Checked = !rbSleepYes.Checked;
			txtSleepHours.Text = exam.SleepHours;
			rbDietYes.Checked = exam.Diet;
			rbDietNo.Checked = !rbDietYes.Checked;
			txtDietDetails.Text = exam.DietDetails;
			rbSportsYes.Checked = exam.Sports;
			rbSportsNo.Checked = !rbSportsYes.Checked;
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
			txtVaccinesGiven.Text = exam.VaccinesRecords;
		}

		private void LoadMedicalExamDetails(ClinicalExam exam)
		{
			UiUtils.CheckExamResult(panelHead, exam.Head);
			txtHead.Text = exam.HeadDetails;
			UiUtils.CheckExamResult(panelEyes, exam.Eyes);
			txtEyes.Text = exam.EyesDetails;
			UiUtils.CheckExamResult(panelEar, exam.Ear);
			txtEar.Text = exam.EarDetails;
			UiUtils.CheckExamResult(panelNose, exam.Nose);
			txtNose.Text = exam.NoseDetails;
			UiUtils.CheckExamResult(panelMouth, exam.Mouth);
			txtMouth.Text = exam.MouthDetails;
			UiUtils.CheckExamResult(panelNeck, exam.Neck);
			txtNeck.Text = exam.NeckDetails;
			UiUtils.CheckExamResult(panelChest, exam.Chest);
			txtChest.Text = exam.ChestDetails;
			UiUtils.CheckExamResult(panelLung, exam.Lung);
			txtLung.Text = exam.LungDetails;
			UiUtils.CheckExamResult(panelHeart, exam.Heart);
			txtHeart.Text = exam.HeartDetails;
            UiUtils.CheckExamResult(panelArtTension,exam.BloodPressureStatus);
		    txtArtTenDetail.Text = exam.BloodPressureStatusDetail;
			UiUtils.CheckExamResult(panelPeripheralVeins, exam.PeripheralVeins);
			txtPeripheralVeins.Text = exam.PeripheralVeinsDetails;
			UiUtils.CheckExamResult(panelPeripheralArteries, exam.PeripheralArteries);
			txtPeripheralArteries.Text = exam.PeripheralArteriesDetails;
			UiUtils.CheckExamResult(panelAbdomen, exam.Abdomen);
			txtAbdomen.Text = exam.AbdomenDetails;
			UiUtils.CheckExamResult(panelHernia, exam.Hernia);
			txtHernia.Text = exam.HerniaDetails;
			UiUtils.CheckExamResult(panelGenitals, exam.Genitals);
			txtGenitals.Text = exam.GenitalsDetails;
            UiUtils.CheckExamResult(panelIMC, exam.IMCStatus);
            txtIMCDetail.Text = exam.IMCStatusDetails;
			UiUtils.CheckExamResult(panelSubcutaneousCellularTissue, exam.SubcutaneousCellularTissue);
			txtSubcutaneousCellularTissue.Text = exam.SubcutaneousCellularTissueDetails;
			UiUtils.CheckExamResult(panelKidneys, exam.Kidneys);
			txtKidneys.Text = exam.KidneysDetails;
			UiUtils.CheckExamResult(panelAnus, exam.Anus);
			txtAnus.Text = exam.AnusDetails;
			UiUtils.CheckExamResult(panelTips, exam.Tips);
			txtTips.Text = exam.TipsDetails;
			UiUtils.CheckExamResult(panelBackbone, exam.Backbone);
			txtBackbone.Text = exam.BackboneDetails;
			UiUtils.CheckExamResult(panelSkin, exam.Skin);
			txtSkin.Text = exam.SkinDetails;
			UiUtils.CheckExamResult(panelLymphNodes, exam.LympNodes);
			txtLymphNodes.Text = exam.LympNodesDetails;
			UiUtils.CheckExamResult(panelNervousSystem, exam.NervousSystem);
			txtNervousSystem.Text = exam.NervousSystemDetails;
			UiUtils.CheckExamResult(panelMotion, exam.Motion);
			txtMotion.Text = exam.MotionDetails;
			UiUtils.CheckExamResult(panelPsychicTest, exam.PsychicTest);
			txtPsychicTest.Text = exam.PsychicTestDetails;
            UiUtils.CheckExamResult(panelBalanceTest, exam.BalanceTest);
            txtBalanceTest.Text = exam.BalanceTestDetails;
			UiUtils.CheckExamResult(panelScars, exam.Scars);
			txtScars.Text = exam.ScarsDetails;
			txtClinicalExamObservations.Text = exam.Observations;
		}

		private void LoadData()
		{
			var pendingPractices = MedicalHistory.GetMedicalHistory(_clinicalHistoryId);
            txtFullName.Text = pendingPractices.Patient.FullName;
            this.Text = string.Format("{0}: {1}", this.Text, pendingPractices.Patient.FullName);
			txtDocumentNumber.Text =
				string.Concat(EnumUtils.AddSpaceInCapitalLetter(pendingPractices.Patient.DocumentType.ToString()), " ",
							  pendingPractices.Patient.DocumentNumber);
			if (FileDirectoryHandler.CheckIfDirectoryExist(ConfigurationManager.AppSettings["filePhotoServerPath"]))
			{
				if (!string.IsNullOrEmpty(pendingPractices.Patient.Photo))
				{
					pbPhoto.ImageLocation = Path.Combine(ConfigurationManager.AppSettings["filePhotoServerPath"],
														 pendingPractices.Patient.Photo);
				}
			}
			else
			{
				pbPhoto.ImageLocation = string.Empty;
			}
			txtClient.Text = pendingPractices.Client.Name;
			txtObservations.Text = pendingPractices.ClinicalHistoryObservations;
            txtAge.Text = UiUtils.GetAge(pendingPractices.Patient.BirthDay).ToString();
            txtTasksToDo.Text = pendingPractices.TaskToDo;
            txtExamType.Text = EnumUtils.AddSpaceInCapitalLetter(pendingPractices.TypeOfExam.ToString());
		}
		private void MarkAsDone()
		{
			var practicesDone = AttentionWorkflow.GetPendingPractices(_clinicalHistoryId, Constants.ClinicId);
			if (practicesDone == null) return;
			if (AttentionWorkflow.MarkAsDone(practicesDone))
			{
				MessageBox.Show(Resources.ClinicalHistoryCompleted, Resources.AllExamsCompleted,
								MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		#endregion        
	}
}
