using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class ClientArea
    {
        #region Properties

        public Guid Id { get; private set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public byte[] LastUpdated { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Methods

        public ClientArea()
        {

        }

        public ClientArea(Guid id)
        {
            Id = id;
        }

        public ClientArea Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        internal void Save(MedilabEntities context)
        {
            if (Id == Guid.Empty)
            {
                Insert(context);
            }
            else
            {
                Update(context);
            }
        }

        private ClientArea Insert()
        {
            using (var context = new MedilabEntities())
            {
                Insert(context);
                context.SaveChanges();
                return this;
            }
        }

        internal void Insert(MedilabEntities context)
        {
            var clientArea = new DataAccess.ClientArea
                                 {
                                     ClientAreaId = Id = Guid.NewGuid(),
                                     CllientId = ClientId,
                                     AreaName = Name,
                                     IsDeleted = false
                                 };
            Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.ClientArea, AuditOperations.Insert,
                                 clientArea.ClientAreaId, clientArea.AreaName);
            context.AddToClientArea(clientArea);
        }

        private ClientArea Update()
        {
            using (var context = new MedilabEntities())
            {
                Update(context);
                context.SaveChanges();
                return this;
            }
        }

        internal void Update(MedilabEntities context)
        {
                var clientArea = (from p in context.ClientArea where p.ClientAreaId == Id select p).First();
                clientArea.AreaName = Name;
                var modifiedFields = Utilities.GetModifiedFields(context, clientArea.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.ClientArea, AuditOperations.Update,
                                     Id, modifiedFields);
        }

        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var clientArea = (from p in context.ClientArea where p.ClientAreaId == Id select p).First();
                if (Tools.IsRecordChanged(clientArea.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                clientArea.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.ClientArea, AuditOperations.Delete,
                                     Id, clientArea.AreaName);
                context.SaveChanges();
            }
        }

        public static ClientArea GetClientArea(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var clientArea = (from a in context.ClientArea
                                  where !a.IsDeleted && a.ClientAreaId == id
                                  select
                                      new ClientArea
                                          {
                                              Id = a.ClientAreaId,
                                              Name = a.AreaName,
                                              LastUpdated = a.LastUpdated,
                                          }).FirstOrDefault();
                if (clientArea != null)
                {
                    return clientArea;
                }
            }
            throw new Exception(BOResources.RecordNotFoudExeptionMessage);
        }

        public static IEnumerable<ClientArea> GetAreasByClient(Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                var clientAreas = (from a in context.ClientArea
                                   where !a.IsDeleted && a.CllientId == clientId
                                   select
                                       new ClientArea
                                           {
                                               Id = a.ClientAreaId,
                                               ClientId = a.CllientId,
                                               Name = a.AreaName,
                                               LastUpdated = a.LastUpdated
                                           }).ToList();
                return clientAreas;
            }
        }
        #endregion
    }
}
