using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ATM_Simulator.Managers;
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
        private readonly List<Banknote> _money = StaticManager.CurrentAtm.Banknotes;
        private ICommand _confirmCommand;
        private ICommand _menuCommand;


        public int Fifty
        {
            //get { return _fifty = _money.; }
            get { return 500; }
            set
            {
                _fifty = value;
                OnPropertyChanged();
            }
        }

        public int Hundred
        {
            // get { return _hundred = CurrentAtm.Hundred; }
            get { return 100; }
            set
            {
                _hundred = value;
                OnPropertyChanged();
            }
        }

        public int TwoHundred
        {
            // get { return _twoHundred = CurrentAtm.TwoHundred; }
            get { return 200; }
            set
            {
                _twoHundred = value;
                OnPropertyChanged();
            }
        }

        public int FiveHundred
        {
            // get { return _fiveHundred = CurrentAtm.FiveHundred; }
            get { return 500; }
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

        private void PutMoney(object obj)
        {
            MessageBox.Show("Operation was successful!");
            //put money in ATM
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
