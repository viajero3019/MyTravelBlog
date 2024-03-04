using Microsoft.AspNetCore.Mvc;
using MyTravelBlog.ApplicationCore.Interfaces;
using Entities = MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.Web.Pages.Shared.Components.MenuComponent;

public class Menu : ViewComponent
{
    public List<Entities.Continent>? LocationModel { get; set; } 

    public readonly IContinentService _continentService;
    private readonly IAppLogger<Menu> _logger;

    public Menu(IContinentService continentService, IAppLogger<Menu> logger)
    {
        _continentService = continentService;
        _logger = logger;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        LocationModel = (await _continentService.GetWithIncludeAsync()).ToList();
        return View(LocationModel);
    }
}