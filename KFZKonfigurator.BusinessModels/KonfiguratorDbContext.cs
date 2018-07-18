using System;
using System.Collections.Generic;
using System.Linq;
using KFZKonfigurator.BusinessModels.Model;

namespace KFZKonfigurator.BusinessModels
{
    using System.Data.Entity;

    public class KonfiguratorDbContext : DbContext
    {
        // Your context has been configured to use a 'KFZKonfiguratorEDM' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KFZKonfigurator.BusinessModels.KFZKonfiguratorEDM' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KFZKonfiguratorEDM' 
        // connection string in the application configuration file.
        public KonfiguratorDbContext() : base("name=KfzKonfiguratorDb") {
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Configuration>().HasRequired(_ => _.Order).WithRequiredPrincipal(_ => _.Configuration);
            modelBuilder.Entity<Order>().HasRequired(_ => _.User);

            modelBuilder.Entity<Order>().Property(_ => _.Price).IsConcurrencyToken();
            modelBuilder.Entity<Varnish>().Property(_ => _.PriceEuro).IsConcurrencyToken();
            modelBuilder.Entity<Varnish>().Property(_ => _.PricePound).IsConcurrencyToken();
            modelBuilder.Entity<Rims>().Property(_ => _.PriceEuro).IsConcurrencyToken();
            modelBuilder.Entity<Rims>().Property(_ => _.PricePound).IsConcurrencyToken();
            modelBuilder.Entity<Equipment>().Property(_ => _.PriceEuro).IsConcurrencyToken();
            modelBuilder.Entity<Equipment>().Property(_ => _.PricePound).IsConcurrencyToken();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Rims> Rimses { get; set; }
        public virtual DbSet<Varnish> Varnishes { get; set; }

        public List<Equipment> FindEquipmentsByIds(IEnumerable<int> ids) {
            if (ids == null || !ids.Any()) return new List<Equipment>();
            return ids.Select(id => Equipments.Single(_ => _.EquipmentId == id)).ToList();
        }

        public Rims FindRimsById(int? id) {
            return !id.HasValue ? null : Rimses.Single(_ => _.RimsId == id);
        }

        public Varnish FindVarnishById(int? id) {
            return !id.HasValue ? null : Varnishes.Single(_ => _.VarnishId == id);
        }

        public Order FindOrderById(Guid? id) {
            return !id.HasValue ? null : Orders.Single(_ => _.OrderId == id);
        }
    }
}