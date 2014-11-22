using BlueOnion.ViewModel.Interfaces;

namespace BlueOnion.ViewModel
{
    public class ReferenceStringDto : DtoBase, IDto<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}