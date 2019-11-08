using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.Transfer;

namespace ATM_Simulator.View.ClientServices.Transfer
{
    /// <summary>
    /// Interaction logic for CheckTransferView.xaml
    /// </summary>
    internal partial class CheckTransferView : UserControl
    {
        internal CheckTransferView()
        {
            InitializeComponent();
            DataContext = new CheckTransferViewModel();
        }
    }
}
