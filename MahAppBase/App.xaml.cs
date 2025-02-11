using System;
using System.Windows;
using Notifications.Wpf;

namespace MahAppBase
{
    
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        public void ShowMessage(string title, string message, NotificationType type)
        {
            var notificationManager = new NotificationManager();
            var ts = new TimeSpan(2, 40, 0) - new TimeSpan(2, 35, 0);
            notificationManager.Show(new NotificationContent
            {
                Title = title,
                Message = message,
                Type = type,
            }, "");
        }
    }
}
