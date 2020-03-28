using AutoMapper;
using EmployeeRegister.Api.Interfaces;
using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common.Interfaces;
using EmployeeRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public RoleController(IRepository repository, IRoleService service, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        public RoleView MapRoleAndRoleView(RoleView roleView)
        {
            return _mapper.Map<RoleView>(roleView);
        }

        [HttpPost]
        public async Task<IResult> AddRole(RoleView roleView)
        {
            var role = MapRoleAndRoleView(roleView);

            return await _service.AddRole(role);
        }
      
        [HttpGet]
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _repository.GetAll<Role>();
        }

        [HttpDelete]
        public async Task<IResult> DeleteRole(RoleView roleView)
        {
            var role = MapRoleAndRoleView(roleView);

            return await _service.DeleteRole(role);
        }
    }
}
