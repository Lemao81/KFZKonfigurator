using log4net;

namespace KFZKonfigurator.Base.Logging
{
    public class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger("DefaultLogger");

        public static void Info(object toLog)
        {
            Log.Info(toLog.ToString());
        }

        public static void Debug(object toLog)
        {
            Log.Debug(toLog.ToString());
        }

        public static void Error(object toLog)
        {
            Log.Error(toLog.ToString());
        }
    }
}