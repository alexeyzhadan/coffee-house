using CoffeeHouse.Core.Features.Shared.Constants;
using CoffeeHouse.Core.Features.Shared.Models.Footer;
using CoffeeHouse.Core.Features.Shared.SiteSettings;
using CoffeeHouse.Core.Features.Shared.UmbracoHelper;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace CoffeeHouse.Core.Features.Shared.Helpers
{
    public static class FooterHelper
    {
        public static FooterViewModel CreateFooter(ISiteSettings siteSettings, IUmbracoHelper umbracoHelper)
        {
            var footer = new FooterViewModel();

            if (siteSettings == null) return footer;

            footer.CopyrightText = siteSettings.CopyrightText;
            footer.Blocks = new List<IFooterBlock>();

            if (siteSettings.FooterBlocks?.Any() == true)
            {
                foreach (var blockContent in siteSettings.FooterBlocks)
                {
                    IFooterBlock footerBlock = null;

                    switch (blockContent.ContentType.Alias)
                    {
                        case ContentTypeAlias.ContactBlock:
                            footerBlock = CreateContactBlock(blockContent);
                            break;
                        case ContentTypeAlias.SubscribeBlock:
                            footerBlock = CreateSubscribeBlock(blockContent, umbracoHelper);
                            break;
                        case ContentTypeAlias.LinksBlock:
                            footerBlock = CreateLinksBlock(blockContent);
                            break;
                    }

                    footer.Blocks.Add(footerBlock);
                }
            }

            return footer;
        }

        private static ContactBlock CreateContactBlock(IPublishedElement content)
        {
            var contactBlock = new ContactBlock
            {
                Title = content.Value<string>(PropertyAlias.Title),
                Text = content.Value<string>(PropertyAlias.Text),
                SocialLinks = new List<SocialLink>()
            };

            var socialLinksContent = content.Value<IEnumerable<IPublishedElement>>(PropertyAlias.SocialLinks);
            if (socialLinksContent?.Any() == true)
            {
                foreach (var socialLinkContent in socialLinksContent)
                {
                    var socialLink = new SocialLink
                    {
                        Logo = socialLinkContent.Value<IPublishedContent>(PropertyAlias.Logo),
                        Link = socialLinkContent.Value<Link>(PropertyAlias.Link)
                    };
                    contactBlock.SocialLinks.Add(socialLink);
                }
            }

            return contactBlock;
        }

        private static SubscribeBlock CreateSubscribeBlock(IPublishedElement content, IUmbracoHelper umbracoHelper)
        {
            var subscribeBlock = new SubscribeBlock
            {
                Title = content.Value<string>(PropertyAlias.Title),
                EmailPlaceholder = content.Value<string>(PropertyAlias.EmailPlaceholder),
                SubscribeLabel = umbracoHelper.GetDictionaryValue(DictionaryKey.SubscribeLabel)
            };
            return subscribeBlock;
        }

        private static LinksBlock CreateLinksBlock(IPublishedElement content)
        {
            var linksBlock = new LinksBlock
            {
                Title = content.Value<string>(PropertyAlias.Title),
                Links = content.Value<IEnumerable<Link>>(PropertyAlias.Links)
            };
            return linksBlock;
        }
    }
}