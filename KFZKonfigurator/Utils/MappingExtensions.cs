using System.Linq;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Utils
{
    public static class MappingExtensions
    {
        public static ConfigurationViewModel MapToViewModel(this Configuration configuration, KonfiguratorDbContext dbContext) {
            return new ConfigurationViewModel(dbContext) {
                EnginePower = configuration.EnginePower ?? 0,
                EquipmentValues = configuration.Equipments.Select(_ => _.EquipmentId).ToList(),
                Name = configuration.Name,
                RimsValue = configuration.Rims.RimsId,
                VarnishValue = configuration.Varnish.VarnishId,
            };
        }

        public static Configuration MapToBusinessObject(this ConfigurationViewModel configuration, KonfiguratorDbContext dbContext) {
            return new Configuration {
                EnginePower = configuration.EnginePower,
                Equipments = configuration.EquipmentValues.Select(e => dbContext.Equipments.Single(_ => _.EquipmentId == e)).ToList(),
                Name = configuration.Name,
                Rims = configuration.RimsValue.HasValue ? dbContext.Rimses.Single(_ => _.RimsId == configuration.RimsValue) : null,
                Varnish = configuration.VarnishValue.HasValue ? dbContext.Varnishes.Single(_ => _.VarnishId == configuration.VarnishValue) : null
            };
        }
    }
}