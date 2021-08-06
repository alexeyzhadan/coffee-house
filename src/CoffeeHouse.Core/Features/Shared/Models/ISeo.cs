using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.Models
{
    public interface ISeo
    {
        string SiteName { get; }
        string PageTitle { get; }
        string MetaDescription { get; }
        string OgTitle { get; }
        string OgDescription { get; }
        IPublishedContent OgImage { get; }
        string OgUrl { get; }
    }
}