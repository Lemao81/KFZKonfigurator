using System.Collections.Generic;
using System.Web.Mvc;
using KFZKonfigurator.Binding.Models;

namespace KFZKonfigurator.Binding.Elements
{
    public class Dropdown : AbstractSelectElement
    {
        public Dropdown(string id, string propertyName, string optionsPropertyName) : base(id, propertyName, optionsPropertyName) { }

        public Dropdown Placeholder(string placeholder) {
            _placeholder = placeholder;
            return this;
        }

        public Dropdown Label(string label) {
            _label = label;
            return this;
        }

        protected override TagBuilder CreateElementBuilder() {
            var selectBuilder = new TagBuilder("select");
            selectBuilder.AddCssClass("form-control");

            var optionsCaption = _placeholder != null ? $", optionsCaption: '{_placeholder}'" : string.Empty;
            var attributes = new Dictionary<string, string> {
                {
                    "data-bind", $"options: {_optionsPropertyName}, optionsText: '{nameof(SelectOption.Label)}', " +
                                 $"optionsValue: '{nameof(SelectOption.Value)}', value: {_propertyName}{optionsCaption}"
                }
            };

            if (_id != null) attributes.Add("id", _id);

            selectBuilder.MergeAttributes(attributes);
            return selectBuilder;
        }
    }
}