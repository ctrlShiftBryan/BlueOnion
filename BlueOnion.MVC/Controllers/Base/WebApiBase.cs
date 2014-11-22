using BlueOnion.ViewModel.Interfaces;
using System.Web.Http;

namespace BlueOnion.MVC.Controllers
{
    public class WebApiBase : ApiController
    {
        public readonly IViewModelServices Services;
        public WebApiBase(IViewModelServices services)
        {
            Services = services;
        }
    }
}