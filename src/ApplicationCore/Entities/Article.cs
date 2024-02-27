using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Entities;

public class Article : BaseEntity, IAggregateRoot
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime WrittingDate { get; set; }
    public int LocationId { get; set; }
}