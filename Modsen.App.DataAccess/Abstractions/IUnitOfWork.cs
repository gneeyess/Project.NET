using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Repositories;

namespace Modsen.App.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        public EFBookingRepository BookingRepository { get; }
        public EFTourRepository TourRepository { get; }
        public EFTourTypeRepository TourTypeRepository { get; }
        public EFTransportRepository TransportRepository { get; }
        public EFUserRepository UserRepository { get; }
    }
}