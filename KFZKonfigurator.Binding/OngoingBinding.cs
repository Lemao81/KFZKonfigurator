using System.Web.Mvc;

namespace KFZKonfigurator.Binding
{
    public class OngoingBinding
    {
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
            return new Textbox(id);
        }
    }
}