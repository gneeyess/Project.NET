using FluentValidation;
using Modsen.App.Core.Models;
using System.Collections.Generic;

namespace Modsen.App.Core.Validators
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(userRole => userRole.Users).NotEmpty();
            RuleFor(userRole => userRole.Users).NotNull().Must(IsValidUsers);
        }

        private bool IsValidUsers(ICollection<User> users)
        {
            return users.Count > 0;
        }
    }
}