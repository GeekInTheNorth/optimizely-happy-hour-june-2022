namespace CmsSampleSite.Features.Pages.Complex;

using System.ComponentModel.DataAnnotations;

using CmsSampleSite.Features.Pages;

using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

[ContentType(
    DisplayName = "Complex Page",
    GUID = "F586450F-B1BE-40B2-9C20-CDECF64BE60E",
    Description = "A page designed to have additional functionality separate to standard CMS properties requiring custom page building logic.",
    GroupName = SystemTabNames.Content)]
public class ComplexPage : SitePageData
{
    [Display(
        Name = "Hero Image",
        Description = "The image to render at the top of the page",
        GroupName = SystemTabNames.Content,
        Order = 10)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference HeroImage { get; set; }

    [Display(
        Name = "Heading",
        Description = "The H1 to display",
        GroupName = SystemTabNames.Content,
        Order = 20)]
    public virtual string Heading { get; set; }

    [Display(
        Name = "Main Content Area",
        Description = "Renders blocks within the main content section of the home page.",
        GroupName = SystemTabNames.Content,
        Order = 30)]
    public virtual ContentArea MainContentArea { get; set; }
}
