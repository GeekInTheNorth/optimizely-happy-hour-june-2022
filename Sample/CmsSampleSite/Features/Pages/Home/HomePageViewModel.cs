using CmsSampleSite.Features.Pages;

namespace CmsSampleSite.Features.Pages.Home
{
    public class HomePageViewModel : ISitePageViewModel<HomePage>
    {
        public HomePage CurrentPage { get; set; }
    }
}