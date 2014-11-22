using BlueOnion.Domain.Interfaces;
using System;

namespace BlueOnion.ViewModel.Interfaces
{
    public interface IHaveDisplayAndId : IEntityBase<Guid>
    {

        string Name { get; }


    }
}
