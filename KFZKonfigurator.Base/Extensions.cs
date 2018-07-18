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

        public static string GetPropertyName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression) {
            if (!(expression.Body is MemberExpression memberExpression) || !(memberExpression.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("Expression is not a property");

            return propertyInfo.Name;
        }

        public static Type GetPropertyType<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression) {
            if (!(expression.Body is MemberExpression memberExpression) || !(memberExpression.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("Expression is not a property");

            return propertyInfo.PropertyType;
        }

        public static PropertyInfo GetPropertyInfo<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression) {
            if (!(expression.Body is MemberExpression memberExpression) || !(memberExpression.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("Expression is not a property");

            return propertyInfo;
        }

        public static string GetDisplay<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression, TModel model) {
            return GetDisplayInternal(expression.GetPropertyInfo(), attribute => expression.GetPropertyInfo().GetValue(model).ToString());
        }

        public static string GetDisplay(this System.Enum enumValue) {
            return GetDisplayInternal(enumValue.GetType().GetMember(enumValue.ToString())[0], attribute => attribute.Name ?? $"{enumValue.GetType().Name}_{enumValue}");
        }

        public static string GetDisplay<TModel, TProperty>(Expression<Func<TModel, TProperty>> property) {
            return GetDisplayInternal(property.GetPropertyInfo(), attribute => attribute.Name);
        }

        private static string GetDisplayInternal(MemberInfo memberInfo, Func<DisplayAttribute, string> resourceKeyFunc) {
            var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute == null)
                return null;

            if (!ResourceManagerCache.ContainsKey(displayAttribute.ResourceType))
                ResourceManagerCache[displayAttribute.ResourceType] = new ResourceManager(displayAttribute.ResourceType);

            var resourceKey = resourceKeyFunc.Invoke(displayAttribute);
            return ResourceManagerCache[displayAttribute.ResourceType].GetString(resourceKey, Thread.CurrentThread.CurrentUICulture);
        }

        public static object CallGeneric(this Type declaringType, string methodName, Type[] genericTypes, object[] parameters, object instance = null) {
            var bindingFlags = instance == null ? BindingFlags.Static : BindingFlags.Instance;
            bindingFlags = bindingFlags | BindingFlags.Public | BindingFlags.NonPublic;

            var method = declaringType.GetMethod(methodName, bindingFlags);
            if (method == null) throw new ArgumentException($"Distinct method {methodName} at type {declaringType.Name} does not exist");

            var genericMethod = method.MakeGenericMethod(genericTypes);
            return genericMethod.Invoke(instance, parameters);
        }

        public static LambdaExpression AsLambdaExpression(this PropertyInfo propertyInfo) {
            var parameterExpression =
                Expression.Parameter(propertyInfo.ReflectedType ?? throw new InvalidOperationException("Reflected type must not be null"));
            var propertyExpression = Expression.Property(parameterExpression, propertyInfo);

            return Expression.Lambda(typeof(Func<,>).MakeGenericType(propertyInfo.ReflectedType, propertyInfo.PropertyType), propertyExpression,
                parameterExpression);
        }

        public static bool IsNullable(this Type type) {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type ToNonNullable(this Type type) {
            return type.IsNullable() ? Nullable.GetUnderlyingType(type) : type;
        }

        public static bool IsEnumOrNullableEnum(this Type type) {
            return type.IsEnum || Nullable.GetUnderlyingType(type) != null && Nullable.GetUnderlyingType(type).IsEnum;
        }

        public static decimal ToDecimal(this double value) {
            return (decimal) value;
        }

        public static string GetPriceLabel(this decimal? price) {
            return $"{price:C}";
        }
    }
}