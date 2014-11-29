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
    /// <typeparam name="Dto"></typeparam>
    /// <typeparam name="DDto"></typeparam>
    public class ViewModelQueryServiceBase<AR, VM, Dto, DDto, REPO, TId> : ViewModelServiceBase<AR, VM, Dto, DDto, TId>, IGenericQueryService<VM, TId>
        where AR : class, IAggregateRoot<TId>, new()
        where VM : IViewModelBase<Dto, DDto, TId>, new()
        where Dto : class, IDto<TId>, new()
        where DDto : class, IDto<TId>, new()
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