using System;
using System.Windows;
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
        public RelayCommand ButtonDonateClickCommand { get; set; }
        public RelayCommand ClosedWindowCommand { get; set; }
        public RelayCommand SettingButtonClickCommand { get; set; }

        #endregion

        #region MemberFunction
        private void InitialCommand()
        {
            try
            {
                ButtonDonateClickCommand = new RelayCommand(ButtonDonateClickAction);
                ClosedWindowCommand = new RelayCommand(ClosedWindowCommandAction);
                SettingButtonClickCommand = new RelayCommand(SettingButtonClickCommandAction);
            }
            catch (Exception ex)
            {
                Common.Log($"{ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
        }

        private void SettingButtonClickCommandAction(object obj)
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
            ((App)Application.Current).ShowMessage("程式啟動", $"{DateTime.Now.ToString("HH:mm:ss")}程式啟動", NotificationType.Success);
        }

        private void ClosedWindowCommandAction(object obj)
        {
            Common.Log("App closed");
            Environment.Exit(0);
        }

        public void ButtonDonateClickAction(object parameter)
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