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
            //builder.HasIndex(tour => tour.Id).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Price).IsRequired().HasMaxLength(12);//delete

            // configures one-to-many relationship
            //builder.HasOne(t => t.TourType).WithMany(b => b.Tours).HasForeignKey(k => k.Id).IsRequired();

            //builder.HasOne(t => t.Transport).WithMany(b => b.Tours).HasForeignKey(k => k.Id).IsRequired();
            builder.HasOne(t => t.TourType).WithMany(b => b.Tours).HasForeignKey(k => k.TourTypeId);

            builder.HasOne(t => t.Transport).WithMany(b => b.Tours).HasForeignKey(k => k.TransportId);
        }
    }
}
