namespace KFZKonfigurator.Binding.Elements
{
    public abstract class AbstractSelectElement : AbstractFormElement
    {
        protected string _optionsPropertyName;

        protected AbstractSelectElement(string id, string propertyName, string optionsPropertyName) : base(id, propertyName) {
            _optionsPropertyName = optionsPropertyName;
        }
    }
}