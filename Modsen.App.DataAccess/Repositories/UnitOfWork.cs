using Modsen.App.DataAccess.Abstractions;
using Dal.Entities;

namespace Modsen.App.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ITourRepository _tourRepository;
    private readonly ITourTypeRepository _tourTypeRepository;
    private readonly ITransportRepository _transportRepository;

    public UnitOfWork(IBookingRepository bookingRepository,
        ITourRepository tourRepository,
        ITourTypeRepository tourTypeRepository,
        ITransportRepository transportRepository)
    {
        _bookingRepository = bookingRepository;
        _tourRepository = tourRepository;
        _tourTypeRepository = tourTypeRepository;
        _transportRepository = transportRepository;
    }

    public IBookingRepository BookingRepository => _bookingRepository;

    public ITourRepository TourRepository => _tourRepository;

    public ITourTypeRepository TourTypeRepository => _tourTypeRepository;

    public ITransportRepository TransportRepository => _transportRepository;
}