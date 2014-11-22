using BlueOnion.ViewModel.Interfaces;
using System.Web.Mvc;
using System.Web.OData;

namespace BlueOnion.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ODataControllerBase : ODataController
    {
        public readonly IViewModelServices Services;
        public ODataControllerBase(IViewModelServices services)
        {
            Services = services;
        }
    }
}