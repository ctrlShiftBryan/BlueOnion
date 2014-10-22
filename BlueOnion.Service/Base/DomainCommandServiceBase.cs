using AutoMapper;
using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel.Common;
using BlueOnion.ViewModel.Interfaces;
using System;


namespace BlueOnion.Service.Base
{
    /// <summary>
    /// This is for working directly with Domain objects primarily from other services. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TRepo"></typeparam>
    public abstract class DomainCommandServiceBase<T, TId> : DomainServiceBase<T>, IDomainCommandService<T, TId>
        where T : class, IAggregateRoot<TId>, new()
        
    {
        public DomainCommandServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, IRepository<T, TId> repo, int limit = 1000) 
            : base(unitOfWork, user, repositories, limit)
        {
            _repo = repo;
        }

        protected readonly IRepository<T, TId> _repo;

        public T ReturnInvalid(SimpleModelState ms, T item)
        {
            return item;
        }

        public T ExecuteSave()
        {
            CopyToChangeTracked(_dbItem);
            UnitOfWork.Save();
            return _dbItem;
        }

        public T ExecuteStage()
        {
            CopyToChangeTracked(_dbItem);
            return _dbItem;
        }

        public bool IsCreate()
        {
            return _inputItem.Id.Equals(GetDefaultIdValue());
        }

        public void DetermineInsertOrUpdate()
        {
            if (IsCreate())
            {
                _dbItem = new T { Id = GetInsertIdValue() };
                SetAuditFields();
                _repo.Add(_dbItem);
            }
            else
            {
                _dbItem = _repo.GetById(_inputItem.Id);
                SetAuditFields();
            }
        }

        public abstract TId GetDefaultIdValue();
        public abstract TId GetInsertIdValue();

        public void SetAuditFields()
        {
            if (IsCreate())
            {
                _dbItem.CreatedDate = DateTime.Now;
                _dbItem.CreatedBy = User.Id.ToString();
            }
            else
            {
                _dbItem.CreatedDate = DateTime.Now;
            }
        }

        public void CopyToChangeTracked(T item)
        {
            DetermineInsertOrUpdate();

            //copy from dto to domain
            Mapper.Map(_inputItem, _dbItem);
            _repo.SetCollectionsUnmodified(_dbItem);
        }

        public T Save(T item, SimpleModelState modelState, bool validateOnly = false)
        {
            _inputItem = item;
            return modelState.IsValid ? (validateOnly ? _inputItem : ExecuteSave()) : ReturnInvalid(modelState, _inputItem);
        }

        public T Stage(T item, SimpleModelState modelState, bool validateOnly = false)
        {
            _inputItem = item;
            return modelState.IsValid ? (validateOnly ? _inputItem : ExecuteStage()) : ReturnInvalid(modelState, _inputItem);
        }
    }
}
