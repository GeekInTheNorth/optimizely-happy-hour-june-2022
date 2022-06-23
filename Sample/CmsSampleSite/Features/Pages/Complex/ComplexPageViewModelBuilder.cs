namespace CmsSampleSite.Features.Pages.Complex;

using CmsSampleSite.Features.Pages;

/// <summary>
/// A builder for constructing a <see cref="ComplexPageViewModel"/>.
/// </summary>
public class ComplexPageViewModelBuilder : IComplexPageViewModelBuilder
{
    private string _parameterOne;

    private string _parameterTwo;

    private ComplexPage _content;

    /// <summary>
    /// Stores the <paramref name="content"/> for use within the <see cref="ISitePageViewModelBuilder{TContent,TModel}.Build"/> method.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public ISitePageViewModelBuilder<ComplexPage, ComplexPageViewModel> WithContent(ComplexPage content)
    {
        _content = content;

        return this;
    }

    /// <summary>
    /// Builds an instance of the <see cref="ComplexPageViewModel"/>.
    /// </summary>
    /// <returns></returns>
    public ComplexPageViewModel Build()
    {
        var textOne = string.IsNullOrWhiteSpace(_parameterOne) ? "Parameter One was not set." : _parameterOne;
        var textTwo = string.IsNullOrWhiteSpace(_parameterTwo) ? "Parameter Two was not set." : _parameterTwo;

        var model = new ComplexPageViewModel
        {
            CurrentPage = _content,
            TextOne = textOne,
            TextTwo = textTwo
        };

        return model;
    }

    /// <inheritdoc cref="IComplexPageViewModelBuilder.WithPageParameters"/>
    public IComplexPageViewModelBuilder WithPageParameters(string parameterOne, string parameterTwo)
    {
        _parameterOne = parameterOne;
        _parameterTwo = parameterTwo;

        return this;
    }
}