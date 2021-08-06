using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.Models
{
    public class BasePageModel : ISeo
    {
        public string SiteName { get; set; }
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public IPublishedContent OgImage { get; set; }
        public string OgUrl { get; set; }
    }
}