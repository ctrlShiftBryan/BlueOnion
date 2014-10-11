using BlueOnion.Domain.Interfaces;

namespace BlueOnion.Domain.Model.Base
{
    /// <summary>
    /// This base model for all AggregateRoot objects
    /// </summary>
    /// <typeparam name="T">The type for the Id</typeparam>
    public class AggregateRoot<T> : ModifiableEntityBase<T>, IAggregateRoot<T>
    {

    }
}