using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace KFZKonfigurator.Base
{
    public static class Extensions
    {
        public static Dictionary<Type, ResourceManager> ResourceManagerCache = new Dictionary<Type, ResourceManager>();

        public static string GetPropertyName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression) || !(memberExpression.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("Expression is not a property");

            return propertyInfo.Name;
        }

        public static Type GetPropertyType<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression) || !(memberExpression.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("Expression is not a property");

            return propertyInfo.PropertyType;
        }

        public static string GetDisplay(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType().GetMember(enumValue.ToString())[0].GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute == null)
                return string.Empty;

            if (!ResourceManagerCache.ContainsKey(displayAttribute.ResourceType))
                ResourceManagerCache[displayAttribute.ResourceType] = new ResourceManager(displayAttribute.ResourceType);

            var resourceKey = displayAttribute.Name ?? $"{enumValue.GetType().Name}_{enumValue}";
            return ResourceManagerCache[displayAttribute.ResourceType].GetString(resourceKey, Thread.CurrentThread.CurrentUICulture);
        }
    }
}