using Abstraction.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;

namespace BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public JwtSecurityToken GenerateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.Email, appUser.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:HelloWorld!"])),
                    SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}
