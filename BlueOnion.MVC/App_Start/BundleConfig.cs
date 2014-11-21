using System.Web.Optimization;

namespace BlueOnion.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = false;
        }
    }
}