using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using Client = Medilab.BusinessObjects.Configuration.Client;
using ClientArea = Medilab.BusinessObjects.Configuration.ClientArea;
using ExamType = Medilab.BusinessObjects.Utils.ExamType;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class MedicalHistory
    {
        #region Properties

        public Guid Id { get; set; }
        public DateTime CreatedDate { set; get; }
        public Patient.Patient Patient { set; get; }
        public Client Client { set; get; }
        public ClientArea Area { set; get; }
        public ExamType TypeOfExam { set; get; }
        public string TaskToDo { set; get; }
        public string WorkArea { set; get; }
        public string ClinicalHistoryObservations { set; get; }
        public ClinicalHistoryStatus Status { set; get; }
        public byte[] LastUpdated { get; set; }
        public ClinicalExam MedicalExam { set; get; }
        public DateTime LastUpdatedDate { set; get; }
        public ClinicaHistoryResult Result { set; get; }
        public BindingList<MedicalHistoryPractice> Practices { set; get; }
        public BindingList<MedicalHistoryPracticeDto> PracticeDisplayList { set; get; }
        public bool IsHighPriority { set; get; }
        public string ResultObservations { set; get; }
        public string AnotherTypeDescription { set; get; }
        public int DailyPatientNumber { set; get; }
        public MedicalHistoryResult HistoryResult { set; get; }
        public Guid? ChargeToClient { set; get; }
        public Guid ReceptionUser { set; get; }
        public string ReceptionUserName { get; private set; }

        #endregion

        #region Methods

        public MedicalHistory()
        {
        }

        public MedicalHistory(Guid id)
        {
            Id = id;
            Practices = new BindingList<MedicalHistoryPractice>();
            PracticeDisplayList = new BindingList<MedicalHistoryPracticeDto>();
        }

        public MedicalHistory Save()
        {
            if (IsValid())
            {
                return Id == Guid.Empty ? Insert() : Update();
            }
            throw new Exception("El objecto no es valido");
        }

        private bool IsValid()
        {
            return !(Patient.Id == Guid.Empty) &&
                   !(Client.Id == Guid.Empty); 
        }

        private MedicalHistory Update()
        {
            using (var context = new MedilabEntities())
            {
                var clinicalHistory = (from p in context.MedicalHistory where p.MedicalHistoryId == Id select p).First();
                if (Tools.IsRecordChanged(clinicalHistory.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                clinicalHistory.ClientId = Client.Id;
                clinicalHistory.Status = (int)Status;
                clinicalHistory.ExamTypeId = (int)TypeOfExam;
                clinicalHistory.TasksToDo = TaskToDo;
                clinicalHistory.WorkArea = WorkArea;
                clinicalHistory.Observations = ClinicalHistoryObservations;
                clinicalHistory.LastUpdateUserId = Security.GetCurrentUser();
                clinicalHistory.LastUpdatedDate = DateTime.Now;
                clinicalHistory.ResultId = (int)Result;
                clinicalHistory.IsHighPriority = IsHighPriority;
                clinicalHistory.ResultObservations = ResultObservations;
                clinicalHistory.AnotherTypeDescription = AnotherTypeDescription;
                clinicalHistory.ChargeToClientId = ChargeToClient;
                if (Area == null)
                {
                    clinicalHistory.ClientAreaId = null;
                }
                else
                {
                    clinicalHistory.ClientAreaId = Area.Id;
                }
                //Save practices
                foreach (var practice in Practices)
                {
                    if (practice.IsNew)
                    {
                        clinicalHistory.Status = (int)ClinicalHistoryStatus.Incompleta;
                        practice.Save(context);
                    }
                    else if (practice.MarkForDetele)
                    {
                        practice.Remove(context);
                    }
                }

                var modifiedFields = Utilities.GetModifiedFields(context, clinicalHistory.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.MedicalHistory,
                                     AuditOperations.Update, Id,
                                     modifiedFields);
                context.SaveChanges();
                LastUpdated = clinicalHistory.LastUpdated;
                return this;
            }
        }

        private MedicalHistory Insert()
        {
            using (var context = new MedilabEntities())
            {
                ReceptionUser = Security.GetCurrentUser();
                var clinicalHistory = new DataAccess.MedicalHistory
                                          {
                                              MedicalHistoryId = Id = Guid.NewGuid(),
                                              CreatedDate = DateTime.Now,
                                              Status = (int) Status,
                                              PatiendId = Patient.Id,
                                              ClientId = Client.Id,
                                              ExamTypeId = (int) TypeOfExam,
                                              TasksToDo = TaskToDo,
                                              WorkArea = WorkArea,
                                              Observations = ClinicalHistoryObservations,
                                              LastUpdateUserId = Security.GetCurrentUser(),
                                              LastUpdatedDate = DateTime.Now,
                                              ResultId = (int) ClinicaHistoryResult.NoEvaluado,
                                              IsHighPriority = IsHighPriority,
                                              ResultObservations = ResultObservations,
                                              AnotherTypeDescription = AnotherTypeDescription,
                                              DailyPatientNumber = GetNextPatientNumber(),
                                              ChargeToClientId = ChargeToClient,
                                              ReceptionUser = ReceptionUser
                                          };
                if (Area == null)
                {
                    clinicalHistory.ClientAreaId = null;
                }
                else
                {
                    clinicalHistory.ClientAreaId = Area.Id;
                }
                context.AddToMedicalHistory(clinicalHistory);
                if(Practices.Count > 0)
                {
                    //Save practices
                    foreach (var practice in Practices)
                    {
                        practice.MedicalHistoryId = Id;
                        practice.Status = ClinicalExamStatus.Incompleto;
                        practice.Save(context);
                    }
                }
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.MedicalHistory,
                                     AuditOperations.Insert,
                                     clinicalHistory.MedicalHistoryId, clinicalHistory.PatiendId.ToString());
                context.SaveChanges();
                LastUpdated = clinicalHistory.LastUpdated;
                return this;
            }
        }

        public static IEnumerable<MedicalHistoryDto> GetMedicalHistoryList()
        {
            return GetMedicalHistoryList(new ClinicalExamFilterCriteria());
        }

        public static IEnumerable<MedicalHistoryDto> GetMedicalHistoryList(ClinicalExamFilterCriteria filterCriteria)
        {
            using (var context = new MedilabEntities())
            {
                var filterFromDate = filterCriteria.FilterByFromDate.Date;

                var filterToDate = filterCriteria.FilterByToDate.Date.AddDays(1);

                var clinicalHistoryList = (from medicalHistory in context.MedicalHistory
                                           where
                                               //filter by patient
                                               (string.IsNullOrEmpty(filterCriteria.FilterByPatient) ||
                                                (medicalHistory.Patient.DocumentNumber.Contains(
                                                    filterCriteria.FilterByPatient) ||
                                                 medicalHistory.Patient.LastName.Contains(filterCriteria.FilterByPatient))) &&
                                               //filter by document number
                                               (string.IsNullOrEmpty(filterCriteria.FilterByDocumentNumber) ||
                                                (medicalHistory.Patient.DocumentNumber.Contains(
                                                    filterCriteria.FilterByDocumentNumber))) &&
                                               //filter by client
                                               (string.IsNullOrEmpty(filterCriteria.FilterByClient) ||
                                                (medicalHistory.Client.ClientName.Contains(filterCriteria.FilterByClient) ||
                                                 medicalHistory.Client.ClientCuit.Contains(filterCriteria.FilterByClient))) &&
                                               //filter by status
                                               ((filterCriteria.FilterByStatus == 0) ||
                                                (medicalHistory.Status == (int)filterCriteria.FilterByStatus)) &&
                                               //filter by created date
                                               (medicalHistory.CreatedDate >= filterFromDate &&
                                                medicalHistory.CreatedDate < filterToDate)
                                           select new
                                                      {
                                                          medicalHistory.MedicalHistoryId,
                                                          medicalHistory.CreatedDate,
                                                          medicalHistory.LastUpdatedDate,
                                                          medicalHistory.DailyPatientNumber,
                                                          medicalHistory.Client.ClientName,
                                                          medicalHistory.Patient.LastName,
                                                          medicalHistory.Patient.FirstName,
                                                          medicalHistory.Patient.DocumentNumber,
                                                          medicalHistory.Status,
                                                          medicalHistory.SystemVersion
                                                      });
                var finalList = new List<MedicalHistoryDto>();
                foreach (var item in clinicalHistoryList)
                {
                    finalList.Add(new MedicalHistoryDto
                    {
                        Id = item.MedicalHistoryId,
                        PatientNumber = item.DailyPatientNumber,
                        DocumentNumber = item.DocumentNumber,
                        PatientName = string.Format("{0}, {1}", item.LastName, item.FirstName),
                        ClientName = item.ClientName,
                        Status =
                            ((ClinicalHistoryStatus)
                             Enum.Parse(typeof(ClinicalHistoryStatus), item.Status.ToString(CultureInfo.InvariantCulture))).
                            ToString(),
                        LastUpdatedDate = item.LastUpdatedDate,
                        Version = item.SystemVersion
                    }
                    );
                }
                return finalList;
            }
        }

        public static MedicalHistory GetMedicalHistory(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var tempMedicalHistory = (from p in context.MedicalHistory
                                          where p.MedicalHistoryId == id
                                          select
                                              new
                                                  {
                                                      p.MedicalHistoryId,
                                                      p.CreatedDate,
                                                      p.LastUpdated,
                                                      p.Observations,
                                                      p.ExamTypeId,
                                                      p.TasksToDo,
                                                      p.WorkArea,
                                                      p.Status,
                                                      p.LastUpdatedDate,
                                                      p.ResultId,
                                                      p.Client,
                                                      p.ClientArea,
                                                      p.Patient,
                                                      p.IsHighPriority,
                                                      p.ResultObservations,
                                                      p.AnotherTypeDescription,
                                                      p.DailyPatientNumber,
                                                      p.ChargeToClientId,
                                                      p.ReceptionUser
                                                  }).FirstOrDefault();
                if (tempMedicalHistory != null)
                {
                    Guid proffesionalId = Guid.Empty;
                    string receptionUserName = string.Empty;
                    if (tempMedicalHistory.ReceptionUser.HasValue)
                    {
                        proffesionalId = tempMedicalHistory.ReceptionUser.Value;
                        
                        var user = (from u in context.User where u.UserId == proffesionalId select u).First();
                        receptionUserName = string.Format("{0} {1}", user.UserFirstName, user.UserLastName);
                    }
                    
                    var medicalHistory = new MedicalHistory
                                             {
                                                 Id = tempMedicalHistory.MedicalHistoryId,
                                                 CreatedDate = tempMedicalHistory.CreatedDate,
                                                 LastUpdated = tempMedicalHistory.LastUpdated,
                                                 ClinicalHistoryObservations = tempMedicalHistory.Observations,
                                                 TypeOfExam = (ExamType) tempMedicalHistory.ExamTypeId,
                                                 TaskToDo = tempMedicalHistory.TasksToDo,
                                                 WorkArea = tempMedicalHistory.WorkArea,
                                                 Status = (ClinicalHistoryStatus) tempMedicalHistory.Status,
                                                 LastUpdatedDate = tempMedicalHistory.LastUpdatedDate,
                                                 Result = (ClinicaHistoryResult) tempMedicalHistory.ResultId,
                                                 Patient =
                                                     BusinessObjects.Patient.Patient.GetPatient(
                                                         tempMedicalHistory.Patient.PatientId),
                                                 Client = Client.GetClient(tempMedicalHistory.Client),
                                                 MedicalExam =
                                                     ClinicalExam.GetClinicalExamByMedicalHistory(
                                                         tempMedicalHistory.MedicalHistoryId, context),
                                                 IsHighPriority = tempMedicalHistory.IsHighPriority,
                                                 ResultObservations = tempMedicalHistory.ResultObservations,
                                                 Area = null,
                                                 AnotherTypeDescription = tempMedicalHistory.AnotherTypeDescription,
                                                 DailyPatientNumber = tempMedicalHistory.DailyPatientNumber,
                                                 ChargeToClient = (tempMedicalHistory.ChargeToClientId != null ?  tempMedicalHistory.ChargeToClientId : Guid.Empty),
                                                 ReceptionUserName = receptionUserName
                                             };
                    var practices = (from p in context.MedicalHistoryPractice
                                     where p.MedicalHistoryId == id
                                     select
                                         new
                                             {
                                                 p.MedicalHistoryPracticeId,
                                                 p.MedicalPractice.MedicalPracticeId,
                                                 p.MedicalPractice.PracticeCode,
                                                 p.MedicalPractice.PracticeName,
                                                 p.MedicalPractice.PracticeDescription,
                                                 p.Status,
                                                 p.GroupId,
                                                 p.MedicalPractice.IsExternal
                                             }).ToList();
                    if (tempMedicalHistory.ClientArea != null)
                    {
                        medicalHistory.Area = new ClientArea(tempMedicalHistory.ClientArea.ClientAreaId)
                                                  {
                                                      Name = tempMedicalHistory.ClientArea.AreaName
                                                  };
                    }
                    medicalHistory.Practices = new BindingList<MedicalHistoryPractice>();
                    medicalHistory.PracticeDisplayList = new BindingList<MedicalHistoryPracticeDto>();
                    foreach (var practice in practices)
                    {
                        medicalHistory.Practices.Add(new MedicalHistoryPractice(practice.MedicalHistoryPracticeId)
                                                         {
                                                             MedicalHistoryId = id,
                                                             MedicalPracticeId = practice.MedicalPracticeId,
                                                             Status = (ClinicalExamStatus) practice.Status,
                                                             GroupId = practice.GroupId
                                                         });
                        medicalHistory.PracticeDisplayList.Add(new MedicalHistoryPracticeDto
                                                                   {
                                                                       Id = practice.MedicalHistoryPracticeId,
                                                                       ClinicalHistoryId = id,
                                                                       MedicalPracticeId = practice.MedicalPracticeId,
                                                                       Code = practice.PracticeCode,
                                                                       Name = practice.PracticeName,
                                                                       Description = practice.PracticeDescription,
                                                                       Status = (ClinicalExamStatus) practice.Status,
                                                                       GroupId = practice.GroupId,
                                                                       IsExternal = practice.IsExternal
                                                                   });
                    }
                    return medicalHistory;
                }
            }
            throw new Exception("Registro no encontrado");
        }

        public static void UpdateMedicalHistoryStatus(Guid id, ClinicalHistoryStatus status)
        {
            using (var context = new MedilabEntities())
            {
                var medicalHistory = (from p in context.MedicalHistory
                                          where p.MedicalHistoryId == id
                                          select p).First();
                medicalHistory.Status = (int) status;
                context.SaveChanges();
            }
        }

        public static void UpdateMedicalHistoryResult(Guid id, ClinicaHistoryResult result, string observations)
        {
            using (var context = new MedilabEntities())
            {
                var medicalHistory = (from p in context.MedicalHistory
                                      where p.MedicalHistoryId == id
                                      select p).First();
                medicalHistory.ResultId = (int) result;
                medicalHistory.ResultObservations = observations;
                medicalHistory.Status = (int) ClinicalHistoryStatus.Evaluada;
                context.SaveChanges();
            }
        }

        private int GetNextPatientNumber()
        {
            int nextPatientNumber;
            DateTime currentDate = DateTime.Now.Date;
            using (var context = new MedilabEntities())
            {
                nextPatientNumber = (from p in context.MedicalHistory
                                     where EntityFunctions.TruncateTime(p.CreatedDate) == currentDate
                                     orderby p.DailyPatientNumber descending
                                      select p.DailyPatientNumber).FirstOrDefault();
            }

            return ++nextPatientNumber;
        }
        #endregion
    }
}