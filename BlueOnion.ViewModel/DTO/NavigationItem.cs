using System.Collections.Generic;

namespace BlueOnion.ViewModel.DTO
{
    public class NavigationItem
    {
        public string DisplayName { get; set; }
        public string CssClass { get; set; }
        public string Url { get; set; }
        public List<NavigationItem> SubNav { get; set; }
    }
}
