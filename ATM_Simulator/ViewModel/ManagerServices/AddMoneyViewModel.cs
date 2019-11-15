using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
using ATM_Simulator.Models;
using ATM_Simulator.Tools;
using DBModels;

namespace ATM_Simulator.ViewModel.ManagerServices
{
    public class AddMoneyViewModel : BasicViewModel
    {
        private int _fifty;
        private int _hundred;
        private int _twoHundred;
        private int _fiveHundred;
        private ICommand _confirmCommand;
        private ICommand _menuCommand;

        public AddMoneyViewModel()
        {
            _fifty = StaticManager.CurrentAtm.Banknote50;
            _hundred = StaticManager.CurrentAtm.Banknote100;
            _twoHundred = StaticManager.CurrentAtm.Banknote200;
            _fiveHundred = StaticManager.CurrentAtm.Banknote500;
        }

        public int Fifty
        {
            get { return _fifty; }
            set
            {
                _fifty = value;
                OnPropertyChanged();
            }
        }

        public int Hundred
        {
            get { return _hundred; }
            set
            {
                _hundred = value;
                OnPropertyChanged();
            }
        }

        public int TwoHundred
        {
            get { return _twoHundred; }
            set
            {
                _twoHundred = value;
                OnPropertyChanged();
            }
        }

        public int FiveHundred
        {
            get { return _fiveHundred; }
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

                DbManager.AddATMManagerAction(new ATMManagerAction(StaticManager.CurrentManager, StaticManager.CurrentAtm, "AddMoney"));
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
