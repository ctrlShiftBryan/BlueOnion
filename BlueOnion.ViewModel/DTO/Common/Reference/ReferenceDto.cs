using BlueOnion.ViewModel.Interfaces;
using System;

namespace BlueOnion.ViewModel
{
    public class ReferenceDto : DtoBase, IDto<Guid>, IHaveDisplayAndId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}