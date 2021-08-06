using CoffeeHouse.Core.Features.Shared.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CoffeeHouse.Core.Features.Shared.UmbracoHelper
{
    public class UmbracoHelperAdapter : IUmbracoHelper
    {
        private readonly Umbraco.Cms.Web.Common.UmbracoHelper umbracoHelper;

        public UmbracoHelperAdapter(IHttpContextAccessor httpContextAccessor)
        {
            umbracoHelper = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<Umbraco.Cms.Web.Common.UmbracoHelper>();
        }

        public string GetDictionaryValue(string key)
        {
            var dictionaryValue = umbracoHelper.GetDictionaryValue(key);

            return !string.IsNullOrWhiteSpace(dictionaryValue)
                ? dictionaryValue
                : key;
        }

        public IPublishedContent GetSiteSettings()
            => GetPageByAlias(ContentTypeAlias.SiteSettings);

        private IPublishedContent GetPageByAlias(string contentTypeAlias)
            => umbracoHelper.ContentSingleAtXPath($"//{contentTypeAlias}");
    }
}