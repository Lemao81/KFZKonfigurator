using System.Collections.Generic;
using KFZKonfigurator.Base;
using KFZKonfigurator.Binding.Models;
using KFZKonfigurator.BusinessModels;

namespace KFZKonfigurator.Models
{
    public class ConfigurationViewModel
    {
        public ConfigurationViewModel(KonfiguratorDbContext dbContext) {
            EnginePower = 50;
            EquipmentValues = new List<int>();

            EquipmentOptions = new List<SelectOption>();
            foreach (var equipment in dbContext.Equipments) {
                EquipmentOptions.Add(new SelectOption {
                    Label = Display.GetValue(_ => _.Name, equipment),
                    Value = equipment.EquipmentId
                });
            }

            VarnishOptions = new List<SelectOption>();
            foreach (var varnish in dbContext.Varnishes) {
                VarnishOptions.Add(new SelectOption {
                    Label = Display.GetValue(_ => _.Name, varnish),
                    Value = varnish.VarnishId
                });
            }

            RimsOptions = new List<SelectOption>();
            foreach (var rims in dbContext.Rimses) {
                RimsOptions.Add(new SelectOption {
                    Label = Display.GetValue(_ => _.Name, rims),
                    Value = rims.RimsId
                });
            }
        }

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
    }
}