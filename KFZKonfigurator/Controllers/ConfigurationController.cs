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

        public ConfigurationController(PriceCalculationService priceCalculationService, UpdateService updateService, OrderService orderService, KonfiguratorDbContext dbContext) {
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

            var viewModel = new ConfigurationOverviewViewModel {
                Name = configuration.Name,
                Email = configuration.Email,
                Price = configuration.Price,
                EnginePower = configuration.EnginePower,
                RimsLabel = Display.GetValue(_ => _.Name, _dbContext.Rimses.SingleOrDefault(_ => _.RimsId == configuration.RimsValue)),
                VarnishLabel = Display.GetValue(_ => _.Name, _dbContext.Varnishes.SingleOrDefault(_ => _.VarnishId == configuration.VarnishValue)),
                EquipmentLabels = configuration.EquipmentValues.Select(value => _dbContext.Equipments.SingleOrDefault(_ => _.EquipmentId == value))
                    .Select(equipment => Display.GetValue(_ => _.Name, equipment)).ToList()
            };
            return PartialView("_ConfigurationOverview", viewModel);
        }

        public ActionResult Order() {
            try {
                _orderService.Order(Session[CONFIGURATION_SESSION_KEY] as ConfigurationViewModel);

                return Json(new {Success = KonfiguratorResx.Success_Order});
            }
            catch (Exception e) {
                Logger.Error(e);
                return Json(new {Error = KonfiguratorResx.Error_OrderFailed});
            }
        }
    }
}