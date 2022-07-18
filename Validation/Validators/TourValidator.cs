using Dal.Entities;
using FluentValidation;

namespace Validation.Validators;

public class TourValidator : AbstractValidator<Tour>
{
    public TourValidator()
    {
        RuleFor(tour => tour.TourTypeId).NotEmpty();
        RuleFor(tour => tour.TransportId).NotEmpty();
        RuleFor(tour => tour.Price).Must(IsValidPrice);
        RuleFor(tour => tour.Name).NotEmpty();
        RuleFor(tour => tour.Start).NotNull();
        RuleFor(tour => tour.End).NotNull();

        RuleFor(tour => tour).Must(IsValidDates);
    }
    private bool IsValidPrice(decimal price)
    {
        return price > 0;
    }

    private bool IsValidDates(Tour tour)
    {
        return tour.Start < tour.End;
    }

}