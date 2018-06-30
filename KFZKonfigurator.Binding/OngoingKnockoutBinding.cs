using System.Web.Mvc;

namespace KFZKonfigurator.Binding
{
    public class OngoingKnockoutBinding
    {
        private readonly string _propertyName;

        public OngoingKnockoutBinding(string propertyName)
        {
            _propertyName = propertyName;
        }

        public MvcHtmlString ToDropdown()
        {
            return MvcHtmlString.Create("");
        }

        public MvcHtmlString ToNumericTextbox()
        {
            return MvcHtmlString.Create("");
        }

        public Textbox ToTextbox(string id = null)
        {
            return new Textbox(id, _propertyName);
        }
    }
}