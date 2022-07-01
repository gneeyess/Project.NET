using System.Collections.Generic;
using FluentValidation;
using Modsen.App.Core.Models;

namespace Modsen.App.Core.Validators
{
    public class TransportValidator : AbstractValidator<Transport>

    {
        public TransportValidator()
        {
            RuleFor(transport => transport.Name).NotEmpty();
            RuleFor(transport => transport.Tours).NotNull().Must(IsValidTours);
        }

        private bool IsValidTours(ICollection<Tour> tours)
        {
            return tours.Count > 0;
        }
    }
}