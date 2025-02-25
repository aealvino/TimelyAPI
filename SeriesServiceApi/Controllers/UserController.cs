using Abstraction.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entities;
using System.Threading.Tasks;

namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(IUserService userService, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }


        [HttpPost("Register")]
        public async Task<int> RegisteredUser([FromBody] RegistrationModel userForRegistration)
        {
            if (userForRegistration == null)
                throw new Exception("Invalid registration data");
            var result = await _userService.RegisterUser(userForRegistration);
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
