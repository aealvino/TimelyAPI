using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entities;

namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<UserForRegistrationDTO> RegisteredUser([FromBody] UserForRegistrationDTO userForRegistration)
        {
            if (await _userManager.FindByEmailAsync(userForRegistration.Email) != null)
            {
                throw new Exception("User with this email already exists");
            }

            var user = _mapper.Map<AppUser>(userForRegistration);
            user.UserName = userForRegistration.Email; 
            user.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                throw new Exception($"User creation failed");
            }
            return userForRegistration;
        }
        [HttpPost("login")]
        public async Task<string> Login([FromBody] UserForLoginDTO userForLogin)
        {
            var user = await _userManager.FindByEmailAsync(userForLogin.Email);
            if (user == null) return "Invalid login attempt.";

            var result = await _signInManager.PasswordSignInAsync(user, userForLogin.Password, false, false);

            if (!result.Succeeded) return "Invalid login attempt.";
            
            return "Login successful";
        }
        [HttpPost("logout")]
        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            return "Logout successful";
        }

    }
}
