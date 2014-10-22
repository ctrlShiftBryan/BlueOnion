

namespace BlueOnion.ViewModel.Interfaces
{
    public interface IDomainQueryService<TDomainPoco> 
    {
        IDomainServices OtherServices { get; set; }

    }
}