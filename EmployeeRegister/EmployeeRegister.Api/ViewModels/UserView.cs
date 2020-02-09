using System;

namespace EmployeeRegister.Api.ViewModels
{
    public class UserView
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
