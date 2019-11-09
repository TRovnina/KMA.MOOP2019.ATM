using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
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

        public string Card
        {
            get { return GetDepositCard(); }
        }

        private string GetDepositCard()
        {
            //get from current client his deposit card
            return "1234 5678 9123 7467";
        }

        public int Amount
        {
            // get { return CurrentSurplus.Amount; }
            get { return 0; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        //public PeriodHandingCashSurplus Periods
        //{
        //    get
        //    {
        //        return CurrentAccount. CurrentSurplus.Amount; }
        //    set
        //    {
        //        _period = value;
        //        OnPropertyChanged();
        //    }
        //}

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
                //create new cash surplus 
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
