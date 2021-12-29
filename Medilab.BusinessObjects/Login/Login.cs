using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using User = Medilab.BusinessObjects.Configuration.User;

namespace Medilab.BusinessObjects.Login
{
    public class Login
    {
        #region Properties
        public Guid UserId { set; get; }
        public string UserName { set; get; }
        public string FirstName { private set; get; }
        public string LastName { private set; get; }
        public string Password { set; get; }
        public bool IsValid { private set; get; }
        public IEnumerable<Privileges> Privileges { private set; get; } 
        #endregion
        #region Methods
        public static Login Validate(string userName, string password)
        {
            using (var context = new MedilabEntities())
            {
                try
                {
                    var user = User.GetUser(context, userName, password);
                    var roleList = user.UserRoles.Select(roles => roles.RoleId).ToList();
                    var userPrivileges =
                        (from p in context.RolePrivilege where roleList.Contains(p.RoleId) select p.PrivilegeName).
                            ToList();
                    var privilegeList = userPrivileges.Select(privilege => (Privileges) Enum.Parse(typeof (Privileges), privilege)).ToList();
                    #if DEBUG
                    if (user.UserName == @"administrator")
                    {
                        privilegeList = GetAdminPrivileges();
                    }
                    #endif
                    return new Login
                    {
                        UserId = user.Id,
                        UserName = userName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        IsValid = true,
                        Privileges = privilegeList
                    };
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return new Login
                    {
                        UserName = userName,
                        FirstName = string.Empty,
                        LastName = string.Empty,
                        IsValid = false,
                        Privileges = null
                    };
                }
            }
        }
        public bool ChangePassword(string newPassword)
        {
            var validLogin = Validate(UserName, Password);
            if (!validLogin.IsValid)
            {
                return false;
            }
            var user = User.GetUser(UserId);
            user.ChangePassword(newPassword);
            return true;
        }
        private static List<Privileges> GetAdminPrivileges()
        {
            var pri = Enum.GetNames(typeof (Privileges));
            return pri.Select(privilege => (Privileges) Enum.Parse(typeof (Privileges), privilege)).ToList();
        }

        #endregion
    }
}
