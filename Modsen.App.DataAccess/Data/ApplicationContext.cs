using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api
            modelBuilder.Entity<User>(UserConfigure);
            modelBuilder.Entity<Transport>(TransportConfigure);
            modelBuilder.Entity<Tour>(TourConfigure);
            modelBuilder.Entity<TourType>(TourTypeConfigure);
            modelBuilder.Entity<Booking>(BookingConfigure);

            base.OnModelCreating(modelBuilder);
        }

        public void BookingConfigure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Tour).IsRequired();
            builder.Property(p => p.User).IsRequired();

            //Тут так не написать price > 0, HasMinLegth. Нет таких свойств.
        }

        public void TourConfigure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Price).IsRequired().HasMaxLength(12);
            builder.Property(p => p.Start).IsRequired();
            //Is p.End actually required?
            builder.Property(p => p.TourType).IsRequired();
            builder.Property(p => p.Transport).IsRequired();
            //p.Description Is not required
        }

        public void TourTypeConfigure(EntityTypeBuilder<TourType> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Tours).IsRequired();
        }

        public void TransportConfigure(EntityTypeBuilder<Transport> builder)
        {            
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);

            builder.Property(p => p.Tours).IsRequired();
        }

        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name_f).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Name_l).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(9); // +375 (xx) xxx-xx-xx
            builder.Property(p => p.Password).IsRequired().HasMaxLength(250);

            builder.Property(p => p.Role).IsRequired();
            builder.Property(p => p.Bookings).IsRequired();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptionsBuilder)
            : base(contextOptionsBuilder)
        { }
    }
}