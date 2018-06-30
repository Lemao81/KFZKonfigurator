using Castle.Windsor;

namespace KFZKonfigurator
{
    public class DependencyInjection
    {
        public static void Setup()
        {
            var container = new WindsorContainer();
        }
    }
}