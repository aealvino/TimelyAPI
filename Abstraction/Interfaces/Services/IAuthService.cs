﻿using Models.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginUser(LoginDto userForLogin);
    }
}
