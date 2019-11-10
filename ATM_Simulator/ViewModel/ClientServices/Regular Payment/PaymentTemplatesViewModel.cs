using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ClientServices.Regular_Payment
{
    internal class PaymentTemplatesViewModel : BasicViewModel
    {
        private List<RegularPayment> _payments;
        private RegularPayment _selectedPayment;

        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public List<RegularPayment> Payments
        {
            get { return _payments = DbManager.GetRegularPayments(StaticManager.CurrentCard.CardNumber); }
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

        private async void Edit(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                StaticManager.CurrentPayment = SelectedPayment;
                DbManager.DeleteRegularPayment(SelectedPayment);
            });
            LoaderManager.Instance.HideLoader();
            NavigationManager.Instance.Navigate(ModesEnum.CreatePayment);
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(Delete, CanExecute)); }
        }

        private async void Delete(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                _payments.Remove(SelectedPayment);
                DbManager.DeleteRegularPayment(SelectedPayment);
                ATMAccountAction action = new ATMAccountAction(StaticManager.CurrentAtm,
                    StaticManager.CurrentCard, "RegularPayment");
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();
            MessageBox.Show("Regular Payment was successfully deleted!");
            NavigationManager.Instance.Navigate(ModesEnum.AskContinue);
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
            StaticManager.Attempts = 3;
            NavigationManager.Instance.Navigate(ModesEnum.CardPin);
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
