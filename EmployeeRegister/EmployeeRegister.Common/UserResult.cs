using EmployeeRegister.Common.Interfaces;
using System;

namespace EmployeeRegister.Common
{
    public class UserResult : IResult
    {
        public Guid Id { get; set; }

        public UserResult(Guid id)
        {
            Id = id;
        }
    }
}
