using EmployeeRegister.Models;
using System;
using System.Collections.Generic;

namespace EmployeeRegister.Api.ViewModels
{
    public class UserView
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Guid> RoleId { get; set; }
    }
}
