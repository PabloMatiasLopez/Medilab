using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Linq;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class MedicalHistoryResult
    {
        #region Properties
        public Guid Id { private set; get; }
        public Guid MedicalHistoryId { set; get; }
        public DateTime CreatedDate { set; get; }
        public Guid CreatedById { private set; get; }
        public ClinicalExamResult ChestXRay { set; get; }
        public string ChestXRayDetails { set; get; }
        public ClinicalExamResult ColumnXRay { set; get; }
        public string ColumnXRayDetails { set; get; }
        public ClinicalExamResult Laboratory { set; get; }
        public string LaboratoryDetails { set; get; }
        public ClinicalExamResult Electrocardiogram { set; get; }
        public string ElectrocardiogramDetails { set; get; }
        public ClinicalExamResult Audiometry { set; get; }
        public string AudiometryDetails { set; get; }
        public ClinicalExamResult Spirometry { set; get; }
        public string SpirometryDetails { set; get; }
        public ClinicalExamResult PsychologicalExam { set; get; }
        public string PsychologicalExamDetails { set; get; }
        public ClinicalExamResult Electroencephalogram { set; get; }
        public string ElectroencephalogramDetails { set; get; }
        public ClinicalExamResult Ergometry { set; get; }
        public string ErgometryDetails { set; get; }
        public ClinicalExamResult Ophthalmology { set; get; }
        public string OphthalmologyDetails { set; get; }
        public ClinicalExamResult Cardiology { set; get; }
        public string CardiologyDetails { set; get; }
        public ClinicalExamResult NeurologicalConsultation { set; get; }
        public string NeurologicalConsultationDetails { set; get; }
        public ClinicalExamResult Neumonology { set; get; }
        public string NeumonologyDetails { set; get; }
        public ClinicalExamResult Dental { set; get; }
        public string DentalDetails { set; get; }
        public ClinicalExamResult ORL { set; get; }
        public string ORLDetails { set; get; }
        public ClinicalExamResult VestibularExam { set; get; }
        public string VestibularExamDetails { set; get; }
        public ClinicalExamResult MagneticResonance { set; get; }
        public string MagneticResonanceDetails { set; get; }
        public ClinicalExamResult Ultrasound { set; get; }
        public string UltrasoundDetails { set; get; }
        public string Others { set; get; }
        public string EvaluatedByName { set; get; }
        #endregion
        public MedicalHistoryResult()
        { 

        }
        public MedicalHistoryResult(Guid id)
        {
            Id = id;
        }
        public MedicalHistoryResult Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private MedicalHistoryResult Update()
        {
            using (var context = new MedilabEntities())
            {
                var result = (from r in context.MedicalHistoryResult where r.MedicalHistoryResultId == Id select r).FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                result.CreatedBy = CreatedById = Security.GetCurrentUser();
                result.ChestXRay = (int)ChestXRay;
                result.ChestXRayDetails = ChestXRayDetails;
                result.ColumnXRay = (int)ColumnXRay;
                result.ColumnXRayDetails = ColumnXRayDetails;
                result.Laboratory = (int)Laboratory;
                result.LaboratoryDetails = LaboratoryDetails;
                result.Electrocardiogram = (int)Electrocardiogram;
                result.ElectrocardiogramDetails = ElectrocardiogramDetails;
                result.Audiometry = (int)Audiometry;
                result.AudiometryDetails = AudiometryDetails;
                result.Spirometry = (int)Spirometry;
                result.SpirometryDetails = SpirometryDetails;
                result.PsychologicalExam = (int)PsychologicalExam;
                result.PsychologicalExamDetails = PsychologicalExamDetails;
                result.Electroencephalogram = (int)Electroencephalogram;
                result.ElectroencephalogramDetails = ElectroencephalogramDetails;
                result.Ergometry = (int)Ergometry;
                result.ErgometryDetails = ErgometryDetails;
                result.Ophthalmology = (int)Ophthalmology;
                result.OphthalmologyDetails = OphthalmologyDetails;
                result.CardiologyConsultation = (int)Cardiology;
                result.CardiologyDetails = CardiologyDetails;
                result.NeurologicalConsultation = (int)NeurologicalConsultation;
                result.NeurologicalDetails = NeurologicalConsultationDetails;
                result.NeumonologyConsultation = (int)Neumonology;
                result.NeumonologyDetails = NeumonologyDetails;
                result.Dental = (int)Dental;
                result.DentalDetails = DentalDetails;
                result.ORL = (int)ORL;
                result.ORLDetails = ORLDetails;
                result.VestibularExam = (int)VestibularExam;
                result.VestibularExamDetails = VestibularExamDetails;
                result.MagneticResonance = (int)MagneticResonance;
                result.MagneticResonanceDetails = MagneticResonanceDetails;
                result.Ultrasound = (int)Ultrasound;
                result.UltrasoundDetails = UltrasoundDetails;
                result.Others = Others;
                context.SaveChanges();
                return this;
            }
        }

        private MedicalHistoryResult Insert()
        {
            using (var context = new MedilabEntities())
            {
                var result = new DataAccess.MedicalHistoryResult
                {
                    MedicalHistoryResultId = Id = Guid.NewGuid(),
                    MedicalHistoryId = MedicalHistoryId,
                    DateCompleted = CreatedDate = DateTime.Now,
                    CreatedBy = CreatedById = Security.GetCurrentUser(),
                    ChestXRay = (int)ChestXRay,
                    ChestXRayDetails = ChestXRayDetails,
                    ColumnXRay = (int)ColumnXRay,
                    ColumnXRayDetails = ColumnXRayDetails,
                    Laboratory = (int)Laboratory,
                    LaboratoryDetails = LaboratoryDetails,
                    Electrocardiogram = (int)Electrocardiogram,
                    ElectrocardiogramDetails = ElectrocardiogramDetails,
                    Audiometry = (int)Audiometry,
                    AudiometryDetails = AudiometryDetails,
                    Spirometry = (int)Spirometry,
                    SpirometryDetails = SpirometryDetails,
                    PsychologicalExam = (int)PsychologicalExam,
                    PsychologicalExamDetails = PsychologicalExamDetails,
                    Electroencephalogram = (int)Electroencephalogram,
                    ElectroencephalogramDetails = ElectroencephalogramDetails,
                    Ergometry = (int)Ergometry,
                    ErgometryDetails = ErgometryDetails,
                    Ophthalmology = (int)Ophthalmology,
                    OphthalmologyDetails = OphthalmologyDetails,
                    CardiologyConsultation = (int)Cardiology,
                    CardiologyDetails = CardiologyDetails,
                    NeurologicalConsultation = (int)NeurologicalConsultation,
                    NeurologicalDetails = NeurologicalConsultationDetails,
                    NeumonologyConsultation = (int)Neumonology,
                    NeumonologyDetails = NeumonologyDetails,
                    Dental = (int)Dental,
                    DentalDetails = DentalDetails,
                    ORL = (int)ORL,
                    ORLDetails = ORLDetails,
                    VestibularExam = (int)VestibularExam,
                    VestibularExamDetails = VestibularExamDetails,
                    MagneticResonance = (int)MagneticResonance,
                    MagneticResonanceDetails = MagneticResonanceDetails,
                    Ultrasound = (int)Ultrasound,
                    UltrasoundDetails = UltrasoundDetails,
                    Others = Others
                };
                context.AddToMedicalHistoryResult(result);
                context.SaveChanges();
                return this;
            }
        }
        public MedicalHistoryResult GetMedicalHistory(Guid medicalHistoryId)
        {
            MedicalHistoryId = medicalHistoryId;
            using (var context = new MedilabEntities())
            {
                var result = (from r in context.MedicalHistoryResult where r.MedicalHistoryId == MedicalHistoryId select r).FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                var medicalResult = new MedicalHistoryResult
                {
                    Id = result.MedicalHistoryResultId,
                    MedicalHistoryId = result.MedicalHistoryId,
                    CreatedDate = result.DateCompleted,
                    CreatedById = result.CreatedBy,
                    ChestXRay = (ClinicalExamResult)result.ChestXRay,
                    ChestXRayDetails = result.ChestXRayDetails,
                    ColumnXRay = (ClinicalExamResult)result.ColumnXRay,
                    ColumnXRayDetails = result.ColumnXRayDetails,
                    Laboratory = (ClinicalExamResult)result.Laboratory,
                    LaboratoryDetails = result.LaboratoryDetails,
                    Electrocardiogram = (ClinicalExamResult)result.Electrocardiogram,
                    ElectrocardiogramDetails = result.ElectrocardiogramDetails,
                    Audiometry = (ClinicalExamResult)result.Audiometry,
                    AudiometryDetails = result.AudiometryDetails,
                    Spirometry = (ClinicalExamResult)result.Spirometry,
                    SpirometryDetails = result.SpirometryDetails,
                    PsychologicalExam = (ClinicalExamResult)result.PsychologicalExam,
                    PsychologicalExamDetails = result.PsychologicalExamDetails,
                    Electroencephalogram = (ClinicalExamResult)result.Electroencephalogram,
                    ElectroencephalogramDetails = result.ElectroencephalogramDetails,
                    Ergometry = (ClinicalExamResult)result.Ergometry,
                    ErgometryDetails = result.ErgometryDetails,
                    Ophthalmology = (ClinicalExamResult)result.Ophthalmology,
                    OphthalmologyDetails = result.OphthalmologyDetails,
                    NeurologicalConsultation = (ClinicalExamResult)result.NeurologicalConsultation,
                    NeurologicalConsultationDetails = result.NeurologicalDetails,
                    Neumonology = (ClinicalExamResult)result.NeumonologyConsultation,
                    NeumonologyDetails = result.NeumonologyDetails,
                    Cardiology = (ClinicalExamResult)result.CardiologyConsultation,
                    CardiologyDetails = result.CardiologyDetails,
                    Dental = (ClinicalExamResult)result.Dental,
                    DentalDetails = result.DentalDetails,
                    ORL = (ClinicalExamResult)result.ORL,
                    ORLDetails = result.ORLDetails,
                    VestibularExam = (ClinicalExamResult)result.VestibularExam,
                    VestibularExamDetails = result.VestibularExamDetails,
                    MagneticResonance = (ClinicalExamResult)result.MagneticResonance,
                    MagneticResonanceDetails = result.MagneticResonanceDetails,
                    Ultrasound = (ClinicalExamResult)result.Ultrasound,
                    UltrasoundDetails = result.UltrasoundDetails,
                    Others = result.Others,
                    EvaluatedByName = result.User.UserFirstName + " " + result.User.UserLastName
                };
                return medicalResult;
            }
        }
        public Guid GetPreviousExamId(Guid clinicalHistoryId)
        {
            using (var context = new MedilabEntities())
            {
                var patientId = (from ch in context.MedicalHistory where ch.MedicalHistoryId == clinicalHistoryId select ch.PatiendId).First();

                var lastResult = (from result in context.MedicalHistoryResult
                                  where result.MedicalHistory.PatiendId == patientId
                                  orderby result.DateCompleted descending
                                  select result.MedicalHistoryId).FirstOrDefault();

                if (lastResult != null)
                {
                    return lastResult;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
    }
}
