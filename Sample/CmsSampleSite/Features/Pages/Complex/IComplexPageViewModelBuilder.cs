namespace CmsSampleSite.Features.Pages.Complex;

public interface IComplexPageViewModelBuilder : ISitePageViewModelBuilder<ComplexPage, ComplexPageViewModel>
{
    /// <summary>
    /// Adds page parameters to the model builder.
    /// As this is higher in the declarations than items on <see cref="ISitePageViewModelBuilder{TContent,TModel}"/>
    /// then this method will need to be called on the builder first.
    /// </summary>
    /// <param name="parameterOne"></param>
    /// <param name="parameterTwo"></param>
    /// <returns></returns>
    IComplexPageViewModelBuilder WithPageParameters(string parameterOne, string parameterTwo);
}