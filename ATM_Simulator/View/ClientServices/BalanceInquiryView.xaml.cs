using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for BalanceInquiryView.xaml
    /// </summary>
    internal partial class BalanceInquiryView : UserControl
    {
        internal BalanceInquiryView()
        {
            InitializeComponent();
            DataContext = new BalanceInquiryViewModel();
        }
    }

}
