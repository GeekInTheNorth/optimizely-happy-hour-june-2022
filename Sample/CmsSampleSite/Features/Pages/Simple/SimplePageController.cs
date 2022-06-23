namespace CmsSampleSite.Features.Pages.Simple;

using CmsSampleSite.Features.Pages;

using Microsoft.AspNetCore.Mvc;

public class SimplePageController : PageControllerBase<SimplePage>
{
    public IActionResult Index(SimplePage currentPage)
    {
        // Simple page has no complex properties to retrieve
        // The basic model can simply be instantiated without the need
        // for heavy weight builder classes
        var model = new SimplePageViewModel { CurrentPage = currentPage };

        return View(model);
    }
}