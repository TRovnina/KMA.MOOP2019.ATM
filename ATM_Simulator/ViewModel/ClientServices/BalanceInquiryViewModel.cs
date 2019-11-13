using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ClientServices
{
    internal class BalanceInquiryViewModel
    {
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string Card
        {
            get
            {
                string[] s = StaticManager.CurrentCard.GetType().ToString().Split('.');
                return s[1];
            }
        }

        public string Text
        {
            get { return GetText(); }
        }

        public int Amount
        {
            get { return (int) (StaticManager.CurrentCard.AvailableSum); }
        }

        //check type of the card and get information
        private string GetText()
        {
            string txt = "";
            if (Card == "CreditAccount")
            {
                CreditAccount account = StaticManager.CurrentCard as CreditAccount;
                txt = "Available Credit sum: " + (int) (account.MaxCreditSum - account.CreditSum) +
                      "\nYour Credit Debt is " + (account.CreditSum + account.Debt) +
                      "\nAfter " + account.EndOfGracePeriod + " will be charged " + account.PercentageCredit +
                      " % of the amount every month";
            }
            else if (Card == "DepositAccount")
            {
                DepositAccount account = StaticManager.CurrentCard as DepositAccount;
                txt = "Every month will be accrued " + account.PercentageDeposit +
                      " % of amount \nDate when amount will be available " + account.AvailableDate;
            }

            return txt;
        }

        public ICommand MenuCommand
        {
            get { return _menuCommand ?? (_menuCommand = new RelayCommand<object>(Menu)); }
        }

        private void Menu(object obj)
        {
            SaveAction();
            StaticManager.Attempts = 3;
            NavigationManager.Instance.Navigate(ModesEnum.CardPin);
        }

        public ICommand EndCommand
        {
            get { return _endCommand ?? (_endCommand = new RelayCommand<object>(End)); }
        }

        private void End(object obj)
        {
            SaveAction();
            NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
        }

        private async void SaveAction()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                ATMAccountAction action = new ATMAccountAction(StaticManager.CurrentAtm,
                    StaticManager.CurrentCard, "BalanceInquiry");
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();
        }
    }
}
