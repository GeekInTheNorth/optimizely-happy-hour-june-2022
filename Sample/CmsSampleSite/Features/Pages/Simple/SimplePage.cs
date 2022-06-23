namespace CmsSampleSite.Features.Pages.Simple;

using System.ComponentModel.DataAnnotations;

using CmsSampleSite.Features.Pages;

using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

[ContentType(
    DisplayName = "Simple Page",
    GUID = "E7E149FE-F5C0-4150-81AD-D8AA2466CED2",
    Description = "A page designed to have few properties with no custom page building logic being required.",
    GroupName = SystemTabNames.Content)]
public class SimplePage : SitePageData
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
