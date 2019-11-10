using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ClientServices.Transfer
{
    internal class CheckTransferViewModel
    {
        private ICommand _cancelCommand;
        private ICommand _confirmCommand;



        public string RecipientCard
        {
            get { return StaticManager.CurrentTransfer.RecipientCard.CardNumber; }
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
            if (StaticManager.CurrentCard.AvailableSum >= Amount)
            {
                StaticManager.CurrentCard.AvailableSum = StaticManager.CurrentCard.AvailableSum - Amount;
                StaticManager.CurrentTransfer.RecipientCard.AvailableSum = StaticManager.CurrentTransfer.RecipientCard.AvailableSum + Amount;
                DbManager.SaveAccount(StaticManager.CurrentCard);
                DbManager.SaveAccount(StaticManager.CurrentTransfer.RecipientCard);
                MessageBox.Show("You have successfully transfer " + Amount + " points to " + RecipientName);
            }
            else
                MessageBox.Show("There is not enough money in your account!", "Refusal!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            
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
