using FluentValidation;
using Modsen.App.Core.Models;
using System.Collections.Generic;

namespace Modsen.App.Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.FirstName).NotEmpty(); 
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.Phone).NotEmpty();
            RuleFor(user => user).Must(IsValidUser);
        }

        private bool IsValidUser(User user)
        {
            return user.Password == user.RepeatPassword;
        }

        private bool IsValidBookings(ICollection<Booking> bookings)
        {
            return bookings.Count > 0;
        }
    }
}