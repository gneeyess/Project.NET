using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models.Dto
{
    //Do I write this file correct?    

    public class TourDto 
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public virtual TourType TourType { get; set; }

        public virtual Transport Transport { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}