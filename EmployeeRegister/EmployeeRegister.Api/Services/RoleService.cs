using EmployeeRegister.Api.Interfaces;
using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common;
using EmployeeRegister.Common.Interfaces;
using EmployeeRegister.Models;
using System;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository _repository;

        public RoleService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoleResult> AddRole(RoleView role)
        {
            var newRole = new Role(role.RoleTitle);
            var allRoles = await _repository.GetAll<Role>();

            if (role.RoleTitle == Common.Enums.RoleTitle.Admin || role.RoleTitle == Common.Enums.RoleTitle.User)
            {
                foreach (var i in allRoles)
                {
                    if (i.RoleTitle == newRole.RoleTitle)
                    {
                        throw new NullReferenceException("Role already exists in database");
                    }
                }

                await _repository.Add(newRole);
                await _repository.Save();
                return new RoleResult(newRole.Id);
            }
            else
            {
                throw new NullReferenceException("Role does not exist");
            }
        }

        public async Task<RoleResult> DeleteRole(RoleView role)
        {
            var roleToDelete = await _repository.GetById<Role>(role.Id.Value);

            await _repository.Delete(roleToDelete);
            await _repository.Save();

            return new RoleResult(roleToDelete.Id);
        }
    }
}
