using System.Text.RegularExpressions;
using System.Windows.Input;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for CashSurplusView.xaml
    /// </summary>
    internal partial class CashSurplusView
    {
        internal CashSurplusView()
        {
            InitializeComponent();
            DataContext = new CashSurplusViewModel();
        }

        //allow to input numbers and spaces
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
