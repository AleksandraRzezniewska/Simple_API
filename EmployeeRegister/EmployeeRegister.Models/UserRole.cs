﻿using EmployeeRegister.Common.Interfaces;
using System;

namespace EmployeeRegister.Models
{
    public class UserRole : IEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
