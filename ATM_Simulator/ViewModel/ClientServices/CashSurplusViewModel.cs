using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ClientServices
{
    internal class CashSurplusViewModel : BasicViewModel
    {
        private int _amount;
        private PeriodHandingCashSurplus _period;

        private ICommand _confirmCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        internal CashSurplusViewModel()
        {
            _amount = (Account.IsHandingCashSurplus ? (int)Account.ThresholdAmount : 0);
            _period = (Account.IsHandingCashSurplus ? Account.PeriodCashSurplus : PeriodHandingCashSurplus.None);
        }

        public string Card
        {
            get { return GetDepositCard(); }
        }

        private string GetDepositCard()
        {
            DepositAccount account = StaticManager.CurrentClient.DepositAccount();
            return account.CardNumber;
        }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }


        private CurrentAccount Account
        {
            get
            {
                return StaticManager.CurrentCard as CurrentAccount;
            }
        }

        public PeriodHandingCashSurplus Period
        {
            get { return _period; }
            set
            {
                _period = value;
                OnPropertyChanged();
            }
        }

        public List<PeriodHandingCashSurplus>  Periods
        {
            get => Enum.GetValues(typeof(PeriodHandingCashSurplus)).Cast<PeriodHandingCashSurplus>().ToList();
            
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(CreateSurplus)); }
        }

        private async void CreateSurplus(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Account.IsHandingCashSurplus = true;
                Account.PeriodCashSurplus = _period;
                Account.ThresholdAmount = _amount;
                DbManager.SaveAccount(Account);

                DbManager.AddATMAccountAction(new ATMAccountAction(StaticManager.CurrentAtm,
                    StaticManager.CurrentCard, "HandingCashSurplus"));
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();

            MessageBox.Show("You have successfully created new cash surplus!");
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
    }
}
