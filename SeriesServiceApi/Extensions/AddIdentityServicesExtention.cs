using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using SeriesServiceApi.Services;
using System;

namespace test.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<StreamingServiceDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthorization();
        }

        public async static void SeedIdentityData(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<StreamingServiceDbContext>();
            dbContext.Database.Migrate();

            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await IdentitySeeder.SeedAsync(userManager, roleManager);
        }
    }
}