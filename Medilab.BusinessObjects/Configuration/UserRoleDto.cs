using System;

namespace Medilab.BusinessObjects.Configuration
{
    internal class UserRoleDto
    {
        public Guid Id { set; get; }
        public Guid RoleId { set; get; }
        public String RoleName { set; get; }
    }
}
