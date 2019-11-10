using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.CashWithdrawal
{
    internal class OtherWithdrawalViewModel : CashModel
    {
        private int _amount;

        private ICommand _confirmCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string Text
        {
            get { return "Maximum available sum is " + AllCash() + "\nEnter a sum multiple of " + CheckMultiplicity(); }
        }

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(GetMoney, CanConfirmExecute)); }
        }

        private bool CanConfirmExecute(object obj)
        {
            return _amount != 0;
        }

        private void GetMoney(object obj)
        {
            var result = Multiplicity(Amount, CountBanknotes());
            if (result == null)
            {
                MessageBox.Show("ATM has not banknotes for this sum!");
                NavigationManager.Instance.Navigate(ModesEnum.OtherWithdrawal);
            }
            else
                GetMoney(Amount, result);
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
