using EmployeeRegister.Common.Interfaces;
using System;

namespace EmployeeRegister.Common
{
    public class UserResult : IResult
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

        public UserResult(Guid id)
        {
            Id = id;
        }

        public UserResult(Guid id, string token)
        {
            Id = id;
            Token = token;
        }
    }
}
