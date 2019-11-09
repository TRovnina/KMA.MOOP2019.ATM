using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices
{
    internal class ClientServicesViewModel : BasicViewModel
    {
        private ICommand _cashWithdrawalCommand;
        private ICommand _balanceInquiryCommand;
        private ICommand _transferCommand;
        private ICommand _regularPaymentCommand;
        private ICommand _cashSurplusCommand;
        private ICommand _changePinCommand;
        private ICommand _endCommand;


        public ICommand CashWithdrawalCommand
        {
            get { return _cashWithdrawalCommand ?? (_cashWithdrawalCommand = new RelayCommand<object>(CashWithdrawal)); }
        }

        private void CashWithdrawal(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CashWithdrawal);
        }

        public ICommand BalanceInquiryCommand
        {
            get { return _balanceInquiryCommand ?? (_balanceInquiryCommand = new RelayCommand<object>(BalanceInquiry)); }
        }

        private void BalanceInquiry(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.BalanceInquiry);
        }

        public ICommand TransferCommand
        {
            get { return _transferCommand ?? (_transferCommand = new RelayCommand<object>(Transfer)); }
        }

        private void Transfer(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Transfer);
        }

        public ICommand RegularPaymentCommand
        {
            get { return _regularPaymentCommand ?? (_regularPaymentCommand = new RelayCommand<object>(RegularPayment)); }
        }

        private void RegularPayment(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.RegularPayment);
        }

        public ICommand CashSurplusCommand
        {
            get { return _cashSurplusCommand ?? (_cashSurplusCommand = new RelayCommand<object>(CashSurplus, CanCashSurplusExecute)); }
        }

        private void CashSurplus(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CashSurplus);
        }

        private bool CanCashSurplusExecute(object obj)
        {
            return true;
            //check type of card
        }

        public ICommand ChangePinCommand
        {
            get { return _changePinCommand ?? (_changePinCommand = new RelayCommand<object>(ChangePin)); }
        }

        private void ChangePin(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.ChangePin);
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
