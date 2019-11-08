using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ManagerServices
{
    internal class ManagerServicesViewModel : BasicViewModel
    {
        private ICommand _addMoney;
        private ICommand _blockedCards;
        private ICommand _endCommand;


        public ICommand AddMoneyCommand
        {
            get { return _addMoney ?? (_addMoney = new RelayCommand<object>(AddMoney)); }
        }

        private void AddMoney(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.AddMoney);
        }

        public ICommand BlockedCardsCommand
        {
            get { return _blockedCards ?? (_blockedCards = new RelayCommand<object>(BlockedCards)); }
        }

        private void BlockedCards(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.BlockedCards);
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
