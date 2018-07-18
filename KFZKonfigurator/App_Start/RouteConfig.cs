using System.Web.Mvc;
using System.Web.Routing;

namespace KFZKonfigurator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "OrderReview",
                url: "{controller}/review/{orderId}",
                defaults: new {controller = "Configuration", action = "OrderReview", orderId = UrlParameter.Optional});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Main", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}