using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(tour => tour.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Price).IsRequired().HasMaxLength(12);

            // configures one-to-many relationship
            builder.HasOne(t => t.TourType).WithMany(b => b.Tours).HasForeignKey(k => k.Id).IsRequired();

            builder.HasOne(t => t.Transport).WithMany(b => b.Tours).HasForeignKey(k => k.Id).IsRequired();

            //builder.Property(p => p.Start).IsRequired();
            //builder.Property(p => p.End).IsRequired();
            //Description is not required
        }
    }
}
