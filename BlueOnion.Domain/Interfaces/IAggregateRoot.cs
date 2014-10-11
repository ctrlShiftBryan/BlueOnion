namespace BlueOnion.Domain.Interfaces
{
    public interface IAggregateRoot<T> : IEntityBase<T>, ICreateable
    {

    }
}