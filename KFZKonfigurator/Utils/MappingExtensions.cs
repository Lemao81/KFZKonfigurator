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

        public static Configuration MapToBusinessModel(this ConfigurationViewModel configuration, KonfiguratorDbContext dbContext) {
            return new Configuration {
                EnginePower = configuration.EnginePower,
                Equipments = configuration.EquipmentValues.Select(e => dbContext.Equipments.SingleOrDefault(_ => _.EquipmentId == e)).ToList(),
                Name = configuration.Name,
                Rims = dbContext.Rimses.SingleOrDefault(_ => _.RimsId == configuration.RimsValue),
                Varnish = dbContext.Varnishes.SingleOrDefault(_ => _.VarnishId == configuration.VarnishValue)
            };
        }
    }
}