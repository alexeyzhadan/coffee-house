using System.Collections.Generic;
using Umbraco.Cms.Core.Models;

namespace CoffeeHouse.Core.Features.Shared.Models.Footer
{
    public class LinksBlock : IFooterBlock
    {
        public string PartialName => "LinksBlock";
        public string Title { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}