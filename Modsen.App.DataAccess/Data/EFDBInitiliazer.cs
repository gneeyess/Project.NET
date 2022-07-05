using System;
using System.Linq;
using Dal.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Modsen.App.DataAccess.Abstractions;

namespace Modsen.App.DataAccess.Data;

public class EFDBInitiliazer : IDBInitializer
{
    private readonly ApplicationContext _context;

    public EFDBInitiliazer(ApplicationContext context)
    {
        _context = context;
    }
    public void Initialize()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Bookings.AddRange(FakeData.Bookings);
        _context.SaveChanges();

        _context.Tours.AddRange(FakeData.Tours);
        _context.SaveChanges();

        _context.TourTypes.AddRange(FakeData.TourTypes);
        _context.SaveChanges();

        _context.Transports.AddRange(FakeData.Transports);
        _context.SaveChanges();

        var roleName = "Admin";
        if (!_context.Roles.Any(x => x.Name == roleName))
        {
            _context.Roles.Add(new IdentityRole<int>(roleName));
            _context.SaveChanges();
        }

        var admin = new User
        {
            Email = "admin@aaa.com",
            NormalizedEmail = "admin@aaa.com",
            UserName = "admin@aaa.com",
            NormalizedUserName = "admin@aaa.com",
            FirstName = "Admin",
            LastName = "Admin",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEHOnF+aiX0aOAcQTNVLA4BNSmJ3aJVLcgq4JtmUakxr/xYQs9CPHyZwRJ9iK2MJfQg==", // !QAZ2wsx
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        if (!_context.Users.Any(x => x.Email == admin.Email))
        {
            _context.Users.Add(admin);
            _context.SaveChanges();
        }

        _context.Users.AddRange(FakeData.Users);
        _context.SaveChanges();
    }
}