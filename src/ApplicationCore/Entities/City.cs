using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Entities;

public class City : BaseEntity, IAggregateRoot
{
    public string? Name { get; private set; }
    public string? Description { get; set; }
    public List<Article>? Articles { get; set; }
}