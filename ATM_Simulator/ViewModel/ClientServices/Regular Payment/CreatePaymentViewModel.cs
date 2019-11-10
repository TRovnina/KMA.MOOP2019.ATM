using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
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
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Card
        {
            get { return _card; }
            set
            {
                _card = value;
                OnPropertyChanged();
            }
        }

        public Double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public PeriodRegularPayment Period
        {
            get
            {
                return _period;
            }
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

        private async void Confirm(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                RegularPayment rg = new RegularPayment(_period, _name, (StaticManager.CurrentCard as CurrentAccount),
                    _amount, _card);
                DbManager.AddRegularPayment(rg);
                StaticManager.CurrentPayment = null;

                ATMAccountAction action = new ATMAccountAction(StaticManager.CurrentAtm,
                    StaticManager.CurrentCard, "RegularPayment");
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();

            MessageBox.Show("You have successfully created regular payment " + _name);
            NavigationManager.Instance.Navigate(ModesEnum.AskContinue);
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

        internal CreatePaymentViewModel()
        {
            _name = (StaticManager.CurrentPayment == null
                ? ""
                : StaticManager.CurrentPayment.RegularPaymentName);
            _period = (StaticManager.CurrentPayment == null
                ? PeriodRegularPayment.None
                : StaticManager.CurrentPayment.PeriodRegularPayment);
            _amount = (StaticManager.CurrentPayment == null ? 0 : StaticManager.CurrentPayment.Sum);
            _card = (StaticManager.CurrentPayment == null
                ? ""
                : StaticManager.CurrentPayment.DestinationAccount);

        }
    }
}
