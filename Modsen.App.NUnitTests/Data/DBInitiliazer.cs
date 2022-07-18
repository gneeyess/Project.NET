using Modsen.App.NUnitTests.Abstractions;

namespace Modsen.App.NUnitTests.Data;

public class DBInitiliazer : IDBInitializer
{
    private readonly TestContext _context;

    public DBInitiliazer(TestContext context)
    {
        _context = context;
    }
    public void Initialize()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Bookings.AddRange(TestData.Bookings);
        _context.SaveChanges();

        _context.Tours.AddRange(TestData.Tours);
        _context.SaveChanges();

        _context.TourTypes.AddRange(TestData.TourTypes);
        _context.SaveChanges();

        _context.Transports.AddRange(TestData.Transports);
        _context.SaveChanges();

    }
}