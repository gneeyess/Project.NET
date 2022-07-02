using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models
{
    public class User : Abstractions.BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // hash of the password // ?
        public string Password { get; set; }

        public string RepeatPassword { get; set; } //Он точно должен быть здесь?

        public virtual UserRole Roles { get; set; }

        // connection with Booking model
        public virtual ICollection<Booking> Bookings { get; set; }

        public User()
        {
            Bookings = new List<Booking>();
        }
    }
}
