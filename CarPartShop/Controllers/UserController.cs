using CarPartShop.DTO;
using CarPartShop.Services;
using Microsoft.AspNetCore.Mvc;
using CarPartShop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var response = _userService.Register(request);
            if (response == null)
                return Conflict(new { message = "This email is already used!" });
            else
                return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            var response = _userService.Login(request);
            if (response == null)
                return Unauthorized(new { message = "The email or password is incorrect" });

            return Ok(response);
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("isLoggedIn")]
        [Authorize]
        public IActionResult IsLoggedIn()
        {
            return Ok(true);
        }
    }
}
