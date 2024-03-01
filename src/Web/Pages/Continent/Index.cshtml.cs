using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities = MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.Web.ViewModels;
using MyTravelBlog.ApplicationCore.Services;

namespace MyTravelBlog.Web.Pages.Continent;

public class IndexModel : PageModel
{
    private readonly IContinentService _continentService;

    public IndexModel(IContinentService continentService)
    {
        _continentService = continentService;
    }

    public required List<ContinentViewModel> ContinentModel { get; set; } = new List<ContinentViewModel>();

    public async void OnGetAsync(int id)
    {
        var continents = await _continentService.GetAllAsync();
        ContinentModel = continents.Select(i => new ContinentViewModel()
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description
        }).ToList();
    }

}