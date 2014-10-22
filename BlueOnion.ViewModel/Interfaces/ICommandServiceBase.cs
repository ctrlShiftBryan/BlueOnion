using BlueOnion.ViewModel.Common;

namespace BlueOnion.ViewModel.Interfaces
{
    public interface ICommandServiceBase<TViewModel> 
    {
        TViewModel SaveViewModel(TViewModel pvm, SimpleModelState modelState, bool validateOnly = false);
    }
}
