using System;
using System.Web.Mvc;

namespace KFZKonfigurator.Binding
{
    public abstract class FormElement
    {
        protected string _id;
        protected string _propertyName;
        protected string _label;

        protected MvcHtmlString CreateFormGroup(TagBuilder inputBuilder)
        {
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("form-group");

            var labelBuilder = new TagBuilder("label");
            labelBuilder.SetInnerText(_label ?? "");

            var id = _id ?? Guid.NewGuid().ToString();
            labelBuilder.MergeAttribute("for", id);
            inputBuilder.MergeAttribute("id", id);

            divBuilder.InnerHtml = labelBuilder.ToString() + inputBuilder;

            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}