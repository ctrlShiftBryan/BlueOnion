using BlueOnion.Domain.Interfaces;
using BlueOnion.ViewModel.Common;


namespace BlueOnion.ViewModel.Interfaces
{
    public interface IDomainCommandService<TDomainPoco, TId> where TDomainPoco : IAggregateRoot<TId>
    {
        TDomainPoco ReturnInvalid(SimpleModelState ms, TDomainPoco item);
        TDomainPoco ExecuteSave();
        TDomainPoco ExecuteStage();
        bool IsCreate();
        IDomainServices OtherServices { get; set; }
        void DetermineInsertOrUpdate();
        void SetAuditFields();
        void CopyToChangeTracked(TDomainPoco item);
        TDomainPoco Save(TDomainPoco item, SimpleModelState modelState, bool validateOnly = false);
        TDomainPoco Stage(TDomainPoco item, SimpleModelState modelState, bool validateOnly = false);
    }
}