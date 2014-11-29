using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel;
using BlueOnion.ViewModel.Interfaces;

namespace BlueOnion.Service.Base
{
    /// <summary>
    /// This is the base class for all services.
    /// It ties together an Aggregate Root (http://martinfowler.com/bliki/DDD_Aggregate.html) 
    /// A View Model (http://lostechies.com/jimmybogard/2009/06/30/how-we-do-mvc-view-models/)
    /// And a summary and detail Dtos (http://martinfowler.com/eaaCatalog/dataTransferObject.html)
    /// </summary>
    /// <typeparam name="AR">The Aggregate Root Class</typeparam>
    /// <typeparam name="VM">The View Model</typeparam>
    /// <typeparam name="Dto">The Summary Dto</typeparam>
    /// <typeparam name="DDto">The Detail Dto</typeparam>
    public class ViewModelServiceBase<AR, VM, Dto, DDto, TId> 
        where AR : class, IAggregateRoot<TId>, new()
        where VM : IViewModelBase<Dto, DDto, TId>, new()
        where Dto : class,  IDto<TId>, new()
        where DDto : class,  IDto<TId>, new()
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IUser User;
        protected readonly IRepositoriesWrapper Repositories;
        protected readonly IDomainServices DomainServices;
        protected readonly int _limit;
        public VM _vm { get; set; }



        public ViewModelServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, IDomainServices domainServices, int limit = 1000)
        {
            UnitOfWork = unitOfWork;
            User = user;
            Repositories = repositories;
            DomainServices = domainServices;
            _limit = limit;
            _vm = new VM();
        }

    }
}