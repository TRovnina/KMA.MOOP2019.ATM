using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.Authentication
{
    internal class CardNumberViewModel : BasicViewModel
    {
        #region Fields

        private string _number;

        #endregion

        #region Commands

        private ICommand _nextCommand;

        #endregion

        #region Properties

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
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

        #endregion

        private bool CanNextExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_number);
        }

        private async void NextImplementation(object obj)
        {
            if (!StaticManager.CurrentAtm.Status)
            {
                MessageBox.Show("ATM is blocked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
                return;
            }

            bool correct = true;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                StaticManager.CurrentCard = DbManager.GetAccountByNum(Number);
                if (StaticManager.CurrentCard == null)
                {
                    StaticManager.CurrentManager = DbManager.GetManagerById(Number);
                    correct = (StaticManager.CurrentManager != null);
                }
                else if (StaticManager.CurrentCard.IsActive)
                    StaticManager.CurrentClient = DbManager.GetClientByItn(StaticManager.CurrentCard.ClientITN);
                else
                    correct = false;
            });
            LoaderManager.Instance.HideLoader();
            
            if (correct)
            {
                StaticManager.Attempts = 3;
                NavigationManager.Instance.Navigate(ModesEnum.CardPin);
            }
            else
            {
                MessageBox.Show("Wrong card number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                NavigationManager.Instance.Navigate(ModesEnum.CardNumber);
            }
        }

        internal CardNumberViewModel()
        {
            StaticManager.CurrentManager = null;
            StaticManager.CurrentCard = null;
            StaticManager.CurrentClient = null;
        }
    }
}
