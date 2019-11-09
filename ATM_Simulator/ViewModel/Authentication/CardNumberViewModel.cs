using System.Threading.Tasks;
using System.Windows.Input;
using ATM_Simulator.Managers;
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
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
            
            });

            LoaderManager.Instance.HideLoader();
            NavigationManager.Instance.Navigate(ModesEnum.CardPin);
        }
    }
}
