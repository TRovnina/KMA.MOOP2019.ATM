using System.Windows.Controls;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using ATM_Simulator.ViewModel;

namespace ATM_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContent
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
