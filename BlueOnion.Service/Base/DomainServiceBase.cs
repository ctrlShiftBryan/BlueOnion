using BlueOnion.Domain.Interfaces;
using BlueOnion.Repository.Interfaces;
using BlueOnion.ViewModel.Interfaces;

namespace BlueOnion.Service.Base
{
    public class DomainServiceBase<T>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IUser User;
        protected readonly IRepositoriesWrapper Repositories;
        protected readonly int _limit;
        protected T _dbItem;
        protected T _inputItem;

        public IDomainServices OtherServices { get; set; }
        public DomainServiceBase(IUnitOfWork unitOfWork, IUser user, IRepositoriesWrapper repositories, int limit = 1000)
        {
            UnitOfWork = unitOfWork;
            User = user;
            Repositories = repositories;
            _limit = limit;
        }

    }
}
