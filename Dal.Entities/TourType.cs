namespace Dal.Entities;

public class TourType : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Tour> Tours { get; set; }

    public TourType()
    {
        Tours = new List<Tour>();
    }
}