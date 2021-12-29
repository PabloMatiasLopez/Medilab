using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class Role : IConcurrence
    {
        #region Properties
        public Guid Id { private set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public IEnumerable<RolePrivilege> Privileges { set; get; }
        public byte[] LastUpdated { get; set; }
        #endregion

        #region Methods

        private Role()
        {
        }

        public Role(Guid id)
        {
            Id = id;
        }

        public Role Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private Role Update()
        {
            using (var context = new MedilabEntities())
            {
                var role = (from r in context.Role where r.RoleId == Id select r).First();
                if (Tools.IsRecordChanged(role.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                role.RoleName = Name;
                role.RoleDescription = Description;
                RolePrivilege.RemovePrivileges(context, Id);
                InsertPrivileges(context);
                var modifiedFields = Utilities.GetModifiedFields(context, role.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Role, AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }

        private Role Insert()
        {
            using (var context = new MedilabEntities())
            {
                var role = new DataAccess.Role
                               {
                                   RoleId = Id = Guid.NewGuid(),
                                   RoleName = Name,
                                   RoleDescription = Description
                               };
                context.Role.AddObject(role);
                InsertPrivileges(context);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Role, AuditOperations.Insert, Id, role.RoleName);
                context.SaveChanges();
                return this;
            }
        }

        private void InsertPrivileges(MedilabEntities context)
        {
            foreach (var privilege in Privileges)
            {
                var rolePrivilege = new RolePrivilege {RoleId = Id, Privilege = privilege.Privilege};
                rolePrivilege.Save(context);
            }
        }

        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var role = (from r in context.Role where r.RoleId == Id select r).First();
                context.DeleteObject(role);
                RolePrivilege.RemovePrivileges(context, Id);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Role, AuditOperations.Delete, Id, role.RoleName);
                context.SaveChanges();
            }
        }

        public static Role GetRole(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var role = (from r in context.Role
                            where r.RoleId == id
                            select new
                                       {
                                           r.RoleId,
                                           r.RoleName,
                                           r.RoleDescription,
                                           r.LastUpdated,
                                           Privileges =
                                (from p in r.RolePrivilege select new {p.RolePrivilegeId, p.PrivilegeName})
                                       }).FirstOrDefault();
                if (role != null)
                {
                    //var privileges = (from p in context.RolePrivileges where p.RoleId == role.RoleId select p).ToList();
                    var privilegesList =
                        role.Privileges.Select(
                            privilege =>
                            new RolePrivilege(privilege.RolePrivilegeId)
                                {RoleId = role.RoleId, Privilege = privilege.PrivilegeName}).ToList();
                    return new Role
                               {
                                   Id = role.RoleId,
                                   Name = role.RoleName,
                                   Description = role.RoleDescription,
                                   Privileges = privilegesList,
                                   LastUpdated = role.LastUpdated
                               };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }

        public static IEnumerable<Role> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var roles = (from r in context.Role orderby r.RoleName select r).ToList();
                return roles.Select(role => new Role
                                                {
                                                    Id = role.RoleId,
                                                    Name = role.RoleName,
                                                    Description = role.RoleDescription
                                                }).ToList();
            }
        }
        #endregion
    }
}
