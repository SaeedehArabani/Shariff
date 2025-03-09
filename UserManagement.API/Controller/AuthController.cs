//using System;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Infrastructure.Services;

namespace UserManagement.API.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            if (_authService.ValidateUserAsync(request.Username, request.Password))
            {
                var token = _authService.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized("نام کاربری یا رمز عبور اشتباه است.");
            }
        }
    }
}
