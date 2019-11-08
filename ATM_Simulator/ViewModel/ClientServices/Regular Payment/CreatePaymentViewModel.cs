
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.Regular_Payment
{
    internal class CreatePaymentViewModel : BasicViewModel
    {
        private string _name;
        private string _card;
        private int _amount;
        private string _description;
        private string _period;

        private ICommand _confirmCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string Name
        {
            get { return _name = (StaticManager.CurrentPayment == null ? "" : StaticManager.CurrentPayment.Name); }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Card
        {
            get { return _card = (StaticManager.CurrentPayment == null ? "" : StaticManager.CurrentPayment.Card); }
            set
            {
                _card = value;
                OnPropertyChanged();
            }
        }

        public int Amount
        {
            get { return _amount = (StaticManager.CurrentPayment == null ? 0 : StaticManager.CurrentPayment.Amount); }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description = (StaticManager.CurrentPayment == null ? "" : StaticManager.CurrentPayment.Description); }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string Period
        {
            get { return _period = (StaticManager.CurrentPayment == null ? "" : StaticManager.CurrentPayment.Period); }
            set
            {
                _period = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(Confirm)); }
        }

        private void Confirm(object obj)
        {
            StaticManager.CurrentPayment = new RegularPayment(Name, Card, Amount, Period, Description);
            NavigationManager.Instance.Navigate(ModesEnum.CheckTransferInfo);
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
