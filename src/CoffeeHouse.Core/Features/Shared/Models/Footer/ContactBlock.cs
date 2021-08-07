using System.Collections.Generic;

namespace CoffeeHouse.Core.Features.Shared.Models.Footer
{
    public class ContactBlock : IFooterBlock
    {
        public string PartialName => "ContactBlock";
        public string Title { get; set; }
        public string Text { get; set; }
        public List<SocialLink> SocialLinks { get; set; }
    }
}