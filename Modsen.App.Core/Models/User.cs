using System;
using System.Collections.Generic;
using System.Text;

namespace Modsen.App.Core.Models
{
    class User : Abstractions.BaseEntity
    {
        public string Name_f { get; set; }

        public string Name_l { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // hash of the password
        public string Password { get; set; }

        // false-user, true-admin
        public bool Role { get; set; }

        // connection with Booking model
        public virtual ICollection<Booking> Bookings { get; set; }
        public User()
        {
            Bookings = new List<Booking>();
        }
    }
}
