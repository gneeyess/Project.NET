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


            //builder.Property(p => p.Date).IsRequired();
            //builder.Property(p => p.Tour).IsRequired();
            //builder.Property(p => p.User).IsRequired();

            //Увы тут нельзя написать price > 0, HasMinLegth. Нет таких свойств.
        }
    }
}
