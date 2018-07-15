using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class Varnish
    {
        public int VarnishId { get; set; }

        [Display(ResourceType = typeof(VarnishResx))]
        public string Name { get; set; }

        public decimal? PriceEuro { get; set; }
        public decimal? PricePound { get; set; }
    }
}