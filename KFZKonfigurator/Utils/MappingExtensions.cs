using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Utils
{
    public static class MappingExtensions
    {
        public static CarConfigurationViewModel MapToViewModel(this CarConfiguration carConfiguration)
        {
            return new CarConfigurationViewModel
            {
                EnginePower = carConfiguration.EnginePower,
                Equipments = carConfiguration.Equipments,
                Name = carConfiguration.Name,
                Rims = carConfiguration.Rims,
                Varnish = carConfiguration.Varnish
            };
        }

        public static CarConfiguration MapToBusinessModel(this CarConfigurationViewModel carConfiguration)
        {
            return new CarConfiguration
            {
                EnginePower = carConfiguration.EnginePower,
                Equipments = carConfiguration.Equipments,
                Name = carConfiguration.Name,
                Rims = carConfiguration.Rims,
                Varnish = carConfiguration.Varnish
            };
        }
    }
}