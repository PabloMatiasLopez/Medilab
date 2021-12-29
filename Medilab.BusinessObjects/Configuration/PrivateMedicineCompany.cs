using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.DataAccess;
using Medilab.BusinessObjects.Utils;
using System.Data;


namespace Medilab.BusinessObjects.Configuration
{
     public class PrivateMedicineCompany
    {
        #region Properties
        
        public Guid Id { private set; get;}
        public string Name { get; set; }
        public string Description{ get; set;}
        public byte[] LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        #region Methods
        private PrivateMedicineCompany()
        {}
        public PrivateMedicineCompany(Guid id)
        {
            Id = id; 
        }
        public PrivateMedicineCompany Save()
        { 
            return Id == Guid.Empty ? Insert(): Update();
        }
        private PrivateMedicineCompany Update()
        {
            using (var context = new MedilabEntities())
            {
                var privateMedicineCompany = (from c in context.PrivateMedicineCompany
                                            where c.PrivateMedicineCompanyId == Id
                                            select c).First();
                if (Tools.IsRecordChanged(privateMedicineCompany.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                privateMedicineCompany.Name = Name;
                privateMedicineCompany.Description = Description;
                
            
               var modifiedFields = Utilities.GetModifiedFields(context, privateMedicineCompany.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PrivateMedicineCompany, AuditOperations.Update, Id, modifiedFields);

                context.SaveChanges();
                return this;
            }
        }
        private PrivateMedicineCompany Insert()
        {
            using(var context = new MedilabEntities())
            {
                var privateMedicineCompany = new DataAccess.PrivateMedicineCompany
                {
                    PrivateMedicineCompanyId = Id = Guid.NewGuid(),
                    Name = Name,
                    Description = Description,
                    IsDeleted=false
                };

                context.AddToPrivateMedicineCompany(privateMedicineCompany);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PrivateMedicineCompany, AuditOperations.Insert, Id, privateMedicineCompany.Name);
                context.SaveChanges();
                return this;
            }
        }
        public static PrivateMedicineCompany GetPrivateMedicineCompany(Guid privateMedicineCompanyId)
        {
            using (var context = new MedilabEntities())
            {
                var privateMedicineCompany = (from c in context.PrivateMedicineCompany
                                       where c.PrivateMedicineCompanyId == privateMedicineCompanyId && !c.IsDeleted 
                                       select c).First();
                if (privateMedicineCompany != null)
                {
                    return new PrivateMedicineCompany
                    {
                        Id = privateMedicineCompany.PrivateMedicineCompanyId,
                        Name = privateMedicineCompany.Name,
                        Description = privateMedicineCompany.Description,
                        IsDeleted = privateMedicineCompany.IsDeleted,
                        LastUpdated = privateMedicineCompany.LastUpdated
                    };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
       }
        public static IEnumerable<PrivateMedicineCompany> GetPrivateMedicineCompanyList()
        {
            using (var context = new MedilabEntities())
            {
                var privateMedicineCompanyList = (from c in context.PrivateMedicineCompany
                                                 where !c.IsDeleted
                                                 orderby c.Name
                                                 select c).ToList();
                return privateMedicineCompanyList.Select(privateMedicineCompany => new PrivateMedicineCompany
                    {
                        Id = privateMedicineCompany.PrivateMedicineCompanyId,
                        Name = privateMedicineCompany.Name,
                        Description = privateMedicineCompany.Description,
                        IsDeleted = privateMedicineCompany.IsDeleted,
                        LastUpdated = privateMedicineCompany.LastUpdated
                    }).ToList();
            }
        }

         /// <summary>
         /// this method represent a softdelete it will just update the flag IsDelete.
         /// </summary>
         /// <param name="privateMedicineCompanyId"></param>
         public static bool Delete(Guid privateMedicineCompanyId)
        {
            using (var context = new MedilabEntities())
            {
                var privateMedicineCompany = (from c in context.PrivateMedicineCompany
                                   where c.PrivateMedicineCompanyId == privateMedicineCompanyId
                                   select c).First();

                privateMedicineCompany.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PrivateMedicineCompany, AuditOperations.Delete, privateMedicineCompany.PrivateMedicineCompanyId, privateMedicineCompany.Name);
                context.SaveChanges();
                return true;
            }

        }
       #endregion
    }
}
