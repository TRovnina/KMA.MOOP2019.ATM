using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.Transfer;

namespace ATM_Simulator.View.ClientServices.Transfer
{
    /// <summary>
    /// Interaction logic for TransferView.xaml
    /// </summary>
    internal partial class TransferView : UserControl
    {
        internal TransferView()
        {
            InitializeComponent();
            DataContext = new TransferViewModel();
        }
    }
}
