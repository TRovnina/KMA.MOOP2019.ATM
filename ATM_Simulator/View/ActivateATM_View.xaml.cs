using ATM_Simulator.Tools.Navigation;
using ATM_Simulator.ViewModel;

namespace ATM_Simulator.View
{
    /// <summary>
    /// Interaction logic for ActivateATM_View.xaml
    /// </summary>
    public partial class ActivateATM_View : INavigatable
    {
        public ActivateATM_View()
        {
            InitializeComponent();
            DataContext = new ActivateATM_ViewModel();
        }
    }
}
