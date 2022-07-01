using FluentValidation;
using Modsen.App.Core.Models;

namespace Modsen.App.Core.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking.Date).NotNull();
            RuleFor(booking => booking.Tour).NotNull();
            RuleFor(booking => booking.User).NotNull();
        }

    }
}