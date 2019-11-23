using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.ClientServices.Regular_Payment;

namespace ATM_Simulator.View.ClientServices.Regular_Payment
{
    /// <summary>
    /// Interaction logic for CreatePaymentView.xaml
    /// </summary>
    internal partial class CreatePaymentView
    {
        internal CreatePaymentView()
        {
            InitializeComponent();
            DataContext = new CreatePaymentViewModel();
        }

        //allow to input numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //allow to input numbers and spaces
        private void CardValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9' ']+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
