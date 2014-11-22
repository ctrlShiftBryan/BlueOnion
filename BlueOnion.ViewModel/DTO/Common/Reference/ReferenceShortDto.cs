using BlueOnion.ViewModel.Interfaces;

namespace BlueOnion.ViewModel
{
    public class ReferenceShortDto : DtoBase, IDto<short>
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}