using ATM_Simulator.ViewModel;

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
    }
}
