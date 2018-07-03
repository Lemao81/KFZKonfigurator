using System;
using System.Web.Mvc;
using KFZKonfigurator.Models;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels.Services;
using KFZKonfigurator.Resources;
using KFZKonfigurator.Utils;

namespace KFZKonfigurator.Controllers
{
    public class CarConfigurationController : Controller
    {
        private const string CONFIGURATION_SESSION_KEY = "configuration_session_key";
        private readonly PriceCalculationService _priceCalculationService;

        public CarConfigurationController(PriceCalculationService priceCalculationService)
        {
            _priceCalculationService = priceCalculationService;
        }

        public ActionResult Index()
        {
            var newConfiguration = new CarConfigurationViewModel();
            Session[CONFIGURATION_SESSION_KEY] = newConfiguration;

            return View(newConfiguration);
        }

        public JsonResult Update(string property, object newValue)
        {
            try
            {
                var configuration = Session[CONFIGURATION_SESSION_KEY] as CarConfigurationViewModel;
                configuration?.GetType().GetProperty(property)?.SetValue(configuration, newValue);
                Session[CONFIGURATION_SESSION_KEY] = configuration;

                var newPrice = _priceCalculationService.CalculatePrice(configuration.MapToBusinessModel());
                return Json(new {Price = newPrice});
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return Json(new {Error = KonfiguratorResx.Error_UpdateFailed});
            }
        }

        public JsonResult OrderConfiguration()
        {
            return Json(new {Error = ""});
        }
    }
}