using System;
using System.Data.Entity.Migrations;
using System.Linq;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Models;
using KFZKonfigurator.Utils;

namespace KFZKonfigurator.Services
{
    public class OrderService
    {
        private readonly KonfiguratorDbContext _dbContext;

        public OrderService(KonfiguratorDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Order(ConfigurationViewModel configurationViewModel) {
            var configurations = _dbContext.Configurations;
            var configuration = configurationViewModel.MapToBusinessModel(_dbContext);
            configuration.ConfigurationId = Guid.NewGuid();

            var user = _dbContext.Users.SingleOrDefault(_ => _.Email == configurationViewModel.Email) ?? new User {
                UserId = Guid.NewGuid(),
                Email = configurationViewModel?.Email
            };

            var order = new Order {
                OrderId = Guid.NewGuid(),
                Created = DateTime.Now,
                Configuration = configuration,
                User = user
            };

            configuration.Order = order;

            _dbContext.Configurations.Add(configuration);
            _dbContext.Users.AddOrUpdate(user);
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();
        }
    }
}