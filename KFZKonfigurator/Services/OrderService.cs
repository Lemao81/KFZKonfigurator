using System;
using System.Data.Entity.Migrations;
using System.Linq;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Models;
using KFZKonfigurator.Utils;

namespace KFZKonfigurator.Services
{
    [Log]
    public class OrderService
    {
        private readonly KonfiguratorDbContext _dbContext;

        public OrderService(KonfiguratorDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Guid Order(ConfigurationViewModel configurationViewModel) {
            var configurationBo = configurationViewModel.MapToBusinessObject(_dbContext);

            configurationBo.ConfigurationId = Guid.NewGuid();

            var user = _dbContext.Users.SingleOrDefault(_ => _.Email == configurationViewModel.Email) ?? new User {
                UserId = Guid.NewGuid(),
                Email = configurationViewModel?.Email
            };

            var order = new Order {
                OrderId = Guid.NewGuid(),
                Created = DateTime.Now,
                Configuration = configurationBo,
                User = user,
                Price = configurationViewModel?.Price
            };

            configurationBo.Order = order;

            _dbContext.Configurations.Add(configurationBo);
            _dbContext.Users.AddOrUpdate(user);
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();

            return order.OrderId;
        }
    }
}