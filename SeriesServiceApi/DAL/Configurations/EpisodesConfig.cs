using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesServiceApi.Models.Entities;

namespace SeriesServiceApi.DAL.Configurations
{
    public class EpisodesConfig
    {
        public void Configure(EntityTypeBuilder<Episodes> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Series).IsRequired();
        }
    }
}
