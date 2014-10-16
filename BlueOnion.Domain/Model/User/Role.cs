using BlueOnion.Domain.Model.Base;
using System;

namespace BlueOnion.Domain.Model
{
    /// <summary>
    /// A role for a Users
    /// </summary>
    public class Role : ModifiableEntityBase<Guid>
    {
        public string Name { get; set; }
    }
}