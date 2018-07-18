using System.Collections.Generic;
using System.Linq;
using KFZKonfigurator.Base.Enum;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels.Model;

namespace KFZKonfigurator.BusinessModels.Services
{
    [Log]
    public class PriceCalculationService
    {
        public decimal CalculatePrice(Currency currency, IEnumerable<Equipment> equipments = null, Rims rims = null, Varnish varnish = null, int? enginePower = null) {
            var equipmentPrice = equipments?.Sum(_ => currency == Currency.Euro ? _.PriceEuro : _.PricePound) ?? decimal.Zero;
            var rimsesPrice = (currency == Currency.Euro ? rims?.PriceEuro : rims?.PricePound) ?? decimal.Zero;
            var varnishesPrice = (currency == Currency.Euro ? varnish?.PriceEuro : varnish?.PricePound) ?? decimal.Zero;
            var engingePowerPrice = (enginePower ?? 0) * (currency == Currency.Euro ? 5 : 4);

            return equipmentPrice + rimsesPrice + varnishesPrice + engingePowerPrice;
        }
    }
}