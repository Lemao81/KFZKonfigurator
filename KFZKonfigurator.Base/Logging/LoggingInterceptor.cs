using System;
using Castle.DynamicProxy;
using log4net;

namespace KFZKonfigurator.Base.Logging
{
    public class LoggingInterceptor : IInterceptor
    {
        private ILog _logger;

        public void Intercept(IInvocation invocation)
        {
            if (_logger == null)
                _logger = LogManager.GetLogger(invocation.Method.DeclaringType?.FullName ?? "Logger");

            _logger.Info(GetMethodInfo(invocation));

            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                _logger.Error(GetMethodInfo(invocation), e);
                throw e;
            }
        }

        private static string GetMethodInfo(IInvocation invocation)
        {
            return $"{invocation.Method.Name}({string.Join(", ", invocation.Arguments)})";
        }
    }
}