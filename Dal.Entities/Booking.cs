using Dal.Entities.Identity;

namespace Dal.Entities;

public class Booking : BaseEntity
{
    public DateTimeOffset Date { get; set; }

    public virtual User User { get; set; }
    public virtual Tour Tour { get; set; }
}