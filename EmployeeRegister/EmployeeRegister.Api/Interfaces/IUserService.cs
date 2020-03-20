using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common;
using EmployeeRegister.Common.Interfaces;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserResult> AddUser(UserView user);
        Task<UserResult> UpdateUser(UserView user);
        Task<UserResult> DeleteUser(UserView user);
    }
}
