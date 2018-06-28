using System.Collections.Generic;
using System.Web.Mvc;
using KFZKonfigurator.Binding.Enum;
using KFZKonfigurator.Binding.Utils;

namespace KFZKonfigurator.Binding
{
    public class Textbox : FormElement
    {
        private string _placeholder;
        private TextboxType _type = TextboxType.Text;

        public Textbox(string id)
        {
            _id = id;
        }

        public Textbox Placeholder(string placeholder)
        {
            _placeholder = placeholder;
            return this;
        }

        public Textbox Type(TextboxType type)
        {
            _type = type;
            return this;
        }

        public Textbox Label(string label)
        {
            _label = label;
            return this;
        }

        public MvcHtmlString Build()
        {
            return _label != null ? CreateFormGroup(CreateInputBuilder()) : MvcHtmlString.Create(CreateInputBuilder().ToString());
        }

        private TagBuilder CreateInputBuilder()
        {
            var inputBuilder = new TagBuilder("input");
            inputBuilder.AddCssClass("form-control");
            inputBuilder.MergeAttribute("type", _type.MapToText());

            if (_id != null) inputBuilder.MergeAttribute("id", _id);
            if (_placeholder != null) inputBuilder.MergeAttribute("placeholder", _placeholder);

            return inputBuilder;
        }
    }
}