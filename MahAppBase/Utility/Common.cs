using NLog;
using Notifications.Wpf;

namespace MahAppBase
{
    public static class Common
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        private static Logger Logger { get; set; } = LogManager.GetCurrentClassLogger();
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void Notify(string message, string title = "Notify", NotificationType type = NotificationType.Information)
        {
            var notificationManager = new NotificationManager();
            notificationManager.Show(new NotificationContent { Title = title, Message = message, Type = type, }, "");
        }
        #endregion
    }
}
