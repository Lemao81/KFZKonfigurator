using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFZKonfigurator.BusinessModels
{
    public class KonfiguratorContext : DbContext
    {
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}