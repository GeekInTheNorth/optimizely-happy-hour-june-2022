namespace CmsSampleSite.Features.Pages.Home;

using CmsSampleSite.Features.Pages;

using Microsoft.AspNetCore.Mvc;

public class HomePageController : PageControllerBase<HomePage>
{
    public IActionResult Index(HomePage currentPage)
    {
        var model = new HomePageViewModel { CurrentPage = currentPage };

        return View(model);
    }
}
