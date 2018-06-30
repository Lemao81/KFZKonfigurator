using System.Web.Mvc;

namespace KFZKonfigurator.Binding
{
    public abstract class AbstractKnockoutBinderView<TViewModel> : WebViewPage<TViewModel>
    {
        public KnockoutBinder<TViewModel> NewKnockoutBinder(TViewModel viewModel)
        {
            return new KnockoutBinder<TViewModel>(Url.Action("Update", "Crud"), Html, viewModel);
        }
    }
}