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
        private readonly AppDbContext _context;
        private readonly IUserService _usersService;
        public UsersController(AppDbContext context, IUserService usersService)
        {
            _context = context;
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userToReturn = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                PicPath = user.PicPath
            };


            return userToReturn;
        }

        [HttpPut("{id:int}")]
        public User PutUser(int id, User user)
        {
           return _usersService.UpdateUserInfo(id, user);
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

            return await _usersService.Register(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                throw new ArgumentException("Missing_login_details");
            }

            var loginResponse = await _usersService.Login(loginRequest);

            if (loginResponse == null)
            {
                throw new ArgumentException("Invalid_credentials");
            }

            return Ok(loginResponse);
        }

    }
}
