using System;

namespace ViewModel.Interfaces
{
    public interface IGenericQueryService<T, TId>
    {
        
        T GetList(DateTime? effectiveDateTime = null);
        T GetDetail(TId id, DateTime? effectiveDateTime = null);
        T GetMeta();
    }
}