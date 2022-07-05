using Modsen.App.DataAccess.Repositories;

namespace Modsen.App.DataAccess.Abstractions;

public interface IUnitOfWork
{
    public BookingRepository BookingRepository { get; }
    public TourRepository TourRepository { get; }
    public TourTypeRepository TourTypeRepository { get; }
    public TransportRepository TransportRepository { get; }
}