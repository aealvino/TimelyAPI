using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interfaces.Services
{
    public interface IUserService
    {
        public Task<int> RegisterUser(RegistrationModel userForRegistration);
        public Task<string> LoginUser(LoginModelDTO userForLogin);
    }
}
