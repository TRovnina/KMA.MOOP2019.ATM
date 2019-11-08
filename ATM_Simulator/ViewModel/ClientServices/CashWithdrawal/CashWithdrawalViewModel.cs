using System;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.CashWithdrawal
{
    internal class CashWithdrawalViewModel : BasicViewModel
    {
        private ICommand _hundredCommand;
        private ICommand _twoHundredCommand;
        private ICommand _fiveHundredCommand;
        private ICommand _otherCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;


        public ICommand HundredCommand
        {
            get { return _hundredCommand ?? (_hundredCommand = new RelayCommand<object>(Hundred)); }
        }

        private void Hundred(object obj)
        {
            GetMoney(100);
        }

        public ICommand TwoHundredCommand
        {
            get { return _twoHundredCommand ?? (_twoHundredCommand = new RelayCommand<object>(TwoHundred)); }
        }

        private void TwoHundred(object obj)
        {
            GetMoney(200);
        }

        public ICommand FiveHundredCommand
        {
            get { return _fiveHundredCommand ?? (_fiveHundredCommand = new RelayCommand<object>(FiveHundred)); }
        }

        private void FiveHundred(object obj)
        {
            GetMoney(500);
        }

        public ICommand OtherCommand
        {
            get { return _otherCommand ?? (_otherCommand = new RelayCommand<object>(Other)); }
        }

        private void Other(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.OtherWithdrawal);
        }

       private void GetMoney(int n)
        {
            MessageBox.Show("You have successfully been issued " + n + " points!");
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
