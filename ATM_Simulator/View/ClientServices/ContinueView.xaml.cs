using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices;

namespace ATM_Simulator.View.ClientServices
{
    /// <summary>
    /// Interaction logic for ContinueView.xaml
    /// </summary>
    internal partial class ContinueView : UserControl
    {
        internal ContinueView()
        {
            InitializeComponent();
            DataContext = new ContinueViewModel();
        }
    }
}
