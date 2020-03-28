using EmployeeRegister.Api.Interfaces;
using EmployeeRegister.Api.ViewModels;
using EmployeeRegister.Common;
using EmployeeRegister.Common.Configuration;
using EmployeeRegister.Common.Interfaces;
using EmployeeRegister.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegister.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly AppSettings _appSettings;
             
        public UserService(IRepository repository, IOptions<AppSettings> appSettings)
        {
            _repository = repository;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResult> Authenticate(string email, string password)
        {
            var users = await _repository.GetAll<User>();

            var authenticatedUser = users.SingleOrDefault(x => x.Email == email && x.Password == password);

            if (authenticatedUser == null)
            {
                throw new NullReferenceException("Username or Password is incorrect");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticatedUser.Id.ToString()),
                    new Claim(ClaimTypes.Role, authenticatedUser.UserRoles.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            authenticatedUser.Token = tokenHandler.WriteToken(token);
            
            return new UserResult(authenticatedUser.Id, authenticatedUser.Token);
        }

        public async Task<UserResult> AddUser(UserView user)
        {
            var newUser = new User(user.FirstName, user.LastName, user.Email, user.Password);
            var userRoleList = new List<UserRole>();

            foreach (var i in user.RoleId)
            {
                var newUserRoles = new UserRole(newUser.Id, i);
                userRoleList.Add(newUserRoles);
            }

            newUser.UserRoles = userRoleList;

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
                userToUpdate.Password = user.Password;
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
