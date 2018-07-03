using KFZKonfigurator.Binding.Elements;

namespace KFZKonfigurator.Binding
{
    public class OngoingKnockoutBinding
    {
        private readonly string _propertyName;
        private readonly string _optionsPropertyName;

        public OngoingKnockoutBinding(string propertyName, string optionsPropertyName = null)
        {
            _propertyName = propertyName;
            _optionsPropertyName = optionsPropertyName;
        }

        public Dropdown ToDropdown(string id = null)
        {
            return new Dropdown(id, _propertyName, _optionsPropertyName);
        }

        public Textbox ToTextbox(string id = null)
        {
            return new Textbox(id, _propertyName);
        }

        public Card ToCard(string id = null)
        {
            return new Card(id, _propertyName);
        }
    }
}