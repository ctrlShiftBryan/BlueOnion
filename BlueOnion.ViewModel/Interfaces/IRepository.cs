using BlueOnion.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BlueOnion.ViewModel.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        List<T> All();
        T GetById(TId id);
        void SetCollectionsUnmodified(T entity);
        void Add(T entity);
        // DbSet<T> DbSet();
        ListWithPageInfo<T> GetPage(ServiceQueryParameters<T> parameters);
        List<T> Where(Expression<Func<T, bool>> predicate);
        void LoadReferences();
    }
}