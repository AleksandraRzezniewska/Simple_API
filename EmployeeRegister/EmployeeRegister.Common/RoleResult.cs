using EmployeeRegister.Common.Interfaces;
using System;

namespace EmployeeRegister.Common
{
    public class RoleResult : IResult
    {
        public Guid RoleId { get; set; }

        public RoleResult(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}
