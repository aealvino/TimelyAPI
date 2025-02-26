using Models.DTO;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interfaces.Services
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccessToken(AppUser user, IList<string> roles);
    }
}
