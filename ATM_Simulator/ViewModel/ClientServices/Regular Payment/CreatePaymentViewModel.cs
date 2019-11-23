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
        private int _amount;
        private DateTime _firstDate;
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

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public DateTime Today
        {
            get { return _firstDate; }
        }

        public DateTime FirstDate
        {
            get { return _firstDate; }
            set
            {
                _firstDate = value;
                OnPropertyChanged();
            }
        }

        public PeriodRegularPayment Period
        {
            get { return _period; }
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
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(Confirm, CanConfirmExecute)); }
        }

        private bool CanConfirmExecute(object obj)
        {
            return _amount != 0 && !string.IsNullOrWhiteSpace(_card) && !string.IsNullOrWhiteSpace(_name) &&
                   _period != PeriodRegularPayment.None;
        }

        private async void Confirm(object obj)
        {
            Card = _card.Replace(" ", "");
            bool correct = true;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Account destination = DbManager.GetAccountByNum(Card);
                if (destination == null)
                {
                    correct = false;
                    MessageBox.Show("Destination account doesn`t exist!", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    RegularPayment rg = new RegularPayment(_period, _name,
                        (StaticManager.CurrentCard as CurrentAccount),
                        _amount, _card, _firstDate);
                    DbManager.AddRegularPayment(rg);
                    StaticManager.CurrentPayment = null;
                    MessageBox.Show("You have successfully created regular payment " + _name);
                }

                DbManager.AddATMAccountAction(new ATMAccountAction(StaticManager.CurrentAtm,
                    StaticManager.CurrentCard, "RegularPayment"));
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();

            if (correct)
                NavigationManager.Instance.Navigate(ModesEnum.AskContinue);

            else
                NavigationManager.Instance.Navigate(ModesEnum.CreatePayment);
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
            _amount = (StaticManager.CurrentPayment == null
                ? 0
                : (int) StaticManager.CurrentPayment.Sum);
            _card = (StaticManager.CurrentPayment == null
                ? ""
                : StaticManager.CurrentPayment.DestinationAccount);
            _firstDate = (StaticManager.CurrentPayment == null
                ? DateTime.Today
                : StaticManager.CurrentPayment.FirstRegularPaymentDate);
        }
    }
}
