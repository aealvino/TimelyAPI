using Abstraction.Interfaces.Services;
using Azure.Core;
using DAL.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.DTO;
using Models.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Common.Resources;

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
                throw new UnauthorizedAccessException(string.Format(ErrorMessages.UserNotFound));

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateAccessToken(user, roles);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _userManager.SetAuthenticationTokenAsync(user, "Default", "RefreshToken", refreshToken);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponseDTO
            {
                AccessToken = tokenString,
                RefreshToken = refreshToken
            };
        }
        public async Task<AuthResponseDTO> RefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentException("Refresh token is required");

            var user = _userManager.Users.AsEnumerable()
               .FirstOrDefault(u => _userManager.GetAuthenticationTokenAsync(u, "Default", "RefreshToken").Result == refreshToken);

            if (user == null) throw new UnauthorizedAccessException("Invalid refresh token");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateAccessToken(user, roles);

            return new AuthResponseDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken
            };
        }

    }
}
