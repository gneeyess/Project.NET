using Dal.Entities;
using FluentValidation;

namespace Validation.Validators;

public class TourTypeValidator : AbstractValidator<TourType>
{
    public TourTypeValidator()
    {
        RuleFor(tourType => tourType.Name).NotEmpty();
    }
}