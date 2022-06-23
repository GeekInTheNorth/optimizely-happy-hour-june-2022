namespace CmsSampleSite.Features.Pages;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CmsSampleSite.Features.Categories;
using CmsSampleSite.Features.Common;

using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

using Geta.Optimizely.Categories.DataAnnotations;

public class SitePageData : PageData, ISitePageData
{
    [Categories]
    public virtual IList<ContentReference> Categories { get; set; }

    [Display(
        Name = "Alternative Category Style",
        Description = "GETA Categories can also use the default IList<ContentReference> UI for editors.",
        GroupName = GroupNames.Examples)]
    [AllowedTypes(typeof(BasicContent), typeof(ExtendedCategory))]
    public virtual IList<ContentReference> AlternativeCategories { get; set; }

    [Display(
        Name = "Teaser Title",
        Description = "A teaser title to use when rendering as a block",
        GroupName = GroupNames.Teaser,
        Order = 700)]
    public virtual string TeaserTitle { get; set; }

    [Display(
        Name = "Teaser Text",
        Description = "Teaser text to use when rendering as a block",
        GroupName = GroupNames.Teaser,
        Order = 701)]
    public virtual string TeaserText { get; set; }

    [Display(
        Name = "Teaser Image",
        Description = "The image to use when rendering as a block",
        GroupName = GroupNames.Teaser,
        Order = 702)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference TeaserImage { get; set; }

    [Display(
        Name = "Meta Title",
        Description = "A meta title to be rendered within the page's title",
        GroupName = GroupNames.SearchEngineOptimization,
        Order = 800)]
    public virtual string MetaTitle { get; set; }

    [Display(
        Name = "Meta Description",
        Description = "The meta description of the page to be shown in search results.",
        GroupName = GroupNames.SearchEngineOptimization,
        Order = 801)]
    public virtual string MetaText { get; set; }

    [Display(
        Name = "Meta Image",
        Description = "The image to use for the meta image for the page",
        GroupName = GroupNames.SearchEngineOptimization,
        Order = 802)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference MetaImage { get; set; }
}
