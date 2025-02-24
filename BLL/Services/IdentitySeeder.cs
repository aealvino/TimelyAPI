using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace SeriesServiceApi.Services
{
    public class IdentitySeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public IdentitySeeder(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            string[] roles = { "SuperAdmin", "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var superAdminEmail = "superadmin@example.com";
            var superAdmin = await _userManager.FindByEmailAsync(superAdminEmail);

            if (superAdmin == null)
            {
                var user = new AppUser
                {
                    UserName = superAdminEmail,
                    Email = superAdminEmail,
                    EmailConfirmed = true,
                    FullName = "Super Admin"
                };

                var result = await _userManager.CreateAsync(user, "SuperAdmin123!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }
    }
}
