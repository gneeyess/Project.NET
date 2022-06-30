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

            base.OnModelCreating(modelBuilder);
        }
        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name_f).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Name_l).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(9); // +375 (xx) xxx-xx-xx
            builder.Property(p => p.Password).IsRequired().HasMaxLength(250);
        }

        public void TransportConfigure(EntityTypeBuilder<Transport> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);           
        }


        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptionsBuilder)
            : base(contextOptionsBuilder)
        { }
    }
}