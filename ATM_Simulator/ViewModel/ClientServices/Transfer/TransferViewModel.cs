using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ClientServices.Transfer
{
    internal class TransferViewModel : BasicViewModel
    {
        private string _recipient;
        private int _amount;
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

        public int Amount
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
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(Confirm, CanConfirmExecute)); }
        }

        private async void Confirm(object obj)
        {
            Recipient = _recipient.Replace(" ", "");
            Account recipient = null;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                recipient = DbManager.GetAccountByNum(Recipient);

                if (recipient == null)
                {
                    DbManager.AddATMAccountAction(new ATMAccountAction(StaticManager.CurrentAtm,
                        StaticManager.CurrentCard, "Transfer", recipient));
                    DbManager.SaveATM(StaticManager.CurrentAtm);
                }
            });
            LoaderManager.Instance.HideLoader();

            if (recipient == null)
            {
                MessageBox.Show("The card " + Recipient + " does not exist!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                NavigationManager.Instance.Navigate(ModesEnum.Transfer);
            }
            else if (Recipient == StaticManager.CurrentCard.CardNumber)
            {
                MessageBox.Show("Number of card sender and card recipient must not match!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                NavigationManager.Instance.Navigate(ModesEnum.Transfer);
            }
            else
            {
                StaticManager.CurrentTransfer = new CurrentTransfer(recipient, Amount, Description);
                NavigationManager.Instance.Navigate(ModesEnum.CheckTransferInfo);
            }
        }

        private bool CanConfirmExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_recipient) && _recipient.Replace(" ", "").Length == 16 && _amount != 0;
        }

        public ICommand MenuCommand
        {
            get { return _menuCommand ?? (_menuCommand = new RelayCommand<object>(Menu)); }
        }

        private void Menu(object obj)
        {
            StaticManager.Attempts = 3;
            NavigationManager.Instance.Navigate(ModesEnum.CardPin);
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
