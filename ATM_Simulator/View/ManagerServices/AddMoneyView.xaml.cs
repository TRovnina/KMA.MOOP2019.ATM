using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.ManagerServices;

namespace ATM_Simulator.View.ManagerServices
{
    /// <summary>
    /// Interaction logic for AddMoneyView.xaml
    /// </summary>
    internal partial class AddMoneyView
    {
        internal AddMoneyView()
        {
            InitializeComponent();
            DataContext = new AddMoneyViewModel();
        }

        //allow to input numbers and spaces
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
