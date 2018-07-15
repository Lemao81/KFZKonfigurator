using System;
using System.Linq.Expressions;
using KFZKonfigurator.Base;
using KFZKonfigurator.Base.Interface;
using KFZKonfigurator.Binding;

namespace KFZKonfigurator.Utils
{
    public abstract class AbstractRenderedView<TViewModel, TRenderer> : AbstractKnockoutBinderView<TViewModel> where TRenderer : IRenderer<TViewModel>
    {
        private TRenderer _renderer;

        protected AbstractRenderedView() {
            _renderer = Activator.CreateInstance<TRenderer>();
        }

        public string Render<TProperty>(Expression<Func<TViewModel, TProperty>> property) {
            return _renderer.Render(property, Model);
        }
    }
}