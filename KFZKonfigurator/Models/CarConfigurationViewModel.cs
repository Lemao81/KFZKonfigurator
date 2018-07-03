using System.Collections.Generic;
using KFZKonfigurator.BusinessModels.Enum;
using System.Linq;
using KFZKonfigurator.Base;
using KFZKonfigurator.Binding.Models;

namespace KFZKonfigurator.Models
{
    public class CarConfigurationViewModel
    {
        public CarConfigurationViewModel()
        {
            EnginePower = 50;
            Equipments = new List<Equipment>();

            VarnishOptions = new List<DropdownOption<Varnish?>>();
            foreach (var value in System.Enum.GetValues(typeof(Varnish)).OfType<Varnish>())
            {
                VarnishOptions.Add(new DropdownOption<Varnish?>
                {
                    Label = value.GetDisplay(),
                    Value = value
                });
            }
        }

        public string Name { get; set; }
        public int EnginePower { get; set; }
        public Varnish? Varnish { get; set; }
        public List<DropdownOption<Varnish?>> VarnishOptions { get; set; }
        public Rims? Rims { get; set; }
        public List<Equipment> Equipments { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }
    }
}