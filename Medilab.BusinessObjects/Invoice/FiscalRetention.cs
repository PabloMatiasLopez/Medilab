using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Medilab.BusinessObjects.Invoice
{
    public class FiscalRetention
    {
        #region Properties
        public Guid Id { private set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public double Value { set; get; }
        public byte[] LastUpdated { get; set; }
        public Guid LastUpdatedUser { set; get; }
        public bool IsIVA { set; get; }
        public int CAECode { set; get; }
        #endregion  

        #region Methods
        private FiscalRetention() { }
        public FiscalRetention(Guid retentionId)
        {
            Id = retentionId;
        }
        public static FiscalRetention GetRetention(Guid retentionId)
        {
            using (var context = new MedilabEntities())
            {
                var retention = (from fr in context.FiscalRetention where !fr.IsDeleted && fr.FiscalRetentionId == retentionId select fr).FirstOrDefault();
                if (retention == null)
                {
                    throw new Exception(BOResources.RecordNotFoudExeptionMessage);
                }
                return new FiscalRetention
                {
                    Id = retention.FiscalRetentionId,
                    Name = retention.Name,
                    Description = retention.Description,
                    Value = retention.Value,
                    LastUpdated = retention.LastUpdated,
                    LastUpdatedUser = retention.LastUpdateUser,
                    IsIVA = retention.IsIVA,
                    CAECode = retention.CAECode
                };
            }
        }
        public FiscalRetention Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }
        private FiscalRetention Update()
        {
            using (var context = new MedilabEntities())
            {
                var retention = (from fr in context.FiscalRetention where fr.FiscalRetentionId == Id select fr).First();
                if (Tools.IsRecordChanged(retention.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                retention.Name = Name;
                retention.Description = Description;
                retention.Value = Value;
                retention.LastUpdateUser = Security.GetCurrentUser();
                retention.IsIVA = IsIVA;
                retention.CAECode = CAECode;
                var modifiedFields = Utilities.GetModifiedFields(context, retention.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.FiscalRetention,
                                     AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }
        private FiscalRetention Insert()
        {
            using (var context = new MedilabEntities())
            {
                var retention = new DataAccess.FiscalRetention
                {
                    FiscalRetentionId = Id = Guid.NewGuid(),
                    Name = Name,
                    Description = Description,
                    Value = Value,
                    LastUpdateUser = Security.GetCurrentUser(),
                    IsIVA = IsIVA,
                    CAECode = CAECode
                };
                context.AddToFiscalRetention(retention);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.FiscalRetention, AuditOperations.Insert, Id, retention.Name);
                context.SaveChanges();
                return this;
            }
        }
        public static IEnumerable<FiscalRetention> GetAllRetentions()
        {
            using (var context = new MedilabEntities())
            {
                var retention = (from fr in context.FiscalRetention where !fr.IsDeleted orderby fr.Name
                                 select new { 
                                     fr.FiscalRetentionId,
                                     fr.Name,
                                     fr.Description,
                                     fr.Value
                                 }).ToList();
                var retentionList = new List<FiscalRetention>();
                foreach (var item in retention)
                {
                    retentionList.Add(new FiscalRetention
                    {
                        Id = item.FiscalRetentionId,
                        Name = item.Name,
                        Description = item.Description,
                        Value = item.Value
                    });
                }
                return retentionList;
            }
        }
        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var retention = (from fr in context.FiscalRetention where fr.FiscalRetentionId == Id select fr).First();
                retention.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.FiscalRetention, AuditOperations.Delete, Id, retention.Name);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
