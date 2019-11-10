using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ManagerServices
{
    internal class BlockedCardsViewModel : BasicViewModel
    {
        private List<Account> _cards;
        private Account _selectedCard;

        private ICommand _unlockCommand;
        private ICommand _menuCommand;

        public List<Account> Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                OnPropertyChanged();
            }
        }

        public Account SelectedCard
        {
            get { return _selectedCard; }

            set
            {
                _selectedCard = value;
                OnPropertyChanged();
            }
        }

        public ICommand UnlockCommand
        {
            get { return _unlockCommand ?? (_unlockCommand = new RelayCommand<object>(Unlock, CanUnlockExecute)); }
        }

        private bool CanUnlockExecute(object obj)
        {
            return SelectedCard != null;
        }

        private async void Unlock(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                SelectedCard.IsActive = true;
                _cards.Remove(SelectedCard);
                DbManager.SaveAccount(SelectedCard);
                ATMManagerAction action = new ATMManagerAction(StaticManager.CurrentManager, StaticManager.CurrentAtm, "UnBlockCard");
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();
            NavigationManager.Instance.Navigate(ModesEnum.BlockedCards);
        }

        public ICommand MenuCommand
        {
            get { return _menuCommand ?? (_menuCommand = new RelayCommand<object>(Menu)); }
        }

        private void Menu(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.ManagerMenu);
        }

        internal BlockedCardsViewModel()
        {
            _cards = DbManager.GetAllBlockedAccounts();
        }
    }
}
