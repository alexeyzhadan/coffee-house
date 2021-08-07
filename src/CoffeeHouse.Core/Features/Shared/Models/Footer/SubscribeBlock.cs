namespace CoffeeHouse.Core.Features.Shared.Models.Footer
{
    public class SubscribeBlock : IFooterBlock
    {
        public string PartialName => "SubscribeBlock";
        public string Title { get; set; }
        public string EmailPlaceholder { get; set; }
        public string SubscribeLabel { get; set; }
    }
}