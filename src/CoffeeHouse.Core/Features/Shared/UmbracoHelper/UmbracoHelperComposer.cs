using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace CoffeeHouse.Core.Features.Shared.UmbracoHelper
{
    public class UmbracoHelperComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IUmbracoHelper, UmbracoHelperAdapter>();
        }
    }
}