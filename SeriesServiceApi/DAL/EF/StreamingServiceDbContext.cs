using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SeriesServiceApi.DAL.Configurations;
using SeriesServiceApi.Models.Entities;
using System;
using Mapster;

namespace SeriesServiceApi.DAL.EF
{
    public class StreamingServiceDbContext : DbContext
    {
        public DbSet<Series> Series { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public StreamingServiceDbContext(DbContextOptions<StreamingServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new SeriesConfig());
            
            base.OnModelCreating(modelBuilder);

            var applicationContextAssembly = typeof(StreamingServiceDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(applicationContextAssembly);
        }
    }
}
