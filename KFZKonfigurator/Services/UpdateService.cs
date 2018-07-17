using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KFZKonfigurator.Base;
using KFZKonfigurator.Base.Logging;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Services
{
    [Log]
    public class UpdateService
    {
        public void Update(ConfigurationViewModel configuration, string propertyName, object newValue) {
            switch (propertyName) {
                case nameof(ConfigurationViewModel.EquipmentValues):
                    if (newValue is IEnumerable<string> array)
                        configuration.EquipmentValues = array.Select(int.Parse).ToList();
                    else
                        configuration.EquipmentValues.Clear();
                    break;
                default:
                    var propertyInfo = configuration?.GetType().GetProperty(propertyName);
                    if (configuration == null || propertyInfo == null) throw new ArgumentException("Current configuration and updated property must not be null");

                    typeof(UpdateService).CallGeneric(nameof(UpdateGeneric), new[] {configuration.GetType(), propertyInfo.PropertyType},
                        new[] {configuration, propertyInfo.AsLambdaExpression(), ((Array) newValue)?.GetValue(0)});
                    break;
            }
        }

        private static void UpdateGeneric<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> property, object newValue) {
            property.GetPropertyInfo().SetValue(model, ConvertValue<TProperty>(newValue));
        }

        private static TResult ConvertValue<TResult>(object newValue) {
            if (newValue == null) return default(TResult);

            if (typeof(TResult).IsEnumOrNullableEnum())
                return (TResult) Enum.ToObject(typeof(TResult).ToNonNullable(), int.Parse(newValue.ToString()));

            return (TResult) Convert.ChangeType(newValue, typeof(TResult).ToNonNullable());
        }
    }
}