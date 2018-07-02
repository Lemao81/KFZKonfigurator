using System.Data.Entity;
using KFZKonfigurator.BusinessModels.Model;

namespace KFZKonfigurator.Data
{
    public class KonfiguratorContext : DbContext
    {
        public DbSet<CarConfiguration> Configurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}