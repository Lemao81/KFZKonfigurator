using System.Collections.Generic;
using System.Linq;
using KFZKonfigurator.Base;
using KFZKonfigurator.Binding.Models;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.BusinessModels.Model;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Services
{
    public class ViewModelService
    {
        private readonly KonfiguratorDbContext _dbContext;

        public ViewModelService(KonfiguratorDbContext dbContext) {
            _dbContext = dbContext;
        }

        public ConfigurationViewModel CreateConfigurationViewModel(KonfiguratorDbContext dbContext) {
            var viewModel = new ConfigurationViewModel {
                EnginePower = 50,
                EquipmentValues = new List<int>(),
                EquipmentOptions = new List<SelectOption>(),
                VarnishOptions = new List<SelectOption>(),
                RimsOptions = new List<SelectOption>()
            };

            foreach (var equipment in dbContext.Equipments) {
                viewModel.EquipmentOptions.Add(new SelectOption {
                    Label = Display.GetValue(_ => _.Name, equipment),
                    Value = equipment.EquipmentId
                });
            }

            foreach (var varnish in dbContext.Varnishes) {
                viewModel.VarnishOptions.Add(new SelectOption {
                    Label = Display.GetValue(_ => _.Name, varnish),
                    Value = varnish.VarnishId
                });
            }

            foreach (var rims in dbContext.Rimses) {
                viewModel.RimsOptions.Add(new SelectOption {
                    Label = Display.GetValue(_ => _.Name, rims),
                    Value = rims.RimsId
                });
            }

            return viewModel;
        }

        public ConfigurationOverviewViewModel CreateConfigurationOverviewViewModel(ConfigurationViewModel configuration) {
            var rimsLabel = Display.GetValue(_ => _.Name, _dbContext.FindRimsById(configuration.RimsValue));
            var varnishLabel = Display.GetValue(_ => _.Name, _dbContext.FindVarnishById(configuration.VarnishValue));
            var equipmentLabels = _dbContext.FindEquipmentsByIds(configuration.EquipmentValues).Select(equipment => Display.GetValue(_ => _.Name, equipment)).ToList();

            return new ConfigurationOverviewViewModel {
                Name = configuration.Name,
                Email = configuration.Email,
                Price = configuration.Price,
                EnginePower = configuration.EnginePower,
                RimsLabel = rimsLabel,
                VarnishLabel = varnishLabel,
                EquipmentLabels = equipmentLabels,
            };
        }

        public ConfigurationOverviewViewModel CreateConfigurationOverviewViewModel(Order order) {
            if (order == null) return new ConfigurationOverviewViewModel {IsValidOrder = false};

            var rimsLabel = Display.GetValue(_ => _.Name, order.Configuration.Rims);
            var varnishLabel = Display.GetValue(_ => _.Name, order.Configuration.Varnish);
            var equipmentLabels = order.Configuration.Equipments.Select(equipment => Display.GetValue(_ => _.Name, equipment)).ToList();

            return new ConfigurationOverviewViewModel {
                Name = order.Configuration.Name,
                Created = order.Created,
                Email = order.User.Email,
                Price = order.Price,
                EnginePower = order.Configuration.EnginePower ?? 0,
                RimsLabel = rimsLabel,
                VarnishLabel = varnishLabel,
                EquipmentLabels = equipmentLabels,
                IsOrdered = true,
                IsValidOrder = true
            };
        }
    }
}