using System.Collections.Generic;
using System.Linq;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels.Model;

namespace KFZKonfigurator.Services
{
    [Log]
    public class PriceCalculationService
    {
        public decimal CalculatePrice(IEnumerable<Equipment> equipments = null, Rims rims = null, Varnish varnish = null, int? enginePower = null) {
            var equipmentPrice = equipments?.Sum(_ => _.PriceEuro) ?? decimal.Zero;
            var rimsesPrice = rims?.PriceEuro ?? decimal.Zero;
            var varnishesPrice = varnish?.PriceEuro ?? decimal.Zero;
            var engingePowerPrice = (enginePower ?? 0) * 5;

            return equipmentPrice + rimsesPrice + varnishesPrice + engingePowerPrice;
        }
    }
}