namespace CmsSampleSite.Features.MetaData;

using CmsSampleSite.Features.Pages;
using CmsSampleSite.Features.Settings;

using EPiServer.Web.Routing;

using Microsoft.AspNetCore.Mvc;

public class MetaDataViewComponent : ViewComponent
{
    private readonly ISiteSettings _siteSettings;
    private readonly UrlResolver _urlResolver;

    public MetaDataViewComponent(ISiteSettings siteSettings, UrlResolver urlResolver)
    {
        _siteSettings = siteSettings;
        _urlResolver = urlResolver;
    }

    public IViewComponentResult Invoke(ISitePageData sitePage)
    {
        var model = new MetaDataViewModel
        {
            Title = $"{_siteSettings?.SiteName} | {sitePage.MetaTitle}",
            Description = sitePage.MetaText,
            Image = _urlResolver.GetUrl(sitePage.MetaImage)
        };

        return View(model);
    }
}
