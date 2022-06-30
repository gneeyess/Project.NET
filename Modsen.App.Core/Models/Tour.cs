using System;
using System.Collections.Generic;
using System.Text;

namespace Modsen.App.Core.Models
{
    public class Tour : Abstractions.BaseEntity
    {

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

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
