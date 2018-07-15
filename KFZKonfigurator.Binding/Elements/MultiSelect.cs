using System.Collections.Generic;
using System.Web.Mvc;
using KFZKonfigurator.Binding.Models;

namespace KFZKonfigurator.Binding.Elements
{
    public class MultiSelect : AbstractSelectElement
    {
        private int _size = 3;

        public MultiSelect(string id, string propertyName, string optionsPropertyName) : base(id, propertyName, optionsPropertyName) { }

        public MultiSelect Label(string label) {
            _label = label;
            return this;
        }

        public MultiSelect Size(int size) {
            _size = size;
            return this;
        }

        protected override TagBuilder CreateElementBuilder() {
            var selectBuilder = new TagBuilder("select");
            selectBuilder.AddCssClass("form-control");

            var attributes = new Dictionary<string, string> {
                {
                    "data-bind",
                    $"options: {_optionsPropertyName}, optionsText: '{nameof(SelectOption.Label)}', optionsValue: '{nameof(SelectOption.Value)}', selectedOptions: {_propertyName}"
                },
                {"size", _size.ToString()},
                {"multiple", "true"}
            };

            if (_id != null) attributes.Add("id", _id);

            selectBuilder.MergeAttributes(attributes);
            return selectBuilder;
        }
    }
}