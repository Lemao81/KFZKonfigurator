using System;
using System.Linq.Expressions;
using KFZKonfigurator.Base;
using KFZKonfigurator.Base.Interface;
using KFZKonfigurator.Models;

namespace KFZKonfigurator.Services
{
    public class ConfigurationRenderer : IRenderer<ConfigurationViewModel>
    {
        public string Render<TProperty>(Expression<Func<ConfigurationViewModel, TProperty>> property, ConfigurationViewModel model) {
            var value = (TProperty) property.GetPropertyInfo().GetValue(model);
            return string.Empty;
//            return value.GetDisplay();
        }
    }
}