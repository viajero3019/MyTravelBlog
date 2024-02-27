using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.Web.ViewModels;

namespace MyTravelBlog.Web.Pages.Country;

public class IndexModel : PageModel
{
    private readonly ICountryService _countryService;

    public IndexModel(ICountryService countryService)
    {
        _countryService = countryService;
    }

    public required List<CountryViewModel> CountryModel { get; set; } = new List<CountryViewModel>();

    public async void OnGet()
    {
        var countries = await _countryService.GetCountriesAsync();

        CountryModel = countries.Select(i => new CountryViewModel()
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            ContinentId = i.ContinentId
        }).ToList();
    }


}