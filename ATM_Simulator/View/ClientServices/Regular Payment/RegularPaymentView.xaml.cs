using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.Regular_Payment;

namespace ATM_Simulator.View.ClientServices.Regular_Payment
{
    /// <summary>
    /// Interaction logic for RegularPaymentView.xaml
    /// </summary>
    internal partial class RegularPaymentView : UserControl
    {
        internal RegularPaymentView()
        {
            InitializeComponent();
            DataContext = new RegularPaymentViewModel();
        }
    }
}
