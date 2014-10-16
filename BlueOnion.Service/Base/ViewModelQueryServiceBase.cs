using AutoMapper;
using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel;
using BlueOnion.ViewModel.Interfaces;
using System;

namespace BlueOnion.Service.Base
{
    /// <summary>
    /// Query Service Base for IModifiable AggregateRoot Entities
    /// </summary>
    /// <typeparam name="AR"></typeparam>
    /// <typeparam name="VM"></typeparam>
    /// <typeparam name="DTO"></typeparam>
    /// <typeparam name="DDTO"></typeparam>
    public class ViewModelQueryServiceBase<AR, VM, DTO, DDTO, REPO, TId> : ViewModelServiceBase<AR, VM, DTO, DDTO, TId>, IGenericQueryService<VM, TId>
        where AR : class, IAggregateRoot<TId>, new()
        where VM : IViewModelBase<DTO, DDTO, TId>, new()
        where DTO : class, IDto<TId>, new()
        where DDTO : class, IDto<TId>, new()
        where REPO : IRepository<AR, TId>
    {
        protected readonly REPO _repo;

        public ViewModelQueryServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, REPO repo, IDomainServices domainServices, int limit = 1000)
            : base(unitOfWork, user, repositories, domainServices, limit)
        {
            _repo = repo;
        }

        public virtual VM GetList(DateTime? effectiveDateTime = null)
        {
            //var userDto = new User()
            //{
            //    Id = User.Id().ToString(),
            //    UserName = User.UserName
            //};
            //_vm.User = userDto;
            return _vm;
        }

        public virtual VM GetDetail(TId id, DateTime? effectiveDateTime = null)
        {
            var repo = _repo;
            var data = repo.GetById(id);
            _vm.ItemDetail = Mapper.Map(data, _vm.ItemDetail);
            return _vm;
        }

        public virtual VM GetMeta()
        {
            return _vm;
        }
    }
}