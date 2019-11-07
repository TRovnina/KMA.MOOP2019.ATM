using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.CashWithdrawal;

namespace ATM_Simulator.View.ClientServices.CashWithdrawal
{
    /// <summary>
    /// Interaction logic for OtherWithdrawalView.xaml
    /// </summary>
    internal partial class OtherWithdrawalView : UserControl
    {
        internal OtherWithdrawalView()
        {
            InitializeComponent();
            DataContext = new OtherWithdrawalViewModel();
        }
    }
}
