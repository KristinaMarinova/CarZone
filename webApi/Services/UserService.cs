using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.jwtAuth.Helpers;
using CarZone.Services.jwtAuth.Interfaces;
using CarZone.Services.jwtAuth.Requests;
using CarZone.Services.jwtAuth.Responses;

namespace CarZone.Services.jwtAuth.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _customersDbContext;
        private readonly UserContext _userContext;
        public UserService(AppDbContext customersDbContext, UserContext userContext)
        {
            _customersDbContext = customersDbContext;
            _userContext = userContext;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var customer = await _customersDbContext.Users
                .SingleOrDefaultAsync(customer => customer.UserName.Trim() == loginRequest.Username.Trim());

            if (customer == null)
            {
                return null;
            }

            var passwordHash = PasswordEncrypt.ComputeHash(loginRequest.Password, customer.Salt);
            if (customer.Password != passwordHash)
            {
                return null;
            }

            customer.LastLogin = DateTime.UtcNow;
            await _customersDbContext.SaveChangesAsync();

            return new LoginResponse
            {
                UserId = customer.Id,
                Username = customer.UserName,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Token = TokenHelper.GenerateToken(customer),
            };
        }
        public User UpdateUserInfo(int id, User user)
        {
            var existingUser = _customersDbContext.Users.Where(x => x.Id == _userContext.UserId).SingleOrDefault();
            existingUser.PicPath = user.PicPath;
            _customersDbContext.SaveChangesAsync();
            return existingUser;
        }
        public async Task<LoginResponse> Register(User user)
        {
            var passwordResult = PasswordEncrypt.ComputeHash(user.Password);

            var userToAdd = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Phone = user.Phone,
                Password = passwordResult.Hash,
                Email = user.Email,
                PicPath = user.PicPath,
                UserType = user.UserType,
                LastLogin = DateTime.UtcNow,
                UserTypeID = user.UserTypeID,
                Cars = user.Cars,
                Salt = passwordResult.Salt
            };

            _customersDbContext.Users.Add(userToAdd);

            await _customersDbContext.SaveChangesAsync();

            return new LoginResponse
            {
                UserId = userToAdd.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = TokenHelper.GenerateToken(userToAdd),
            };
        }

    }
}
