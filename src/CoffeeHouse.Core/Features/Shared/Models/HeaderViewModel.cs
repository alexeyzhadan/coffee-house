using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.Models
{
    public class HeaderViewModel
    {
        public string LogoTitle { get; set; }
        public IEnumerable<IPublishedContent> NavigationItems { get; set; }
    }
}