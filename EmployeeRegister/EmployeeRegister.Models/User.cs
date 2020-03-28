using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmployeeRegister.Models
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User()
        {
        }
    }
}
