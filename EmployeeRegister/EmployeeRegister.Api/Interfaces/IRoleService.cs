using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Interfaces
{
    public interface IRoleService
    {
        Task<RoleResult> AddRole(RoleView role);
        Task<RoleResult> DeleteRole(RoleView role);
    }
}
