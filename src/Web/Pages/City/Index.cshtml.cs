using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities = MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.Web.ViewModels;
using MyTravelBlog.ApplicationCore.Services;

namespace MyTravelBlog.Web.Pages.City;

public class IndexModel : PageModel
{
    private readonly ICityService _cityService;

    public IndexModel(ICityService cityService)
    {
        _cityService = cityService;
    }

    public required List<CityViewModel> CityModel { get; set; } = new List<CityViewModel>();

    public async void OnGetAsync(int id)
    {
        var continents = await _cityService.GetFitlerAsync(id);
        CityModel = continents.Select(i => new CityViewModel()
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description
        }).ToList();
    }

}