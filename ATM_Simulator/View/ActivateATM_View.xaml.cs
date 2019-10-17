using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
