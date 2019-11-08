using System.Windows.Controls;
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
    }
}
