using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
namespace DAL.EF
{
    public class StreamingServiceDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Series> Series { get; set; }
        public DbSet<Episode> Episodes { get; set; }
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
