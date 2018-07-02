using System;
using System.Web.Mvc;
using KFZKonfigurator.Models;
using System.Collections.Generic;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels.Enum;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.BusinessModels.Services;
using KFZKonfigurator.Data;
using KFZKonfigurator.Resources;

namespace KFZKonfigurator.Controllers
{
    public class CarConfigurationController : Controller
    {
        private readonly IDao<CarConfiguration> _dao;
        private readonly PriceCalculationService _priceCalculationService;

        public CarConfigurationController(IDao<CarConfiguration> dao, PriceCalculationService priceCalculationService)
        {
            _priceCalculationService = priceCalculationService;
            _dao = dao;
        }

        public ActionResult Index()
        {
            return View(new CarConfigurationViewModel
            {
                EnginePower = 50,
                Equipments = new List<Equipment>()
            });
        }

        public JsonResult Update(UpdateData data)
        {
            try
            {
                var configuration = _dao.Update(data.Id, data.PropertyName, data.NewValue);
                var newPrice = _priceCalculationService.CalculatePrice(configuration);
                return Json(new {Price = newPrice});
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return Json(new {Error = KonfiguratorResx.Error_UpdateFailed});
            }
        }
    }
}