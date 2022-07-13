using Modsen.App.DataAccess.Abstractions;
using Dal.Entities;

namespace Modsen.App.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    // DELETE ME ? No there are will be some logic

    private readonly IRepository<Booking> _bookingRepository;
    private readonly ITourRepository _tourRepository;
    private readonly ITourTypeRepository _tourTypeRepository;
    private readonly ITransportRepository _transportRepository;

    public UnitOfWork(IRepository<Booking> bookingRepository,
        ITourRepository tourRepository,
        ITourTypeRepository tourTypeRepository,
        ITransportRepository transportRepository)
    {
        _bookingRepository = bookingRepository;
        _tourRepository = tourRepository;
        _tourTypeRepository = tourTypeRepository;
        _transportRepository = transportRepository;
    }

    public BookingRepository BookingRepository => (BookingRepository)_bookingRepository;

    public ITourRepository TourRepository => _tourRepository;

    public ITourTypeRepository TourTypeRepository => _tourTypeRepository;

    public ITransportRepository TransportRepository => _transportRepository;
}