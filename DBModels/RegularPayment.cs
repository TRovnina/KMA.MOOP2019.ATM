using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class RegularPayment
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // TODO i don`t know how it works
        private int _regularPaymentId;
        [DataMember]
        private DateTime _firstRegularPaymentDate;
        [DataMember]
        private PeriodRegularPayment _periodRegularPayment;
        [DataMember]
        private string _regularPaymentName;

        [DataMember]
        private CurrentAccount _currentAccount;
        [DataMember]
        private string _currentAccountNum;

        #endregion

        #region Constructors

        private RegularPayment()
        {
            _firstRegularPaymentDate = DateTime.Now;
        }

        public RegularPayment(PeriodRegularPayment periodRegularPayment, string regularPaymentName, 
            CurrentAccount currentAccount) : this()
        {
            _periodRegularPayment = periodRegularPayment;
            _regularPaymentName = regularPaymentName;
            _currentAccount = currentAccount;
            _currentAccountNum = currentAccount.CardNumber;
        }

        #endregion

        #region Properties

        public int RegularPaymentId
        {
            get { return _regularPaymentId; }
            private set { _regularPaymentId = value; }
        }

        public DateTime FirstRegularPaymentDate
        {
            get { return _firstRegularPaymentDate; }
            private set { _firstRegularPaymentDate = value; }
        }

        public PeriodRegularPayment PeriodRegularPayment
        {
            get { return _periodRegularPayment; }
            private set { _periodRegularPayment = value; }
        }

        public string RegularPaymentName
        {
            get { return _regularPaymentName; }
            private set { _regularPaymentName = value; }
        }

        public CurrentAccount CurrentAccount
        {
            get { return _currentAccount; }
            private set { _currentAccount = value; }
        }

        public string CurrentAccountNum
        {
            get { return _currentAccountNum; }
            private set { _currentAccountNum = value; }
        }

        #endregion

    }
}