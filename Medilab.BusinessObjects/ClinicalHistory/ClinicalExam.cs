using System;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class ClinicalExam
    {
        #region Properties
        public Guid Id { get; set; }
        public DateTime CreatedDate { set; get; }
        public Guid MedicalHistoryId { set; get; }
        public ClinicalExamStatus Status { set; get; }
        public Guid ProfessionalId { set; get; }
        public string ProfessionalName { get; private set; }
        //Personal History
        public string HereditaryRecords { set; get; }
        public string PathologicalRecords { set; get; }
        public string SurgicalRecords { set; get; }
        public string TraumaRecors { set; get; }
        public string ObstetricalRecords { set; get; }
        public string OtherRecords { set; get; }
        public string VaccinesRecords { set; get; }
        //Complementary History
        public bool Smoke { set; get; }
        public string SmokeCount { set; get; }
        public bool Alcohol { set; get; }
        public string AlcoholCount { set; get; }
        public bool NormalSleep { set; get; }
        public string SleepHours { set; get; }
        public bool Diet { set; get; }
        public string DietDetails { set; get; }
        public bool Sports { set; get; }
        public string SportsDetails { set; get; }
        //View 
        public bool UseEyeglasses { set; get; }
        public int? EyeFarNoCorrectionRight { set; get; }
        public int? EyeFarNoCorrectionLeft { set; get; }
        public int? EyeFarWithCorrectionRight { set; get; }
        public int? EyeFarWithCorrectionLeft { set; get; }
        public double? EyeNearNoCorrectionRight { set; get; }
        public double? EyeNearNoCorrectionLeft { set; get; }
        public double? EyeNearWithCorrectionRight { set; get; }
        public double? EyeNearWithCorrectionLeft { set; get; }
        public string ColorVision { set; get; }
        public string FunduscopicRight { set; get; }
        public string FunduscopicLeft { set; get; }
        public string ViewObservations { set; get; }
        //Clinical Exam
        public int Size { set; get; }
        public int Weight { set; get; }
        public double BodyMassIndex 
        { 
            get 
            {
                double sizeInMeters = ((double)Size) / 100;
                return Weight / (sizeInMeters * sizeInMeters); 
            } 
        }
        public int? AbdominalCircunference { set; get; }
        public int BloodPressureHight { set; get; }
        public int BloodPressureLow { set; get; }
        public int Pulse { set; get; }
        public int? CervicalPerimeter { set; get; }
        public ClinicalExamResult Head { set; get; }
        public string HeadDetails { set; get; }
        public ClinicalExamResult Eyes { set; get; }
        public string EyesDetails { set; get; }
        public ClinicalExamResult Ear { set; get; }
        public string EarDetails { set; get; }
        public ClinicalExamResult Nose { set; get; }
        public string NoseDetails { set; get; }
        public ClinicalExamResult Mouth { set; get; }
        public string MouthDetails { set; get; }
        public ClinicalExamResult Neck { set; get; }
        public string NeckDetails { set; get; }
        public ClinicalExamResult Chest { set; get; }
        public string ChestDetails { set; get; }
        public ClinicalExamResult Lung { set; get; }
        public string LungDetails { set; get; }
        public ClinicalExamResult Heart { set; get; }
        public string HeartDetails { set; get; }
        public ClinicalExamResult BloodPressureStatus { set; get; }
        public string BloodPressureStatusDetail { set; get; }
        public ClinicalExamResult PeripheralVeins { set; get; }
        public string PeripheralVeinsDetails { set; get; }
        public ClinicalExamResult PeripheralArteries { set; get; }
        public string PeripheralArteriesDetails { set; get; }
        public ClinicalExamResult Abdomen { set; get; }
        public string AbdomenDetails { set; get; }
        public ClinicalExamResult Hernia { set; get; }
        public string HerniaDetails { set; get; }
        public ClinicalExamResult Genitals { set; get; }
        public string GenitalsDetails { set; get; }
        public ClinicalExamResult IMCStatus{ set; get; }
        public string IMCStatusDetails { set; get; }
        public ClinicalExamResult Anus { set; get; }
        public string AnusDetails { set; get; }
        public ClinicalExamResult Tips { set; get; }
        public string TipsDetails { set; get; }
        public ClinicalExamResult Backbone { set; get; }
        public string BackboneDetails { set; get; }
        public ClinicalExamResult Skin { set; get; }
        public string SkinDetails { set; get; }
        public ClinicalExamResult LympNodes { set; get; }
        public string LympNodesDetails { set; get; }
        public ClinicalExamResult NervousSystem { set; get; }
        public string NervousSystemDetails { set; get; }
        public ClinicalExamResult Motion { set; get; }
        public string MotionDetails { set; get; }
        public ClinicalExamResult PsychicTest { set; get; }
        public string PsychicTestDetails { set; get; }
        public ClinicalExamResult BalanceTest { set; get; }
        public string BalanceTestDetails { set; get; }
        public ClinicalExamResult Scars { set; get; }
        public string ScarsDetails { set; get; }
        public ClinicalExamResult Kidneys { set; get; }
        public string KidneysDetails { set; get; }
        public ClinicalExamResult SubcutaneousCellularTissue { set; get; }
        public string SubcutaneousCellularTissueDetails { set; get; }
        public byte[] LastUpdated { get; set; }
        public string Observations { set; get; }

        #endregion

        #region Methods
        public ClinicalExam(){}
        public ClinicalExam(Guid id)
        {
            Id = id;
        }

        public ClinicalExam Save()
        {
            if (IsValid())
            {
                return Id == Guid.Empty ? Insert() : Update();
            }
            throw new Exception("El objecto no es valido");
        }

        private ClinicalExam Update()
        {
            using (var context = new MedilabEntities())
            {
                var clinicalExam =
                    (from ce in context.ClinicalExam where ce.ClinicalExamId == Id select ce).First();
                if (Tools.IsRecordChanged(clinicalExam.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                clinicalExam.Status = (int)Status;
                clinicalExam.HereditaryHistory = HereditaryRecords;
                clinicalExam.PathologicalHistory = PathologicalRecords;
                clinicalExam.SurgicalHistory = SurgicalRecords;
                clinicalExam.TraumaHistory = TraumaRecors;
                clinicalExam.ObstetricalHistory = ObstetricalRecords;
                clinicalExam.OtherHistory = OtherRecords;
                clinicalExam.VaccinesHistory = VaccinesRecords;
                clinicalExam.Smoke = Smoke;
                clinicalExam.SmokeCount = SmokeCount;
                clinicalExam.Alcohol = Alcohol;
                clinicalExam.AlcoholCount = AlcoholCount;
                clinicalExam.NormalSleep = NormalSleep;
                clinicalExam.SleepHours = SleepHours;
                clinicalExam.Diet = Diet;
                clinicalExam.DietDetails = DietDetails;
                clinicalExam.Sports = Sports;
                clinicalExam.SportsDetails = SportsDetails;
                clinicalExam.UseEyeGlasses = UseEyeglasses;
                clinicalExam.EyeFarNoCorrectionRight = EyeFarNoCorrectionRight;
                clinicalExam.EyeFarNoCorrectionLeft = EyeFarNoCorrectionLeft;
                clinicalExam.EyeNearNoCorrectionRight = EyeNearNoCorrectionRight;
                clinicalExam.EyeNearNoCorrectionLeft = EyeNearNoCorrectionLeft;
                clinicalExam.EyeFarWithCorrectionRight = EyeFarWithCorrectionRight;
                clinicalExam.EyeFarWithCorrectionLeft = EyeFarWithCorrectionLeft;
                clinicalExam.EyeNearWithCorrectionRight = EyeNearWithCorrectionRight;
                clinicalExam.EyeNearWithCorrectionLeft = EyeNearWithCorrectionLeft;
                clinicalExam.ColorVision = ColorVision;
                clinicalExam.FunduscopicRight = FunduscopicRight;
                clinicalExam.FunduscopicLeft = FunduscopicLeft;
                clinicalExam.ViewObservations = ViewObservations;
                clinicalExam.Size = Size;
                clinicalExam.Weight = Weight;
                clinicalExam.AbdominalCircunference = AbdominalCircunference;
                clinicalExam.BloodPressureHight = BloodPressureHight;
                clinicalExam.BloodPressureLow = BloodPressureLow;
                clinicalExam.CervicalPerimeter = CervicalPerimeter;
                clinicalExam.Pulse = Pulse;
                clinicalExam.Head = (int)Head;
                clinicalExam.HeadDetails = HeadDetails;
                clinicalExam.Eyes = (int)Eyes;
                clinicalExam.EyesDetails = EyesDetails;
                clinicalExam.Ear = (int)Ear;
                clinicalExam.EarDetails = EarDetails;
                clinicalExam.Nose = (int)Nose;
                clinicalExam.NoseDetails = NoseDetails;
                clinicalExam.Mouth = (int)Mouth;
                clinicalExam.MouthDetails = MouthDetails;
                clinicalExam.Neck = (int)Neck;
                clinicalExam.NeckDetails = NeckDetails;
                clinicalExam.Chest = (int)Chest;
                clinicalExam.ChestDetails = ChestDetails;
                clinicalExam.Lung = (int)Lung;
                clinicalExam.LungDetails = LungDetails;
                clinicalExam.Heart = (int)Heart;
                clinicalExam.HeartDetails = HeartDetails;
                clinicalExam.BloodPressureStatus = (int)BloodPressureStatus;
                clinicalExam.BloodPressureStatusDetail = BloodPressureStatusDetail;
                clinicalExam.PeripheralVeins = (int)PeripheralVeins;
                clinicalExam.PeripheralVeinsDetails = PeripheralVeinsDetails;
                clinicalExam.PeripheralArteries = (int)PeripheralArteries;
                clinicalExam.PeripheralArteriesDetails = PeripheralArteriesDetails;
                clinicalExam.Abdomen = (int)Abdomen;
                clinicalExam.AbdomenDetails = AbdomenDetails;
                clinicalExam.Hernia = (int)Hernia;
                clinicalExam.HerniaDetails = HerniaDetails;
                clinicalExam.Genitals = (int)Genitals;
                clinicalExam.GenitalsDetails = GenitalsDetails;
                clinicalExam.IMCStatus = (int)IMCStatus;
                clinicalExam.IMCStatusDetail = IMCStatusDetails;
                clinicalExam.Anus = (int)Anus;
                clinicalExam.AnusDetails = AnusDetails;
                clinicalExam.Tips = (int)Tips;
                clinicalExam.TipsDetails = TipsDetails;
                clinicalExam.Backbone = (int)Backbone;
                clinicalExam.BackboneDetails = BackboneDetails;
                clinicalExam.Skin = (int)Skin;
                clinicalExam.SkinDetails = SkinDetails;
                clinicalExam.LympNodes = (int)LympNodes;
                clinicalExam.LympNodesDetails = LympNodesDetails;
                clinicalExam.NervousSystem = (int)NervousSystem;
                clinicalExam.NervousSystemDetails = NervousSystemDetails;
                clinicalExam.Motion = (int)Motion;
                clinicalExam.MotionDetails = MotionDetails;
                clinicalExam.PsychicTest = (int)PsychicTest;
                clinicalExam.PsychicTestDetails = PsychicTestDetails;
                clinicalExam.BalanceTest = (int)BalanceTest;
                clinicalExam.BalanceTestDetails = BalanceTestDetails;
                clinicalExam.Scars = (int)Scars;
                clinicalExam.ScarsDetails = ScarsDetails;
                clinicalExam.Kidneys = (int)Kidneys;
                clinicalExam.KidneysDetails = KidneysDetails;
                clinicalExam.SubcutaneousCellularTissue = (int)SubcutaneousCellularTissue;
                clinicalExam.SubcutaneousCellularTissueDetails = SubcutaneousCellularTissueDetails;
                clinicalExam.Observations = Observations;

                var modifiedFields = Utilities.GetModifiedFields(context, clinicalExam.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.ClinicalExam, AuditOperations.Update, Id,
                                    modifiedFields);

                context.SaveChanges();
                LastUpdated = clinicalExam.LastUpdated;
                return this;
            }
        }

        private bool IsValid()
        {
            //TODO: Need to implement validation
            //check if something is patologic it has to have a comment
            return true;
        }
        private ClinicalExam Insert()
        {
            using (var context = new MedilabEntities())
            {
                var professionalId = Security.GetCurrentUser();
                var clinicalExam = new DataAccess.ClinicalExam
                {
                    ClinicalExamId = Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Status = (int)Status,
                    MedicalHistory = (from mh in context.MedicalHistory where mh.MedicalHistoryId == MedicalHistoryId select mh).First(),
                    HereditaryHistory = HereditaryRecords,
                    PathologicalHistory = PathologicalRecords,
                    SurgicalHistory = SurgicalRecords,
                    TraumaHistory = TraumaRecors,
                    ObstetricalHistory = ObstetricalRecords,
                    OtherHistory = OtherRecords,
                    VaccinesHistory = VaccinesRecords,
                    Smoke = Smoke,
                    SmokeCount = SmokeCount,
                    Alcohol = Alcohol,
                    AlcoholCount = AlcoholCount,
                    NormalSleep = NormalSleep,
                    SleepHours = SleepHours,
                    Diet = Diet,
                    DietDetails = DietDetails,
                    Sports = Sports,
                    SportsDetails = SportsDetails,
                    UseEyeGlasses = UseEyeglasses,
                    EyeFarNoCorrectionRight = EyeFarNoCorrectionRight,
                    EyeFarNoCorrectionLeft = EyeFarNoCorrectionLeft,
                    EyeFarWithCorrectionRight = EyeFarWithCorrectionRight,
                    EyeFarWithCorrectionLeft = EyeFarWithCorrectionLeft,
                    EyeNearNoCorrectionRight = EyeNearNoCorrectionRight,
                    EyeNearNoCorrectionLeft = EyeNearNoCorrectionLeft,
                    EyeNearWithCorrectionRight = EyeNearWithCorrectionRight,
                    EyeNearWithCorrectionLeft = EyeNearWithCorrectionLeft,
                    ColorVision = ColorVision,
                    FunduscopicRight = FunduscopicRight,
                    FunduscopicLeft = FunduscopicLeft,
                    ViewObservations = ViewObservations,
                    Size = Size,
                    Weight = Weight,
                    AbdominalCircunference = AbdominalCircunference,
                    BloodPressureHight = BloodPressureHight,
                    BloodPressureLow = BloodPressureLow,
                    Pulse = Pulse,
                    CervicalPerimeter = CervicalPerimeter,
                    Head = (int)Head,
                    HeadDetails = HeadDetails,
                    Eyes = (int)Eyes,
                    EyesDetails = EyesDetails,
                    Ear = (int)Ear,
                    EarDetails = EarDetails,
                    Nose = (int)Nose,
                    NoseDetails = NoseDetails,
                    Mouth = (int)Mouth,
                    MouthDetails = MouthDetails,
                    Neck = (int)Neck,
                    NeckDetails = NeckDetails,
                    Chest = (int)Chest,
                    ChestDetails = ChestDetails,
                    Lung = (int)Lung,
                    LungDetails = LungDetails,
                    Heart = (int)Heart,
                    HeartDetails = HeartDetails,
                    BloodPressureStatus = (int)BloodPressureStatus,
                    BloodPressureStatusDetail = BloodPressureStatusDetail,
                    PeripheralVeins = (int)PeripheralVeins,
                    PeripheralVeinsDetails = PeripheralVeinsDetails,
                    PeripheralArteries = (int)PeripheralArteries,
                    PeripheralArteriesDetails = PeripheralArteriesDetails,
                    Abdomen = (int)Abdomen,
                    AbdomenDetails = AbdomenDetails,
                    Hernia = (int)Hernia,
                    HerniaDetails = HerniaDetails,
                    Genitals = (int)Genitals,
                    GenitalsDetails = GenitalsDetails,
                    IMCStatus = (int) IMCStatus,
                    IMCStatusDetail = IMCStatusDetails,
                    Anus = (int)Anus,
                    AnusDetails = AnusDetails,
                    Tips = (int)Tips,
                    TipsDetails = TipsDetails,
                    Backbone = (int)Backbone,
                    BackboneDetails = BackboneDetails,
                    Skin = (int)Skin,
                    SkinDetails = SkinDetails,
                    LympNodes = (int)LympNodes,
                    LympNodesDetails = LympNodesDetails,
                    NervousSystem = (int)NervousSystem,
                    NervousSystemDetails = NervousSystemDetails,
                    Motion = (int)Motion,
                    MotionDetails = MotionDetails,
                    PsychicTest = (int)PsychicTest,
                    PsychicTestDetails = PsychicTestDetails,
                    BalanceTest = (int)BalanceTest,
                    BalanceTestDetails = BalanceTestDetails,
                    Scars = (int)Scars,
                    ScarsDetails = ScarsDetails,
                    Kidneys = (int)Kidneys,
                    KidneysDetails = KidneysDetails,
                    SubcutaneousCellularTissue = (int)SubcutaneousCellularTissue,
                    SubcutaneousCellularTissueDetails = SubcutaneousCellularTissueDetails,
                    Observations = Observations,
                    ProfessionalId = professionalId
                };
                context.AddToClinicalExam(clinicalExam);
                
                Audit.Audit.LogAudit(context, professionalId, ObjectTypes.ClinicalExam, AuditOperations.Insert,
                                    clinicalExam.ClinicalExamId, clinicalExam.MedicalHistoryId.ToString());
                context.SaveChanges();
                return this;
            }
        }

        internal static ClinicalExam GetClinicalExamByMedicalHistory(Guid medicalHistoryId, MedilabEntities context)
        {
            var clinicalExam =
                (from ce in context.ClinicalExam where ce.MedicalHistoryId == medicalHistoryId select ce).FirstOrDefault
                    ();
            if (clinicalExam != null)
            {
                var proffesionalId = Guid.Empty;
                var proffesionalName = string.Empty;
                if(clinicalExam.ProfessionalId.HasValue)
                {
                    proffesionalId = clinicalExam.ProfessionalId.Value;
                    var user = (from u in context.User where u.UserId == proffesionalId select u).First();
                    proffesionalName = string.Format("{0} {1}", user.UserFirstName, user.UserLastName);
                }
                return new ClinicalExam
                           {
                               Id = clinicalExam.ClinicalExamId,
                               CreatedDate = clinicalExam.CreatedDate,
                               Status = (ClinicalExamStatus)clinicalExam.Status,
                               ProfessionalId = proffesionalId,
                               ProfessionalName = proffesionalName,
                               //Personal History
                               HereditaryRecords = clinicalExam.HereditaryHistory,
                               PathologicalRecords = clinicalExam.PathologicalHistory,
                               SurgicalRecords = clinicalExam.SurgicalHistory,
                               TraumaRecors = clinicalExam.TraumaHistory,
                               ObstetricalRecords = clinicalExam.ObstetricalHistory,
                               OtherRecords = clinicalExam.OtherHistory,
                               VaccinesRecords = clinicalExam.VaccinesHistory,
                               //Complementary History
                               Smoke = clinicalExam.Smoke,
                               SmokeCount = clinicalExam.SmokeCount,
                               Alcohol = clinicalExam.Alcohol,
                               AlcoholCount = clinicalExam.AlcoholCount,
                               NormalSleep = clinicalExam.NormalSleep,
                               SleepHours = clinicalExam.SleepHours,
                               Diet = clinicalExam.Diet,
                               DietDetails = clinicalExam.DietDetails,
                               Sports = clinicalExam.Sports,
                               SportsDetails = clinicalExam.SportsDetails,
                               //View 
                               UseEyeglasses = clinicalExam.UseEyeGlasses,
                               EyeFarNoCorrectionRight = clinicalExam.EyeFarNoCorrectionRight,
                               EyeFarNoCorrectionLeft = clinicalExam.EyeFarNoCorrectionLeft,
                               EyeFarWithCorrectionRight = clinicalExam.EyeFarWithCorrectionRight,
                               EyeFarWithCorrectionLeft = clinicalExam.EyeFarWithCorrectionLeft,
                               EyeNearNoCorrectionRight = clinicalExam.EyeNearNoCorrectionRight,
                               EyeNearNoCorrectionLeft = clinicalExam.EyeNearNoCorrectionLeft,
                               EyeNearWithCorrectionRight = clinicalExam.EyeNearWithCorrectionRight,
                               EyeNearWithCorrectionLeft = clinicalExam.EyeNearWithCorrectionLeft,
                               ColorVision = clinicalExam.ColorVision,
                               FunduscopicRight = clinicalExam.FunduscopicRight,
                               FunduscopicLeft = clinicalExam.FunduscopicLeft,
                               ViewObservations = clinicalExam.ViewObservations,
                               //Clinical Exam
                               Size = clinicalExam.Size,
                               Weight = clinicalExam.Weight,
                               AbdominalCircunference = clinicalExam.AbdominalCircunference,
                               BloodPressureHight = clinicalExam.BloodPressureHight,
                               BloodPressureLow = clinicalExam.BloodPressureLow,
                               Pulse = clinicalExam.Pulse,
                               CervicalPerimeter = clinicalExam.CervicalPerimeter,
                               Head = (ClinicalExamResult)clinicalExam.Head,
                               HeadDetails = clinicalExam.HeadDetails,
                               Eyes = (ClinicalExamResult)clinicalExam.Eyes,
                               EyesDetails = clinicalExam.EyesDetails,
                               Ear = (ClinicalExamResult)clinicalExam.Ear,
                               EarDetails = clinicalExam.EarDetails,
                               Nose = (ClinicalExamResult)clinicalExam.Nose,
                               NoseDetails = clinicalExam.NoseDetails,
                               Mouth = (ClinicalExamResult)clinicalExam.Mouth,
                               MouthDetails = clinicalExam.MouthDetails,
                               Neck = (ClinicalExamResult)clinicalExam.Neck,
                               NeckDetails = clinicalExam.NeckDetails,
                               Chest = (ClinicalExamResult)clinicalExam.Chest,
                               ChestDetails = clinicalExam.ChestDetails,
                               Lung = (ClinicalExamResult)clinicalExam.Lung,
                               LungDetails = clinicalExam.LungDetails,
                               Heart = (ClinicalExamResult)clinicalExam.Heart,
                               HeartDetails = clinicalExam.HeartDetails,
                               BloodPressureStatus = (ClinicalExamResult)clinicalExam.BloodPressureStatus,
                               BloodPressureStatusDetail = clinicalExam.BloodPressureStatusDetail,
                               PeripheralVeins = (ClinicalExamResult)clinicalExam.PeripheralVeins,
                               PeripheralVeinsDetails = clinicalExam.PeripheralVeinsDetails,
                               PeripheralArteries = (ClinicalExamResult)clinicalExam.PeripheralArteries,
                               PeripheralArteriesDetails = clinicalExam.PeripheralArteriesDetails,
                               Abdomen = (ClinicalExamResult)clinicalExam.Abdomen,
                               AbdomenDetails = clinicalExam.AbdomenDetails,
                               Hernia = (ClinicalExamResult)clinicalExam.Hernia,
                               HerniaDetails = clinicalExam.HerniaDetails,
                               Genitals = (ClinicalExamResult)clinicalExam.Genitals,
                               GenitalsDetails = clinicalExam.GenitalsDetails,
                               IMCStatus = (ClinicalExamResult)clinicalExam.IMCStatus,
                               IMCStatusDetails = clinicalExam.IMCStatusDetail,
                               Anus = (ClinicalExamResult)clinicalExam.Anus,
                               AnusDetails = clinicalExam.AnusDetails,
                               Tips = (ClinicalExamResult)clinicalExam.Tips,
                               TipsDetails = clinicalExam.TipsDetails,
                               Backbone = (ClinicalExamResult)clinicalExam.Backbone,
                               BackboneDetails = clinicalExam.BackboneDetails,
                               Skin = (ClinicalExamResult)clinicalExam.Skin,
                               SkinDetails = clinicalExam.SkinDetails,
                               LympNodes = (ClinicalExamResult)clinicalExam.LympNodes,
                               LympNodesDetails = clinicalExam.LympNodesDetails,
                               NervousSystem = (ClinicalExamResult)clinicalExam.NervousSystem,
                               NervousSystemDetails = clinicalExam.NervousSystemDetails,
                               Motion = (ClinicalExamResult)clinicalExam.Motion,
                               MotionDetails = clinicalExam.MotionDetails,
                               PsychicTest = (ClinicalExamResult)clinicalExam.PsychicTest,
                               PsychicTestDetails = clinicalExam.PsychicTestDetails,
                               BalanceTest = (ClinicalExamResult)clinicalExam.BalanceTest,
                               BalanceTestDetails = clinicalExam.BalanceTestDetails,
                               Scars = (ClinicalExamResult)clinicalExam.Scars,
                               ScarsDetails = clinicalExam.ScarsDetails,
                               Kidneys = (ClinicalExamResult)clinicalExam.Kidneys,
                               KidneysDetails = clinicalExam.KidneysDetails,
                               SubcutaneousCellularTissue = (ClinicalExamResult)clinicalExam.SubcutaneousCellularTissue,
                               SubcutaneousCellularTissueDetails = clinicalExam.SubcutaneousCellularTissueDetails,
                               LastUpdated = clinicalExam.LastUpdated,
                               Observations = clinicalExam.Observations
                           };
            }
            return null;
        }

        #endregion
    }
}
