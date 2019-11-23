using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.ClientServices.Transfer;

namespace ATM_Simulator.View.ClientServices.Transfer
{
    /// <summary>
    /// Interaction logic for TransferView.xaml
    /// </summary>
    internal partial class TransferView
    {
        internal TransferView()
        {
            InitializeComponent();
            DataContext = new TransferViewModel();
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
