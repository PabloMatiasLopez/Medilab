using System;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using User = Medilab.BusinessObjects.Configuration.User;

namespace Medilab.BusinessObjects.Audit
{
    public class Audit
    {
        #region Properties

        public Guid Id { set; get; }
        public DateTime Created { get; set; }
        public User AuditUser { set; get; }
        public ObjectTypes ObjectType { set; get; }
        public AuditOperations Operation { set; get; }
        public string OldValues { set; get; }
        public string NewValues { set; get; }

        #endregion

        #region Methods

        internal static void LogAudit(MedilabEntities context, Guid userId, ObjectTypes objectType,
                                      AuditOperations operation, Guid objectId, string changedValues)
        {
            var objectTypeId = (int) objectType;
            var auditLog = new DataAccess.Audit
                               {
                                   AuditId = Guid.NewGuid(),
                                   AuditCreatedDate = DateTime.Now,
                                   User = (from u in context.User where u.UserId == userId select u).First(),
                                   ObjectType =
                                       (from ot in context.ObjectType where ot.ObjectTypeId == objectTypeId select ot).
                                       First(),
                                   AuditOperation = operation.ToString(),
                                   AuditObjectId = objectId,
                                   AuditChangedValues = changedValues
                               };
            context.AddToAudit(auditLog);
        }

        #endregion
    }
}
