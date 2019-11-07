using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for ClientServicesView.xaml
    /// </summary>
    internal partial class ClientServicesView : UserControl
    {
        internal ClientServicesView()
        {
            InitializeComponent();
            DataContext = new ClientServicesViewModel();
        }
    }
}
