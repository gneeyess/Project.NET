namespace Dal.Entities;

public class Transport : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Tour> Tours { get; set; }

    public Transport()
    {
        Tours = new List<Tour>();
    }
}