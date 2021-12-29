using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class WorkRiskInsurance
    {
        #region Properties

        public Guid Id { private set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] LastUpdated { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Methods

        private WorkRiskInsurance()
        {
        }

        public WorkRiskInsurance(Guid id)
        {
            Id = id;
        }

        public WorkRiskInsurance Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private WorkRiskInsurance Update()
        {
            using (var context = new MedilabEntities())
            {
                var workRiskInsurance = (from c in context.WorkRiskInsurance
                                              where c.WorkRiskInsuranceId == Id
                                              select c).First();
                if (Tools.IsRecordChanged(workRiskInsurance.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                workRiskInsurance.WorkRiskInsuranceName = Name;
                workRiskInsurance.WorkRiskInsuranceDescription = Description;


                var modifiedFields = Utilities.GetModifiedFields(context, workRiskInsurance.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.WorkRiskInsurance, AuditOperations.Update,
                                     Id, modifiedFields);

                context.SaveChanges();
                return this;
            }
        }

        private WorkRiskInsurance Insert()
        {
            using (var context = new MedilabEntities())
            {
                var workRiskInsurance = new DataAccess.WorkRiskInsurance
                                                 {
                                                     WorkRiskInsuranceId = Id = Guid.NewGuid(),
                                                     WorkRiskInsuranceName = Name,
                                                     WorkRiskInsuranceDescription = Description,
                                                     IsDeleted = false
                                                 };

                context.AddToWorkRiskInsurance(workRiskInsurance);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PrivateMedicineCompany, AuditOperations.Insert,
                                     Id, workRiskInsurance.WorkRiskInsuranceName);
                context.SaveChanges();
                return this;
            }
        }

        public static WorkRiskInsurance GetWorkRiskInsurance(Guid workRiskInsuranceId)
        {
            using (var context = new MedilabEntities())
            {
                var workRiskInsurance = (from c in context.WorkRiskInsurance
                                              where
                                                  c.WorkRiskInsuranceId == workRiskInsuranceId && !c.IsDeleted
                                              select c).First();
                if (workRiskInsurance != null)
                {
                    return new WorkRiskInsurance
                               {
                                   Id = workRiskInsurance.WorkRiskInsuranceId,
                                   Name = workRiskInsurance.WorkRiskInsuranceName,
                                   Description = workRiskInsurance.WorkRiskInsuranceDescription,
                                   IsDeleted = workRiskInsurance.IsDeleted,
                                   LastUpdated = workRiskInsurance.LastUpdated
                               };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }

        public static IEnumerable<WorkRiskInsurance> GetWorkRiskInsuranceList()
        {
            using (var context = new MedilabEntities())
            {
                var workRiskInsuranceList = (from c in context.WorkRiskInsurance
                                                  where !c.IsDeleted
                                                  orderby c.WorkRiskInsuranceName
                                                  select c).ToList();
                return workRiskInsuranceList.Select(workRiskInsurance => new WorkRiskInsurance
                                                                             {
                                                                                 Id =
                                                                                     workRiskInsurance.
                                                                                     WorkRiskInsuranceId,
                                                                                 Name =
                                                                                     workRiskInsurance.
                                                                                     WorkRiskInsuranceName,
                                                                                 Description =
                                                                                     workRiskInsurance.
                                                                                     WorkRiskInsuranceDescription,
                                                                                 IsDeleted = workRiskInsurance.IsDeleted,
                                                                                 LastUpdated =
                                                                                     workRiskInsurance.LastUpdated
                                                                             }).ToList();
            }
        }

        /// <summary>
        /// this method represent a softdelete it will just update the flag IsDelete.
        /// </summary>
        /// <param name="workRiskInsuranceId"></param>
        public static bool Delete(Guid workRiskInsuranceId)
        {
            using (var context = new MedilabEntities())
            {
                var workRiskInsurance = (from c in context.WorkRiskInsurance
                                              where c.WorkRiskInsuranceId == workRiskInsuranceId
                                              select c).First();

                workRiskInsurance.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.WorkRiskInsurance, AuditOperations.Delete,
                                     workRiskInsurance.WorkRiskInsuranceId, workRiskInsurance.WorkRiskInsuranceName);
                context.SaveChanges();
                return true;
            }

        }
        #endregion
    }
}