using NLog;

namespace MahAppBase
{
    public static class Common
    {
        #region Properties
        private static Logger Logger { get; set; } = LogManager.GetCurrentClassLogger();
        #endregion

        #region Methods
        public static void Log(string message, LogType type = LogType.Information)
        {
            switch (type)
            {
                case LogType.Error:
                    Logger.Error(message);
                    break;
                case LogType.Warning:
                    Logger.Warn(message);
                    break;
                case LogType.Information:
                    Logger.Info(message);
                    break;
            }
        }
        #endregion
    }
}
