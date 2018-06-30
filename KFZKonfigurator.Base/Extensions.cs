using System;
using System.Linq.Expressions;
using System.Reflection;

namespace KFZKonfigurator.Base
{
    public static class Extensions
    {
        public static string GetPropertyName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression) || !(memberExpression.Member is PropertyInfo propertyInfo))
                throw new ArgumentException("Expression is not a property");

            return propertyInfo.Name;
        }
    }
}