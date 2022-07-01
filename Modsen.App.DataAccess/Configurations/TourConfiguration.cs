using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Configurations
{
	class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(tour => tour.Id);
            builder.HasIndex(tour => tour.Id).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Price).IsRequired().HasMaxLength(12);
            builder.Property(p => p.Start).IsRequired();
            //Is p.End actually required?
            builder.Property(p => p.TourType).IsRequired();
            builder.Property(p => p.Transport).IsRequired();
            //p.Description Is not required
        }
    }
}
