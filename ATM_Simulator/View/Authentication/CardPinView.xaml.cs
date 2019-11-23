using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using ATM_Simulator.ViewModel.Authentication;


namespace ATM_Simulator.View.Authentication
{
    /// <summary>
    /// Interaction logic for CardPinView.xaml
    /// </summary>
    internal partial class CardPinView : UserControl
    {
        internal CardPinView()
        {
            InitializeComponent();
            DataContext = new CardPinViewModel();
        }

        //allow to input numbers and spaces
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
