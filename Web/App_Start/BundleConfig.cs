using System.Web.Optimization;

namespace Web
{
    /// <summary>
    /// Бандел конфиг
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Регистрируем скрипты
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/noty/jquery.noty.packaged.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css", "~/Content/site.css", "~/Content/loading-bar.css"));


            bundles.Add(new StyleBundle("~/bundles/signalr")
                .Include("~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/Angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/Scripts/angular-cookies.js")
                .Include("~/Scripts/angular-sanitize.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-animate.js")
                .Include("~/Scripts/ng-infinite-scroll.js")
                .Include("~/Scripts/loading-bar.js"));
        }
    }
}
