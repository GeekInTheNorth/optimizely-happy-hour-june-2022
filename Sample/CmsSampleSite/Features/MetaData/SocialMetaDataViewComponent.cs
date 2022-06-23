namespace CmsSampleSite.Features.MetaData;

using CmsSampleSite.Features.Pages;
using CmsSampleSite.Features.Settings;

using EPiServer.DataAbstraction;

using Microsoft.AspNetCore.Mvc;

public class SocialMetaDataViewComponent : ViewComponent
{
    private readonly ISiteSettings _siteSettings;
    private readonly IContentTypeRepository _contentTypeRepository;

    public SocialMetaDataViewComponent(ISiteSettings siteSettings, IContentTypeRepository contentTypeRepository)
    {
        _siteSettings = siteSettings;
        _contentTypeRepository = contentTypeRepository;
    }

    public IViewComponentResult Invoke(ISitePageData sitePage)
    {
        var contentType = _contentTypeRepository.Load(sitePage.ContentTypeID);

        var model = new SocialMetaDataViewModel
        {
            Title = $"{_siteSettings?.SiteName} | {sitePage.MetaTitle}",
            Description = sitePage.MetaText,
            ImageReference = sitePage.MetaImage ?? sitePage.TeaserImage,
            PageReference = sitePage.ContentLink,
            SiteName = _siteSettings?.SiteName,
            TypeName = contentType?.DisplayName
        };

        return View(model);
    }
}