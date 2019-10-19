using System.Windows;
using System.Windows.Controls;
using ATM_Simulator.Tools.Manager;
using ATM_Simulator.Tools.Navigation;
using ATM_Simulator.ViewModel;

namespace ATM_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContent
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            StaticManager.Initialize();
            NavigationManager.Instance.Initialize(new NavigationInit(this));
            NavigationManager.Instance.Navigate(ViewType.ActivateAtm);
        }
    }
}
