using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities = MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.Web.ViewModels;
using MyTravelBlog.ApplicationCore.Services;

namespace MyTravelBlog.Web.Pages.Country;

public class IndexModel : PageModel
{
    private readonly ICountryService _countryService;
    private readonly IContinentService _continentService;

    public IndexModel(ICountryService countryService, IContinentService continentService)
    {
        _countryService = countryService;
        _continentService = continentService;
    }

    public required ContinentViewModel ContinentModel { get; set; } = new ContinentViewModel();

    public async void OnGetAsync(int id)
    {
        var countries = await _countryService.GetFitlerAsync(id);
        var continent = await _continentService.GetByIdAsync(id);

        ContinentModel.Id = continent.Id;
        ContinentModel.Name = continent.Name;
        ContinentModel.Countries = countries.Select(i => new CountryViewModel()
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            ContinentId = i.ContinentId,
        }).ToList();
    }

}