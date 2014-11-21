using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace BlueOnion.MVC.Common
{
    public static class RazorUtil
    {
        public static HtmlHelper GetPageHelper(this System.Web.WebPages.Html.HtmlHelper html)
        {
            return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html;
        }

        public static string ImageUrl(string filename)
        {
            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["ImageURL"];
            baseUrl = baseUrl.TrimEnd('/');
            return String.Format("{0}/{1}", baseUrl, filename);
        }

        public static string WebConfigValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static string GetBaseURL()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            // if (!string.IsNullOrWhiteSpace(appUrl)) appUrl += "/";

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}