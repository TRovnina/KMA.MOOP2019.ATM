using System.Collections.ObjectModel;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.Regular_Payment
{
    internal class PaymentTemplatesViewModel : BasicViewModel
    {
        private ObservableCollection<RegularPayment> _payments;
        private RegularPayment _selectedPayment;

        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public ObservableCollection<RegularPayment> Payments
        {
            get { return _payments; }
            set
            {
                _payments = value;
                OnPropertyChanged();
            }
        }

        public RegularPayment SelectedPayment
        {
            get { return _selectedPayment; }

            set
            {
                _selectedPayment = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand<object>(Edit, CanExecute)); }
        }

        private void Edit(object obj)
        {
            StaticManager.CurrentPayment = SelectedPayment;
            NavigationManager.Instance.Navigate(ModesEnum.CreatePayment);
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(Delete, CanExecute)); }
        }

        private void Delete(object obj)
        {
            //remove selected payment
        }

        private bool CanExecute(object obj)
        {
            return SelectedPayment != null;
        }

        public ICommand MenuCommand
        {
            get { return _menuCommand ?? (_menuCommand = new RelayCommand<object>(Menu)); }
        }

        private void Menu(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.ClientMenu);
        }

        public ICommand EndCommand
        {
            get { return _endCommand ?? (_endCommand = new RelayCommand<object>(End)); }
        }

        private void End(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
        }
    }
}
