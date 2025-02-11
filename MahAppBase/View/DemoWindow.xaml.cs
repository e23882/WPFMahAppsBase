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
        #region Declarations
        /// <summary>
        /// 
        /// </summary>
        public DemoWindowViewModel ViewModel { get; set; }
        #endregion

        #region MemberFunction
        /// <summary>
        /// 
        /// </summary>
        public DemoWindow()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<DemoWindowViewModel>();
            this.DataContext = ViewModel;
        }
        #endregion
    }

    public class DemoWindowViewModel : ViewModelBase
    {
        #region Declarations
        private string _Data = "TestWindow1";
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
