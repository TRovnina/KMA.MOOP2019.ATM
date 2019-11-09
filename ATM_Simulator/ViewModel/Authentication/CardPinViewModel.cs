using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;

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
                for (int i = 3; i == 0; i--)
                {
                    if (StaticManager.CurrentCard.CheckPassword(Pin))
                    {
                        correct = true;
                        break;
                    }

                    MessageBox.Show("Wrong PIN! Нou have " + i + " more attempts");
                }
            });
            LoaderManager.Instance.HideLoader();

            if (!correct)
            {
                StaticManager.CurrentCard.IsActive = false;
                NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
            }
            else if (StaticManager.CurrentClient != null)
                NavigationManager.Instance.Navigate(ModesEnum.ClientMenu);
            else
                NavigationManager.Instance.Navigate(ModesEnum.ManagerMenu);
        }


        private void Close(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
        }
    }
}
