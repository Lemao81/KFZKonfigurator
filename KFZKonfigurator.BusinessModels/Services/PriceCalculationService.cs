using System.Linq;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.BusinessModels.Utils;

namespace KFZKonfigurator.BusinessModels.Services
{
    public class PriceCalculationService
    {
        public decimal CalculatePrice(CarConfiguration carConfiguration)
        {
            return carConfiguration.Equipments.Sum(_ => _.GetPrice()) + carConfiguration.Rims.GetPrice() + carConfiguration.EnginePower * 5;
        }
    }
}