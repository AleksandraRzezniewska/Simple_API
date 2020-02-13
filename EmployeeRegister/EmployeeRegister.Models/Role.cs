using EmployeeRegister.Common.Enums;
using System.Collections.Generic;

namespace EmployeeRegister.Models
{
    public class Role : EntityBase
    {
        public RoleTitle RoleTitle { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}
