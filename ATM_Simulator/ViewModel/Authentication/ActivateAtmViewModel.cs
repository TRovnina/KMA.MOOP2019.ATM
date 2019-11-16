using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.ServiceReference1;
using ATM_Simulator.Tools;

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
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(Close)); }
        }

        #endregion

        private bool CanActivateExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_code) && _code.Length == 16;
        }

        private async void ActivateImplementation(object obj)
        {
            bool correct = true;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                ServiceReference1.ServiceATMClient client = new ServiceATMClient();
                var atm = client.GetATMByCode(Code);
                StaticManager.CurrentAtm = atm;
                if (atm == null || !atm.CheckPassword(Password))
                    correct = false;
                else
                {
                    StaticManager.CurrentAtm.Status = true;
                    DbManager.SaveATM(StaticManager.CurrentAtm);
                }
            });
            LoaderManager.Instance.HideLoader();
            if (correct)
                NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
            else
            {
                MessageBox.Show("Wrong code or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                NavigationManager.Instance.Navigate(ModesEnum.ActivateAtm);
            }
        }


        private void Close(object obj)
        {
            StaticManager.CloseApp();
        }
    }
}
