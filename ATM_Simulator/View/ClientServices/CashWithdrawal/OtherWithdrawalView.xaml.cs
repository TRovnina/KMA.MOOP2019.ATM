using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.ClientServices.CashWithdrawal;

namespace ATM_Simulator.View.ClientServices.CashWithdrawal
{
    /// <summary>
    /// Interaction logic for OtherWithdrawalView.xaml
    /// </summary>
    internal partial class OtherWithdrawalView
    {
        internal OtherWithdrawalView()
        {
            InitializeComponent();
            DataContext = new OtherWithdrawalViewModel();
        }

        //allow to input numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
