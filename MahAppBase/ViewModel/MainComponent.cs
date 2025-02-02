using System;
using MahAppBase.Command;
using MahAppBase.CustomerUserControl;

namespace MahAppBase.ViewModel
{
    public class MainComponent
    {
        #region Declarations
        ucDonate donate = new ucDonate();
        #endregion

        #region Property
        /// <summary>
        /// Donate Button Click Command
        /// </summary>
        public RelayCommand ButtonDonateClick { get; set; }
        public bool DonateIsOpen { get; set; }
        #endregion

        #region MemberFunction
        /// <summary>
        /// Constructor
        /// </summary>
        public MainComponent()
        {
            Common.Log("Starting initial");
            InitialCommand();
            Common.Log("Initial done");
            Common.Log("test log warning", LogType.Warning);
            Common.Log("test log error", LogType.Error);
        }

        private void InitialCommand()
        {
            try
            {
                ButtonDonateClick = new RelayCommand(ButtonDonateClickAction);
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
                if (!DonateIsOpen)
                {
                    donate = new ucDonate
                    {
                        Topmost = true
                    };
                    donate.Closed += Donate_Closed;
                    DonateIsOpen = true;
                    donate.Show();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Common.Log($"{ex.Message}\r\n{ex.StackTrace}", LogType.Error);
            }
            
        }

        /// <summary>
        /// 關閉Donate Flyout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Donate_Closed(object sender, EventArgs e)
        {
            DonateIsOpen = false;
        }
        #endregion
    }
}