using Abstraction.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace BLL.Services
{
    public class SeedService : ISeedService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public SeedService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedUsersAndRolesAsync()
        {
            string[] roleNames = { "User", "Admin", "Manager" };

            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new AppRole { Name = roleName, NormalizedName = roleName.ToUpper() });
                }
            }

            var users = new[]
            {
                new { Email = "user@example.com", UserName = "user", Password = "User123!", Role = "User" },
                new { Email = "admin@example.com", UserName = "admin", Password = "Admin123!", Role = "Admin" },
                new { Email = "manager@example.com", UserName = "manager", Password = "Manager123!", Role = "Manager" }
            };

            foreach (var userData in users)
            {
                var existingUser = await _userManager.FindByEmailAsync(userData.Email);
                if (existingUser == null)
                {
                    var user = new AppUser
                    {
                        UserName = userData.UserName,
                        Email = userData.Email,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(user, userData.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, userData.Role);
                    }
                }
            }
        }
    }
}
