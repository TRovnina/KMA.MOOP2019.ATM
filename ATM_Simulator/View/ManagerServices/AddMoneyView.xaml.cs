using System.Windows.Controls;
using ATM_Simulator.ViewModel.ManagerServices;

namespace ATM_Simulator.View.ManagerServices
{
    /// <summary>
    /// Interaction logic for AddMoneyView.xaml
    /// </summary>
    internal partial class AddMoneyView : UserControl
    {
        internal AddMoneyView()
        {
            InitializeComponent();
            DataContext = new AddMoneyViewModel();
        }
    }
}
