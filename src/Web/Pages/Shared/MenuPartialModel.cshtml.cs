using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTravelBlog.ApplicationCore.Interfaces;
using Entities = MyTravelBlog.ApplicationCore.Entities;
 
namespace MyTravelBlog.Web.Pages;

public class MenuPartialModel : PageModel
{
    public List<Entities.Continent>? LocationModel { get; set; } 
    public readonly IContinentService _continentService;

    public MenuPartialModel(IContinentService continentService)
    {
        _continentService = continentService;
    }

    public async Task OnGetAsync()
    {
        LocationModel = (await _continentService.GetAllAsync()).ToList();
    }
}