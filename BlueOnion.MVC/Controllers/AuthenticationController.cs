using BlueOnion.ViewModel.Interfaces;
using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace BlueOnion.MVC.Controllers
{
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IViewModelServices services) : base(services)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var authCookie = Response.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value)) return RedirectToLocal(returnUrl);

            var OnQ_APPURL = GetAuthenticationUrl(returnUrl);

            if (!AllowDevLogin)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    returnUrl = "/";

                if (User.Identity.IsAuthenticated)
                    return new RedirectResult(returnUrl);

                return new RedirectResult(OnQ_APPURL);

            }

            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = "/";

            if (User.Identity.IsAuthenticated)
                return RedirectToLocal(returnUrl);

            return View(); 
            //todo return proper user view model for login
            //return View(new UserSecurityProfileViewModel { ReturnUrl = returnUrl });
        }

        private bool AllowDevLogin
        {
            get
            {
                var testLogin = false;
                bool.TryParse(WebConfigurationManager.AppSettings["AllowDevLogin"], out testLogin);

                return testLogin;
            }
        }

        private string GetAuthenticationUrl(string returnUrl)
        {
            var baseUrl = ConfigurationManager.AppSettings["SiteRoot"];
            if (String.IsNullOrEmpty(returnUrl)) return ConfigurationManager.AppSettings["AuthenticationSiteRoot"];
            return returnUrl.IndexOf(baseUrl) > -1 ?

               String.Format("{0}{1}",
                       ConfigurationManager.AppSettings["AuthenticationSiteRoot"],
                       returnUrl
                   )
               :

               String.Format("{0}{1}{2}",
                       ConfigurationManager.AppSettings["AuthenticationSiteRoot"],
                       baseUrl,
                       returnUrl
                   );
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "MaintenanceTable");
        }
    }
}