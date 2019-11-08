using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.CashWithdrawal;

namespace ATM_Simulator.View.ClientServices.CashWithdrawal
{
    /// <summary>
    /// Interaction logic for CashWithdrawalView.xaml
    /// </summary>
    internal partial class CashWithdrawalView : UserControl
    {
        internal CashWithdrawalView()
        {
            InitializeComponent();
            DataContext = new CashWithdrawalViewModel();
        }
    }
}
