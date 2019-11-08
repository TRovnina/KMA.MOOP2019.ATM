using System.Collections.ObjectModel;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ManagerServices
{
    internal class BlockedCardsViewModel : BasicViewModel
    {
        //private ObservableCollection<Amount> _cards;
        //private Amount _selectedCard;

        private ICommand _menuCommand;

        //public ObservableCollection<Amount> Cards
        //{
        //    get { return _cards; }
        //    set
        //    {
        //        _cards = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public Amount SelectedCard
        //{
        //    get { return _selectedCard; }

        //    set
        //    {
        //        _selectedCard = value;
        //        OnPropertyChanged();
        //    }
        //}

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
