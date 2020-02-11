using AutoMapper;
using EmployeeRegister.Api.Interfaces;
using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common.Interfaces;
using EmployeeRegister.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IRepository _repository;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IRepository repository, IUserService service, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        public UserView MapUserAndUserView(UserView userView)
        {
            return _mapper.Map<UserView>(userView);
        }

        [HttpPost]
        public async Task<IResult> CreateUser(UserView userView)
        {
            var user = MapUserAndUserView(userView); 
            
            return await _service.AddUser(user);
        }

        [HttpPut]
        public async Task<IResult> UpdateUser(UserView userView)
        {
            var user = MapUserAndUserView(userView);

            return await _service.UpdateUser(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAll<User>();
        } 

        [HttpGet("{id}")]
        public async Task<User> GetById(Guid id)
        {
            return await _repository.GetById<User>(id);
        }

        [HttpDelete]
        public async Task<IResult> DeleteUser(UserView userView)
        {
            var user = MapUserAndUserView(userView);

            return await _service.DeleteUser(user);
        }
    }
}
