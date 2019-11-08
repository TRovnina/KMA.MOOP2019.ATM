using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

namespace ATM_Simulator.ViewModel.ClientServices
{
    internal class ContinueViewModel : BasicViewModel
    {
        private ICommand _noCommand;
        private ICommand _yesCommand;

        public ICommand NoCommand
        {
            get { return _noCommand ?? (_noCommand = new RelayCommand<object>(End)); }
        }

        private void Continue(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CardPin);
        }

        public ICommand YesCommand
        {
            get { return _yesCommand ?? (_yesCommand = new RelayCommand<object>(Continue)); }
        }

        private void End(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
        }
    }
}
