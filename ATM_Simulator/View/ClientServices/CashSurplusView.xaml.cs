using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for CashSurplusView.xaml
    /// </summary>
    internal partial class CashSurplusView : UserControl
    {
        internal CashSurplusView()
        {
            InitializeComponent();
            DataContext = new CashSurplusViewModel();
        }
    }
}
