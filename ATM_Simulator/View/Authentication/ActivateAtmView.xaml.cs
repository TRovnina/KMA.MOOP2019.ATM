using ATM_Simulator.ViewModel.Authentication;

namespace ATM_Simulator.View.Authentication
{
    /// <summary>
    /// Interaction logic for ActivateAtmView.xaml
    /// </summary>
    internal partial class ActivateAtmView
    {
        internal ActivateAtmView()
        {
            InitializeComponent();
            DataContext = new ActivateAtmViewModel();
        }
    }
}
