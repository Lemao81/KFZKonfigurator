﻿using System.Collections.Generic;
using System.Web.Mvc;
using KFZKonfigurator.Binding.Enum;
using KFZKonfigurator.Binding.Utils;

namespace KFZKonfigurator.Binding {
    public class Textbox : AbstractFormElement {
        private TextboxType _type = TextboxType.Text;
        private int? _minValue;
        private int? _maxValue;

        public Textbox(string id, string propertyName) : base(id, propertyName) { }

        public Textbox Placeholder(string placeholder) {
            _placeholder = placeholder;
            return this;
        }

        public Textbox Type(TextboxType type) {
            _type = type;
            return this;
        }

        public Textbox Label(string label) {
            _label = label;
            return this;
        }

        public Textbox MinValue(int minValue) {
            _minValue = minValue;
            return this;
        }

        public Textbox MaxValue(int maxValue) {
            _maxValue = maxValue;
            return this;
        }

        public Textbox Required {
            get {
                _required = true;
                return this;
            }
        }

        protected override TagBuilder CreateElementBuilder() {
            var inputBuilder = new TagBuilder("input");
            inputBuilder.AddCssClass("form-control");

            var attributes = new Dictionary<string, string> {
                {"type", _type.MapToText()},
                {"data-bind", $"textInput: {_propertyName}, event: {{ blur: function() {{ onFocusLost('{_propertyName}'); }} }}"}
            };

            if (_id != null) attributes.Add("id", _id);
            if (_placeholder != null) attributes.Add("placeholder", _placeholder);
            if (_type == TextboxType.NumericInteger) attributes.Add("pattern", "\\d+");
            if (_minValue != null && (_type == TextboxType.NumericInteger || _type == TextboxType.NumericDecimal)) attributes.Add("min", _minValue.ToString());
            if (_maxValue != null && (_type == TextboxType.NumericInteger || _type == TextboxType.NumericDecimal)) attributes.Add("max", _maxValue.ToString());
            if (_required) attributes.Add("required", "required");

            inputBuilder.MergeAttributes(attributes);
            return inputBuilder;
        }
    }
}