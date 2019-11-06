using System.Windows.Controls;
using ATM_Simulator.ViewModel;

namespace ATM_Simulator.View.Authentication
{
    /// <summary>
    /// Interaction logic for CardPasswordView.xaml
    /// </summary>
    internal partial class CardPasswordView : UserControl
    {
        internal CardPasswordView()
        {
            InitializeComponent();
            DataContext = new CardPasswordViewModel();
        }
    }
}
