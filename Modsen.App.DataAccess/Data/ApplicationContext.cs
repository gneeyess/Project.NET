
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly IEntityTypeConfiguration<User> _userEntityTypeConfiguration;
        private readonly IEntityTypeConfiguration<Transport> _transportEntityTypeConfiguration;

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api
            modelBuilder.Entity<User>(_userEntityTypeConfiguration.Configure);
            modelBuilder.Entity<Transport>(_transportEntityTypeConfiguration.Configure);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptionsBuilder,
               IEntityTypeConfiguration<User> userEntityTypeConfiguration,
               IEntityTypeConfiguration<Transport> transportEntityTypeConfiguration)
            : base(contextOptionsBuilder)
        {
            _transportEntityTypeConfiguration = transportEntityTypeConfiguration;
            _userEntityTypeConfiguration = userEntityTypeConfiguration;
        }
    }
}