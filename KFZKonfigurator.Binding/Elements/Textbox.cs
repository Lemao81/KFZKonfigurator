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

        public Textbox(string id, string propertyName)
        {
            _id = id;
            _propertyName = propertyName;
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

            var attributes = new Dictionary<string, string>
            {
                {"type", _type.MapToText()},
                {"data-bind", $"textInput: {_propertyName}"}
            };

            if (_id != null) attributes.Add("id", _id);
            if (_placeholder != null) attributes.Add("placeholder", _placeholder);

            inputBuilder.MergeAttributes(attributes);
            return inputBuilder;
        }
    }
}