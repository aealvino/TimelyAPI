using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace SeriesServiceApi.Services
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            string email = "superadmin@example.com";
            string password = "SuperAdmin123!";
            string roleName = "SuperAdmin";


            string[] roles = { "SuperAdmin", "Admin", "User" };

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var superAdminEmail = "superadmin@example.com";

            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    FullName = "Главный Админ",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
