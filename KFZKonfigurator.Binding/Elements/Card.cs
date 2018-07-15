using System.Web.Mvc;

namespace KFZKonfigurator.Binding.Elements
{
    public class Card
    {
        private readonly string _id;
        private readonly string _propertyName;
        private string _label;
        private string _actionUrl;
        private string _buttonId;
        private string _buttonCaption;

        public Card(string id, string propertyName) {
            _id = id;
            _propertyName = propertyName;
        }

        public Card Label(string label) {
            _label = label;
            return this;
        }

        public Card Button(string id, string actionUrl, string caption) {
            _actionUrl = actionUrl;
            _buttonId = id;
            _buttonCaption = caption;
            return this;
        }

        public MvcHtmlString Build() {
            return MvcHtmlString.Create(CreateElementBuilder().ToString());
        }

        private TagBuilder CreateElementBuilder() {
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("card");
            if (_id != null) divBuilder.MergeAttribute("id", _id);

            var bodyDivBuilder = new TagBuilder("div");
            bodyDivBuilder.AddCssClass("card-body");

            var titleBuilder = new TagBuilder("h5");
            titleBuilder.AddCssClass("card-title");
            titleBuilder.SetInnerText(_label ?? string.Empty);

            var textBuilder = new TagBuilder("p");
            textBuilder.AddCssClass("card-text");
            textBuilder.MergeAttribute("data-bind", $"text: {_propertyName}");

            bodyDivBuilder.InnerHtml = titleBuilder.ToString() + textBuilder;

            if (_actionUrl != null) {
                var buttonBuilder = new TagBuilder("a");
                buttonBuilder.AddCssClass("btn btn-primary");
                buttonBuilder.MergeAttribute("id", _buttonId);
                buttonBuilder.MergeAttribute("data-url", _actionUrl);
                buttonBuilder.MergeAttribute("href", "#");
                buttonBuilder.SetInnerText(_buttonCaption);

                bodyDivBuilder.InnerHtml = bodyDivBuilder.InnerHtml + buttonBuilder;
            }

            divBuilder.InnerHtml = bodyDivBuilder.ToString();
            return divBuilder;
        }
    }
}