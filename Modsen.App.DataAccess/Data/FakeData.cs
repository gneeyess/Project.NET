using Modsen.App.Core.Models;
using System.Collections.Generic;

namespace Modsen.App.DataAccess.Data
{
    public static class FakeData
    {
        //Будет заменена на SQL

        public static ICollection<Booking> Bookings = new List<Booking>();

        public static ICollection<Tour> Tours = new List<Tour>();

        public static ICollection<TourType> TourTypes = new List<TourType>();

        public static ICollection<Transport> Transports = new List<Transport>();

        public static ICollection<User> Users = new List<User>();
    }
}