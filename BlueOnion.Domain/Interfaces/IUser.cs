using System;

namespace BlueOnion.Domain.Interfaces
{
    public interface IUser<T>
    {
        T Id { get; set; }
        string UserName { get; set; }
        bool IsInRole(string role);
    }

    public interface IUser : IUser<Guid>
    {

    }
}