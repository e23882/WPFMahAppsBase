using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using MahAppBase.Command;
using MahAppBase.View;
using Notifications.Wpf;
using StackExchange.Redis;

namespace MahAppBase.ViewModel
{
    public class MainComponent : ViewModelBase
    {
        #region Declarations
        private string _FormalEnvironmentMessage;
        private string _SITEnvironmentMessage;

        private double _WindowOpacity = 100;
        #endregion

        #region Property
        public TextBox UATTextBoxInstance { get; set; }
        public TextBox SITTextBoxInstance { get; set; }
        /// <summary>
        /// 視窗透明度
        /// </summary>
        public double WindowOpacity
        {
            get
            {
                return _WindowOpacity;
            }
            set
            {
                _WindowOpacity = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 測試環境收到的求救訊息
        /// </summary>
        public string SITEnvironmentMessage
        {
            get
            {
                return _SITEnvironmentMessage;
            }
            set
            {
                _SITEnvironmentMessage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 正式環境收到的求救訊息
        /// </summary>
        public string FormalEnvironmentMessage
        {
            get
            {
                return _FormalEnvironmentMessage;
            }
            set
            {
                _FormalEnvironmentMessage = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand SendSOSCommand { get; set; }


        #endregion

        #region MemberFunction
        /// <summary>
        /// 
        /// </summary>
        public virtual void InitialCommand()
        {
            try
            {
                ClosedWindowCommand = new RelayCommand(ClosedWindowCommandAction);
                SendSOSCommand = new RelayCommand(SendSOSCommandAction);
            }
            catch (Exception ex)
            {
                Common.Log($"{ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
        }

        private void SendSOSCommandAction(object obj)
        {
            string ip = ConfigurationManager.AppSettings["UATRedisIP"];
            string port = ConfigurationManager.AppSettings["UATRedisPort"];
            string password = ConfigurationManager.AppSettings["UATRedisPassword"];
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect($"{ip}:{port},password={password}");
            redis.GetSubscriber().Publish("SOS1", "Test sos");
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainComponent(TextBox instanceUAT, TextBox instanceSIT)
        {
            Common.Log("App running..");
            InitialCommand();
            this.UATTextBoxInstance = instanceUAT;
            this.SITTextBoxInstance = instanceSIT;
            Common.Notify($"{DateTime.Now.ToString("HH:mm:ss")}程式啟動", "程式啟動", NotificationType.Success);
            InitialFormalEnvironmentConnection();
            InitialUATEnvironmentConnection();
        }

        private void InitialFormalEnvironmentConnection()
        {
            try
            {
                string ip = ConfigurationManager.AppSettings["SITRedisIP"];
                string port = ConfigurationManager.AppSettings["SITRedisPort"];
                string password = ConfigurationManager.AppSettings["SITRedisPassword"];
                ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect($"{ip}:{port},password={password}");
                ISubscriber Subscriber = Redis.GetSubscriber();
                // 訂閱頻道
                Subscriber.Subscribe("EmergencyCall", (channel, message) =>
                {
                    HandleSITRedisMessage(channel.ToString(), message);
                });
                Subscriber.Subscribe("SOS", (channel, message) =>
                {
                    HandleSITRedisMessage(channel.ToString(), message);
                });
            }
            catch (Exception ex)
            {
                Common.Notify($"初始化正式環境Redis連線發生錯誤: {ex.Message}\r\n");
                Common.Log($"初始化正式環境Redis連線發生錯誤: {ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void HandleSITRedisMessage(string channel, RedisValue message)
        {
            FormalEnvironmentMessage += $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}[正式環境{channel}] {message}\r\n";
            Common.Notify(message, channel, NotificationType.Error);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(
                () =>
                {
                    SITTextBoxInstance.ScrollToEnd();
                    AlertWindow alertWindow = new AlertWindow($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}[正式環境{channel}] {message}\r\n");
                    alertWindow.Show();
                }));
        }

        private void InitialUATEnvironmentConnection()
        {
            try
            {
                string ip = ConfigurationManager.AppSettings["UATRedisIP"];
                string port = ConfigurationManager.AppSettings["UATRedisPort"];
                string password = ConfigurationManager.AppSettings["UATRedisPassword"];
                ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect($"{ip}:{port},password={password}");
                ISubscriber Subscriber = Redis.GetSubscriber();
                // 訂閱頻道
                Subscriber.Subscribe("EmergencyCall", (channel, message) =>
                {
                    HandleUATRedisMessage(channel.ToString(), message);
                });
                Subscriber.Subscribe("SOS", (channel, message) =>
                {
                    HandleUATRedisMessage(channel.ToString(), message);
                });

                Subscriber.Subscribe("SOS1", (channel, message) =>
                {
                    HandleUATRedisMessage(channel.ToString(), message);
                });
            }
            catch (Exception ex)
            {
                Common.Notify($"初始化正式環境Redis連線發生錯誤: {ex.Message}\r\n");
                Common.Log($"初始化正式環境Redis連線發生錯誤: {ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void HandleUATRedisMessage(string channel, RedisValue message)
        {
            SITEnvironmentMessage += $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}[測試環境{channel}] {message}\r\n";
            Common.Notify(message, channel, NotificationType.Error);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(
                () => 
                {
                    UATTextBoxInstance.ScrollToEnd();
                    AlertWindow alertWindow = new AlertWindow($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}[測試環境{channel}] {message}\r\n");
                    alertWindow.Show();
                }));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void ClosedWindowCommandAction(object obj)
        {
            Common.Log("App closed");
            Environment.Exit(0);
        }

        #endregion
    }
}