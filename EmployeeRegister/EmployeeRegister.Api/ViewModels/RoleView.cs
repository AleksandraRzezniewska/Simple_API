using EmployeeRegister.Common.Enums;
using System;

namespace EmployeeRegister.Api.ViewModels
{
    public class RoleView
    {
        public Guid? Id { get; set; }
        public RoleTitle RoleTitle { get; set; }
    }
}
