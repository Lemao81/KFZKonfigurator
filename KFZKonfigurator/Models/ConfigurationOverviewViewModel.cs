using System.Collections.Generic;

namespace KFZKonfigurator.Models
{
    public class ConfigurationOverviewViewModel
    {
        public string Name { get; set; }
        public int EnginePower { get; set; }
        public string VarnishLabel { get; set; }
        public string RimsLabel { get; set; }
        public List<string> EquipmentLabels { get; set; }
        public decimal? Price { get; set; }
        public string Email { get; set; }
    }
}