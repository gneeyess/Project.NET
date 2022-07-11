using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Configurations
{
    public class TourTypeConfiguration : IEntityTypeConfiguration<TourType>
	{
        public void Configure(EntityTypeBuilder<TourType> builder)
        {
            builder.HasKey(tourType => tourType.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);

        }
    }
}
