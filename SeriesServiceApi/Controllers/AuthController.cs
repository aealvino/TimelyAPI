using Abstraction.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<AuthResponseDTO> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(loginDto), "Login data cannot be null");
            }
            var tokens = await _authService.LoginUser(loginDto);
            return tokens;
        }
        //[HttpPost("refresh")]
        //public async Task<AuthResponseDTO> Refresh([FromBody] RefreshRequest request)
        //{
        //    if (string.IsNullOrEmpty(request.RefreshToken))
        //    {
        //        throw new ArgumentException("Refresh token is required");
        //    }
        //        var tokens = await _authService.RefreshTokenAsync(request.RefreshToken);
        //    return tokens;
        //}
    }
}
