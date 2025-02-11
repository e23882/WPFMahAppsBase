using System;
using System.Windows;
using System.Windows.Input;
using Autofac;
using MahAppBase.Command;

namespace MahAppBase
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class DemoWindow : Window
    {
        public DemoWindowViewModel ViewModel { get; set; }
        public DemoWindow()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<DemoWindowViewModel>();
            this.DataContext = ViewModel;
        }
    }

    public class DemoWindowViewModel : ViewModelBase 
    {
        #region Declarations
        private string _Data = "TestWindow1";
        #endregion

        #region Properties
        public string Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                OnPropertyChanged();
            }
        }
        public ICommand TestButtonClickCommand { get; set; }

        #endregion

        #region MemberFunction
        /// <summary>
        /// 
        /// </summary>
        public DemoWindowViewModel()
        {
            TestButtonClickCommand = new RelayCommand(TestButtonClickCommandAction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void TestButtonClickCommandAction(object obj)
        {
            Guid id = Guid.NewGuid();
            Data = $"Update Id : {id.ToString()}";
        }
        #endregion
    }
}
