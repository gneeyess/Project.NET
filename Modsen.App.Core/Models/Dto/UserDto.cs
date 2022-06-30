using System.Collections.Generic;

namespace Modsen.App.Core.Models.Dto
{
    //Data Transfer Object
    public class UserDto 
    {
        public string Name_f { get; set; }

        public string Name_l { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // false-user, true-admin
        public bool Role { get; set; }

        // connection with Booking model
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}