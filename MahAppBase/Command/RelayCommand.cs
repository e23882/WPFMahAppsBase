using System;
using System.Windows.Input;

namespace MahAppBase.Command
{
    /// <summary>
    /// 有參數共用Command
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Declarations
        private readonly Action<object> _execute;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Memberfunction
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }
        #endregion
    }
}