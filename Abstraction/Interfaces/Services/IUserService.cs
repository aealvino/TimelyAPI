﻿using Models.DTO.YourNamespace.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> RegisterUser(RegistrationDto registrationDto);
    }
}
