namespace CmsSampleSite.Features.Pages.Complex;

using CmsSampleSite.Features.Pages;

using Microsoft.AspNetCore.Mvc;

public class ComplexPageController : PageControllerBase<ComplexPage>
{
    private readonly IComplexPageViewModelBuilder _modelBuilder;

    public ComplexPageController(IComplexPageViewModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public IActionResult Index(
        ComplexPage currentPage,
        string parameterOne = null,
        string parameterTwo = null)
    {
        // Complex page has multiple parameters which affect the building of the view model
        // As there is additional business logic for this page a model builder can be used
        // This separates controller flow from complex business logic.
        var model = _modelBuilder.WithPageParameters(parameterOne, parameterTwo)
                                 .WithContent(currentPage)
                                 .Build();

        return View(model);
    }
}