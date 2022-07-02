using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models
{
    public class TourType : Abstractions.BaseEntity
    {
        public string Name { get; set; }

        // connection with Tour model

        public virtual ICollection<Tour> Tours { get; set; }

        public TourType()
        {
            Tours = new List<Tour>();
        }
    }
}
