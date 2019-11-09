
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ClientServices.Regular_Payment
{
    internal class CreatePaymentViewModel : BasicViewModel
    {
        private string _name;
        private string _card;
        private Double _amount;
        private PeriodRegularPayment _period;

        private ICommand _confirmCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string Name
        {
            get { return _name = (StaticManager.CurrentPayment == null ? "" : StaticManager.CurrentPayment.RegularPaymentName); }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Card
        {
            get { return _card = (StaticManager.CurrentPayment == null ? "" : StaticManager.CurrentPayment.DestinationAccount); }
            set
            {
                _card = value;
                OnPropertyChanged();
            }
        }

        public Double Amount
        {
            get { return _amount = (StaticManager.CurrentPayment == null ? 0 : StaticManager.CurrentPayment.Sum); }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public PeriodRegularPayment Period
        {
            get { return _period = (StaticManager.CurrentPayment == null ? PeriodRegularPayment.None: StaticManager.CurrentPayment.PeriodRegularPayment); }
            set
            {
                _period = value;
                OnPropertyChanged();
            }
        }

        public List<PeriodRegularPayment> Periods
        {
            get => Enum.GetValues(typeof(PeriodRegularPayment)).Cast<PeriodRegularPayment>().ToList();
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(Confirm)); }
        }

        private void Confirm(object obj)
        {
            StaticManager.CurrentPayment = new RegularPayment(_period, _name, (StaticManager.CurrentCard as CurrentAccount), _amount, _card);
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
