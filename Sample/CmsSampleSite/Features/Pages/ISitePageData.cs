namespace CmsSampleSite.Features.Pages;

using EPiServer.Core;

using Geta.Optimizely.Categories;

public interface ISitePageData : IContent, ICategorizableContent
{
    string TeaserTitle { get; }

    string TeaserText { get; }

    ContentReference TeaserImage { get; }

    string MetaTitle { get; }

    string MetaText { get; }

    ContentReference MetaImage { get; }
}