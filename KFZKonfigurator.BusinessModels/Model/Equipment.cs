using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KFZKonfigurator.BusinessModels.Resources;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        [Display(ResourceType = typeof(EquipmentResx))]
        public string Name { get; set; }

        public decimal? PriceEuro { get; set; }
        public decimal? PricePound { get; set; }
        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}