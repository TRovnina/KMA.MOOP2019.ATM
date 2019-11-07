using System;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class DepositAccount : Account
    {
        #region Fields

        [DataMember]
        private DateTime _depositDate;
        [DataMember]
        private DateTime _storegedDate;
        [DataMember]
        private int _persentage;
        [DataMember]
        private DateTime _availableDate; // Дата коли гроші будуть доступні = Deposit_Date + Storage_Date

        // TODO 
       // private CurrentAccount _currentAccount;

        #endregion

        #region Constructors

        public DepositAccount(string cardNumber, string cardPassword, Client client,
            DateTime depositDate, DateTime storegedDate, int persentage)
            : base(cardNumber, cardPassword, client)
        {
            _depositDate = depositDate;
            _storegedDate = storegedDate;
            _persentage = persentage;
            _availableDate = CalculateAvailableDate();
        }

        private DepositAccount()
        {

        }

        #endregion

        #region Properties

        public DateTime DepositDate
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
            get { return _availableDate = CalculateAvailableDate(); }
            private set { _availableDate = value; }
        }

        #endregion

        private DateTime CalculateAvailableDate()
        {
            return DepositDate.AddSeconds(StoregedDate.Second);
        }

    }
}