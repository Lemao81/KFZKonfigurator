using System.Collections.Generic;
using KFZKonfigurator.Base;
using KFZKonfigurator.Binding.Models;

namespace KFZKonfigurator.Models
{
    public class ConfigurationViewModel
    {
        public string Name { get; set; }
        public int EnginePower { get; set; }
        public int? VarnishValue { get; set; }
        public List<SelectOption> VarnishOptions { get; set; }
        public int? RimsValue { get; set; }
        public List<SelectOption> RimsOptions { get; set; }
        public List<int> EquipmentValues { get; set; }
        public List<SelectOption> EquipmentOptions { get; set; }
        public decimal? Price { get; set; }
        public string Email { get; set; }
        public string PriceLabel => Price.GetPriceLabel();
    }
}