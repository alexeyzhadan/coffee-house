using CoffeeHouse.Core.Features.Shared.Constants;
using CoffeeHouse.Core.Features.Shared.UmbracoHelper;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace CoffeeHouse.Core.Features.Shared.SiteSettings
{
    public class SiteSettingsResolver
    {
        private readonly IUmbracoHelper umbracoHelper;

        public SiteSettingsResolver(IUmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }

        public SiteSettings Resolve()
        {
            var model = new SiteSettings();

            var siteSettings = umbracoHelper.GetSiteSettings();
            if (siteSettings == null) return model;

            PopulateModel(siteSettings, model);

            return model;
        }

        private void PopulateModel(IPublishedContent content, SiteSettings model)
        {
            model.SiteName = content.Value<string>(PropertyAlias.SiteName);
            model.LogoTitle = content.Value<string>(PropertyAlias.LogoTitle);
            model.NavigationItems = content.Value<IEnumerable<IPublishedContent>>(PropertyAlias.NavigationItems);
            model.CopyrightText = content.Value<string>(PropertyAlias.CopyrightText);
            model.FooterBlocks = content.Value<IEnumerable<IPublishedElement>>(PropertyAlias.Blocks);
        }
    }
}