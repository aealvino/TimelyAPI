using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace SeriesServiceApi.Services
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            //string email = "superadmin@example.com";
            //string password = "SuperAdmin123!";
            //string roleName = "SuperAdmin";

            string[] roles = { "SuperAdmin", "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
