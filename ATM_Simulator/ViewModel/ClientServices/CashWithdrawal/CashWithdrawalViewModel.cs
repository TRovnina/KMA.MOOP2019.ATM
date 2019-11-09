using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.CashWithdrawal
{
    internal class CashWithdrawalViewModel : CashModel
    {
        private ICommand _hundredCommand;
        private ICommand _twoHundredCommand;
        private ICommand _fiveHundredCommand;
        private ICommand _otherCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        private int[] _result100;
        private int[] _result200;
        private int[] _result500;
        


        public ICommand HundredCommand
        {
            get { return _hundredCommand ?? (_hundredCommand = new RelayCommand<object>(Hundred, CanHundredExecute)); }
        }

        private bool CanHundredExecute(object obj)
        {
            return (_result100 = Multiplicity(100, Banknotes)) != null;
        }

        private void Hundred(object obj)
        {
            GetMoney(100, _result100);
        }

        public ICommand TwoHundredCommand
        {
            get
            {
                return _twoHundredCommand ??
                       (_twoHundredCommand = new RelayCommand<object>(TwoHundred, CanTwoHundredExecute));
            }
        }

        private bool CanTwoHundredExecute(object obj)
        {
            return (_result200 = Multiplicity(200, Banknotes)) != null;
        }

        private void TwoHundred(object obj)
        {
            GetMoney(200, _result200);
        }

        public ICommand FiveHundredCommand
        {
            get
            {
                return _fiveHundredCommand ??
                       (_fiveHundredCommand = new RelayCommand<object>(FiveHundred, CanFiveHundredExecute));
            }
        }

        private bool CanFiveHundredExecute(object obj)
        {
            return(_result500 = Multiplicity(500, Banknotes)) != null;
        }

        private void FiveHundred(object obj)
        {
            GetMoney(500, _result500);
        }

        public ICommand OtherCommand
        {
            get { return _otherCommand ?? (_otherCommand = new RelayCommand<object>(Other)); }
        }

        private void Other(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.OtherWithdrawal);
        }

        private void GetMoney(int n, int[] res)
        {
            RemoveBanknotes(res);
            MessageBox.Show("You have successfully been issued " + n + " points! \nBanknotes " + res);
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
