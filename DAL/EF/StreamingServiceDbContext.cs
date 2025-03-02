using DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
namespace DAL.EF
{
    public class StreamingServiceDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Series> Series { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }

        public StreamingServiceDbContext(DbContextOptions<StreamingServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var applicationContextAssembly = typeof(StreamingServiceDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(applicationContextAssembly);
            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}
