using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.Models.Footer
{
    public class SocialLink
    {
        public IPublishedContent Logo { get; set; }
        public Link Link { get; set; }
    }
}