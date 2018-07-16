using System.Web.Http;

namespace KFZKonfigurator.Controllers
{
    public class WebApiController : ApiController
    {
        public string Get(int id) {
            return "Hello World";
        }
    }
}