namespace CmsSampleSite.Features.Pages.Complex;

public class ComplexPageViewModel : ISitePageViewModel<ComplexPage>
{
    public ComplexPage CurrentPage { get; set; }

    public string TextOne { get; set; }

    public string TextTwo { get; set; }
}