using System;
using System.Linq.Expressions;
using System.Threading;

namespace KFZKonfigurator.Base
{
    public class Display
    {
        public static string GetValue<TModel, TProperty>(Expression<Func<TModel, TProperty>> property, TModel model) {
            return model != null ? property.GetDisplay(model) : string.Empty;
        }

        public static string GetCurrencySymbol() {
            return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLowerInvariant() == "de" ? "€" : "£";
        }
    }
}