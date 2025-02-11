using System;
using System.Windows.Input;
using MahAppBase.Command;
using Notifications.Wpf;

namespace MahAppBase.ViewModel
{
    public class MainComponent:ViewModelBase
    {
        #region Declarations
        private bool _DonateIsOpen = false;
        private bool _SettingIsOpen = false;
        #endregion

        #region Property
        /// <summary>
        /// 
        /// </summary>
        public bool DonateIsOpen
        {
            get
            {
                return _DonateIsOpen;
            }
            set
            {
                _DonateIsOpen = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool SettingIsOpen
        {
            get
            {
                return _SettingIsOpen;
            }
            set
            {
                _SettingIsOpen = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Donate Button Click Command
        /// </summary>
        public ICommand ButtonDonateClickCommand { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICommand ClosedWindowCommand { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICommand SettingButtonClickCommand { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICommand TestButtonClickCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand TestInvokeExceptionCommand { get; set; }
        #endregion

        #region MemberFunction
        /// <summary>
        /// 
        /// </summary>
        public virtual void InitialCommand()
        {
            try
            {
                ButtonDonateClickCommand = new RelayCommand(ButtonDonateClickAction);
                ClosedWindowCommand = new RelayCommand(ClosedWindowCommandAction);
                SettingButtonClickCommand = new RelayCommand(SettingButtonClickCommandAction);
                TestButtonClickCommand = new RelayCommand(TestButtonClickCommandAction);
                TestInvokeExceptionCommand = new RelayCommand(TestInvokeExceptionCommandAction);
            }
            catch (Exception ex)
            {
                Common.Log($"{ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
        }

        [HandleException]
        public virtual void TestInvokeExceptionCommandAction(object obj)
        {
            throw new NotImplementedException("故意放在這的例外，程式會自己handle不會crash");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public virtual void TestButtonClickCommandAction(object obj)
        {
            DemoWindow win = new DemoWindow();
            win.Show();
            TestInterceptorWorking();
        }

        [HandleException]
        public virtual void TestInterceptorWorking()
        {
            Console.WriteLine("123");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public virtual void SettingButtonClickCommandAction(object obj)
        {
            SettingIsOpen = !SettingIsOpen;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainComponent()
        {
            Common.Log("App running..");
            InitialCommand();
            Common.Notify($"{DateTime.Now.ToString("HH:mm:ss")}程式啟動", "程式啟動", NotificationType.Success);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        private void ButtonDonateClickAction(object parameter)
        {
            try
            {
                DonateIsOpen = !DonateIsOpen;
            }
            catch (Exception ex)
            {
                Common.Log($"{ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
        }
        #endregion
    }
}