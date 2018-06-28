using System;
using System.Linq.Expressions;

namespace KFZKonfigurator.Binding
{
    public class KnockoutBinder<TViewModel> : IDisposable
    {
        public OngoingBinding Bind<TProperty>(Expression<Func<TViewModel, TProperty>> property)
        {
            return new OngoingBinding();
        }

        public void Dispose()
        {
        }
    }
}