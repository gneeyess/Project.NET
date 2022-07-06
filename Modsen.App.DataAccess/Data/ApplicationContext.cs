using Dal.Entities;
using Dal.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Configurations;

namespace Modsen.App.DataAccess.Data;

public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> optionsBuilder) : base(optionsBuilder)
    {
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<TourType> TourTypes { get; set; }
    public DbSet<Transport> Transports { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        builder.ApplyConfiguration(new BookingConfiguration());
        builder.ApplyConfiguration(new TourConfiguration());
        builder.ApplyConfiguration(new TourTypeConfiguration());
        builder.ApplyConfiguration(new TransportConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}