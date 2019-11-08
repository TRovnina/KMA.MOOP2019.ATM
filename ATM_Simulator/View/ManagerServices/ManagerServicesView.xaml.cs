using System.Windows.Controls;
using ATM_Simulator.ViewModel.ManagerServices;

namespace ATM_Simulator.View.ManagerServices
{
    /// <summary>
    /// Interaction logic for ManagerServicesView.xaml
    /// </summary>
    internal partial class ManagerServicesView : UserControl
    {
        internal ManagerServicesView()
        {
            InitializeComponent();
            DataContext = new ManagerServicesViewModel();
        }
    }
}
