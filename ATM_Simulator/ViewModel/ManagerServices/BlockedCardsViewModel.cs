using System.Collections.ObjectModel;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ManagerServices
{
    internal class BlockedCardsViewModel : BasicViewModel
    {
        private ObservableCollection<Account> _cards;
        private Account _selectedCard;

        private ICommand _unlockCommand;
        private ICommand _menuCommand;

        public ObservableCollection<Account> Cards
        {
            get { return StaticManager.CurrentAtm.; }
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
            get { return _unlockCommand ?? (_unlockCommand = new RelayCommand<object>(Unlock)); }
        }

        private void Unlock(object obj)
        {
            SelectedCard.IsActive = true;
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

    }
}
