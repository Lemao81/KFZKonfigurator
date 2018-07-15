using System.Linq;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Services
{
    public class PriceCalculationService
    {
        private readonly KonfiguratorDbContext _dbContext;

        public PriceCalculationService(KonfiguratorDbContext dbContext) {
            _dbContext = dbContext;
        }

        public decimal CalculatePrice(ConfigurationViewModel configuration) {
            var equipmentPrice = configuration.EquipmentValues?.Select(e => _dbContext.Equipments.SingleOrDefault(_ => _.EquipmentId == e)).Sum(_ => _.PriceEuro) ?? decimal.Zero;
            var rimsesPrice = _dbContext.Rimses.SingleOrDefault(_ => _.RimsId == configuration.RimsValue)?.PriceEuro ?? decimal.Zero;
            var varnishesPrice = _dbContext.Varnishes.SingleOrDefault(_ => _.VarnishId == configuration.VarnishValue)?.PriceEuro ?? decimal.Zero;
            var engingePowerPrice = configuration.EnginePower * 5;

            return equipmentPrice + rimsesPrice + varnishesPrice + engingePowerPrice;
        }
    }
}