using BlueOnion.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace BlueOnion.ViewModel.Interfaces
{
    public interface IDomainQueryServiceBase<T, TId> where T : class, IAggregateRoot<TId>, new()
    {
        List<T> GetList(DateTime? effectiveDateTime = null);
        T GetDetail(TId id, DateTime? effectiveDateTime = null);
        IDomainServices OtherServices { get; set; }
    }
}