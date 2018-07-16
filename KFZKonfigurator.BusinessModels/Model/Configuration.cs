using System;
using System.Collections.Generic;

namespace KFZKonfigurator.BusinessModels.Model
{
    public class Configuration
    {
        public Guid ConfigurationId { get; set; }
        public string Name { get; set; }
        public int? EnginePower { get; set; }
        public Varnish Varnish { get; set; }
        public Rims Rims { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}