using Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Abstraction.Interfaces.Services
{
    public interface ITokenService
    {
        public JwtSecurityToken GenerateToken(AppUser appUser);
    }
}
