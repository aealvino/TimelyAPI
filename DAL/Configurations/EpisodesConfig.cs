using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.DAL.Configurations
{
    public class EpisodesConfig
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Series).IsRequired();
        }
    }
}
