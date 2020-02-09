using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common;
using EmployeeRegister.Common.Interfaces;
using EmployeeRegister.Models;
using System;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Services
{
    public class UserService : IService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResult> AddUser(UserView user)
        {
            var newUser = new User(user.FirstName, user.LastName, user.Email);

            await _repository.Add(newUser);
            await _repository.Save();

            return new UserResult(newUser.Id);
        }

        public async Task<UserResult> UpdateUser(UserView user)
        {
            var userToUpdate = await _repository.GetById<User>(user.Id.Value);

            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                await _repository.Save();
            }
            else
            {
                throw new NullReferenceException("User in not in the database");
            }

            return new UserResult(userToUpdate.Id);
        }

        public async Task<UserResult> DeleteUser(UserView user)
        {
            var userToDelete = await _repository.GetById<User>(user.Id.Value);

            await _repository.Delete<User>(userToDelete);
            await _repository.Save();

            return new UserResult(userToDelete.Id);
        }
    }
}
