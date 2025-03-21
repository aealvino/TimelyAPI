﻿using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace SeriesServiceApi.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StreamingServiceDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }
    }

}
