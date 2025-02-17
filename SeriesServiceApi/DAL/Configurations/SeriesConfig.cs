using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeriesServiceApi.DAL.Configurations
{
    public class SeriesConfig : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Genre).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.BoxOffice).HasPrecision(10, 2).IsRequired();

            builder.HasMany(x => x.Episodes)
                .WithOne(x => x.Series)
                .HasForeignKey(x => x.SeriesID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
