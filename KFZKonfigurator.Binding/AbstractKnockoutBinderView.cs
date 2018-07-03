using System.Web.Mvc;

namespace KFZKonfigurator.Binding
{
    public abstract class AbstractKnockoutBinderView<TViewModel> : WebViewPage<TViewModel>
    {
        public KnockoutBinder<TViewModel> NewKnockoutBinder(TViewModel viewModel, string updateUrl)
        {
            return new KnockoutBinder<TViewModel>(Html, viewModel, updateUrl);
        }
    }
}