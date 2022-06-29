using System;
using System.Collections.Generic;
using System.Text;

namespace Modsen.App.Core.Models
{
    class Transport : Abstractions.BaseEntity
    {
        public string Name { get; set; }

        // connection with Tour model
        public virtual ICollection<Tour> Tours { get; set; }
        public Transport()
        {
            Tours = new List<Tour>();
        }

    }
}
