using CoffeeHouse.Core.Features.Shared.Models;
using CoffeeHouse.Core.Features.Shared.SiteSettings;

namespace CoffeeHouse.Core.Features.Shared.Helpers
{
    public static class HeaderHelper
    {
        public static HeaderViewModel CreateHeader(ISiteSettings siteSettings)
        {
            var header = new HeaderViewModel();

            if (siteSettings == null) return header;

            header.LogoTitle = siteSettings.LogoTitle;
            header.NavigationItems = siteSettings.NavigationItems;

            return header;
        }
    }
}