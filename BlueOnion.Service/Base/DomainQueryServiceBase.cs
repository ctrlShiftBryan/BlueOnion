using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel.Interfaces;
using System;
using System.Collections.Generic;

namespace BlueOnion.Service.Base
{


    public class DomainQueryServiceBase<T, TRepo, TId> : DomainServiceBase<T>, IDomainQueryServiceBase<T, TId>
        where T : class, IAggregateRoot<TId>, new()
        where TRepo : IRepository<T, TId>
    {
        protected readonly TRepo _repo;

        public DomainQueryServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, TRepo repo, int limit = 1000) 
            : base(unitOfWork, user, repositories, limit)
        {
            _repo = repo;
        }

        public List<T> GetList(DateTime? effectiveDateTime = null)
        {
            var repo = _repo;
            var data = repo.All();
           
            return data;
        }

        public T GetDetail(TId id, DateTime? effectiveDateTime = null)
        {
            var repo = _repo;
            var data = repo.GetById(id);
            return data;
        }

    }
}