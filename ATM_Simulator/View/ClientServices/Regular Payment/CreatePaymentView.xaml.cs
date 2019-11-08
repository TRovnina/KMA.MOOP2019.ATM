using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.Regular_Payment;

namespace ATM_Simulator.View.ClientServices.Regular_Payment
{
    /// <summary>
    /// Interaction logic for CreatePaymentView.xaml
    /// </summary>
    internal partial class CreatePaymentView : UserControl
    {
        internal CreatePaymentView()
        {
            InitializeComponent();
            DataContext = new CreatePaymentViewModel();
        }
    }
}
