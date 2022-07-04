using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using System;

namespace Modsen.App.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // DELETE ME ?

        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Tour> _tourRepository;
        private readonly IRepository<TourType> _tourTypeRepository;
        private readonly IRepository<Transport> _transportRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        public UnitOfWork(IRepository<Booking> bookingRepository,
            IRepository<Tour> tourRepository,
            IRepository<TourType> tourTypeRepository,
            IRepository<Transport> transportRepository,
            IRepository<User> userRepository,
            IRepository<UserRole> userRoleRepository)
        {
            _bookingRepository = bookingRepository;
            _tourRepository = tourRepository;
            _tourTypeRepository = tourTypeRepository;
            _transportRepository = transportRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public EFBookingRepository BookingRepository => (EFBookingRepository)_bookingRepository;

        public EFTourRepository TourRepository => (EFTourRepository)_tourRepository;

        public EFTourTypeRepository TourTypeRepository => (EFTourTypeRepository)_tourTypeRepository;

        public EFTransportRepository TransportRepository => (EFTransportRepository)_transportRepository;

        public EFUserRepository UserRepository => (EFUserRepository)_userRepository;

        public EFUserRoleRepository UserRoleRepository => (EFUserRoleRepository)_userRoleRepository;

    }
}