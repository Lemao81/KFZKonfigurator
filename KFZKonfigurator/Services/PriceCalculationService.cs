using System.Linq;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Services
{
    [Log]
    public class PriceCalculationService
    {
        private readonly KonfiguratorDbContext _dbContext;

        public PriceCalculationService(KonfiguratorDbContext dbContext) {
            _dbContext = dbContext;
        }

        public decimal CalculatePrice(ConfigurationViewModel configuration) {
            var equipmentPrice = configuration.EquipmentValues?.Select(e => _dbContext.Equipments.Single(_ => _.EquipmentId == e)).Sum(_ => _.PriceEuro) ?? decimal.Zero;
            var rimsesPrice = configuration.RimsValue.HasValue ? _dbContext.Rimses.Single(_ => _.RimsId == configuration.RimsValue).PriceEuro ?? decimal.Zero : decimal.Zero;
            var varnishesPrice = configuration.VarnishValue.HasValue ? _dbContext.Varnishes.Single(_ => _.VarnishId == configuration.VarnishValue).PriceEuro ?? decimal.Zero : decimal.Zero;
            var engingePowerPrice = configuration.EnginePower * 5;

            return equipmentPrice + rimsesPrice + varnishesPrice + engingePowerPrice;
        }
    }
}