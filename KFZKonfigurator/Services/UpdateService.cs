using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KFZKonfigurator.Base;
using KFZKonfigurator.BusinessModels;
using KFZKonfigurator.Controllers;
using KFZKonfigurator.Models;
using KFZKonfigurator.Utils;

namespace KFZKonfigurator.Services
{
    public class UpdateService
    {
        private readonly PriceCalculationService _priceCalculationService;
        private readonly KonfiguratorDbContext _dbContext;

        public UpdateService(PriceCalculationService priceCalculationService, KonfiguratorDbContext dbContext) {
            _dbContext = dbContext;
            _priceCalculationService = priceCalculationService;
        }

        public void Update(ConfigurationViewModel configuration, string propertyName, object newValue) {
            var valueArray = (Array) newValue;

            switch (propertyName) {
                case nameof(ConfigurationViewModel.EquipmentValues):
                    configuration.EquipmentValues = ((IEnumerable<string>) valueArray).Select(_ => int.Parse(_)).ToList();
                    break;
                default:
                    var propertyInfo = configuration?.GetType().GetProperty(propertyName);
                    if (configuration == null || propertyInfo == null) throw new ArgumentException("Current configuration and updated property must not be null");

                    typeof(UpdateService).CallGeneric(nameof(UpdateGeneric), new[] {configuration.GetType(), propertyInfo.PropertyType},
                        new[] {configuration, propertyInfo.AsLambdaExpression(), valueArray.GetValue(0)});
                    break;
            }

            configuration.Price = _priceCalculationService.CalculatePrice(configuration);
        }

        private static void UpdateGeneric<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> property, object newValue) {
            if (typeof(IEnumerable).IsAssignableFrom(typeof(TProperty)) && typeof(TProperty) != typeof(string))
                typeof(ConfigurationController).CallGeneric(nameof(UpdateEnumerable),
                    new[] {typeof(TModel), typeof(TProperty), typeof(TProperty).GenericTypeArguments[0]}, new[] {model, property, newValue});
            else
                property.GetPropertyInfo().SetValue(model, ConvertValue<TProperty>(newValue));
        }

        private static void UpdateEnumerable<TModel, TProperty, TGeneric>(TModel model, Expression<Func<TModel, TProperty>> property,
            IEnumerable<string> newValue) {
            var result = newValue.Select(ConvertValue<TGeneric>).ToList();
            property.GetPropertyInfo().SetValue(model, result);
        }

        private static TResult ConvertValue<TResult>(object newValue) {
            if (newValue == null) return default(TResult);
            if (typeof(TResult).IsEnumOrNullableEnum())
                return (TResult) Enum.ToObject(typeof(TResult).ToNonNullable(), int.Parse(newValue.ToString()));
            return (TResult) Convert.ChangeType(newValue, typeof(TResult).ToNonNullable());
        }
    }
}