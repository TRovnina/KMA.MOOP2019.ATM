using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.Authentication
{
    internal class CardPinViewModel : BasicViewModel
    {
        #region Fields

        private string _pin;

        #endregion

        #region Commands

        private ICommand _nextCommand;
        private ICommand _closeCommand;

        #endregion

        #region Properties

        public string Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand =
                           new RelayCommand<object>(NextImplementation, CanNextExecute));
            }
        }


        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(Close)); }
        }

        #endregion

        private bool CanNextExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_pin);
        }

        private async void NextImplementation(object obj)
        {
            bool correct = false;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                StaticManager.Attempts = StaticManager.Attempts - 1;
                if ((StaticManager.CurrentCard != null && StaticManager.CurrentCard.CheckPassword(Pin)) ||
                    (StaticManager.CurrentManager != null && StaticManager.CurrentManager.CheckPassword(Pin)))
                    correct = true;

                else if (StaticManager.CurrentCard != null && StaticManager.Attempts == 0)
                {
                    StaticManager.CurrentCard.IsActive = false;
                    DbManager.SaveAccount(StaticManager.CurrentCard);
                }
                
                if (StaticManager.CurrentCard != null)
                {
                    ATMAccountAction action = new ATMAccountAction(StaticManager.CurrentAtm,
                        StaticManager.CurrentCard, "Authentication");
                    DbManager.SaveATM(StaticManager.CurrentAtm);
                }
                else
                {
                    ATMManagerAction action = new ATMManagerAction(StaticManager.CurrentManager, StaticManager.CurrentAtm, "Authentication");
                    DbManager.SaveATM(StaticManager.CurrentAtm);
                }

            });
            LoaderManager.Instance.HideLoader();

            if (!correct)
            {
                MessageBox.Show("You have " + StaticManager.Attempts + " attempts!", "Wrong PIN!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                ModesEnum mode = (StaticManager.Attempts == 0 ? ModesEnum.CardNumber : ModesEnum.CardPin);
                NavigationManager.Instance.Navigate(mode);
            }
            else if (StaticManager.CurrentCard != null)
                NavigationManager.Instance.Navigate(ModesEnum.ClientMenu);
            else if (StaticManager.CurrentManager != null)
                NavigationManager.Instance.Navigate(ModesEnum.ManagerMenu);
        }


        private void Close(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
        }
    }
}
