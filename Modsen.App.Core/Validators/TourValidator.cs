using System.Collections;
using System.Collections.Generic;
using FluentValidation;
using Modsen.App.Core.Models;

namespace Modsen.App.Core.Validators
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(tour => tour.Bookings).NotNull();
            RuleFor(tour => tour.TourType).NotNull();
            RuleFor(tour => tour.Transport).NotNull();
            RuleFor(tour => tour.Price).Must(IsValidPrice);
            RuleFor(tour => tour.Name).NotEmpty();

            RuleFor(tour => tour.Bookings).NotNull().Must(IsValidBookings);
            RuleFor(tour => tour.Start).NotNull();
            RuleFor(tour => tour.End).NotNull();

            RuleFor(tour => tour).Must(IsValidDates);
        }
        private bool IsValidPrice(int price)
        {
            return price > 0;
        }

        private bool IsValidDates(Tour tour)
        {
            return tour.Start < tour.End;
        }

        private bool IsValidBookings(ICollection<Booking> bookings)
        {
            return bookings.Count > 0;
        }
    }
}