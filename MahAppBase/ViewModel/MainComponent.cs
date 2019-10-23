using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public NoParameterCommand ButtonDonateClick { get; set; }
        public bool DonateIsOpen { get; set; }
        #endregion

        #region MemberFunction
        public MainComponent()
        {
            ButtonDonateClick = new NoParameterCommand(ButtonDonateClickAction);
        }

        public void ButtonDonateClickAction()
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
            {

            }
        }

        private void Donate_Closed(object sender, EventArgs e)
        {
            DonateIsOpen = false;
        }

        #endregion
    }
}