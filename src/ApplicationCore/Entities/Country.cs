using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Entities;

public class Country : BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ContinentId { get; set; }
}