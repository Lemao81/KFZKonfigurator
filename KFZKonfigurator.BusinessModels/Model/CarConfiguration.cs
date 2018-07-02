using System;
using System.Collections.Generic;
using KFZKonfigurator.BusinessModels.Enum;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class CarConfiguration
    {
        public Guid ConfigurationId { get; set; }
        public string Name { get; set; }
        public int EnginePower { get; set; }
        public Varnish Varnish { get; set; }
        public Rims Rims { get; set; }
        public List<Equipment> Equipments { get; set; }

        public virtual Order Order { get; set; }
    }
}