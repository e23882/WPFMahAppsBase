using System;
using System.Windows;
using Autofac;
using MahAppBase.ViewModel;
using Notifications.Wpf;

namespace MahAppBase
{

    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        #region Properties
        /// <summary>
        /// 依賴注入容器
        /// </summary>
        public static IContainer Container { get; set; }
        #endregion

        #region MemberFunction
        public App() 
        {
            InitialDIContainer();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitialDIContainer() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainComponent>().SingleInstance();
            builder.RegisterType<DemoWindowViewModel>().SingleInstance();
            Container = builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
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
        #endregion
    }
}
