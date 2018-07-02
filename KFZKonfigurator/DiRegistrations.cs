using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.BusinessModels.Services;
using KFZKonfigurator.Controllers;
using KFZKonfigurator.Data;
using KFZKonfigurator.Services;

namespace KFZKonfigurator
{
    public class DiRegistrations
    {
        public static void Setup()
        {
            var container = new WindsorContainer();

            ControllerBuilder.Current.SetControllerFactory(new DiControllerFactory(container));

            container.Register(Component.For<IDao<CarConfiguration>>().ImplementedBy<CarConfigurationDao>());
            container.Register(Component.For<CarConfigurationController>().ImplementedBy<CarConfigurationController>());
            container.Register(Component.For<PriceCalculationService>().ImplementedBy<PriceCalculationService>());
        }
    }
}