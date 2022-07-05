using Microsoft.AspNetCore.Identity;

namespace Dal.Entities.Identity;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; }
}