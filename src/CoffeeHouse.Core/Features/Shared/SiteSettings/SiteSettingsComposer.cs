using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace CoffeeHouse.Core.Features.Shared.SiteSettings
{
    public class SiteSettingsComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<SiteSettingsResolver>();
            builder.Services.AddScoped(x => (ISiteSettings)x.GetService<SiteSettingsResolver>()?.Resolve());
        }
    }
}