using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MahAppBase.View
{
    /// <summary>
    /// AlertWindow.xaml 的互動邏輯
    /// </summary>
    public partial class AlertWindow : Window
    {
        public AlertWindowViewModel ViewModel { get; set; }
        public AlertWindow(string message)
        {
            InitializeComponent();
            ViewModel = new AlertWindowViewModel(message);
            ViewModel.CurrentInstance = this;
            this.DataContext = ViewModel;
        }
    }
}
