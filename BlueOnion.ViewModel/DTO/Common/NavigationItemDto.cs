using System.Collections.Generic;

namespace BlueOnion.ViewModel
{
    public class NavigationItemDto
    {
        public string DisplayName { get; set; }
        public string CssClass { get; set; }
        public string Url { get; set; }
        public List<NavigationItemDto> SubNav { get; set; }
    }
}
