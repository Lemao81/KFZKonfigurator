using System.Collections.Generic;
using KFZKonfigurator.BusinessModels.Enum;

namespace KFZKonfigurator.Models
{
    public class CarConfigurationViewModel
    {
        public string Name { get; set; }
        public int EnginePower { get; set; }
        public Varnish Varnish { get; set; }
        public Rims Rims { get; set; }
        public List<Equipment> Equipments { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }
    }
}