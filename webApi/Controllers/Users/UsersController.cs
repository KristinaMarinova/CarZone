using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Models.DTOs;
using CarZone.Services.jwtAuth.Interfaces;
using CarZone.Services.jwtAuth.Requests;
using CarZone.Services.jwtAuth.Responses;

namespace CarZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IUserService usersService;
        public UsersController(AppDbContext context, IUserService usersService)
        {
            this.context = context;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<UserDTO> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                throw new ArgumentException("User doesn't exist.");
            }

            var userToReturn = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                PicPath = user?.PicPath
            };

            return userToReturn;
        }

        [HttpPut("{id:int}")]
        public User PutUser(int id, User user)
        {
           return usersService.UpdateUserInfo(id, user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> PostUser(User user)
        {
            var regex = @"(?:\d+[a-z]|[a-z]+\d)[a-z\d]*";

            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                 return BadRequest("Username, First name and Last name can not be empty.");
            }

            var match = Regex.Match(user.UserName, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return BadRequest("Username must contain at least one letter or number.");
            }

            if (user.Phone.Length < 10)
            {
                return BadRequest("Phone number must be at least 10 numbers");
            }

            return await usersService.Register(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return user;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                throw new ArgumentException("Missing login details");
            }

            var loginResponse = await usersService.Login(loginRequest);

            if (loginResponse == null)
            {
                throw new ArgumentException("Invalid credentials");
            }

            return Ok(loginResponse);
        }

    }
}
