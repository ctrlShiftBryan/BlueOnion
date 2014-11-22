using BlueOnion.Repository.Common;
using BlueOnion.ViewModel.AutoMapper;
using BlueOnion.ViewModel.Interfaces;
using System;
using System.Data.Entity;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace BlueOnion.MVC
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigMapper.MapAll();
            Database.SetInitializer<BlueOnionContext>(null); ;           
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || string.IsNullOrEmpty(authCookie.Value)) return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var domainServices = DependencyResolver.Current.GetService(typeof(IDomainServices)) as IDomainServices;
            //to use user service
            //var userCommandService = domainServices.UserSecurityProfileQueryService;
            //var user = userCommandService.GetByUsername(authTicket.Name);
            //var roles = user.UserSecurityProfileRoles.Select(x => x.Role.Name).ToArray();
            var roles = new string[0];
            var genericIdentity = new GenericIdentity(authTicket.Name);

            var genericPrincipal = new GenericPrincipal(genericIdentity, roles);

            Thread.CurrentPrincipal = genericPrincipal;
            Context.User = genericPrincipal;
        }
    }


}