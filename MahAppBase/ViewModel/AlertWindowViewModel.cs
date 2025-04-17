using System.Windows;
using System.Windows.Input;
using MahAppBase.Command;

namespace MahAppBase
{
    public class AlertWindowViewModel:ViewModelBase
    {
        #region Declarations
        private string _AlertMessage;
        #endregion

        #region Properties
        public ICommand GotItCommand { get; set; }

        public Window CurrentInstance { get; set; }

        /// <summary>
        /// 收到的求救訊息
        /// </summary>
        public string AlertMessage
        {
            get
            {
                return _AlertMessage;
            }
            set
            {
                _AlertMessage = value;
                Common.Log($"設定訊息: {value}");
                OnPropertyChanged();
            }
        }
        #endregion

        #region Public Methods
        public AlertWindowViewModel(string message) 
        {
            GotItCommand = new RelayCommand(GotItAction);
            AlertMessage = message;
        }

        private void GotItAction(object obj)
        {
            CurrentInstance.Close();
        }
        #endregion
    }
}
