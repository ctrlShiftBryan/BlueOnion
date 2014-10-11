using BlueOnion.Domain.Interfaces;
using System;

namespace BlueOnion.Domain.Model.Base
{
    /// <summary>
    /// The base model for everything with an Id, Created and Created by.
    /// </summary>
    /// <typeparam name="T">The type of the Id</typeparam>
    public class EntityBase<T> : IEntityBase<T>, ICreateable
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            CreatedBy = "System";
        }

        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}