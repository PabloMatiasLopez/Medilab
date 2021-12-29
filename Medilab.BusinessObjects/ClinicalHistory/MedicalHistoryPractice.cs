using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class MedicalHistoryPractice
    {
        #region Properties

        public Guid Id { private set; get; }
        public Guid MedicalHistoryId { set; get; }
        public Guid MedicalPracticeId { set; get; }
        public ClinicalExamStatus Status { set; get; }
        public Guid? GroupId { set; get; }
        public bool IsNew { set; get; }
        public bool MarkForDetele { set; get; }
        public ClinicalExamResult? Result { set; get; }
        public string Observations { set; get; }

        #endregion

        #region Methods

        public MedicalHistoryPractice()
        {
            
        }

        public MedicalHistoryPractice(Guid id)
        {
            Id = id;
        }

        public MedicalHistoryPractice Save()
        {
            using (var context = new MedilabEntities())
            {
                Save(context);
                context.SaveChanges();
                return this;
            }
        }

        internal void Save(MedilabEntities context)
        {
            var medicalHistoryPractice = new DataAccess.MedicalHistoryPractice
                                             {
                                                 MedicalHistoryPracticeId = Id = Guid.NewGuid(),
                                                 MedicalHistoryId = MedicalHistoryId,
                                                 MedicalPracticeId = MedicalPracticeId,
                                                 Status = (int) Status,
                                                 GroupId = GroupId
                                             };
            context.MedicalHistoryPractice.AddObject(medicalHistoryPractice);
        }

        internal static IEnumerable<MedicalHistoryPractice> GetPractices(MedilabEntities context, Guid medicalHistoryId)
        {
            var practices =
                (from p in context.MedicalHistoryPractice where p.MedicalHistoryId == medicalHistoryId select p).ToList();
            var resultList = new List<MedicalHistoryPractice>();
            foreach (var practice in practices)
            {
                var medicalPractice = new MedicalHistoryPractice
                {
                    Id = practice.MedicalHistoryPracticeId,
                    MedicalHistoryId = practice.MedicalHistoryId,
                    MedicalPracticeId = practice.MedicalPracticeId,
                    Status = (ClinicalExamStatus) practice.Status,
                    GroupId = practice.GroupId,
                    Result = (ClinicalExamResult) practice.Result
                };
                if (!string.IsNullOrEmpty( practice.Observations))
                {
                    medicalPractice.Observations = practice.Observations;
                }
                resultList.Add(medicalPractice);
            }
            return resultList;
        }

        internal static void UpdatePracticeStatus(MedilabEntities context, Guid medicalHistoryId, Guid practiceId,
                                                  ClinicalExamStatus status, Guid professionalId)
        {
            var practice = (from p in context.MedicalHistoryPractice
                            where p.MedicalHistoryId == medicalHistoryId && p.MedicalPracticeId == practiceId
                            select p).FirstOrDefault();
            if (practice == null) return;
            if ((int)status < practice.Status) return;
            practice.Status = (int)status;
            if (professionalId != null)
            {
                practice.ProfessionalId = professionalId;
                practice.AttentionDate = DateTime.Now;
            }
        }

        public static MedicalHistoryPracticeDto GetPractice(Guid medicalHistoryId, Guid practiceId)
        {
            using (var context = new MedilabEntities())
            {
                var practice = (from mp in context.MedicalHistoryPractice
                                where mp.MedicalHistoryId == medicalHistoryId && mp.MedicalPracticeId == practiceId
                                select new MedicalHistoryPracticeDto
                                           {
                                               Id = mp.MedicalHistoryPracticeId,
                                               ClinicalHistoryId = mp.MedicalHistoryId,
                                               Code = mp.MedicalPractice.PracticeCode,
                                               Description = mp.MedicalPractice.PracticeDescription,
                                               Name = mp.MedicalPractice.PracticeName,
                                               MedicalPracticeId = mp.MedicalPracticeId,
                                               Status = (ClinicalExamStatus) mp.Status,
                                               GroupId = mp.GroupId
                                           }).First();
                return practice;
            }
        }

        public static void UpdatePracticeStatus(Guid medicalHistoryId, Guid practiceId,ClinicalExamStatus status)
        {
            using (var context = new MedilabEntities())
            {
                var practices = (from mp in context.MedicalHistoryPractice
                                where mp.MedicalHistoryId == medicalHistoryId && mp.MedicalPracticeId == practiceId
                                select mp);
                foreach (DataAccess.MedicalHistoryPractice medicalPractice in practices)
                {
                    medicalPractice.Status = (int)status;
                    if (status == ClinicalExamStatus.Incompleto)
                    {
                        var medicalHistory = (from mh in context.MedicalHistory where mh.MedicalHistoryId == medicalPractice.MedicalHistoryId select mh).First();
                        medicalHistory.Status = (int)ClinicalHistoryStatus.Incompleta;
                    }   
                }
                context.SaveChanges();
            }
        }
        public static void MarkAsInvoiced(Guid medicalHistoryId, Guid practiceId, Guid invoiceId, MedilabEntities context)
        {
            var practice = (from mp in context.MedicalHistoryPractice
                            where mp.MedicalHistoryId == medicalHistoryId && mp.MedicalPracticeId == practiceId
                            select mp).First();
            practice.InvoiceId = invoiceId;
        }

        public static IEnumerable<MedicalHistoryPractice> GetPracticesInGroup(Guid medicalHistoryId, Guid groupId)
        {
            using (var context = new MedilabEntities())
            {
                var practice = (from mp in context.MedicalHistoryPractice 
                                where mp.MedicalHistoryId == medicalHistoryId && mp.GroupId == groupId
                                select new MedicalHistoryPractice
                                {
                                    MedicalHistoryId = mp.MedicalHistoryId,
                                    MedicalPracticeId = mp.MedicalPracticeId
                                }).ToList();
                return practice;
            }
        }

        public static List<MedicalHistoryPracticeDto> GetPracticesDtoInGroup(Guid medicalHistoryId, Guid groupId)
        {
            using (var context = new MedilabEntities())
            {
                var practices = (from mp in context.MedicalHistoryPractice
                                where mp.MedicalHistoryId == medicalHistoryId && mp.GroupId == groupId
                                 select new MedicalHistoryPracticeDto
                                {
                                    Name = mp.MedicalPractice.PracticeName,
                                    Description = mp.MedicalPractice.PracticeDescription,
                                    Status = (ClinicalExamStatus)mp.Status,
                                    Code = mp.MedicalPractice.PracticeCode,
                                    Id = mp.MedicalHistoryPracticeId
                                }).ToList();

                return practices;
            }
        }
        internal void Remove(MedilabEntities context)
        {
            if(GroupId.HasValue)
            {
                var practices = (from p in context.MedicalHistoryPractice
                                where p.GroupId == GroupId.Value &&
                                    p.MedicalHistoryId == MedicalHistoryId
                                select p).ToList();
                foreach (var item in practices)
                {
                    context.DeleteObject(item);
                }
            }
            else
            {
                var practice = (from p in context.MedicalHistoryPractice
                                where p.MedicalPracticeId == MedicalPracticeId &&
                                    p.MedicalHistoryId == MedicalHistoryId
                                select p).First();
                context.DeleteObject(practice);
            }
        }
        public static IEnumerable<MedicalHistoryPracticeDto> GetPracticeResults(Guid medicalHistoryId)
        {
            using (var context = new MedilabEntities())
            {
                var practice = (from mp in context.MedicalHistoryPractice
                                where mp.MedicalHistoryId == medicalHistoryId && mp.MedicalPractice.Speciality.SpecialityId != Constants.ClinicId
                                select new MedicalHistoryPracticeDto
                                {
                                    Name = mp.MedicalPractice.PracticeName,
                                    Observations = mp.Observations,
                                    Result = (ClinicalExamResult)mp.Result
                                }).ToList();
                return practice;
            }
        }
        #endregion
    }
}
