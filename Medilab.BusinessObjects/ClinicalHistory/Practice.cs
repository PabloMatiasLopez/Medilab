using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.ListOfPrice;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using Speciality = Medilab.BusinessObjects.Configuration.Speciality;
using Medilab.BusinessObjects.DTOs;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class Practice : IConcurrence
    {
        #region Properties
        public Guid Id { private set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Speciality Speciality { set; get; }
        public byte[] LastUpdated { get; set; }
        public double Price { set; get; }
        public bool IsExternal { set; get; }
        public string ReportName { get; set; }

        #endregion

        #region Methods

        private Practice()
        {
        }

        public Practice(Guid id)
        {
            Id = id;
        }

        public Practice Save()
        {
            try
            {
                return Id == Guid.Empty ? Insert() : Update();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException as SqlException;
                if (innerException != null)
                {
                    var errorCode = (innerException).ErrorCode;
                    if (errorCode == -2146232060)
                    {
                        throw new Exception("El código ya existe");
                    }
                }
                throw;
            }
        }

        private Practice Update()
        {
            using (var context = new MedilabEntities())
            {
                if (Id != Constants.ClinicalExamId)
                {
                    var practice = (from s in context.MedicalPractice where s.MedicalPracticeId == Id select s).First();
                    if (Tools.IsRecordChanged(practice.LastUpdated, LastUpdated))
                    {
                        throw new OptimisticConcurrencyException(
                            "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                    }
                    practice.PracticeName = Name;
                    practice.PracticeDescription = Description;
                    practice.PracticeCode = Code;
                    practice.SpecialityId = Speciality.Id;
                    practice.IsExternal = IsExternal;
                    practice.ReportName = ReportName;
                    var modifiedFields = Utilities.GetModifiedFields(context, practice.ToString());
                    Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.MedicalPractice,
                                         AuditOperations.Update, Id, modifiedFields);
                }
                //Update price
                var practicePrice =
                    (from p in context.PracticeGroupPrice where p.PracticeGroupId == Id select p).FirstOrDefault();
                if(practicePrice == null)
                {
                    PracticePrice.InsertPrice(context, new PracticeGroupPriceDto
                    {
                        PracticeGroupId = Id,
                        Price = Price
                    });
                }
                else
                {
                    var priceModifiedFields = Utilities.GetModifiedFields(context, practicePrice.ToString());
                    practicePrice.Price = Price;
                    Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PracticeGroupPrice, AuditOperations.Update, Id, priceModifiedFields);
                }
                context.SaveChanges();
                return this;
            }
        }

        private Practice Insert()
        {
            if (Id == Constants.ClinicalExamId) return null;
            using (var context = new MedilabEntities())
            {
                var medicalPractice = new MedicalPractice
                               {
                                   MedicalPracticeId = Id = Guid.NewGuid(),
                                   PracticeCode = Code,
                                   PracticeName = Name,
                                   PracticeDescription = Description,
                                   SpecialityId = Speciality.Id,
                                   IsDeleted = false,
                                   IsExternal = IsExternal,
                                   ReportName = ReportName,
                               };
                context.AddToMedicalPractice(medicalPractice);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.MedicalPractice, AuditOperations.Insert, Id, medicalPractice.PracticeCode.ToString());
                //Save Price
                PracticePrice.InsertPrice(context, new PracticeGroupPriceDto
                {
                    PracticeGroupId = Id,
                    Price = Price
                });
                context.SaveChanges();
                return this;
            }
        }

        public void Delete()
        {
            if (Id == Constants.ClinicalExamId) return;
            using (var context = new MedilabEntities())
            {
                var medicalPractice = (from s in context.MedicalPractice where s.MedicalPracticeId == Id select s).First();
                medicalPractice.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.MedicalPractice, AuditOperations.Delete, Id, medicalPractice.PracticeCode.ToString());
                context.SaveChanges();
            }
        }

        public static Practice GetPractice(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var practice = (from mp in context.MedicalPractice
                                where mp.MedicalPracticeId == id
                                select new PracticeDto
                                             {
                                                 Id = mp.MedicalPracticeId,
                                                 Code = mp.PracticeCode,
                                                 Name = mp.PracticeName,
                                                 Description = mp.PracticeDescription,
                                                 SpecialityId = mp.SpecialityId,
                                                 LastUpdated = mp.LastUpdated,
                                                 IsExternal = mp.IsExternal,
                                                 ReportName = mp.ReportName,
                                                 Price =  (from p in context.PracticeGroupPrice where p.PracticeGroupId == id select p.Price).FirstOrDefault()
                                             }).FirstOrDefault();
                return GetPractice(practice, context);
            }
        }

        public static Practice GetPractice(int code)
        {
            using (var context = new MedilabEntities())
            {
                var practice = (from mp in context.MedicalPractice
                                where !mp.IsDeleted && mp.PracticeCode == code
                                select new PracticeDto
                                {
                                    Id = mp.MedicalPracticeId,
                                    Code = mp.PracticeCode,
                                    Name = mp.PracticeName,
                                    Description = mp.PracticeDescription,
                                    SpecialityId = mp.SpecialityId,
                                    LastUpdated = mp.LastUpdated,
                                    IsExternal = mp.IsExternal,
                                    ReportName = mp.ReportName
                                }).FirstOrDefault();
                return GetPractice(practice, context);
            }
        }
        private static Practice GetPractice(PracticeDto practiceDto, MedilabEntities context)
        {
            if (practiceDto != null)
            {
                return new Practice
                           {
                               Id = practiceDto.Id,
                               Code = practiceDto.Code,
                               Name = practiceDto.Name,
                               Description = practiceDto.Description,
                               Speciality = Speciality.GetSpeciality(practiceDto.SpecialityId, context),
                               LastUpdated = practiceDto.LastUpdated,
                               Price = practiceDto.Price,
                               IsExternal = practiceDto.IsExternal,
                               ReportName =  practiceDto.ReportName
                           };
            }
            return null;
        }

        public static IEnumerable<PracticeDto> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var medicalPractices = (from mp in context.MedicalPractice
                                        where !mp.IsDeleted
                                        orderby mp.PracticeCode
                                        select new
                                                   {
                                                       mp.MedicalPracticeId,
                                                       mp.PracticeCode,
                                                       mp.PracticeName,
                                                       mp.PracticeDescription,
                                                       mp.SpecialityId,
                                                       mp.Speciality.SpecialityName,
                                                       mp.IsExternal,
                                                       mp.ReportName,
                                                   }
                                       ).ToList();

                return medicalPractices.Select(practice => new PracticeDto
                                                {
                                                    Id = practice.MedicalPracticeId,
                                                    Code = practice.PracticeCode,
                                                    Name = practice.PracticeName,
                                                    Description = practice.PracticeDescription,
                                                    SpecialityId = practice.SpecialityId,
                                                    SpecialityName = practice.SpecialityName,
                                                    IsExternal = practice.IsExternal,
                                                    ReportName = practice.ReportName,
                                                }).OrderBy(p => p.Name).ToList();
            }
        }

        public static IEnumerable<ListItemDto<Guid>> GetDisplayList()
        {
            using (var context = new MedilabEntities())
            {
                var medicalPractices = (from mp in context.MedicalPractice
                                        where !mp.IsDeleted
                                        orderby mp.PracticeCode
                                        select new
                                                   {
                                                       mp.MedicalPracticeId,
                                                       mp.PracticeName,
                                                   }
                                       ).ToList();
                var praticeList = new List<ListItemDto<Guid>>();
                foreach (var practice in medicalPractices)
                {
                    praticeList.Add(new ListItemDto<Guid>
                    {
                        Id = practice.MedicalPracticeId,
                        Value = practice.PracticeName
                    });
                }
                return praticeList;
            }
        }
        public static IEnumerable<PracticeDto> SearchPractice(string criteria)
        {
            using (var context = new MedilabEntities())
            {
                var medicalPractices = (from mp in context.MedicalPractice
                                        where !mp.IsDeleted &&
                                        (mp.PracticeName.Contains(criteria) || mp.PracticeDescription.Contains(criteria))
                                        orderby mp.PracticeName
                                        select new
                                        {
                                            mp.MedicalPracticeId,
                                            mp.PracticeCode,
                                            mp.PracticeName,
                                            mp.PracticeDescription,
                                            mp.Speciality.SpecialityName,
                                            mp.IsExternal,
                                            mp.ReportName
                                        }
                                       ).ToList();

                return medicalPractices.Select(practice => new PracticeDto
                {
                    Id = practice.MedicalPracticeId,
                    Code = practice.PracticeCode,
                    Name = practice.PracticeName,
                    Description = practice.PracticeDescription,
                    SpecialityName = practice.SpecialityName,
                    IsExternal = practice.IsExternal,
                    ReportName = practice.ReportName
                }).ToList();
            }
        }
        public static IEnumerable<PracticeDto> SearchPractice(int practiceCode)
        {
            using (var context = new MedilabEntities())
            {
                var medicalPractices = (from mp in context.MedicalPractice
                                        where !mp.IsDeleted &&
                                        (mp.PracticeCode == practiceCode)
                                        orderby mp.PracticeName
                                        select new
                                        {
                                            mp.MedicalPracticeId,
                                            mp.PracticeCode,
                                            mp.PracticeName,
                                            mp.PracticeDescription,
                                            mp.Speciality.SpecialityName,
                                            mp.IsExternal,
                                            mp.ReportName
                                        }
                                       ).ToList();

                return medicalPractices.Select(practice => new PracticeDto
                {
                    Id = practice.MedicalPracticeId,
                    Code = practice.PracticeCode,
                    Name = practice.PracticeName,
                    Description = practice.PracticeDescription,
                    SpecialityName = practice.SpecialityName,
                    IsExternal = practice.IsExternal,
                    ReportName = practice.ReportName
                }).ToList();
            }
        }
        public static Speciality GetPraticeSpeciality(Guid practiceId)
        {
            using (var context = new MedilabEntities())
            {
                var practice = (from mp in context.MedicalPractice
                                where !mp.IsDeleted && mp.MedicalPracticeId == practiceId
                                select new
                                {
                                    mp.Speciality
                                }).FirstOrDefault();
                if (practice != null)
                {
                    return new Speciality(practice.Speciality.SpecialityId)
                               {
                                   Description = practice.Speciality.SpecialityDescription,
                                   Name = practice.Speciality.SpecialityName
                               };
                }
                return null;
            }
        }
        #endregion
    }
}
