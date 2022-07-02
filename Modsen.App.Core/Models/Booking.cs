using System;

namespace Modsen.App.Core.Models
{
    public class Booking : Abstractions.BaseEntity
    {
        public DateTime Date { get; set; }

        // foreign keys
        public virtual User User { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
