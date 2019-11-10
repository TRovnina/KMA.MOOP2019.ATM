using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ManagerServices
{
    internal class AddMoneyViewModel : BasicViewModel
    {
        private int _fifty;
        private int _hundred;
        private int _twoHundred;
        private int _fiveHundred;
        private ICommand _confirmCommand;
        private ICommand _menuCommand;


        public int Fifty
        {
            get { return _fifty = StaticManager.CurrentAtm.Banknote50; }
            set
            {
                _fifty = value;
                OnPropertyChanged();
            }
        }

        public int Hundred
        {
            get { return _hundred = StaticManager.CurrentAtm.Banknote100; }
            set
            {
                _hundred = value;
                OnPropertyChanged();
            }
        }

        public int TwoHundred
        {
            get { return _twoHundred = StaticManager.CurrentAtm.Banknote200; }
            set
            {
                _twoHundred = value;
                OnPropertyChanged();
            }
        }

        public int FiveHundred
        {
            get { return _fiveHundred = StaticManager.CurrentAtm.Banknote500; }
            set
            {
                _fiveHundred = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(PutMoney)); }
        }

        private async void PutMoney(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                StaticManager.CurrentAtm.Banknote50 = _fifty;
                StaticManager.CurrentAtm.Banknote100 = _hundred;
                StaticManager.CurrentAtm.Banknote200 = _twoHundred;
                StaticManager.CurrentAtm.Banknote500 = _fiveHundred;

                //ATMManagerAction action = new ATMManagerAction(ActionType.AddMoney, StaticManager.CurrentManager, StaticManager.CurrentAtm);
                DbManager.SaveATM(StaticManager.CurrentAtm);
            });
            LoaderManager.Instance.HideLoader();
            MessageBox.Show("Operation was successful!");
            NavigationManager.Instance.Navigate(ModesEnum.ManagerMenu);
        }

        public ICommand MenuCommand
        {
            get { return _menuCommand ?? (_menuCommand = new RelayCommand<object>(Menu)); }
        }

        private void Menu(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.ManagerMenu);
        }

    }
}
