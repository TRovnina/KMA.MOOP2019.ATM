using System.Windows.Forms;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Tools;
using MessageBox = System.Windows.MessageBox;

namespace ATM_Simulator.ViewModel.ClientServices
{
    internal class ChangePinViewModel : BasicViewModel
    {
        private string _oldPin;
        private string _newPin1;
        private string _newPin2;

        private ICommand _confirmCommand;
        private ICommand _menuCommand;
        private ICommand _endCommand;

        public string OldPin
        {
            get { return _oldPin; }
            set
            {
                _oldPin = value;
                OnPropertyChanged();
            }
        }

        public string NewPin1
        {
            get { return _newPin1; }
            set
            {
                _newPin1 = value;
                OnPropertyChanged();
            }
        }

        public string NewPin2
        {
            get { return _newPin2; }
            set
            {
                _newPin2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(ChangePin, CanConfirmExecute)); }
        }

        private bool CanConfirmExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_oldPin) && !string.IsNullOrWhiteSpace(_newPin1) && !string.IsNullOrWhiteSpace(_newPin2);
        }

        private void ChangePin(object obj)
        {
            if (_newPin1 != _newPin2 && !StaticManager.CurrentCard.CheckPassword(_oldPin))
            {
                System.Windows.Forms.MessageBox.Show("Something is wrong! Check all information!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                NavigationManager.Instance.Navigate(ModesEnum.ChangePin);
                return;
            }

            StaticManager.CurrentCard.CardPassword = NewPin1;

            MessageBox.Show("You PIN was successfully changed!");
            NavigationManager.Instance.Navigate(ModesEnum.AskContinue);
        }

        public ICommand MenuCommand
        {
            get { return _menuCommand ?? (_menuCommand = new RelayCommand<object>(Menu)); }
        }

        private void Menu(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.ClientMenu);
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
