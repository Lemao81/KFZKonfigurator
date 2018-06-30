using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace KFZKonfigurator.Base.Logging
{
    public class LoggingInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (!type.IsDefined(typeof(LogAttribute))) return interceptors;

            var list = interceptors.ToList();
            list.Add(new LoggingInterceptor());
            return list.ToArray();

        }
    }
}