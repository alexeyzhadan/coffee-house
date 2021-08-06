using CoffeeHouse.Core.Features.Shared.Constants;
using CoffeeHouse.Core.Features.Shared.Models;
using CoffeeHouse.Core.Features.Shared.SiteSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace CoffeeHouse.Core.Features.Shared.Controllers
{
    public class BasePageController<TModel> : RenderController where TModel : BasePageModel, new()
    {
        private readonly ISiteSettings siteSettings;

        public BasePageController(
            ILogger<BasePageController<TModel>> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            ISiteSettings siteSettings)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            this.siteSettings = siteSettings;
        }

        public override IActionResult Index()
        {
            var viewModel = new TModel();
            PopulateModel(CurrentPage, viewModel);

            return View(viewModel);
        }

        protected virtual void PopulateModel(IPublishedContent content, TModel model)
        {
            model.SiteName = siteSettings?.SiteName;
            model.PageTitle = content.Value<string>(PropertyAlias.PageTitle);
            model.MetaDescription = content.Value<string>(PropertyAlias.MetaDescription);
            model.OgTitle = content.Value<string>(PropertyAlias.OgTitle);
            model.OgDescription = content.Value<string>(PropertyAlias.OgDescription);
            model.OgImage = content.Value<IPublishedContent>(PropertyAlias.OgImage);
            model.OgUrl = content.Url(mode: UrlMode.Absolute);
        }
    }
}