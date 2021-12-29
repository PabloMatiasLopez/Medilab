using System;
using System.Collections.Generic;

namespace Medilab.BusinessObjects.Configuration
{
    internal class UserDto
    {
        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public bool IsActive { set; get; }
        public bool IsDeleted { set; get; }
        public byte[] LastUpdated { get; set; }
        public IEnumerable<UserRoleDto> UserRoles { set; get; }
        public SpecialityDto Speciality { set; get; }
    }
}
