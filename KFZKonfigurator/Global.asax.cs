using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.Controllers;
using KFZKonfigurator.Services;
using log4net.Config;

namespace KFZKonfigurator
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e) {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            SetupWindsorRegistrations();
        }

        public static void SetupWindsorRegistrations() {
            var container = new WindsorContainer();

            ControllerBuilder.Current.SetControllerFactory(new DiControllerFactory(container));

            container.Register(Component.For<LoggingInterceptor>().ImplementedBy<LoggingInterceptor>());
            container.Register(Component.For<KonfiguratorDbContext>().ImplementedBy<KonfiguratorDbContext>().LifeStyle.Transient);
            container.Register(Component.For<OrderService>().ImplementedBy<OrderService>());
            container.Register(Component.For<ConfigurationController>().Interceptors<LoggingInterceptor>().ImplementedBy<ConfigurationController>().LifeStyle.Transient);
            container.Register(Component.For<PriceCalculationService>().Interceptors<LoggingInterceptor>().ImplementedBy<PriceCalculationService>());
            container.Register(Component.For<UpdateService>().Interceptors<LoggingInterceptor>().ImplementedBy<UpdateService>());
        }
    }
}