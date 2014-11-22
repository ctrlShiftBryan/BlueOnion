using BlueOnion.ViewModel.Interfaces;
using System.Web;
using System.Web.Mvc;

namespace BlueOnion.MVC.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            //Skip authorization if [AllowAnonymous] is declared
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (skipAuthorization)
                return;

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {

                var domainServices = DependencyResolver.Current.GetService(typeof(IDomainServices)) as IDomainServices;


                var menuItem = "";


                //if (controllerName == "FacilityGroupDetail")
                //{
                //    menuItem = MenuItems.FacilityGroups;
                //}

                //if (controllerName == "DedupAddress")
                //{
                //    menuItem = MenuItems.Addresses;
                //}

                //if (controllerName == "DuplicateEntity")
                //{
                //    menuItem = MenuItems.EntityContacts;
                //}

                //if (controllerName == "DedupContactsIndividualNameDuplicate")
                //{
                //    menuItem = MenuItems.IndividualContacts;

                //}

                //if (controllerName == "MaintenanceTable")
                //{
                //    menuItem = MenuItems.MaintenanceTables;
                //}

                //if (controllerName == "DirectoryExport")
                //{
                //    menuItem = MenuItems.DirectoryExportEmbassySuites;
                //}

                if (!string.IsNullOrWhiteSpace(menuItem))
                {
                    //if (!domainServices.UserSecurityProfileQueryService.UserCanAccessMenuItem(menuItem))
                    //{
                    //    filterContext.Result = new HttpUnauthorizedResult();
                    //}
                }


                //TABLE MAINTENANCE Meta Edit Only Available to TableMaintenanceAdministrators
                //var isTableMaintenanceAdmin = RoleSecurityService.IsMaintenanceTableAdmin(HttpContext.Current.User);
                //if (controllerName != "MaintenanceTable" || actionName != "Edit" || isTableMaintenanceAdmin) return;
                //var model = filterContext.Controller.ViewData.Model as MaintenanceTableViewModel;


                //TODO throw HttpUnauthorizedResult on Meta edit if not admin
                //if (model == null)
                //{
                //    filterContext.Result = new HttpUnauthorizedResult();
                //}
                //else
                //{
                //    if (!model.IsDynamicTable)
                //    {
                //        filterContext.Result = new HttpUnauthorizedResult();
                //    }

                //}
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var domainServices = DependencyResolver.Current.GetService(typeof(IDomainServices)) as IDomainServices;
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                //var properties = viewResult.Model.GetType().GetProperties().Where(x => x.Name.Equals("IsTableMaintenanceAdmin")).ToList();
                //if (properties.Count == 1)
                //{
                //    var isTableMaintenanceAdmin = RoleSecurityService.IsMaintenanceTableAdmin(HttpContext.Current.User);
                //    properties.Single().SetValue(viewResult.Model, isTableMaintenanceAdmin, null);
                //}
            }

            //var jsonResult = filterContext.Result as JsonNetResult;
            //if (jsonResult != null)
            //{
            //    var vm = jsonResult.Data as FacilityGroupDetailViewModel;
            //    if (vm != null)
            //    {
            //        var user = HttpContext.Current.User.Identity.Name;
            //        var isAdmin = RoleSecurityService.IsFacilityGroupAdmin(HttpContext.Current.User);
            //        var userIsResponsiblePerson = vm.ItemDetail.ResponsiblePeople.Any(x => x.UserId == user);
            //        vm.ItemDetail.UserCanEdit = userIsResponsiblePerson || isAdmin;
            //        vm.ItemDetail.UserIsResponsiblePerson = userIsResponsiblePerson;
            //    }
            //}
        }
    }
}