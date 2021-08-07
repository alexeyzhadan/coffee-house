using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.SiteSettings
{
    public interface ISiteSettings
    {
        string SiteName { get; }

        #region Header
        string LogoTitle { get; }
        IEnumerable<IPublishedContent> NavigationItems { get; }
        #endregion

        #region Footer
        IEnumerable<IPublishedElement> FooterBlocks { get; }
        string CopyrightText { get; }
        #endregion
    }
}