using Abstraction.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Models.DTO;
using Models.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(ITokenService tokenService, UserManager<AppUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<AuthResponseDTO> LoginUser(LoginDto userForLogin)
        {
            var user = await _userManager.FindByEmailAsync(userForLogin.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForLogin.Password))
                throw new Exception("Invalid email or password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateAccessToken(user, roles);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponseDTO
            {
                AccessToken = tokenString
            };
        }
    }
}
