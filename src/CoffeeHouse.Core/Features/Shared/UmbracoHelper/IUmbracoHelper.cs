using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.UmbracoHelper
{
    public interface IUmbracoHelper
    {
        string GetDictionaryValue(string key);
        IPublishedContent GetSiteSettings();
    }
}