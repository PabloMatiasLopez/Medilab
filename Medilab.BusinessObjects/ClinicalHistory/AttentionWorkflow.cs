using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Patient;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class AttentionWorkflow
    {
        public static IEnumerable<PendingPatientDto> GetPendingPractices(bool allDays)
        {
            using (var context = new MedilabEntities())
            {
                var userId = Security.GetCurrentUser();
                
                var practices = (from p in context.MedicalHistoryPractice
                                 where
                                     p.MedicalHistory.Status == (int) ClinicalHistoryStatus.Incompleta &&
                                     (allDays || 
                                     (p.MedicalHistory.CreatedDate.Year == DateTime.Now.Year &&
                                      p.MedicalHistory.CreatedDate.Month == DateTime.Now.Month &&
                                      p.MedicalHistory.CreatedDate.Day == DateTime.Now.Day)) &&
                                     p.MedicalPractice.Speciality.SpecialityId ==
                                     (from u in context.User where u.UserId == userId select u.Speciality.SpecialityId).
                                         FirstOrDefault() &&
                                     p.Status == (int) ClinicalExamStatus.Incompleto &&
                                     !p.MedicalPractice.IsExternal
                                 select new
                                            {
                                                ClinicalHistoryId = p.MedicalHistoryId,
                                                PatientId = p.MedicalHistory.PatiendId,
                                                p.MedicalHistory.Patient.DocumentNumber,
                                                p.MedicalHistory.IsHighPriority,
                                                p.MedicalHistory.CreatedDate,
                                                PatientName = p.MedicalHistory.Patient.LastName + ", " + p.MedicalHistory.Patient.FirstName
                                            }).Distinct().ToList();
                practices = (from p in practices orderby !p.IsHighPriority , p.CreatedDate select p).ToList();

                var rta = new List<PendingPatientDto>();
                foreach (var medicalHistoryPractice in practices)
                {
                    MedicalHistory clinicalHistory =
                        MedicalHistory.GetMedicalHistory(medicalHistoryPractice.ClinicalHistoryId);
                    rta.Add(new PendingPatientDto
                                {
                                    ClinicalHistoryId = medicalHistoryPractice.ClinicalHistoryId,
                                    PatientId = medicalHistoryPractice.PatientId,
                                    DocumentNumber = medicalHistoryPractice.DocumentNumber,
                                    PatientName = medicalHistoryPractice.PatientName,
                                    PatientNumber = clinicalHistory.DailyPatientNumber
                                });
                }
                return rta;
            }
        }

        public static PatientPracticesDto GetPendingPractices(Guid medicalHistoryId, Guid specialityId)
        {
            using (var context = new MedilabEntities())
            {
                var pendingPractices = new List<PendingPracticeDto>();
                var practices = (from p in context.MedicalHistoryPractice
                                 where p.MedicalHistoryId == medicalHistoryId &&
                                       p.MedicalPractice.Speciality.SpecialityId == specialityId &&
                                       p.Status == (int) ClinicalExamStatus.Incompleto &&
                                       !p.MedicalPractice.IsExternal
                                 select new
                                            {
                                                p.MedicalHistoryId,
                                                p.MedicalHistory.PatiendId,
                                                p.MedicalHistory.Patient.FirstName,
                                                p.MedicalHistory.Patient.LastName,
                                                p.MedicalHistory.Patient.DocumentType.DocumentTypeName,
                                                p.MedicalHistory.Patient.DocumentNumber,
                                                p.MedicalHistory.Patient.Photo,
                                                p.MedicalPracticeId,
                                                p.MedicalPractice.PracticeCode,
                                                p.MedicalPractice.PracticeName,
                                                p.MedicalPractice.PracticeDescription,
                                                p.MedicalPractice.SpecialityId,
                                                p.MedicalHistory.Client.ClientName,
                                                p.MedicalHistory.Observations,
                                                p.MedicalHistory.DailyPatientNumber,
                                                p.MedicalHistory.ExamTypeId
                                            }).ToList();
                if (practices.Count > 0)
                {
                    foreach (var practice in practices)
                    {
                        var isDone = false;
                        if(practice.MedicalPracticeId == Constants.ClinicalExamId)
                        {
                            isDone = true;
                        }
                        pendingPractices.Add(new PendingPracticeDto
                                                 {
                                                     Id = practice.MedicalPracticeId,
                                                     Code = practice.PracticeCode,
                                                     Name = practice.PracticeName,
                                                     Description = practice.PracticeDescription,
                                                     IsDone = isDone,
                                                     SpecialityId = practice.SpecialityId
                                                 });
                    }
                    
                    return new PatientPracticesDto
                               {
                                   ClinicalHistoryId = practices[0].MedicalHistoryId,
                                   PatientInformation = new PatientListItemDto
                                                            {
                                                                DocumentType = practices[0].DocumentTypeName,
                                                                DocumentNumber = practices[0].DocumentNumber,
                                                                FirstName = practices[0].FirstName,
                                                                LastName = practices[0].LastName,
                                                                Id = practices[0].PatiendId,
                                                                Photo = practices[0].Photo
                                                            },
                                   Practices = pendingPractices,
                                   ClientName = practices[0].ClientName,
                                   Observations = practices[0].Observations,
                                   PatientNumber = practices[0].DailyPatientNumber,
                                   HistoryType = (Utils.ExamType)practices[0].ExamTypeId
                               };
                }
            }
            return null;
        }

        public static bool MarkAsDone(PatientPracticesDto practices)
        {
            var isComplete = false;
            using (var context = new MedilabEntities())
            {
                foreach (var practice in practices.Practices)
                {
                    if (practice.IsDone)
                    {
                        MedicalHistoryPractice.UpdatePracticeStatus(context, practices.ClinicalHistoryId, practice.Id,
                                                                    practice.SpecialityId == Constants.ClinicId
                                                                        ? ClinicalExamStatus.Completa
                                                                        : ClinicalExamStatus.Realizada,
                                                                        Security.GetCurrentUser());
                    }
                    context.SaveChanges();
                }
                if (CheckIsComplete(context, practices.ClinicalHistoryId, ClinicalExamStatus.Incompleto, true))
                {
                    var medicalHistory =
                        (from mh in context.MedicalHistory
                         where mh.MedicalHistoryId == practices.ClinicalHistoryId
                         select mh).First();
                    medicalHistory.Status = (int)ClinicalHistoryStatus.Realizada;
                    isComplete = true;
                    context.SaveChanges();
                }
            }
            return isComplete;
        }

        public static bool MarkAsComplete(PatientPracticesDto practices)
        {
            var isComplete = false;
            using (var context = new MedilabEntities())
            {
                foreach (var practice in practices.Practices)
                {
                    if (practice.IsDone)
                    {
                        MedicalHistoryPractice.UpdatePracticeStatus(context, practices.ClinicalHistoryId, practice.Id, ClinicalExamStatus.Completa, 
                            Security.GetCurrentUser());
                    }
                    context.SaveChanges();
                }
                if (CheckIsComplete(context, practices.ClinicalHistoryId, ClinicalExamStatus.Realizada, false))
                {
                    var medicalHistory =
                        (from mh in context.MedicalHistory
                         where mh.MedicalHistoryId == practices.ClinicalHistoryId
                         select mh).First();
                    medicalHistory.Status = (int)ClinicalHistoryStatus.Completa;
                    isComplete = true;
                    context.SaveChanges();
                }
            }
            return isComplete;
        }

        internal static bool CheckIsComplete(MedilabEntities context, Guid medicalHistoryId, ClinicalExamStatus status, bool excludeExternals)
        {
            var practices = (from p in context.MedicalHistoryPractice
                                 where p.MedicalHistoryId == medicalHistoryId &&
                                       p.Status <= (int) status 
                                 select new
                                            {
                                                p.MedicalPractice.IsExternal
                                            }).ToList();
            if(excludeExternals)
            {
                practices = (from p in practices where !p.IsExternal select p).ToList();
            }
            var practiceCount = practices.Count();
            var clinicalExam = (from ce in context.ClinicalExam
                                where ce.MedicalHistoryId == medicalHistoryId
                                select ce).FirstOrDefault();
            var isClinicalExamComplete = true;
            if (clinicalExam != null)
            {
                isClinicalExamComplete = clinicalExam.Status == (int) ClinicalExamStatus.Completa;
            }
            return (practiceCount == 0) && isClinicalExamComplete;
        }

        public static PatientPracticesDto GetPractices(Guid medicalHistoryId)
        {
            using (var context = new MedilabEntities())
            {
                var pendingPractices = new List<PendingPracticeDto>();
                var practices = (from p in context.MedicalHistoryPractice
                                 where p.MedicalHistoryId == medicalHistoryId
                                 select new
                                            {
                                                p.MedicalHistoryId,
                                                p.MedicalHistory.PatiendId,
                                                p.MedicalHistory.Patient.FirstName,
                                                p.MedicalHistory.Patient.LastName,
                                                p.MedicalHistory.Patient.DocumentType.DocumentTypeName,
                                                p.MedicalHistory.Patient.DocumentNumber,
                                                p.MedicalHistory.Patient.Photo,
                                                p.MedicalPracticeId,
                                                p.MedicalPractice.PracticeCode,
                                                p.MedicalPractice.PracticeName,
                                                p.MedicalPractice.PracticeDescription,
                                                p.MedicalPractice.SpecialityId,
                                                p.Status,
                                                p.MedicalHistory.Client.ClientName,
                                                p.MedicalHistory.Observations,
                                                p.MedicalHistory.DailyPatientNumber,
                                                p.MedicalHistory.ExamTypeId
                                            }).ToList();
                if (practices.Count > 0)
                {
                    foreach (var practice in practices)
                    {
                        pendingPractices.Add(new PendingPracticeDto
                                                 {
                                                     Id = practice.MedicalPracticeId,
                                                     Code = practice.PracticeCode,
                                                     Name = practice.PracticeName,
                                                     Description = practice.PracticeDescription,
                                                     Status = (ClinicalExamStatus) practice.Status,
                                                     SpecialityId = practice.SpecialityId
                                                 });
                    }
                    return new PatientPracticesDto
                               {
                                   ClinicalHistoryId = practices[0].MedicalHistoryId,
                                   PatientInformation = new PatientListItemDto
                                                            {
                                                                DocumentType = practices[0].DocumentTypeName,
                                                                DocumentNumber = practices[0].DocumentNumber,
                                                                FirstName = practices[0].FirstName,
                                                                LastName = practices[0].LastName,
                                                                Id = practices[0].PatiendId,
                                                                Photo = practices[0].Photo
                                                            },
                                   Practices = pendingPractices,
                                   ClientName = practices[0].ClientName,
                                   Observations = practices[0].Observations,
                                   PatientNumber = practices[0].DailyPatientNumber,
                                   HistoryType = (Utils.ExamType) practices[0].ExamTypeId
                               };
                }
            }
            return null;
        }

        public static IEnumerable<PendingPracticePatientClientDto> GetPendingPractices(PendingExamFilterCriteria pendingExamFilterCriteria)
        {
            var pendingPracticePatientClientDto = new List<PendingPracticePatientClientDto>();
            using (var context = new MedilabEntities())
            {
                var pendingExams = (from m in context.MedicalHistoryPractice
                                    where (m.Status == (int) pendingExamFilterCriteria.FilterByStatus)
                                          &&
                                          (m.MedicalPractice.Speciality.SpecialityId ==
                                           pendingExamFilterCriteria.Speciality)
                                          &&
                                          (m.MedicalHistory.CreatedDate >= pendingExamFilterCriteria.FilterByFromDate &&
                                           m.MedicalHistory.CreatedDate <= pendingExamFilterCriteria.FilterByToDate)
                                    select new
                                               {
                                                   m.MedicalPractice.PracticeCode,
                                                   m.MedicalPractice.PracticeName,
                                                   m.MedicalHistory.Patient.DocumentType,
                                                   m.MedicalHistory.Patient.DocumentNumber,
                                                   m.MedicalHistory.Patient.FirstName,
                                                   m.MedicalHistory.Patient.LastName,
                                                   m.MedicalHistory.Client.ClientName,
                                                   m.MedicalHistory.Client.ClientCuit
                                               }).ToList();

                if(pendingExams.Count > 0)
                {
                    foreach (var pendingExam in pendingExams)
                    {
                        pendingPracticePatientClientDto.Add(new PendingPracticePatientClientDto
                                                                {
                                                                    Code = pendingExam.PracticeCode,
                                                                    Name = pendingExam.PracticeName,
                                                                    DocumentNumber = pendingExam.DocumentNumber,
                                                                    PatientName = string.Format("{0}, {1}", pendingExam.LastName, pendingExam.FirstName),
                                                                    ClientName = pendingExam.ClientName,
                                                                    Cuit = pendingExam.ClientCuit
                                                                });
                    }
                    return pendingPracticePatientClientDto;
                }
                return null;
            }
        }

        public static IEnumerable<PendingPracticePatientClientDto> GetPracticesByProfessional(PendingExamFilterCriteria filterCriteria)
        {
            var practiceByProfessionalDto = new List<PendingPracticePatientClientDto>();
            var currentUserId = Security.GetCurrentUser();
            filterCriteria.Speciality = Configuration.User.GetUser(currentUserId).Speciality.Id;
            using (var context = new MedilabEntities())
            {
                var practices = (from m in context.MedicalHistoryPractice
                                    where (m.MedicalPractice.Speciality.SpecialityId ==
                                           filterCriteria.Speciality)
                                          &&
                                          (m.AttentionDate >= filterCriteria.FilterByFromDate &&
                                           m.AttentionDate <= filterCriteria.FilterByToDate) &&
                                           m.ProfessionalId == currentUserId
                                           orderby m.MedicalHistory.Patient.LastName descending
                                           orderby m.MedicalHistory.Patient.FirstName descending
                                    select new
                                    {
                                        m.MedicalPractice.PracticeCode,
                                        m.MedicalPractice.PracticeName,
                                        m.MedicalHistory.Patient.DocumentType,
                                        m.MedicalHistory.Patient.DocumentNumber,
                                        m.MedicalHistory.Patient.FirstName,
                                        m.MedicalHistory.Patient.LastName,
                                        m.MedicalHistory.Client.ClientName,
                                        m.MedicalHistory.Client.ClientCuit,
                                        m.MedicalHistory.DailyPatientNumber,
                                        m.AttentionDate
                                    }).ToList();

                if (practices.Count > 0)
                {
                    foreach (var pendingExam in practices)
                    {
                        practiceByProfessionalDto.Add(new PendingPracticePatientClientDto
                        {
                            Code = pendingExam.PracticeCode,
                            Name = pendingExam.PracticeName,
                            DocumentNumber = pendingExam.DocumentNumber,
                            PatientName = string.Format("{0}, {1}", pendingExam.LastName, pendingExam.FirstName),
                            ClientName = pendingExam.ClientName,
                            Cuit = pendingExam.ClientCuit,
                            Date = pendingExam.AttentionDate.HasValue ? pendingExam.AttentionDate.Value.ToShortDateString() : string.Empty,
                            PatientNumber = pendingExam.DailyPatientNumber
                        });
                    }
                    return practiceByProfessionalDto;
                }
                return null;
            }
        }

        public static IEnumerable<PendingPracticePatientClientDto> GetPracticesByClient(PendingExamFilterCriteria filterCriteria)
        {
            var practiceByProfessionalDto = new List<PendingPracticePatientClientDto>();
            using (var context = new MedilabEntities())
            {
                var practices = (from m in context.MedicalHistoryPractice
                                 where (m.MedicalHistory.ClientId ==
                                        filterCriteria.ClientId)
                                       &&
                                       (m.AttentionDate >= filterCriteria.FilterByFromDate &&
                                        m.AttentionDate <= filterCriteria.FilterByToDate) 
                                 select new
                                 {
                                     m.MedicalPractice.PracticeCode,
                                     m.MedicalPractice.PracticeName,
                                     m.MedicalHistory.Patient.DocumentType,
                                     m.MedicalHistory.Patient.DocumentNumber,
                                     m.MedicalHistory.Patient.FirstName,
                                     m.MedicalHistory.Patient.LastName,
                                     m.MedicalHistory.Client.ClientName,
                                     m.MedicalHistory.Client.ClientCuit,
                                     m.AttentionDate
                                 }).ToList();

                if (practices.Count > 0)
                {
                    foreach (var pendingExam in practices)
                    {
                        practiceByProfessionalDto.Add(new PendingPracticePatientClientDto
                        {
                            Code = pendingExam.PracticeCode,
                            Name = pendingExam.PracticeName,
                            DocumentNumber = pendingExam.DocumentNumber,
                            PatientName = string.Format("{0}, {1}", pendingExam.LastName, pendingExam.FirstName),
                            ClientName = pendingExam.ClientName,
                            Cuit = pendingExam.ClientCuit,
                            Date = pendingExam.AttentionDate.HasValue ? pendingExam.AttentionDate.Value.ToShortDateString() : string.Empty
                        });
                    }
                    return practiceByProfessionalDto;
                }
                return null;
            }
        }
    }
}