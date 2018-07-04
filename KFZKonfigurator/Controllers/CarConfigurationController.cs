using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using KFZKonfigurator.Base;
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

        public JsonResult Update(string propertyName, object newValue)
        {
            try
            {
                var configuration = Session[CONFIGURATION_SESSION_KEY] as CarConfigurationViewModel;

                var propertyInfo = configuration?.GetType().GetProperty(propertyName);
                newValue = (newValue as Array)?.GetValue(0);
                if (configuration == null || propertyInfo == null) throw new ArgumentException("Current configuration and updated property must not be null");

                typeof(CarConfigurationController).CallGeneric(nameof(UpdateGeneric), new[] {configuration.GetType(), propertyInfo.PropertyType},
                    new[] {configuration, propertyInfo.AsLambdaExpression(), newValue});

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

        public static void UpdateGeneric<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> property, object newValue)
        {
            var convertedValue = newValue == null ? default(TProperty)
                : typeof(TProperty).IsEnumOrNullableEnum() ? (TProperty) Enum.ToObject(typeof(TProperty).ToNonNullable(), int.Parse(newValue.ToString()))
                : (TProperty) Convert.ChangeType(newValue, typeof(TProperty).ToNonNullable());

            property.GetPropertyInfo().SetValue(model, convertedValue);
        }

        public JsonResult OrderConfiguration()
        {
            return Json(new {Error = ""});
        }
    }
}