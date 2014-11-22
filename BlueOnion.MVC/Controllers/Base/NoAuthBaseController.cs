using BlueOnion.ViewModel.Interfaces;
using System.Web.Mvc;

namespace BlueOnion.MVC.Controllers
{
    public class NoAuthBaseController : AsyncController
    {
        public readonly IViewModelServices Services;

        public NoAuthBaseController(IViewModelServices services)
        {
            Services = services;
        }
    }
}