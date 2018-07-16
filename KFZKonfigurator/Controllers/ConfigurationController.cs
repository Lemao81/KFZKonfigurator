using System;
using System.Collections.Generic;
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

        public ConfigurationController(PriceCalculationService priceCalculationService, UpdateService updateService, OrderService orderService, KonfiguratorDbContext dbContext,
            EmailService emailService) {
            _emailService = emailService;
            _priceCalculationService = priceCalculationService;
            _dbContext = dbContext;
            _orderService = orderService;
            _updateService = updateService;
        }

        public ActionResult Index() {
            var newConfiguration = new ConfigurationViewModel(_dbContext);
            newConfiguration.Price = _priceCalculationService.CalculatePrice(newConfiguration);
            Session[CONFIGURATION_SESSION_KEY] = newConfiguration;

            return View(newConfiguration);
        }

        public JsonResult Update(string propertyName, object newValue) {
            try {
                var configuration = Session[CONFIGURATION_SESSION_KEY] as ConfigurationViewModel;
                _updateService.Update(configuration, propertyName, newValue);

                return Json(new {configuration?.Price});
            }
            catch (Exception e) {
                Logger.Error(e);
                return Json(new {Error = KonfiguratorResx.Error_UpdateFailed});
            }
        }

        public ActionResult Complete() {
            var configuration = Session[CONFIGURATION_SESSION_KEY] as ConfigurationViewModel;

            var rimsLabel = configuration.RimsValue.HasValue ? Display.GetValue(_ => _.Name, _dbContext.Rimses.Single(_ => _.RimsId == configuration.RimsValue)) : string.Empty;
            var varnishLabel = configuration.VarnishValue.HasValue ? Display.GetValue(_ => _.Name, _dbContext.Varnishes.Single(_ => _.VarnishId == configuration.VarnishValue)) : string.Empty;
            var equipmentLabels = configuration.EquipmentValues.Select(value => _dbContext.Equipments.Single(_ => _.EquipmentId == value))
                .Select(equipment => Display.GetValue(_ => _.Name, equipment)).ToList();

            var viewModel = new ConfigurationOverviewViewModel {
                Name = configuration.Name,
                Email = configuration.Email,
                Price = configuration.Price,
                EnginePower = configuration.EnginePower,
                RimsLabel = rimsLabel,
                VarnishLabel = varnishLabel,
                EquipmentLabels = equipmentLabels,
                IsOrdered = false
            };
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
            var order = _dbContext.Orders.SingleOrDefault(_ => _.OrderId == orderId);
            ConfigurationOverviewViewModel viewModel;

            if (order != null) {
                var rimsLabel = Display.GetValue(_ => _.Name, order.Configuration.Rims);
                var varnishLabel = Display.GetValue(_ => _.Name, order.Configuration.Varnish);
                var equipmentLabels = order.Configuration.Equipments.Select(equipment => Display.GetValue(_ => _.Name, equipment)).ToList();

                viewModel = new ConfigurationOverviewViewModel {
                    Name = order.Configuration.Name,
                    Created = order.Created,
                    Email = order.User.Email,
                    Price = order.Price,
                    EnginePower = order.Configuration.EnginePower ?? 0,
                    RimsLabel = rimsLabel,
                    VarnishLabel = varnishLabel,
                    EquipmentLabels = equipmentLabels,
                    IsOrdered = true,
                    IsValidOrder = true
                };
            }
            else {
                viewModel = new ConfigurationOverviewViewModel {IsValidOrder = false};
            }

            return View(viewModel);
        }
    }
}