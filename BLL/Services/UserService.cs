using Abstraction.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models.DTO.YourNamespace.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<int> RegisterUser(RegistrationDto registrationDto)
        {
            if (registrationDto == null)
                throw new Exception("You've missed field");
            var user = _mapper.Map<AppUser>(registrationDto);
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
                throw new Exception("Failed to register a user");

            return StatusCodes.Status200OK;
        }
    }
}
