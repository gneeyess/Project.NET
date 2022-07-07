using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Configurations
{
	public class BookingConfiguration : IEntityTypeConfiguration<Booking>
	{
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(booking => booking.Id);
            builder.HasIndex(booking => booking.Id).IsUnique();

            // configures one-to-many relationship
            builder.HasOne(t => t.Tour).WithMany(b => b.Bookings).HasForeignKey(k => k.Id).IsRequired();

            builder.HasOne(u => u.User).WithMany(b => b.Bookings).HasForeignKey(k => k.Id).IsRequired();

            //builder.Property(p => p.Date).IsRequired();
            //builder.Property(p => p.Tour).IsRequired();
            //builder.Property(p => p.User).IsRequired();

            //Увы тут нельзя написать price > 0, HasMinLegth. Нет таких свойств.
        }
    }
}
