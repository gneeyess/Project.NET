using Modsen.App.DataAccess.Abstractions;
using Dal.Entities;

namespace Modsen.App.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    // DELETE ME ?

    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<Tour> _tourRepository;
    private readonly IRepository<TourType> _tourTypeRepository;
    private readonly IRepository<Transport> _transportRepository;

    public UnitOfWork(IRepository<Booking> bookingRepository,
        IRepository<Tour> tourRepository,
        IRepository<TourType> tourTypeRepository,
        IRepository<Transport> transportRepository)
    {
        _bookingRepository = bookingRepository;
        _tourRepository = tourRepository;
        _tourTypeRepository = tourTypeRepository;
        _transportRepository = transportRepository;
    }

    public BookingRepository BookingRepository => (BookingRepository)_bookingRepository;

    public TourRepository TourRepository => (TourRepository)_tourRepository;

    public TourTypeRepository TourTypeRepository => (TourTypeRepository)_tourTypeRepository;

    public TransportRepository TransportRepository => (TransportRepository)_transportRepository;
}