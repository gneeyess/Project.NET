using Dal.Entities;
using FluentValidation;

namespace Validation.Validators;

public class TransportValidator : AbstractValidator<Transport>
{
    public TransportValidator()
    {
        RuleFor(transport => transport.Name).NotEmpty();
    }
}