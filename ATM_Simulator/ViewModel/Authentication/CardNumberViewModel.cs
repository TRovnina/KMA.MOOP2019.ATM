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
            bool correct = true;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                //var client = getClient (_number)
                //var manager = getManager(_number)
                //if(client != null){
                // StaticManager.CurrentClient = client;
                // StaticManager.CurrentAccount = getAccount(_number);
                //}else if (manager != null)
                // StaticManager.CurrentManager = manager;
                //else{
                //  correct = false;
                //  MessageBox.Show("Wrong card number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //}
            });
            LoaderManager.Instance.HideLoader();
            if(correct)
                NavigationManager.Instance.Navigate(ModesEnum.CardPin);
        }
    }
}
