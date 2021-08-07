using System.Collections.Generic;

namespace CoffeeHouse.Core.Features.Shared.Models.Footer
{
    public class FooterViewModel
    {
        public List<IFooterBlock> Blocks { get; set; }
        public string CopyrightText { get; set; }
    }
}