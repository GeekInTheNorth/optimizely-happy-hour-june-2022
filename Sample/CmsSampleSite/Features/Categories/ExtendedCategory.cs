namespace CmsSampleSite.Features.Categories;

using EPiServer.Core;
using EPiServer.DataAnnotations;

[ContentType(
    DisplayName = "Extended Category",
    Description = "This category type has extended data to be shared across content types.")]
public class ExtendedCategory : BasicCategory
{
    [CultureSpecific]
    public virtual XhtmlString MainBody { get; set; }
}
