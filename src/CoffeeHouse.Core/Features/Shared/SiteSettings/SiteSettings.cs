using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.SiteSettings
{
    public class SiteSettings : ISiteSettings
    {
        public string SiteName { get; set; }

        public string LogoTitle { get; set; }
        public IEnumerable<IPublishedContent> NavigationItems { get; set; }

        public IEnumerable<IPublishedElement> FooterBlocks { get; set; }
        public string CopyrightText { get; set; }
    }
}