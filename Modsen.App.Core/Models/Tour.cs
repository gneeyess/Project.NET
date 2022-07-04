using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models
{
    public class Tour : Abstractions.BaseEntity
    {
        public string Name { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        // foreign keys

        public virtual TourType TourType { get; set; }

        public virtual Transport Transport { get; set; }

        // connection with Booking model

        public virtual ICollection<Booking> Bookings { get; set; }

        public Tour()
        {
            Bookings = new List<Booking>();
        }
    }
}
