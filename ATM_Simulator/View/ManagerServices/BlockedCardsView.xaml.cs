using System.Windows.Controls;
using ATM_Simulator.ViewModel.ManagerServices;

namespace ATM_Simulator.View.ManagerServices
{
    /// <summary>
    /// Interaction logic for BlockedCardsView.xaml
    /// </summary>
    internal partial class BlockedCardsView : UserControl
    {
        internal BlockedCardsView()
        {
            InitializeComponent();
            DataContext = new BlockedCardsViewModel();
        }
    }
}
