using Abstraction.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.YourNamespace.DTOs;

namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<int> Register([FromBody] RegistrationDto registrationDto)
        {
            if (registrationDto == null)
                throw new ArgumentNullException("Registration data is required");
            var result = await _userService.RegisterUser(registrationDto);
            return result;
        }

        [HttpPost("Login")]
        public async Task<string> Login([FromBody] LoginModelDTO userForLogin)
        {
            if (userForLogin == null)
                throw new Exception("Invalid login data");

            var token = await _userService.LoginUser(userForLogin);
            return token;
        }
    }
}
