using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.Transfer
{
    internal class TransferViewModel : BasicViewModel
    {
        private string _recipient;
        private double _amount;
        private string _description;

        private ICommand _confirmCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string Recipient
        {
            get { return _recipient; }
            set
            {
                _recipient = value;
                OnPropertyChanged();
            }
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(Confirm)); }
        }

        private void Confirm(object obj)
        {
            StaticManager.CurrentTransfer = new Models.Transfer(Recipient, Amount, Description);
            NavigationManager.Instance.Navigate(ModesEnum.CheckInfo);
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
