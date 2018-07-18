using System;
using System.Web.Mvc;

namespace KFZKonfigurator.Binding
{
    public abstract class AbstractFormElement
    {
        protected string _id;
        protected string _propertyName;
        protected string _label;
        protected string _placeholder;
        protected bool _required;

        protected AbstractFormElement(string id, string propertyName) {
            _id = id;
            _propertyName = propertyName;
        }

        public MvcHtmlString Build() {
            return _label != null ? CreateFormGroup(CreateElementBuilder()) : MvcHtmlString.Create(CreateElementBuilder().ToString());
        }

        private MvcHtmlString CreateFormGroup(TagBuilder elementBuilder) {
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("form-group");

            var labelBuilder = new TagBuilder("label");
            labelBuilder.SetInnerText(_label ?? "");

            var id = _id ?? Guid.NewGuid().ToString();
            labelBuilder.MergeAttribute("for", id);
            elementBuilder.MergeAttribute("id", id);

            divBuilder.InnerHtml = labelBuilder.ToString() + elementBuilder;

            return MvcHtmlString.Create(divBuilder.ToString());
        }

        protected abstract TagBuilder CreateElementBuilder();
    }
}