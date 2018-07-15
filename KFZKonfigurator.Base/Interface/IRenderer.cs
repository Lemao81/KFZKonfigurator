using System;
using System.Linq.Expressions;

namespace KFZKonfigurator.Base.Interface
{
    public interface IRenderer<TModel>
    {
        string Render<TProperty>(Expression<Func<TModel, TProperty>> property, TModel model);
    }
}