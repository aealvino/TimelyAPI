using Models.DTO;
using Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Abstraction.Interfaces.Services
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccessToken(AppUser user, IList<string> roles);
    }
}
