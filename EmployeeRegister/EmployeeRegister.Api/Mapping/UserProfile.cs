using AutoMapper;
using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Models;

namespace EmployeeRegister.Api.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserView>();
        }
    }
}
