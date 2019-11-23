using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for ChangePinView.xaml
    /// </summary>
    internal partial class ChangePinView
    {
        internal ChangePinView()
        {
            InitializeComponent();
            DataContext = new ChangePinViewModel();
        }

        //allow to input numbers and spaces
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
