using Abstraction.Interfaces.Services;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.YourNamespace.DTOs;

namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<int> Register([FromBody] RegistrationDto registrationDto)
        {
            if (registrationDto == null)
                throw new ArgumentNullException("Registration data is required");
            var result = await _userService.RegisterUser(registrationDto);
            return result;
        }
    }
}
