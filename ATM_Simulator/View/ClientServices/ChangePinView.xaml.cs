using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for ChangePinView.xaml
    /// </summary>
    internal partial class ChangePinView : UserControl
    {
        internal ChangePinView()
        {
            InitializeComponent();
            DataContext = new ChangePinViewModel();
        }
    }
}
