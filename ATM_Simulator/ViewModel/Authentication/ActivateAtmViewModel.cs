using System.Threading.Tasks;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.Authentication
{
    internal class ActivateAtmViewModel : BasicViewModel
    {
        #region Fields

        private string _password;
        private string _code;

        #endregion

        #region Commands

        private ICommand _activateCommand;
        private ICommand _closeCommand;

        #endregion

        #region Properties

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
      
        #endregion

        #region Commands

        public ICommand ActivateCommand
        {
            get
            {
                return _activateCommand ?? (_activateCommand =
                           new RelayCommand<object>(ActivateImplementation, CanActivateExecute));
            }
        }


        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(Close));
            }
        }

        #endregion

        private bool CanActivateExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_code);
        }

        private async void ActivateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                //var atm = get ATM(Code, Password);
                //StaticManager.CurrentAtm = atm;
            });

            LoaderManager.Instance.HideLoader();
            NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
        }


        private void Close(object obj)
        {
            StaticManager.CloseApp();
        }

    }
}
