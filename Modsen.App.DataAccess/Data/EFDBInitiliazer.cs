using Modsen.App.DataAccess.Abstractions;

namespace Modsen.App.DataAccess.Data
{
    public class EFDBInitiliazer : IDBInitializer
    {
        private ApplicationContext _context;
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

            _context.Users.AddRange(FakeData.Users);
            _context.SaveChanges();
        }
    }
}