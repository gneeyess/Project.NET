using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Configurations
{
	class TourTypeConfiguration : IEntityTypeConfiguration<TourType>
	{
        public void Configure(EntityTypeBuilder<TourType> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Tours).IsRequired();
        }
    }
}
