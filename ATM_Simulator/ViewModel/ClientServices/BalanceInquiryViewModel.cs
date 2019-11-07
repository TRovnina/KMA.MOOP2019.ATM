
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices
{
    internal class BalanceInquiryViewModel : BasicViewModel
    {
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string Card
        {
            //get { return Card.Type + " Card"; }
            get { return "Current Card"; }
        }

        public string Text
        {
            get { return GetText();  }
        }

        public int Amount
        {
            //get { return Card.Amount; }
            get { return 100; }
        }

        private string GetText()
        {
            //check type of the card and get information
            string txt = "";
            //if(Card.Type == "Credit")
            //  txt = "Your Credit Amount is " + Card.Credit +"\nAfter " + CreditDate + " will be charged " + Credit.Commission + " % of the amount every month";
            //else if(Card.Type == "Deposit")
            // txt = "Every month will be accrued " + Card.Commission + " % of amount \nDate when amount will be available " + Card.Date
            return txt;
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
