namespace CmsSampleSite.Features.Pages.Home
{
    using System.ComponentModel.DataAnnotations;
    using CmsSampleSite.Features.Settings;
    using EPiServer.Core;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;

    public partial class HomePage
    {
        [Display(
            Name = "Site Settings",
            Description = "The currently active settings for this site.",
            GroupName = SystemTabNames.Settings,
            Order = 1000)]
        [AllowedTypes(typeof(SiteSettingsPage))]
        public virtual ContentReference SiteSettings { get; set; }
    }
}
