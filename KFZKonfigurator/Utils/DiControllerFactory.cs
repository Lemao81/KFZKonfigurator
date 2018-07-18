using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace KFZKonfigurator.Utils
{
    public class DiControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _windsorContainer;

        public DiControllerFactory(IWindsorContainer container) {
            _windsorContainer = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName) {
            var controllerType = GetControllerType(requestContext, controllerName);
            var controller = _windsorContainer.Resolve(controllerType) as IController;

            return controller ?? base.CreateController(requestContext, controllerName);
        }
    }
}