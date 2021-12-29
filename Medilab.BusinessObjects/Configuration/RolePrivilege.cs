using System;
using System.Linq;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class RolePrivilege
    {
        #region Properties
        public Guid Id { private set; get; }
        public Guid RoleId { set; get; }
        public string Privilege { set; get; }
        #endregion

        #region Methods
        public RolePrivilege()
        {
        }

        public RolePrivilege(Guid id)
        {
            Id = id;
        }

        public RolePrivilege Save()
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
            var rolePrivilege = new DataAccess.RolePrivilege
            {
                RolePrivilegeId = Id = Guid.NewGuid(),
                RoleId = RoleId,
                PrivilegeName = Privilege
            };
            context.RolePrivilege.AddObject(rolePrivilege);
        }
        internal static void RemovePrivileges(MedilabEntities context, Guid roleId)
        {
            var privilegeList = (from p in context.RolePrivilege where p.RoleId == roleId select p).ToList();
            foreach (var rolePrivilege in privilegeList)
            {
                context.DeleteObject(rolePrivilege);
            }
        }

        #endregion
    }
}
