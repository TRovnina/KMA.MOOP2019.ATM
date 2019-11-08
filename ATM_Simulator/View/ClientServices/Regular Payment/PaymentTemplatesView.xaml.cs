using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ATM_Simulator.ViewModel.ClientServices.Regular_Payment;

namespace ATM_Simulator.View.ClientServices.Regular_Payment
{
    /// <summary>
    /// Interaction logic for PaymentTemplatesView.xaml
    /// </summary>
    internal partial class PaymentTemplatesView : UserControl
    {
        internal PaymentTemplatesView()
        {
            InitializeComponent();
            DataContext = new PaymentTemplatesViewModel();
        }
    }
}
