using AutoMapper;
using EmployeeRegister.Api.Services;
using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common.Interfaces;
using EmployeeRegister.Models;
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
        private readonly IMapper _mapper;

        public UserController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserView MapUserAndUserView(UserView user)
        {
            return _mapper.Map<UserView>(user);
        }

        [HttpPost]
        public async Task<IResult> CreateUser(UserView user)
        {
            var userService = new UserService(_repository);
            var model = MapUserAndUserView(user); 
            
            return await userService.AddUser(model);
        }

        [HttpPut]
        public async Task<IResult> UpdateUser(UserView user)
        {
            var userService = new UserService(_repository);
            var model = MapUserAndUserView(user);

            return await userService.UpdateUser(model);
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
        public async Task<IResult> DeleteUser(UserView user)
        {
            var userService = new UserService(_repository);
            var model = MapUserAndUserView(user);

            return await userService.DeleteUser(model);
        }
    }
}
