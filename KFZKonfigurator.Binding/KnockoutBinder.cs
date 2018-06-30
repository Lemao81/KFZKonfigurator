using System;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using KFZKonfigurator.Base;
using KFZKonfigurator.Base.Logging;

namespace KFZKonfigurator.Binding
{
    public class KnockoutBinder<TViewModel> : IDisposable
    {
        private readonly HtmlHelper _htmlHelper;
        private readonly TViewModel _viewModel;
        private readonly Guid _id = Guid.NewGuid();
        private readonly JavaScriptSerializer _javaScriptSerializer = new JavaScriptSerializer();
        private readonly string _updateUrl;

        public KnockoutBinder(string updateUrl, HtmlHelper htmlHelper, TViewModel viewModel)
        {
            _htmlHelper = htmlHelper;
            _viewModel = viewModel;
            _updateUrl = updateUrl;

            SetStartingJavascript(htmlHelper.ViewContext.Writer);
        }

        public OngoingKnockoutBinding Bind<TProperty>(Expression<Func<TViewModel, TProperty>> property)
        {
            return new OngoingKnockoutBinding(property.GetPropertyName());
        }

        public void Dispose()
        {
            SetClosingJavascript(_htmlHelper.ViewContext.Writer);
        }

        private void SetStartingJavascript(TextWriter writer)
        {
            writer.WriteLine($"<div id='{_id}'>");
        }

        private void SetClosingJavascript(TextWriter writer)
        {
            var viewModelSerialized = _javaScriptSerializer.Serialize(_viewModel);
            Logger.Info(viewModelSerialized);

            writer.WriteLine("</div>");
            writer.WriteLine("<script>");
            writer.WriteLine($"var viewModel = $.binding.createKoViewModel({viewModelSerialized}, '{_updateUrl}');");
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine($"ko.applyBindings(viewModel, $('#{_id}')[0]);");
            writer.WriteLine("</script>");
        }
    }
}