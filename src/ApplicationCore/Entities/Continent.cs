namespace MyTravelBlog.ApplicationCore.Entities;

public class Continent : BaseEntity, IAggregateRoot
{
    public string? Name { get; private set; }
    public string? Description { get; set; }
    public List<Country>? Countries { get; set; }
}