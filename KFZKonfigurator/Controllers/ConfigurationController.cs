using System;
using System.Linq;
using System.Web.Mvc;
using KFZKonfigurator.Base;
using KFZKonfigurator.Models;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.Resources;
using KFZKonfigurator.Services;

namespace KFZKonfigurator.Controllers
{
    [Log]
    public class ConfigurationController : Controller
    {
        private const string CONFIGURATION_SESSION_KEY = "configuration_session_key";
        private readonly UpdateService _updateService;
        private readonly OrderService _orderService;
        private readonly KonfiguratorDbContext _dbContext;
        private readonly PriceCalculationService _priceCalculationService;
        private readonly EmailService _emailService;
        private readonly ViewModelService _viewModelService;

        public ConfigurationController(PriceCalculationService priceCalculationService, UpdateService updateService, OrderService orderService, KonfiguratorDbContext dbContext,
            EmailService emailService, ViewModelService viewModelService) {
            _viewModelService = viewModelService;
            _emailService = emailService;
            _priceCalculationService = priceCalculationService;
            _dbContext = dbContext;
            _orderService = orderService;
            _updateService = updateService;
        }

        public ActionResult Index() {
            var newConfiguration = _viewModelService.CreateConfigurationViewModel(_dbContext);
            newConfiguration.Price = _priceCalculationService.CalculatePrice(enginePower: newConfiguration.EnginePower);

            Session[CONFIGURATION_SESSION_KEY] = newConfiguration;

            return View(newConfiguration);
        }

        public JsonResult Update(string propertyName, object newValue) {
            try {
                var configuration = Session[CONFIGURATION_SESSION_KEY] as ConfigurationViewModel;
                _updateService.Update(configuration, propertyName, newValue);

                var equipments = _dbContext.FindEquipmentsByIds(configuration.EquipmentValues);
                var rims = _dbContext.FindRimsById(configuration.RimsValue);
                var varnish = _dbContext.FindVarnishById(configuration.VarnishValue);

                configuration.Price = _priceCalculationService.CalculatePrice(equipments, rims, varnish, configuration.EnginePower);

                return Json(new {configuration.PriceLabel});
            }
            catch (Exception e) {
                Logger.Error(e);
                return Json(new {Error = KonfiguratorResx.Error_UpdateFailed});
            }
        }

        public ActionResult Complete() {
            var configuration = Session[CONFIGURATION_SESSION_KEY] as ConfigurationViewModel;
            if (configuration == null) Json(new {Error = KonfiguratorResx.Error_CompletionFailed});

            var viewModel = _viewModelService.CreateConfigurationOverviewViewModel(configuration);
            return PartialView("_ConfigurationOverview", viewModel);
        }

        public ActionResult Order() {
            try {
                var orderId = _orderService.Order(Session[CONFIGURATION_SESSION_KEY] as ConfigurationViewModel);
                _emailService.SendEmail(_dbContext.Orders.Single(_ => _.OrderId == orderId));

                return Json(new {Success = KonfiguratorResx.Success_Order});
            }
            catch (Exception e) {
                Logger.Error(e);
                return Json(new {Error = KonfiguratorResx.Error_OrderFailed});
            }
        }

        public ActionResult OrderReview(Guid orderId) {
            var order = _dbContext.FindOrderById(orderId);
            var viewModel = _viewModelService.CreateConfigurationOverviewViewModel(order);

            return View(viewModel);
        }
    }
}