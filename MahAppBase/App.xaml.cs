using System;
using System.Windows;
using Autofac;
using Autofac.Extras.DynamicProxy;
using MahAppBase.Utility;
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
            builder.RegisterType<TryCatchInterceptor>();
            builder.RegisterType<MainComponent>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(TryCatchInterceptor))
                .SingleInstance();
            builder.RegisterType<DemoWindowViewModel>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(TryCatchInterceptor))
                .SingleInstance();
            
            Container = builder.Build();
        }
        #endregion
    }
}
