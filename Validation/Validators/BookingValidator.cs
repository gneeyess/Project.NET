using Dal.Entities;
using FluentValidation;

namespace Validation.Validators;

public class BookingValidator : AbstractValidator<Booking>
{
    public BookingValidator()
    {
        RuleFor(booking => booking.Date).NotNull();
        RuleFor(booking => booking.Tour).NotNull();
        RuleFor(booking => booking.User).NotNull();
    }
}