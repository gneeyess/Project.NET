using Dal.Entities;
using Dal.Entities.Identity;

namespace Modsen.App.NUnitTests.Data;

public static class TestData
{
    public static ICollection<Booking> Bookings = new List<Booking>();

    public static ICollection<Tour> Tours = new List<Tour>
    {
        new Tour
        {
            Description = "Description1",
            End = DateTimeOffset.Now,
            Name = "Tour1",
            Price = 1,
            Start = DateTimeOffset.Now,
            TourType = TourTypes.FirstOrDefault(),
            Transport = Transports.FirstOrDefault()
        },
        new Tour
        {
            Description = "Description2",
            End = DateTimeOffset.Now,
            Name = "Tour2",
            Price = 2,
            Start = DateTimeOffset.Now,
            TourType = TourTypes.FirstOrDefault(),
            Transport = Transports.FirstOrDefault()
        },
        new Tour
        {
            Description = "Description3",
            End = DateTimeOffset.Now,
            Name = "Tour3",
            Price = 3,
            Start = DateTimeOffset.Now,
            TourType = TourTypes.FirstOrDefault(),
            Transport = Transports.FirstOrDefault()
        }
    };
    public static ICollection<TourType> TourTypes => new List<TourType>
    {
        new TourType
        {
            Name = "Type1",
            Tours = Tours
        }

    };
    public static ICollection<Transport> Transports => new List<Transport>
    {
        new Transport
        {
            Name="Transport1",
            Tours = Tours
        }
    };

    public static ICollection<User> Users = new List<User>();
}