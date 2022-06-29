using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;

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

            base.OnModelCreating(modelBuilder);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptionsBuilder)
            : base(contextOptionsBuilder)
        { }
    }
}