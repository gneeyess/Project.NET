using System.Collections.Generic;
using FluentValidation;
using Modsen.App.Core.Models;

namespace Modsen.App.Core.Validators
{
    public class TourTypeValidator : AbstractValidator<TourType>
    {
        public TourTypeValidator()
        {
            RuleFor(tourType => tourType.Name).NotEmpty();
            RuleFor(tourType => tourType.Tours).NotNull().Must(IsValidTours);
        }
        private bool IsValidTours(ICollection<Tour> tours)
        {
            throw new System.NotImplementedException();
            
            //Он же выбросит исключение в любом случае ??
        }
    }
}