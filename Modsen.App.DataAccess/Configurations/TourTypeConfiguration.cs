using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Configurations
{
	class TourTypeConfiguration : IEntityTypeConfiguration<TourType>
	{
        public void Configure(EntityTypeBuilder<TourType> builder)
        {
            builder.HasKey(tourType => tourType.Id);
            builder.HasIndex(tourType => tourType.Id).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Tours).IsRequired();
        }
    }
}
