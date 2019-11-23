using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.Authentication;

namespace ATM_Simulator.View.Authentication
{
    /// <summary>
    /// Interaction logic for CardNumberView.xaml
    /// </summary>
    internal partial class CardNumberView
    {
        internal CardNumberView()
        {
            InitializeComponent();
            DataContext = new CardNumberViewModel();
        }

        //allow to input numbers and spaces
        private void CardValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9' ']+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
