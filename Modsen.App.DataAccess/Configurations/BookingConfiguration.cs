using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modsen.App.Core.Models;

namespace Modsen.App.DataAccess.Configurations
{
	class BookingConfiguration : IEntityTypeConfiguration<Booking>
	{
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Tour).IsRequired();
            builder.Property(p => p.User).IsRequired();

            //Тут так не написать price > 0, HasMinLegth. Нет таких свойств.
        }
    }
}
