using System;
using System.Collections.Generic;
using System.Text;

namespace Modsen.App.Core.Models
{
    class Booking : Abstractions.BaseEntity
    {
        public DateTime Date { get; set; }

        // foreign keys
        public virtual User User { get; set; }

        public virtual Tour Tour { get; set; }

    }
}
