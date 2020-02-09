using EmployeeRegister.Common.Interfaces;
using System;

namespace EmployeeRegister.Models
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
