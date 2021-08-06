using CoffeeHouse.Core.Features.Shared.Constants;
using CoffeeHouse.Core.Features.Shared.Controllers;
using CoffeeHouse.Core.Features.Shared.SiteSettings;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace CoffeeHouse.Core.Features.Pages.StartPage
{
    public class StartPageController : BasePageController<StartPage>
    {
        public StartPageController(
            ILogger<BasePageController<StartPage>> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ISiteSettings siteSettings)
            : base(logger, compositeViewEngine, umbracoContextAccessor, siteSettings)
        {
        }

        protected override void PopulateModel(IPublishedContent content, StartPage model)
        {
            base.PopulateModel(content, model);

            model.Heading = content.Value<string>(PropertyAlias.Heading);
        }
    }
}