using System.Collections.ObjectModel;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.Regular_Payment
{
    internal class PaymentTemplatesViewModel : BasicViewModel
    {
        private ObservableCollection<RegularPayment> _payments;
        private RegularPayment _selectedPayments;

        public ObservableCollection<RegularPayment> Payments
        {
            get { return _payments; }
            set
            {
                _payments = value;
                OnPropertyChanged();
            }
        }

        public RegularPayment SelectedPayments
        {
            get { return _selectedPayments; }

            set
            {
                _selectedPayments = value;
                OnPropertyChanged();
            }
        }
    }
}
