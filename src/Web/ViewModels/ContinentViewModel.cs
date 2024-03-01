using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.Web.ViewModels;

public class ContinentViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<CountryViewModel>? Countries { get; set; }
}