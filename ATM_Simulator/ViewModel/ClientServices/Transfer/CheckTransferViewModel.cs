using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.Transfer
{
    internal class CheckTransferViewModel : BasicViewModel
    {
        private ICommand _cancelCommand;
        private ICommand _confirmCommand;



        public string RecipientCard
        {
            get { return StaticManager.CurrentTransfer.RecipientCard; }
        }

        public string RecipientName
        {
            get { return StaticManager.CurrentTransfer.RecipientName; }
        }

        public double Amount
        {
            get { return StaticManager.CurrentTransfer.Amount; }
        }

        public string Commission
        {
            get { return StaticManager.CurrentTransfer.Commission + " %"; }
        }

        public string Description
        {
            get { return StaticManager.CurrentTransfer.Description; }
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(Confirm)); }
        }

        private void Confirm(object obj)
        {
            MessageBox.Show("You have successfully transfer " + Amount + " points to " + RecipientName);
            NavigationManager.Instance.Navigate(ModesEnum.AskContinue);
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(Cancel)); }
        }

        private void Cancel(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Transfer);
        }
    }
}
