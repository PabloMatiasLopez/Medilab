using System;
using System.Linq;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class UserRole
    {
         #region Properties
        public Guid Id { private set; get; }
        public Guid RoleId { set; get; }
        public Guid UserId { set; get; }
        public String RoleName { set; get; }
        #endregion

        #region Methods
        public UserRole()
        {
        }

        internal UserRole(Guid id)
        {
            Id = id;
        }

        internal void Insert(MedilabEntities context)
        {
            var userRole = new DataAccess.UserRole
            {
                UserRoleId = Id = Guid.NewGuid(),
                RoleId = RoleId,
                UserId = UserId
            };
            context.UserRole.AddObject(userRole);
        }
        internal static void RemoveRoles(MedilabEntities context, Guid userId)
        {
            var roleList = (from r in context.UserRole where r.UserId == userId select r).ToList();
            foreach (var userRole in roleList)
            {
                context.DeleteObject(userRole);
            }
        }

        #endregion
    }
}
