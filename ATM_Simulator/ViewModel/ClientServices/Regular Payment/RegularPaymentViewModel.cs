using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices.Regular_Payment
{
    internal class RegularPaymentViewModel
    {
        private ICommand _templatesCommand;
        private ICommand _createCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;


        public ICommand TemplatesCommand
        {
            get { return _templatesCommand ?? (_templatesCommand = new RelayCommand<object>(Templates)); }
        }

        private void Templates(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.PaymentTemplates);
        }

        public ICommand CreateCommand
        {
            get { return _createCommand ?? (_createCommand = new RelayCommand<object>(Create)); }
        }

        private void Create(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CreatePayment);
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
