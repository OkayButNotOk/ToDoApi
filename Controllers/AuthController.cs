using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using ToDoApi.DTOs;
using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IUserService _userService;
        public AuthController(AuthService authService, IUserService userService)
        {
            _authService = authService;
            this._userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto) 
        {
           
            var response = _userService.RegisterUser(userDto);

            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto userDto)
        {
            User existingUser = _userService.GetUser(userDto.Username);

            if (existingUser != null && BCrypt.Net.BCrypt.Verify(userDto.Password, existingUser.PasswordHash))
            {
                var token = _authService.GenerateToken(existingUser);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}
