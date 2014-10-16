using BlueOnion.Domain.Interfaces;
using System;

namespace BlueOnion.Domain.Model.Base
{
    /// <summary>
    /// A entity model with modified and deleted dates.
    /// </summary>
    /// <typeparam name="T">The type for the Id</typeparam>
    public class ModifiableEntityBase<T> : EntityBase<T>, IModifiable
    {
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
    }
}