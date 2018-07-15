using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class Rims
    {
        public int RimsId { get; set; }

        [Display(ResourceType = typeof(RimsResx))]
        public string Name { get; set; }

        public decimal? PriceEuro { get; set; }
        public decimal? PricePound { get; set; }
    }
}