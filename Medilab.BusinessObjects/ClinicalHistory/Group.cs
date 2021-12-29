using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.ListOfPrice;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using Medilab.BusinessObjects.DTOs;

namespace Medilab.BusinessObjects.ClinicalHistory
{
    public class Group : IConcurrence
    {
        #region Properties
        public Guid Id { private set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public IEnumerable<Practice> Practices { set; get; }
        public byte[] LastUpdated { get; set; }
        public double Price { set; get; }

        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        private Group()
        {
        }
        /// <summary>
        /// Public Contructor
        /// </summary>
        /// <param name="id">Group Id</param>
        public Group(Guid id)
        {
            Id = id;
        }
        /// <summary>
        /// Save Group
        /// </summary>
        /// <returns>Saved group</returns>
        public Group Save()
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
        /// <summary>
        /// Update existing group
        /// </summary>
        /// <returns>Updated group</returns>
        private Group Update()
        {
            using (var context = new MedilabEntities())
            {
                var group = (from r in context.Group where r.GroupId == Id select r).First();
                if (Tools.IsRecordChanged(group.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                group.GroupName = Name;
                group.GroupCode = Code;
                group.GroupDescription= Description;
                GroupMedicalPractice.RemoveMedicalPractices(context, Id);
                InsertGroupPractices(context);
                var modifiedFields = Utilities.GetModifiedFields(context, group.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Group, AuditOperations.Update, Id, modifiedFields);
                //Update price
                var practicePrice =
                    (from p in context.PracticeGroupPrice where p.PracticeGroupId == Id select p).FirstOrDefault();
                if (practicePrice == null)
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
        /// <summary>
        /// Add new group
        /// </summary>
        /// <returns>Added group</returns>
        private Group Insert()
        {
            using (var context = new MedilabEntities())
            {
                var group = new DataAccess.Group
                                {
                                    GroupId = Id = Guid.NewGuid(),
                                    GroupCode = Code,
                                    GroupName = Name,
                                    GroupDescription = Description
                                };
                context.Group.AddObject(group);
                InsertGroupPractices(context);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Group, AuditOperations.Insert, Id,
                                     group.GroupName);
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

        /// <summary>
        /// Insert practices for the group
        /// </summary>
        /// <param name="context"></param>
        private void InsertGroupPractices(MedilabEntities context)
        {
            foreach (var practice in Practices)
            {
                var groupMedicalPractice = new GroupMedicalPractice { GroupId = Id, MedicalPracticeId = practice.Id };
                groupMedicalPractice.Save(context);
            }
        }
        /// <summary>
        /// Delete group
        /// </summary>
        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var group = (from r in context.Group where r.GroupId == Id select r).First();
                group.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Group, AuditOperations.Delete, Id, group.GroupName);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Get group by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Group GetGroup(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var group = (from g in context.Group
                             where g.GroupId == id
                             select new GroupDto
                                        {
                                            Id = g.GroupId,
                                            Code = g.GroupCode,
                                            Name = g.GroupName,
                                            Description = g.GroupDescription,
                                            LastUpdated = g.LastUpdated,
                                            Practices =
                                                (from p in g.GroupMedicalPractice
                                                 select
                                                     new PracticeDto
                                                         {
                                                             Id = p.MedicalPracticeId,
                                                             Name = p.MedicalPractice.PracticeName,
                                                             Code = p.MedicalPractice.PracticeCode,
                                                             Description = p.MedicalPractice.PracticeDescription
                                                         }),
                                            Price =
                                                (from p in context.PracticeGroupPrice
                                                 where p.PracticeGroupId == id
                                                 select p.Price).
                                                FirstOrDefault()
                                        }).FirstOrDefault();

                return GetGroup(group);
            }
        }
        /// <summary>
        /// Get group by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Group GetGroup(int code)
        {
            using (var context = new MedilabEntities())
            {
                var group = (from g in context.Group
                             where g.GroupCode == code && !g.IsDeleted
                             select new GroupDto
                             {
                                 Id = g.GroupId,
                                 Code = g.GroupCode,
                                 Name = g.GroupName,
                                 Description = g.GroupDescription,
                                 LastUpdated = g.LastUpdated,
                                 Practices =
                      (from p in g.GroupMedicalPractice
                       select
                           new PracticeDto
                           {
                               Id = p.MedicalPracticeId,
                               Name = p.MedicalPractice.PracticeName,
                               Code = p.MedicalPractice.PracticeCode,
                               Description = p.MedicalPractice.PracticeDescription
                           })
                             }).FirstOrDefault();
                return GetGroup(group);
            }
        }
        /// <summary>
        /// Return group if match the criteria or return null
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private static Group GetGroup(GroupDto group)
        {
            if (group != null)
            {
                var practices =
                    group.Practices.Select(
                        practice =>
                        new Practice(practice.Id)
                        {
                            Name = practice.Name,
                            Code = practice.Code,
                            Description = practice.Description
                        }).ToList();
                return new Group
                {
                    Id = group.Id,
                    Code = group.Code,
                    Name = group.Name,
                    Description = group.Description,
                    Practices = practices,
                    LastUpdated = group.LastUpdated,
                    Price = group.Price
                };
            }
            return null;
        }
        /// <summary>
        /// Get a list of groups
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Group> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var groups = (from g in context.Group where !g.IsDeleted orderby g.GroupName select g).ToList();
                return groups.Select(group => new Group
                                                {
                                                    Id = group.GroupId,
                                                    Code = group.GroupCode,
                                                    Name = group.GroupName,
                                                    Description = group.GroupDescription
                                                }).ToList();
            }
        }

        public static IEnumerable<ListItemDto<Guid>> GetDisplayList()
        {
            using (var context = new MedilabEntities())
            {
                var groups = (from g in context.Group
                              where !g.IsDeleted
                              orderby g.GroupName
                              select new { g.GroupId, g.GroupName }).ToList();

                return groups.Select(group => new ListItemDto<Guid>
                {
                    Id = group.GroupId,
                    Value = group.GroupName
                }).ToList();
            }
        }
        #endregion
    }
}
