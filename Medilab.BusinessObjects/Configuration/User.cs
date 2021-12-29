using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class User : IConcurrence
    {
        #region Properties

        public Guid Id { private set; get; }
        public string UserName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public bool IsActive { set; get; }
        public bool IsDeleted { set; get; }
        public byte[] LastUpdated { get; set; }
        public IEnumerable<UserRole> UserRoles { set; get; }
        public Speciality Speciality { set; get; }

        #endregion

        #region Methods

        private User()
        {
        }

        public User(Guid id)
        {
            Id = id;
        }

        public User Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private User Update()
        {
            using (var context = new MedilabEntities())
            {
                var user = (from r in context.User where r.UserId == Id select r).First();
                if (Tools.IsRecordChanged(user.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                user.UserFirstName = FirstName;
                user.UserLastName = LastName;
                user.EmailAddress = Email;
                user.IsActive = IsActive;
                user.UserName = UserName;
                if (Password != null)
                {
                    user.Password = Security.ComputeHash(Password, HashType.SHA256);
                }
                InsertRoles(context);
                user.SpecialityId = Speciality.Id;
                var modifiedFields = Utilities.GetModifiedFields(context, user.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.User, AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }

        private User Insert()
        {
            using (var context = new MedilabEntities())
            {
                var user = new DataAccess.User
                               {
                                   UserId = Id = Guid.NewGuid(),
                                   UserName = UserName,
                                   UserFirstName = FirstName,
                                   UserLastName = LastName,
                                   EmailAddress = Email,
                                   IsActive = IsActive = true,
                                   IsDeleted = IsDeleted = false,
                                   Password = Security.ComputeHash(Password,HashType.SHA256),
                                   SpecialityId = Speciality.Id
                               };
                context.AddToUser(user);
                InsertRoles(context);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.User, AuditOperations.Insert,
                                     user.UserId, user.UserName);
                context.SaveChanges();
                return this;
            }
        }

        private void InsertRoles(MedilabEntities context)
        {
            UserRole.RemoveRoles(context, Id);
            foreach (var userRole in UserRoles.Select(role => new UserRole { RoleId = role.RoleId, UserId = Id }))
            {
                userRole.Insert(context);
            }
        }

        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var user = (from u in context.User where u.UserId == Id select u).First();
                if (Tools.IsRecordChanged(user.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                user.IsActive = false;
                user.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.User, AuditOperations.Delete, Id, user.UserName);
                context.SaveChanges();
            }
        }

        public static User GetUser(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var user = (from u in context.User
                            where u.UserId == id
                            select new UserDto
                                       {
                                           Id = u.UserId,
                                           UserName = u.UserName,
                                           FirstName = u.UserFirstName,
                                           LastName = u.UserLastName,
                                           Email = u.EmailAddress,
                                           IsActive = u.IsActive,
                                           IsDeleted = u.IsDeleted,
                                           LastUpdated = u.LastUpdated,
                                           UserRoles =
                                               (from r in u.UserRole
                                                select
                                                    new UserRoleDto
                                                        {
                                                            Id = r.UserRoleId,
                                                            RoleId = r.RoleId,
                                                            RoleName = r.Role.RoleName
                                                        }),
                                           Speciality = new SpecialityDto
                                                            {
                                                                Id = u.SpecialityId,
                                                                Name = u.Speciality.SpecialityName,
                                                                Description = u.Speciality.SpecialityDescription
                                                            }
                                       }).FirstOrDefault();
                if (user != null)
                {
                    return GetUser(user);
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }

        internal static User GetUser(MedilabEntities context, string userName, string password)
        {
            
            var user = (from u in context.User
                        where u.UserName == userName
                        select new UserDto
                                   {
                                       Id = u.UserId,
                                       UserName = u.UserName,
                                       FirstName = u.UserFirstName,
                                       LastName = u.UserLastName,
                                       Email = u.EmailAddress,
                                       IsActive = u.IsActive,
                                       IsDeleted = u.IsDeleted,
                                       Password = u.Password,
                                       UserRoles = 
                            (from r in u.UserRole select new UserRoleDto {Id = r.UserRoleId, RoleId = r.RoleId, RoleName = r.Role.RoleName}),
                                       Speciality = new SpecialityDto
                                                        {
                                                            Id = u.Speciality.SpecialityId,
                                                            Name = u.Speciality.SpecialityName,
                                                            Description = u.Speciality.SpecialityDescription
                                                        }
                                   }).FirstOrDefault();
            if (user != null)
            {
                if (Security.VerifyHash(password, HashType.SHA256, user.Password))
                {
                    return GetUser(user);
                }
            }
            throw new Exception(BOResources.UserOrPasswordInvalid);
        }

        private static User GetUser(UserDto user)
        {
             var roleList =
                        user.UserRoles.Select(
                            roles =>
                            new UserRole(roles.Id) { RoleId = roles.RoleId, UserId = user.Id, RoleName = roles.RoleName }).ToList();
                    return new User
                               {
                                   Id = user.Id,
                                   FirstName = user.FirstName,
                                   LastName = user.LastName,
                                   Email = user.Email,
                                   UserName = user.UserName,
                                   IsActive = user.IsActive,
                                   IsDeleted = user.IsDeleted,
                                   UserRoles = roleList,
                                   LastUpdated = user.LastUpdated,
                                   Speciality = new Speciality(user.Speciality.Id)
                                   {
                                       Name = user.Speciality.Name,
                                       Description = user.Speciality.Description
                                   }
                               };
        }
        public static IEnumerable<User> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var users = (from u in context.User where !u.IsDeleted orderby u.UserLastName select u).ToList();
                return users.Select(user => new User
                                                {
                                                    Id = user.UserId,
                                                    Email = user.EmailAddress,
                                                    FirstName = user.UserFirstName,
                                                    LastName = user.UserLastName,
                                                    IsActive = user.IsActive,
                                                    IsDeleted = user.IsDeleted,
                                                    UserName = user.UserName
                                                }).ToList();
            }
        }

        public void ChangePassword(string newPassword)
        {
            using (var context = new MedilabEntities())
            {
                var user = (from r in context.User where r.UserId == Id select r).First();
                if (Tools.IsRecordChanged(user.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                user.Password = Security.ComputeHash(newPassword, HashType.SHA256);
                context.SaveChanges();
            }
        }
        
        public static bool IsUserNameAvailable(string username, Guid userId)
        {
            using (var context = new MedilabEntities())
            {
                return !(from r in context.User where r.UserName == username && r.UserId != userId select r).Any();
            }
        }
        #endregion
    }
}
