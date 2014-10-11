using BlueOnion.Domain.Model.Base;
using System;

namespace BlueOnion.Domain.Model
{
    public class Role : ModifiableEntityBase<Guid>
    {
        public string Name { get; set; }
    }
}