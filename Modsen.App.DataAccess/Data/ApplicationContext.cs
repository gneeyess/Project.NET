
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modsen.App.DataAccess.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly IEntityTypeConfiguration<User> _userEntityTypeConfiguration;
        private readonly IEntityTypeConfiguration<UserRole> _userRoleEntityTypeConfiguration;
        private readonly IEntityTypeConfiguration<Transport> _transportEntityTypeConfiguration;
        private readonly IEntityTypeConfiguration<Tour> _tourEntityTypeConfiguration;
        private readonly IEntityTypeConfiguration<TourType> _tourTypeEntityTypeConfiguration;
        private readonly IEntityTypeConfiguration<Booking> _bookingEntityTypeConfiguration;

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api

            modelBuilder.Entity<User>(_userEntityTypeConfiguration.Configure);
            modelBuilder.Entity<UserRole>(_userRoleEntityTypeConfiguration.Configure);
            modelBuilder.Entity<Transport>(_transportEntityTypeConfiguration.Configure);
            modelBuilder.Entity<Booking>(_bookingEntityTypeConfiguration.Configure);
            modelBuilder.Entity<Tour>(_tourEntityTypeConfiguration.Configure);
            modelBuilder.Entity<TourType>(_tourTypeEntityTypeConfiguration.Configure);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext
        (
            DbContextOptions<ApplicationContext> contextOptionsBuilder,
            IEntityTypeConfiguration<User> userEntityTypeConfiguration,
            IEntityTypeConfiguration<UserRole> userRoleEntityTypeConfiguration,
            IEntityTypeConfiguration<Transport> transportEntityTypeConfiguration,
            IEntityTypeConfiguration<Booking> bookingEntityTypeConfiguration,
            IEntityTypeConfiguration<Tour> tourEntityTypeConfiguration,
            IEntityTypeConfiguration<TourType> tourTypeEntityTypeConfiguration)
            : base(contextOptionsBuilder)
        {
            _transportEntityTypeConfiguration = transportEntityTypeConfiguration;
            _userEntityTypeConfiguration = userEntityTypeConfiguration;
            _userRoleEntityTypeConfiguration = userRoleEntityTypeConfiguration;
            _tourEntityTypeConfiguration = tourEntityTypeConfiguration;
            _tourTypeEntityTypeConfiguration = tourTypeEntityTypeConfiguration;
            _bookingEntityTypeConfiguration = bookingEntityTypeConfiguration;
        }
    }
}