using System;
using MahAppBase.Command;

namespace MahAppBase.ViewModel
{
    public class MainComponent:ViewModelBase
    {
        #region Declarations
        private bool _DonateIsOpen = false;
        #endregion

        #region Property
        /// <summary>
        /// Donate Button Click Command
        /// </summary>
        public RelayCommand ButtonDonateClickCommand { get; set; }
        
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
        #endregion

        #region MemberFunction
        /// <summary>
        /// Constructor
        /// </summary>
        public MainComponent()
        {
            InitialCommand();
        }

        private void InitialCommand()
        {
            try
            {
                ButtonDonateClickCommand = new RelayCommand(ButtonDonateClickAction);
            }
            catch (Exception ex)
            {
                Common.Log($"{ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
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