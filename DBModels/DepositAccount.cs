using System;

namespace DBModels
{
    public class DepositAccount : Account
    {
        private DateTime _depositDate;
        private DateTime _storegedDate;
        private int _persentage;
        private DateTime _availableDate; // Дата коли гроші будуть доступні = Deposit_Date + Storage_Date

        public DepositAccount(string cardNumber, string cardPassword, Client client,
            DateTime depositDate, DateTime storegedDate, int persentage, DateTime availableDate) 
            : base(cardNumber, cardPassword, client)
        {
            _depositDate = depositDate;
            _storegedDate = storegedDate;
            _persentage = persentage;
            _availableDate = availableDate;
        }

        public DateTime _DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }

        public DateTime StoregedDate
        {
            get { return _storegedDate; }
            set { _storegedDate = value; }
        }

        public int Persentage
        {
            get { return _persentage; }
            set { _persentage = value; }
        }

        public DateTime AvailableDate
        {
            get { return _availableDate = _depositDate.AddSeconds(_storegedDate.Second); }
            private set { _availableDate = value; }
        }
    }
}