using BlueOnion.MVC.Filters;
using BlueOnion.ViewModel.Interfaces;

namespace BlueOnion.MVC.Controllers
{
    [AuthorizationFilter]
    public class BaseController : NoAuthBaseController
    {
        public BaseController(IViewModelServices services)
            : base(services)
        {

        }
    }
}