using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Models.DTO.YourNamespace.DTOs;
using Models.Entities;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<int> RegisterUser(RegistrationDto registrationDto)
        {
            if (registrationDto == null)
                throw new Exception("You've missed field");
            var user = _mapper.Map<AppUser>(registrationDto);
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
                throw new Exception("Failed to register a user");
            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.PasswordSignInAsync(user, "User", isPersistent:true, lockoutOnFailure:true);

            return StatusCodes.Status200OK;
        }
        public async Task<string> LoginUser(LoginModelDTO userForLogin)
        {
            var user = await _userManager.FindByEmailAsync(userForLogin.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForLogin.Password))
                throw new Exception("Invalid email or password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
